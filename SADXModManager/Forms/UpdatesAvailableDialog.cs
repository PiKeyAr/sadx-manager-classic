using ModManagerCommon;
using SADXModManager.DataClasses;
using SADXModManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SADXModManager.Forms
{
	public partial class UpdatesAvailableDialog : Form
	{
		/// <summary>Possible states of the download</summary>
		private enum ItemAction
		{
			None,
			Download,
			Extract,
			ParseManifest,
			ApplyManifest,
			Finish,
		};

		private ItemAction currentAction = ItemAction.None; // Current state of the download
		private string statItemName; // Name of the current download item

		private int statItemIndex; // Index of the currently downloaded mod/tool
		private int statItemsTotal; // Total number of mods/tools to download

		private long statSizeTotal; // Total size of mods/tools to download
		private long statSizeDownloaded; // Size of mods/tools that has been downloaded, including the current one
		private long statSizeDownloadedPrevItem; // Size of mods/tools that has been downloaded before the current one
		private long statSizeItemTotal; // Total size of the currently downloaded mod/tool
		private long statSizeItemDownloaded; // Size of the currently downloaded mod/tool

		private long statFilesItemTotal; // Number of files for the currently downloaded mod/tool
		private long statFilesItemDownloaded; // Number of files for the currently downloaded mod/tool

		private readonly string updatePath; // Temporary folder path
		private readonly List<DownloadItem> Items; // List of all items
		private List<DownloadItem> ItemsToDownload; // List of selected items

		private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
		public event EventHandler CancelEvent;

		public UpdatesAvailableDialog(List<DownloadItem> items, string updatePath, bool firstInstall = false)
		{
			InitializeComponent();
			this.updatePath = updatePath;
			this.CancelEvent += OnCancelEvent;
			Items = items;
			listViewUpdates.BeginUpdate();
			foreach (DownloadItem item in Items)
			{
				if (item != null)
				{
					listViewUpdates.Items.Add(new ListViewItem(new[] { string.Format("{0} {1}", item.Name, item.Version), SizeSuffix.GetSizeSuffix(item.Size) })
					{
						Checked = true,
						Tag = item,
					});
				}
			}
			ClearDownloadDetails();
			listViewUpdates.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent); // Update name
			listViewUpdates.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent); // Update size
			if (listViewUpdates.Items.Count > 0)
				listViewUpdates.Items[0].Selected = true;
			listViewUpdates.EndUpdate();
			if (firstInstall)
			{
				buttonCancel.Enabled = false;
				buttonUpdateSelected.Enabled = false;
				labelUpdatesAvailable.Text = "To install the Mod Loader, the following files will be downloaded:";
				Text = "Installing SADX Mod Loader";
				if (listViewUpdates.Items.Count == 0)
				{
					MessageBox.Show(this, "All items have already been installed.", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Process.Start(Path.Combine(Variables.managerExePath, "SADXModManager.exe"));
					Environment.Exit(0);
				}
				Shown += OnShown;
			}
		}

		private void OnShown(object sender, EventArgs eventArgs)
		{
			BeginUpdate();
		}

		protected virtual void OnCancelEvent()
		{
			CancelEvent?.Invoke(this, EventArgs.Empty);
		}

		private void OnCancelEvent(object sender, EventArgs eventArgs)
		{
			tokenSource.Cancel();
		}

		/// <summary>Retrieves the name of the file from a link.</summary>
		private string GetFilenameFromUrl(string url)
		{
			Uri uri = new Uri(url);
			string result = uri.Segments.Last();
			if (result.Contains("."))
				return result;
			else
				return "";
		}

		/// <summary>Extracts .gz streams.</summary>
		private void ExtractGz(byte[] data, string path)
		{
			MemoryStream sourceFileStream = new MemoryStream(data);
			FileStream destFileStream = File.Create(path);

			GZipStream decompressingStream = new GZipStream(sourceFileStream,
				CompressionMode.Decompress);
			int byteRead;
			while ((byteRead = decompressingStream.ReadByte()) != -1)
			{
				destFileStream.WriteByte((byte)byteRead);
			}

			decompressingStream.Close();
			sourceFileStream.Close();
			destFileStream.Close();
		}

		/// <summary>Starts the update process.</summary>
		private void BeginUpdate()
		{
			// Block the update button
			buttonUpdateSelected.Enabled = false;

			// Make a list of items to download
			ItemsToDownload = new List<DownloadItem>();
			foreach (ListViewItem item in listViewUpdates.Items)
			{
				if (item.Checked)
					ItemsToDownload.Add(item.Tag as DownloadItem);
			}

			// If there are no items, exit
			if (ItemsToDownload.Count == 0)
			{
				DialogResult = DialogResult.Cancel;
				Close();
			}

			// Create temp folder
			DialogResult result = DialogResult.OK;
			try
			{
				if (!Directory.Exists(updatePath))
				{
					Directory.CreateDirectory(updatePath);
				}
			}
			catch (Exception ex)
			{
				result = MessageBox.Show(this, "Failed to create temporary update directory:\n" + ex.Message
											   + "\n\nWould you like to retry?", "Directory Creation Failed", MessageBoxButtons.RetryCancel);
				if (result == DialogResult.Cancel) return;
			}
			while (result == DialogResult.Retry) ;

			// Set up paths and 7z.exe
			if (!File.Exists(Path.Combine(updatePath, "7z.exe")))
				ExtractGz(Resources._7z_exe, Path.Combine(updatePath, "7z.exe"));
			if (!File.Exists(Path.Combine(updatePath, "7z.dll")))
				ExtractGz(Resources._7z_dll, Path.Combine(updatePath, "7z.dll"));
			System.Environment.SetEnvironmentVariable("PATH", updatePath);

			// Set total items
			statItemsTotal = ItemsToDownload.Count;

			// Set total size
			statSizeTotal = 0;
			foreach (var item in ItemsToDownload)
				statSizeTotal += item.Size;

			// Set up updater
			using (var client = new UpdaterWebClient())
			{
				CancellationToken token = tokenSource.Token;

				void OnExtracting(object o, CancelEventArgs args)
				{
					currentAction = ItemAction.Extract;
					args.Cancel = token.IsCancellationRequested;
					UpdateProgress();
				}
				void OnParsingManifest(object o, CancelEventArgs args)
				{
					currentAction = ItemAction.ParseManifest;
					args.Cancel = token.IsCancellationRequested;
					UpdateProgress();
				}
				void OnApplyingManifest(object o, CancelEventArgs args)
				{
					currentAction = ItemAction.ApplyManifest;
					args.Cancel = token.IsCancellationRequested;
					UpdateProgress();
				}
				void OnDownloadProgress(object o, DownloadProgressEventArgs args)
				{
					statFilesItemDownloaded = args.FileDownloading;
					statFilesItemTotal = args.FilesToDownload;
					statSizeItemDownloaded = args.BytesReceived;
					statSizeItemTotal = args.TotalBytesToReceive;
					statSizeDownloaded = statSizeDownloadedPrevItem + args.BytesReceived;
					currentAction = ItemAction.Download;
					args.Cancel = token.IsCancellationRequested;
					UpdateProgress();
				}
				void OnDownloadCompleted(object o, CancelEventArgs args)
				{
					currentAction = ItemAction.Finish;
					statSizeDownloadedPrevItem = statSizeDownloaded;
					args.Cancel = token.IsCancellationRequested;
					if (statFilesItemDownloaded == statFilesItemTotal && statItemIndex >= statItemsTotal - 1)
					{
						progressBarTotal.Value = 100;
						DialogResult = DialogResult.OK;
						Close();
					}
					else
					{
						statFilesItemDownloaded += 1;
					}
					UpdateProgress();
				}

				foreach (DownloadItem item in ItemsToDownload)
				{
					statItemName = item.Name;
					statItemIndex = ItemsToDownload.IndexOf(item) + 1;
					ModDownload update = item.ModDownloadInfo;
					// Loader, Manager and Launcher
					if (item.Type != DownloadItem.DownloadItemType.Mod)
					{
						do
						{
							result = DialogResult.Cancel;

							try
							{
								// poor man's await Task.Run (not available in .net 4.0)
								using (var task = new Task(() =>
								{
									var cancelArgs = new CancelEventArgs(false);
									DownloadProgressEventArgs downloadArgs = null;

									void DownloadComplete(object _sender, AsyncCompletedEventArgs args)
									{
										lock (args.UserState)
										{
											Monitor.Pulse(args.UserState);
										}
									}

									void DownloadProgressChanged(object _sender, DownloadProgressChangedEventArgs args)
									{
										downloadArgs = new DownloadProgressEventArgs(args, 1, 1);
										OnDownloadProgress(this, downloadArgs);
										if (downloadArgs.Cancel)
										{
											client.CancelAsync();
										}
									}

									var uri = new Uri(item.URL);
									string filePath = Path.Combine(updatePath, uri.Segments.Last());

									var info = new FileInfo(filePath);
									client.DownloadFileCompleted += DownloadComplete;
									client.DownloadProgressChanged += DownloadProgressChanged;

									var sync = new object();
									lock (sync)
									{
										client.DownloadFileAsync(uri, filePath, sync);
										Monitor.Wait(sync);
									}

									client.DownloadProgressChanged -= DownloadProgressChanged;
									client.DownloadFileCompleted -= DownloadComplete;

									if (cancelArgs.Cancel || downloadArgs?.Cancel == true)
									{
										return;
									}

									OnDownloadCompleted(this, cancelArgs);
									if (cancelArgs.Cancel)
									{
										return;
									}

									if (token.IsCancellationRequested)
									{
										return;
									}

									switch (item.Type)
									{
										// Install Loader
										case DownloadItem.DownloadItemType.Loader:
											// Extract SADXModLoader.dll, border image, codes, game patches
											Process.Start(new ProcessStartInfo("7z.exe", $"e -aoa -o\"{Path.Combine(Variables.gameSettings.GamePath, "mods")}\" \"{filePath}\" *.*") { UseShellExecute = false, CreateNoWindow = true }).WaitForExit();
											// Generate sadxmlver.txt
											File.WriteAllText(Path.Combine(Variables.managerAppDataPath, "sadxmlver.txt"), item.Version);
											// Extract extlibs
											Process.Start(new ProcessStartInfo("7z.exe", $"x -aoa -o\"{Variables.managerAppDataPath}\" \"{filePath}\" extlib") { UseShellExecute = false, CreateNoWindow = true }).WaitForExit();
											// Copy SADXModLoader.dll to system\CHRMODELS.dll if the Loader is installed
											if (File.Exists(Variables.datadllorigpath))
											{
												DialogResult mlres = DialogResult.Cancel;
												do
												{
													try
													{
														File.Copy(Path.Combine(Variables.gameSettings.GamePath, "mods", "SADXModLoader.dll"), Variables.datadllpath, true);
														mlres = DialogResult.OK;
													}
													catch (Exception ex)
													{
														mlres = MessageBox.Show(this, $"Failed to update the Mod Loader DLL file:\r\n\n{ex.Message.ToString()}\n\nMake sure the game is not running.", "Update Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
													}
												}
												while (mlres == DialogResult.Retry);
											}
											// Copy d3d8to9 DLL to game folder
											if (File.Exists(Variables.d3d8to9InstalledDLLName))
											{
												DialogResult d3res = DialogResult.Cancel;
												do
												{
													try
													{
														File.Copy(Variables.d3d8to9StoredDLLName, Variables.d3d8to9InstalledDLLName, true);
														d3res = DialogResult.OK;
													}
													catch (Exception ex)
													{
														d3res = MessageBox.Show(this, $"Failed to update Direct3D8to9 file:\r\n\n{ex.Message.ToString()}\n\nMake sure the game is not running.", "Update Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
													}
												}
												while (d3res == DialogResult.Retry);
											}
											break;
										// Install Launcher
										case DownloadItem.DownloadItemType.Launcher:
											// Extract to game folder
											Process.Start(new ProcessStartInfo("7z.exe", $"x -aoa -o\"{Variables.gameSettings.GamePath}\" \"{filePath}\"")	{ UseShellExecute = false, CreateNoWindow = true }).WaitForExit();
											break;
										// Install Manager
										case DownloadItem.DownloadItemType.Manager:
											// Add sadxmanagerver.txt
											File.WriteAllText(Path.Combine(updatePath, "sadxmanagerver.txt"), item.Version);
											// Start the new EXE and close
											Process.Start(filePath, $"update \"{Variables.managerExePath}\"");
											Environment.Exit(0);
											break;
										// Install Steam tools
										case DownloadItem.DownloadItemType.SteamTools:
											// Extract to game folder
											Process.Start(new ProcessStartInfo("7z.exe", $"x -aoa -o\"{Path.Combine(updatePath, "steam_tools")}\" \"{filePath}\"") { UseShellExecute = false, CreateNoWindow = true }).WaitForExit();
											// Initialize conversion
											string arg = "\"" + Variables.gameSettings.GamePath + "\"" + " \"" + Path.Combine(updatePath, "steam_tools") + "\"";
											Process.Start(Path.Combine(updatePath, "steam_tools", "SteamHelper.exe"), arg).WaitForExit();
										break;

									}
								}, token))
								{
									task.Start();

									while (!task.IsCompleted && !task.IsCanceled)
									{
										Application.DoEvents();
									}

									task.Wait(token);
								}
							}
							catch (AggregateException ae)
							{
								ae.Handle(ex =>
								{
									result = MessageBox.Show(this, $"Failed to update:\r\n{ex.ToString()}",
										"Update Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
									return true;
								});
							}
						} while (result == DialogResult.Retry);
					}
					// Mods
					else
					{
						// Add stuff for mods
						update.Extracting += OnExtracting;
						update.ParsingManifest += OnParsingManifest;
						update.ApplyingManifest += OnApplyingManifest;
						update.DownloadProgress += OnDownloadProgress;
						update.DownloadCompleted += OnDownloadCompleted;
						// Download and install
						do
						{
							result = DialogResult.Cancel;

							try
							{
								// poor man's await Task.Run (not available in .net 4.0)
								using (var task = new Task(() => update.Download(client, updatePath), token))
								{
									task.Start();

									while (!task.IsCompleted && !task.IsCanceled)
									{
										Application.DoEvents();
									}

									task.Wait(token);
								}
							}
							catch (AggregateException ae)
							{
								ae.Handle(ex =>
								{
									result = MessageBox.Show(this, $"Failed to update mod {update.Info.Name}:\r\n{ex.Message}"
										+ "\r\n\r\nPress Retry to try again, or Cancel to skip this mod.",
										"Update Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
									return true;
								});
							}
						} while (result == DialogResult.Retry);
						// Remove stuff for mods
						update.Extracting -= OnExtracting;
						update.ParsingManifest -= OnParsingManifest;
						update.ApplyingManifest -= OnApplyingManifest;
						update.DownloadProgress -= OnDownloadProgress;
						update.DownloadCompleted -= OnDownloadCompleted;
					}
				}
			}
		}
	
		/// <summary>Updates download info in UI.</summary>
		private void SetDownloadDetails(DownloadItem item)
		{
			// Changelog
			textBoxChangelog.Text = item.Changelog;
			// Mod download info
			ModDownload entry = item.ModDownloadInfo;
			if (entry != null)
			{
				// Number of files in the download
				labelDownloadFileCountValue.Text = entry.FilesToDownload.ToString();
				// Download details
				labelDownloadPublishedValue.Text = entry.Updated.ToString(CultureInfo.CurrentCulture);
				labelDownloadSizeValue.Text = SizeSuffix.GetSizeSuffix(entry.Size);
				labelDownloadFileCountValue.Text = entry.FilesToDownload.ToString();
				// Release details
				if (string.IsNullOrEmpty(entry.Name))
					groupReleaseDetails.Visible = false;
				else
				{
					labelReleasePublishedValue.Text = entry.Published.ToString(CultureInfo.CurrentCulture);
					labelReleasePageValue.Text = !string.IsNullOrEmpty(entry.ReleaseUrl) ? entry.ReleaseUrl : entry.Url;
					labelReleaseNameValue.Text = entry.Name;
					labelReleaseTagValue.Text = entry.Version;
					groupReleaseDetails.Visible = true;
				}
				listViewUpdateFiles.BeginUpdate();
				listViewUpdateFiles.Items.Clear();
				// List of files for self-hosted mods
				if (entry.Type == ModDownloadType.Modular)
				{
					foreach (ModManifestDiff i in entry.ChangedFiles)
					{
						string file = i.State == ModManifestState.Moved ? $"{i.Last.FilePath} -> {i.Current.FilePath}" : i.Current.FilePath;
						listViewUpdateFiles.Items.Add(new ListViewItem(new[] { i.State.ToString(), file }));
					}
				}
				// Add the single file from direct download URL for archive mods
				else
				{
					listViewUpdateFiles.Items.Add(new ListViewItem(new[] { "Download", GetFilenameFromUrl(entry.Url) }));
				}
				listViewUpdateFiles.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
				listViewUpdateFiles.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
				listViewUpdateFiles.EndUpdate();
			}
			// Loader/Manager/Launcher download info
			else
			{
				labelDownloadFileCountValue.Text = "1";
				labelDownloadSizeValue.Text = SizeSuffix.GetSizeSuffix(item.Size);
				labelReleasePageValue.Text = item.URL;
				labelReleaseNameValue.Text = item.Name;
				labelDownloadPublishedValue.Text = item.Published.ToString(CultureInfo.CurrentCulture);
				// File list
				listViewUpdateFiles.BeginUpdate();
				listViewUpdateFiles.Items.Clear();
				listViewUpdateFiles.Items.Add(new ListViewItem(new[] { "Download", GetFilenameFromUrl(item.URL) }));
				listViewUpdateFiles.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
				listViewUpdateFiles.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
				listViewUpdateFiles.EndUpdate();
			}
		}

		/// <summary>Erases download info in UI.</summary>
		private void ClearDownloadDetails()
		{
			textBoxChangelog.Text = "No changelog available";
			labelDownloadFileCountValue.Text = "N/A";
			labelDownloadPublishedValue.Text = "N/A";
			labelDownloadSizeValue.Text = "N/A";
			labelReleaseNameValue.Text = "N/A";
			labelReleasePageValue.Text = "N/A";
			labelReleaseTagValue.Text = "N/A";
			labelReleasePublishedValue.Text = "N/A";
			listViewUpdateFiles.Items.Clear();
		}

		private void listViewUpdates_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (!buttonUpdateSelected.Enabled)
				e.NewValue = e.CurrentValue;
		}

		/// <summary>Refreshes item details.</summary>
		private void listViewUpdates_SelectedIndexChanged(object sender, EventArgs e)
		{
			var items = listViewUpdates.SelectedItems;
			if (items.Count > 1 || items.Count == 0)
			{
				ClearDownloadDetails();
			}
			else
			{
				var entry = items[0].Tag as DownloadItem;
				SetDownloadDetails(entry);
			}
		}

		/// <summary>Clicking links in release info.</summary>
		private void labelReleasePageValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (labelReleasePageValue.Text == "N/A")
				return;
			Process.Start(new ProcessStartInfo(labelReleasePageValue.Text) { UseShellExecute = true });
		}

		/// <summary>Clicking links in the changelog.</summary>
		private void textBoxChangelog_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
		}

		/// <summary>Clicking the Update Selected button.</summary>
		private void buttonUpdateSelected_Click(object sender, EventArgs e)
		{
			BeginUpdate();
		}

		/// <summary>Clicking the Cancel button.</summary>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			switch (currentAction)
			{
				// If nothing is going on, just close the window
				case ItemAction.None:
					DialogResult = DialogResult.Cancel;
					Close();
					return;
				// If something is going on, show a prompt first
				default:
					if (MessageBox.Show(this, "Are you sure you want to cancel?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
						return;
					OnCancelEvent();
					DialogResult = DialogResult.Cancel;
					Close();
					return;
			}
		}


		/// <summary>Refreshes the UI based on the current action.</summary>
		public void UpdateProgress()
		{
			if (InvokeRequired)
			{
				Invoke((Action)UpdateProgress);
			}
			else
			{
				switch (currentAction)
				{
					case ItemAction.None:
						progressBarItem.Value = 0;
						progressBarTotal.Value = 0;
						labelItemProgress.Text = "Item progress will be displayed here.";
						labelTotalProgress.Text = "Total progress will be displayed here.";
						break;
					case ItemAction.Download:
						progressBarItem.Value = (int)((double)statSizeItemDownloaded / (double)statSizeItemTotal * 100.0);
						progressBarTotal.Value = (int)((double)statSizeDownloaded / (double)statSizeTotal * 100.0);
						labelItemProgress.Text = string.Format("Downloading {0}: file {1} of {2}: {3}/{4}", statItemName, statFilesItemDownloaded, statFilesItemTotal, SizeSuffix.GetSizeSuffix(statSizeItemDownloaded), SizeSuffix.GetSizeSuffix(statSizeItemTotal));
						labelTotalProgress.Text = string.Format("Downloading item {0} of {1}: {2}/{3}", statItemIndex, statItemsTotal, SizeSuffix.GetSizeSuffix(statSizeDownloaded), SizeSuffix.GetSizeSuffix(statSizeTotal));
						break;
					case ItemAction.Extract:
						progressBarItem.Value = 100;
						labelItemProgress.Text = string.Format("Extracting {0}", statItemName);
						labelTotalProgress.Text = string.Format("Extracting item {0} of {1}", statItemIndex, statItemsTotal);
						break;
					case ItemAction.ParseManifest:
					case ItemAction.ApplyManifest:
						progressBarItem.Value = 100;
						labelItemProgress.Text = string.Format("Parsing manifest of {0}", statItemName);
						labelTotalProgress.Text = string.Format("Parsing manifest: item {0} of {1}", statItemIndex, statItemsTotal);
						break;
					case ItemAction.Finish:
						progressBarItem.Value = 100;
						labelItemProgress.Text = string.Format("Downloading {0}: finished file {1} of {2}", statItemName, Math.Min(statFilesItemDownloaded, statFilesItemTotal), statFilesItemTotal);
						labelTotalProgress.Text = string.Format("Downloading item {0} of {1}: {2}/{3}", statItemIndex, statItemsTotal, SizeSuffix.GetSizeSuffix(statSizeDownloaded), SizeSuffix.GetSizeSuffix(statSizeTotal));
						break;
				}
			}	
		}
	}
}