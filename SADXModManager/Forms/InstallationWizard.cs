using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using SADXModManager.DataClasses;
using static SADXModManager.Variables;
using static SADXModManager.Utils;

namespace SADXModManager.Forms
{
	public partial class InstallationWizard : Form
	{
		public InstallationWizard()
		{
			managerExePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\', '/' });
			InitializeComponent();
			Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
			pictureBoxManagerIcon.Image = Icon.ToBitmap();
			textBoxGameFolder.Text = LocateGameFolder();
			FormClosing += OnClose;
		}

		private void OnClose(object sender, FormClosingEventArgs args)
		{
			Environment.Exit(0);
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Close();
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
			// Lock the install button
			buttonInstall.Enabled = false;
			bool overwrite = true; // If false, the JSON files will only be created if they don't already exist
			// Get game and manager data path
			gameMainPath = NormalizePath(textBoxGameFolder.Text);
			managerAppDataPath = Path.GetFullPath(Path.Combine(gameMainPath, "mods", ".modloader"));
			// Check for new configuration
			if (Directory.Exists(managerAppDataPath))
			{
				switch (MessageBox.Show(this, string.Format("An existing configuration was found in '{0}'. Would you like to reuse it?", managerAppDataPath), "SADX Mod Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
				{
					case DialogResult.Cancel:
						buttonInstall.Enabled = true;
						return;
					case DialogResult.Yes:
						overwrite = false;
						break;
					case DialogResult.No:
						break;
				}
			}
			else
			{
				// Check for old configuration: Portable mode
				string managerAppDataPathOld = Path.Combine(gameMainPath, "SAManager");
				// Check for old configuration: AppData mode
				if (!Directory.Exists(managerAppDataPathOld))
					managerAppDataPathOld = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SAManager");
				// Reuse an existing configuration if it exists
				if (Directory.Exists(managerAppDataPathOld))
				{
					if (File.Exists(Path.Combine(managerAppDataPathOld, "Manager.json")) || File.Exists(Path.Combine(managerAppDataPathOld, "ManagerClassic.json")))
					{
						switch (MessageBox.Show(this, string.Format("An existing configuration was found in '{0}'. Would you like to reuse it?", managerAppDataPathOld), "SADX Mod Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
						{
							case DialogResult.No:
								break;
							case DialogResult.Cancel:
								buttonInstall.Enabled = true;
								return;
							case DialogResult.Yes:
								// Load ManagerClassic.json if it exists
								if (File.Exists(Path.Combine(managerAppDataPathOld, "ManagerClassic.json")))
								{
									managerClassicConfig = JsonDeserialize<ClassicManagerJson>(Path.Combine(managerAppDataPathOld, "ManagerClassic.json"));
								}
								overwrite = false;
								break;
						}
					}
				}
				// Check if SADXModLoader.ini exists and prompt to reuse it
				bool cancelled = CheckOldLoaderSettings(this);
				if (cancelled)
				{
					buttonInstall.Enabled = true;
					return;
				}
			}
			// Create necessary folders
			Directory.CreateDirectory(Path.Combine(managerAppDataPath, "profiles"));
			// Create ManagerClassic.json
			if (overwrite || !File.Exists(Path.Combine(managerAppDataPath, "ManagerClassic.json")))
			{
				if (managerClassicConfig == null)
					managerClassicConfig = new DataClasses.ClassicManagerJson();
				JsonSerialize(managerClassicConfig, Path.Combine(managerAppDataPath, "ManagerClassic.json"));
			}
			// Create Profiles.json
			if (overwrite || !File.Exists(Path.Combine(managerAppDataPath, "profiles", "Profiles.json")))
			{
				profilesJson = new DataClasses.ProfilesJson();
				profilesJson.ProfilesList.Add(new ProfileData { Name = "Default", Filename = "Default.json" });
				JsonSerialize(profilesJson, Path.Combine(managerAppDataPath, "profiles", "Profiles.json"));
			}
			// Create Default.json
			if (overwrite || !File.Exists(Path.Combine(managerAppDataPath, "profiles", "Default.json")))
			{
				if (gameSettings == null)
					gameSettings = new GameSettings { GamePath = gameMainPath };
				gameSettings.Graphics.HorizontalResolution = Screen.PrimaryScreen.Bounds.Width;
				gameSettings.Graphics.VerticalResolution = Screen.PrimaryScreen.Bounds.Height;
				JsonSerialize(gameSettings, Path.Combine(managerAppDataPath, "profiles", "Default.json"));
			}
			// Copy SADXModManager.exe to the game folder
			if (managerExePath != gameMainPath)
			{
				int attempt = 0;
				DialogResult copyres = DialogResult.Cancel;
				do
				{
					try
					{
						// Copy Manager.exe
						File.Copy(Application.ExecutablePath, Path.Combine(gameMainPath, "SADXModManager.exe"), true);
					}
					catch (Exception ex)
					{
						copyres = DialogResult.Retry;
						attempt++;
						if (attempt > 10)
							copyres = MessageBox.Show(null, string.Format("Unable to install SADX Mod Manager: {0}. Try again?", ex.Message.ToString()), "SADX Mod Manager Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					}
				}
				while (copyres == DialogResult.Retry);
			}
			// Write the version file
			File.WriteAllText(Path.Combine(managerAppDataPath, "sadxmanagerver.txt"), internalVersion.ToString());
			// Set Manager EXE path to game path
			managerExePath = gameMainPath;
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
			}
			// Open the dialog
			using (UpdatesAvailableDialog uDialog = new UpdatesAvailableDialog(items, Path.Combine(managerAppDataPath, "updates"), true))
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
							{
								DeleteOldFiles(this, managerExePath);
								Process.Start(Path.Combine(managerExePath, "SADXModManager.exe"));
							}
						}
						Close();
						return;
					// No items to download
					case DialogResult.None:
						if (!isManager)
						{
							if (File.Exists(Path.Combine(managerExePath, "SADXModManager.exe")))
							{
								DeleteOldFiles(this, managerExePath);
								Process.Start(Path.Combine(managerExePath, "SADXModManager.exe"));
							}
							Close();
						}
						break;
					// Downloads cancelled or critical error
					case DialogResult.Abort:
						Close();
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