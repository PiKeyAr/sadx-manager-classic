using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using SADXModManager.Properties;
using SADXModManager.DataClasses;
using static SADXModManager.Variables;
using static SADXModManager.Utils;

namespace SADXModManager.Forms
{
	public partial class InstallationWizard : Form
	{
		public InstallationWizard()
		{
			managerExePath = AppDomain.CurrentDomain.BaseDirectory;
			InitializeComponent();
			Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
			pictureBoxManagerIcon.Image = Icon.ToBitmap();
			textBoxGameFolder.Text = LocateGameFolder();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		public string LocateGameFolder()
		{
			string result = "";
			
			RegistryKey key;
			// Current game folder
			if (File.Exists(Path.Combine(managerExePath, "sonic.exe")) || File.Exists(Path.Combine(managerExePath, "Sonic Adventure DX.exe")))
				return managerExePath;
			// Steam
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 71250");
			if (key != null)
			{
				string val = (string)key.GetValue("InstallLocation", "");
				if (val != null && val.Length > 0)
				{
					if (File.Exists(Path.Combine(val, "Sonic Adventure DX.exe")))
						return val;
					else if (File.Exists(Path.Combine(val, "sonic.exe")))
						return val;
				}
			}
			// SADX 2004
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\SONICADVDX");
			if (key != null)
			{
				string val = (string)key.GetValue("UninstallString", "");
				if (val != null && val.Length > 12)
				{
					string path = val.Substring(0, val.Length - 12);
					if (File.Exists(Path.Combine(path, "Sonic Adventure DX.exe")))
						return path;
					else if (File.Exists(Path.Combine(path, "sonic.exe")))
						return path;
				}
			}
			// Dreamcast Collection (original)
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\SEGA\\Dreamcast Collection");
			if (key != null)
			{
				string val = (string)key.GetValue("DisplayIcon", "");
				if (val != null && val.Length > 13)
				{
					string path = val.Substring(0, val.Length - 13) + "\\Sonic Adventure DX";
					if (File.Exists(Path.Combine(path, "Sonic Adventure DX.exe")))
						return path;
					else if (File.Exists(Path.Combine(path, "sonic.exe")))
						return path;
				}
			}
			// Dreamcast Collection (remastered)
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dreamcast Collection Remastered_is1");
			if (key != null)
			{
				string val = (string)key.GetValue("Inno Setup: App Path", "");
				if (val != null && val.Length > 0)
				{
					string path = val + "\\Sonic Adventure DX";
					if (File.Exists(Path.Combine(path, "Sonic Adventure DX.exe")))
						return path;
					else if (File.Exists(Path.Combine(path, "sonic.exe")))
						return path;
				}
			}
			return result;
		}

		bool ValidateGameFolder(string path)
		{
			return File.Exists(Path.Combine(path, "sonic.exe")) || File.Exists(Path.Combine(path,"Sonic Adventure DX.exe"));
		}

		private void textBoxGameFolder_TextChanged(object sender, EventArgs e)
		{
			buttonInstall.Enabled = ValidateGameFolder(textBoxGameFolder.Text);
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog
			{
				Title = "Select the location of sonic.exe",
				InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
				Filter = "SADX EXE|sonic.exe;Sonic Adventure DX.exe",
				AutoUpgradeEnabled = true,
				CheckFileExists = true,
				CheckPathExists = true,
				Multiselect = false,
				RestoreDirectory = true
			})
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					textBoxGameFolder.Text = Path.GetDirectoryName(dialog.FileName);
				}
			}
		}

		private void pictureBoxManagerIcon_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this, "Ты пидор.");
		}

		private string NormalizePath(string path)
		{
			path = path.Replace('/', '\\');
			return path.TrimEnd('\\');
		}

		private void buttonInstall_Click(object sender, EventArgs e)
		{
			buttonInstall.Enabled = false;
			string gamePath = NormalizePath(textBoxGameFolder.Text);
			managerAppDataPath = Path.GetFullPath(radioButtonGameFolder.Checked ? Path.Combine(gamePath, "SAManager") : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SAManager"));
			// Reuse an existing configuration
			if (Directory.Exists(managerAppDataPath))
			{
				if (File.Exists(Path.Combine(managerAppDataPath, "Manager.json")) || File.Exists(Path.Combine(managerAppDataPath, "ManagerClassic.json")))
				{
					DialogResult useCurrent = MessageBox.Show(this, string.Format("Setup has found a Mod Manager configuration in {0}. Would you like to reuse it?", managerAppDataPath), "SADX Mod Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
					switch (useCurrent)
					{
						case DialogResult.Cancel:
						default:
							buttonInstall.Enabled = true;
							return;
						case DialogResult.Yes:
							int attempt = 0;
							DialogResult copyres = DialogResult.Cancel;
							do {
								try
								{
									// Copy Manager.exe
									if (managerExePath != gamePath)
										File.Copy(Application.ExecutablePath, Path.Combine(gamePath, "SADXModManager.exe"), true);
									// Delete old Loader/Manager files if they exist
									DeleteOldFiles(this, gamePath);
									// Copy sadxmanagerver.txt
									File.WriteAllText(Path.Combine(managerAppDataPath, "sadxmanagerver.txt"), Resources.VersionString);
									// Run the manager from the new location
									Process.Start(Path.Combine(gamePath, "SADXModManager.exe"), "");
									Environment.Exit(0);
								}
								catch (Exception ex)
								{
									copyres = DialogResult.Retry;
									attempt++;
									if (attempt > 10)
										copyres = MessageBox.Show(null, string.Format("Unable to install SADX Mod Manager: {0}. Try again?", ex.Message.ToString()), "SADX Mod Manager Update Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
								}
							}
							while (copyres == DialogResult.Retry);
							break;
						case DialogResult.No:
							break;
					}
				}
			}
			// Check if SADXModLoader.ini exists and prompt to reuse it
			bool cancelled = CheckOldLoaderSettings(this, gamePath);
			if (cancelled)
			{
				buttonInstall.Enabled = true;
				return;
			}
			// Create a new configuration			
			Directory.CreateDirectory(managerAppDataPath);
			managerConfig = new DataClasses.ClassicManagerJson();
			profilesJson = new DataClasses.ProfilesJson();
			profilesJson.ProfilesList.Add(new ProfileData { Name = "Default", Filename = "Default.json" });
			if (gameSettings == null)
			{
				gameSettings = new GameSettings { GamePath = gamePath };
				gameSettings.Graphics.HorizontalResolution = Screen.PrimaryScreen.Bounds.Width;
				gameSettings.Graphics.VerticalResolution = Screen.PrimaryScreen.Bounds.Height;
			}
			JsonSerialize(gameSettings, Path.Combine(managerAppDataPath, "SADX", "Default.json"));
			JsonSerialize(profilesJson, Path.Combine(managerAppDataPath, "SADX", "Profiles.json"));
			JsonSerialize(managerConfig, Path.Combine(managerAppDataPath, "ManagerClassic.json"));
			if (radioButtonGameFolder.Checked)
				managerExePath = gamePath;
			// Create download items
			List<DownloadItem> items = new List<DownloadItem>();
			if (checkBoxVCC.Checked)
				items.AddRange(CheckVisualCRuntimeUpdates(this));
			if (checkBoxDirectX.Checked)
				items.Add(GetDirectXDownload(this));
			items.Add(CheckSteamToolUpdates(this));
			items.Add(CheckLoaderUpdates(this));
			items.Add(CheckLauncherUpdates(this));
			DownloadItem manager = CheckManagerUpdates(this);
			bool isManager = manager != null; // Manager has been downloaded
			if (isManager)
				items.Add(manager);
			// If a critical error happened during the download check, abort
			if (criticalError)
			{
				Close();
				Application.Exit();
			}
			// Open the dialog
			using (UpdatesAvailableDialog uDialog = new UpdatesAvailableDialog(items, Path.Combine(managerAppDataPath, "Updates"), true))
			{
				DialogResult result = uDialog.ShowDialog();
				switch (result)
				{
					// Downloads finished
					case DialogResult.OK:
						// If the Manager wasn't downloaded but is present in the folder, run it
						if (!isManager)
						{
							if (File.Exists(Path.Combine(managerExePath, "SADXModManager.exe")))
								Process.Start(Path.Combine(managerExePath, "SADXModManager.exe"));
						}
						Close();
						Application.Exit();
						return;
					// No items to download
					case DialogResult.None:
						if (!isManager)
						{
							if (File.Exists(Path.Combine(managerExePath, "SADXModManager.exe")))
								Process.Start(Path.Combine(managerExePath, "SADXModManager.exe"));
							Close();
							Application.Exit();
						}
						break;
					// Downloads cancelled or critical error
					case DialogResult.Abort:
						Close();
						Application.Exit();
						return;
				}
			}
		}

		private void InstallationWizard_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && buttonInstall.Enabled)
			{
				buttonInstall_Click(sender, e);
			}
		}

		private void textBoxGameFolder_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && buttonInstall.Enabled)
			{
				buttonInstall_Click(sender, e);
			}
		}
	}
}