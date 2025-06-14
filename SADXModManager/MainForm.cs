﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniFile;
using SharpDX.DirectInput;
using ModManagerCommon;
using ModManagerCommon.Forms;
using SADXModManager.Forms;
using SADXModManager.Controls;
using SADXModManager.DataClasses;
using static SADXModManager.GraphicsSettings;
using static SADXModManager.Variables;
using static SADXModManager.Utils;
using System.Text;
using System.Windows.Input;

// TODO:
// SDL Configuration
// Mod dependencies
// Add mods from archive
// Clean up code
// Game Health Check

namespace SADXModManager
{
	public partial class MainForm : Form
	{
		#region Variables and classes
		// Paths
		/// <summary>Path to sonicDX.ini</summary>
		private string sonicDxIniPath;
		/// <summary>Path to Codes.lst</summary>
		public string codelstpath;
		/// <summary>Path to Codes.xml</summary>
		public string codexmlpath;
		/// <summary>Path to Codes.dat</summary>
		public string codedatpath;
		/// <summary>Path to Patch.dat</summary>
		public string patchdatpath;
		/// <summary>Path to Patches.json</summary>
		public string patchesJsonPath;
		/// <summary>Path to old SAManager folder in case settings were migrated</summary>
		public string oldManagerSettingsPath = string.Empty;
		// Controller
		/// <summary>DirectInput object</summary>
		DirectInput directInput;
		/// <summary>Joystick device</summary>
		Joystick inputDevice;
		/// <summary>Joystick button control list</summary>
		readonly List<ButtonControl> buttonControls = new List<ButtonControl>();
		/// <summary>Serializable controller configuration for sonicDX.ini</summary>
		readonly List<ControllerConfigInternal> controllerConfig = new List<ControllerConfigInternal>();
		/// <summary>Thread to poll DInput controller status</summary>
		System.Threading.Thread controllerThread;
		/// <summary>List of controller button IDs</summary>
		static readonly int[] buttonIDs = { 16, 17, 3, 2, 1, 10, 9, 8 };
		/// <summary>Current action set for the DInput controller</summary>
		int currentAction;

		// Other
		/// <summary>4:3 aspect ratio</summary>
		const decimal ratio = 4 / 3m;
		/// <summary>Class used for mod update checks</summary>
		readonly ModUpdater modUpdater = new ModUpdater();
		/// <summary>Background check for updates</summary>
		BackgroundWorker updateWorker;
		/// <summary>"Updates available" form</summary>
		Form updatesAvailableWindow;
		/// <summary>Drag and drop identifier</summary>
		static readonly string moddropname = "Mod" + Process.GetCurrentProcess().Id;
		/// <summary>Class to sort ListView by column</summary>
		readonly ListViewColumnSorter lvwColumnSorter;
		/// <summary>List of URIs to parse for 1-click mod install</summary>
		static List<string> uri1click = new List<string>();
		// Serialized structs
		/// <summary>Deserialized sonicDX.ini</summary>
		private SonicDxIni sonicDxIni;
		/// <summary>Deserialized config.ini for d3d8to11</summary>
		private D3d8to11ConfigIni d3d8to11ConfigIni;
		/// <summary>Deserialized Patches.json</summary>
		GamePatchesJson patchesJson;

		/// <summary>Mods list</summary>
		Dictionary<string, SADXModInfo> mods;
		/// <summary>Codes list from Codes.xml</summary>
		CodeList mainCodes;
		/// <summary>Active codes list</summary>
		List<Code> codes;

		// Toggles
		/// <summary>True if the Mod Loader is installed</summary>
		bool installed;
		/// <summary>When this is true, UI event handlers are suppressed</summary>
		bool suppressEvent;
		/// <summary>True if the warning about mod manifests has been displayed at least once</summary>
		private bool displayedManifestWarning;
		/// <summary>True if an update check has completed successfully</summary>
		private bool checkedForUpdates;

		/// <summary>Actions for the DInput controller</summary>
		static readonly string[] actionNames =
		{
			"Rotate camera right",
			"Rotate camera left",
			"Start/Set",
			"Jump",
			"Cancel/Attack",
			"Action",
			"Flute",
			"Z Button"
		};

		/// <summary>Resolution profiles for the combo box</summary>
		static readonly Size[] resolutionPresets =
		{
			new Size(640, 480), // 640x480
			new Size(800, 600), // 800x600
			new Size(1024, 768), // 1024x768
			new Size(1152, 864), // 1152x864
			new Size(1280, 960), // 1280x960
			new Size(1280, 1024), // 1280x1024
			new Size(), // Native
			new Size(), // 1/2x Native
			new Size(), // 2x Native
			new Size(1280, 720), // 720p
			new Size(1920, 1080), // 1080p
			new Size(3840, 2160), // 4K
			new Size(7680, 4320) // 8K
		};
		#endregion

		#region Startup
		/// <summary>Sets up various paths dynamically and loads the configuration.</summary>
		private void InitConfigAndPaths()
		{
			// Set the base folder
			managerExePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\', '/' });
			// If the manager is located in the game folder and a .modloader folder is found, set paths
			if (Directory.Exists(Path.Combine(managerExePath, "mods", ".modloader")))
			{
				gameMainPath = managerExePath;
			}
			// Otherwise try to read from the Manager's old data location
			else
			{
				gameMainPath = GetGamePathFromSettings();
			}
			// If game path detection failed
			if (string.IsNullOrEmpty(gameMainPath))
			{
				// If the manager is located in the same folder as the game, set game path and proceed
				if (File.Exists(Path.Combine(managerExePath, "sonic.exe")))
				{
					gameMainPath = managerExePath;
					Directory.CreateDirectory(Path.Combine(gameMainPath, "mods", ".modloader", "profiles"));			
				}
				// If the manager isn't located in the same folder as the game, hide the form and load the installation wizard instead
				else
				{
					Hide();
					Form wizard = new InstallationWizard();
					wizard.ShowDialog();
					return;
				}
			}
			// Set manager data path
			managerAppDataPath = Path.Combine(gameMainPath, "mods", ".modloader");
			managerClassicConfigJsonPath = Path.Combine(gameMainPath, "mods", ".modloader", "ManagerClassic.json");
			// Temp folder
			updatesTempPath = Path.Combine(managerAppDataPath, "updates");
			// d3d8to11 path
			d3d8to11ConfigPath = Path.Combine(managerAppDataPath, "extlib", "d3d8to11", "config.ini");
			// Load SAManager settings JSON file
			if (managerClassicConfig == null) // It might be already loaded from a legacy location (SAManager folder)
				managerClassicConfig = JsonDeserialize<ClassicManagerJson>(managerClassicConfigJsonPath);
			// If loading failed, create a new configuration
			if (managerClassicConfig == null)
				managerClassicConfig = new ClassicManagerJson(){ KeepManagerOpen = true, ManagerUpdateCheck = true };
			if (managerClassicConfig.IgnoredModUpdates == null)
				managerClassicConfig.IgnoredModUpdates = new List<string>();
			// Load the SADX profiles JSON file
			profilesListJsonPath = Path.Combine(managerAppDataPath, "profiles", "Profiles.json");
			profilesJson = JsonDeserialize<ProfilesJson>(profilesListJsonPath);
			// Create a new profile list if one doesn't exist
			if (profilesJson == null)
			{
				profilesJson = new ProfilesJson();
				profilesJson.ProfilesList.Add(new ProfileData { Name = "Default", Filename = "Default.json" });
			}
		}

		private string GetGamePathFromSettings()
		{
			// Locate the manager data folder (portable mode or otherwise)
			oldManagerSettingsPath = Path.GetFullPath(Directory.Exists(Path.Combine(managerExePath, "SAManager")) ? Path.Combine(managerExePath, "SAManager") : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SAManager"));
			if (!Directory.Exists(oldManagerSettingsPath))
			{
				return string.Empty; // Failed to find the manager data folder
			}
			// If it fails, try to locate the game path in Manager.json
			string managerjsonpath = Path.Combine(oldManagerSettingsPath, "Manager.json");
			{
				if (File.Exists(managerjsonpath))
				{
					// Load ManagerClassic.json if it exists
					if (File.Exists(Path.Combine(oldManagerSettingsPath, "ManagerClassic.json")))
						managerClassicConfig = JsonDeserialize<ClassicManagerJson>(Path.Combine(oldManagerSettingsPath, "ManagerClassic.json"));
					ManagerJson settings = JsonDeserialize<ManagerJson>(managerjsonpath);
					if (settings != null && settings.GameEntries != null && settings.GameEntries.Count > 0)
					{
						// Look for the SADX entry
						foreach (var entry in settings.GameEntries)
						{
							// If the game folder is written in Manager.json, it's safe to assume the rest is in the mods folder
							if (entry != null && entry.Type == GameEntry.GameType.SADX || !string.IsNullOrEmpty(entry.Directory))
							{
								return entry.Directory;
							}
						}
					}
				}
			}
			// If locating the game path in Manager.json or ManagerClassic.json failed, try the currently selected profile or Default.json
			string tempCurrentProfileJsonPath = string.Empty;
			// Load the Profiles.json file (old path)
			string tempProfilesListJsonPath = Path.Combine(oldManagerSettingsPath, "SADX", "Profiles.json");
			// If Profiles.json exists, try to read it
			if (File.Exists(tempProfilesListJsonPath))
			{
				profilesJson = JsonDeserialize<ProfilesJson>(profilesListJsonPath);
				// Find the filename of the currently selected profile
				if (profilesJson != null && profilesJson.ProfilesList != null)
					tempCurrentProfileJsonPath = Path.Combine(oldManagerSettingsPath, "SADX", profilesJson.ProfilesList[Math.Min(profilesJson.ProfilesList.Count - 1, profilesJson.ProfileIndex)].Filename);
				// If the specified profile doesn't exist, try to load the default one
				if (!File.Exists(tempCurrentProfileJsonPath))
					tempCurrentProfileJsonPath = Path.Combine(oldManagerSettingsPath, "SADX", "Default.json");
			}
			// If Profiles.json doesn't exist, assume Default.json
			else
				tempCurrentProfileJsonPath = Path.Combine(oldManagerSettingsPath, "SADX", "Default.json");
			// If Default.json doesn't exist either...
			if (!File.Exists(tempCurrentProfileJsonPath))
				return string.Empty; // Failed to find profile
			gameSettings = JsonDeserialize<GameSettings>(tempCurrentProfileJsonPath);
			if (gameSettings == null || string.IsNullOrEmpty(gameSettings.GamePath))
				return string.Empty; // Failed to load the profile or retrieve the game path
			// Set the .modloader folder location
			managerAppDataPath = Path.Combine(gameSettings.GamePath, "mods", ".modloader");
			DialogResult resultMigrate;
			// Attempt transfer
			do
			{
				try
				{
					resultMigrate = DialogResult.Cancel;
					// Create the profiles folder
					Directory.CreateDirectory(Path.Combine(gameSettings.GamePath, "mods", ".modloader", "profiles"));
					// Copy all JSON files from the SADX folder
					string[] srcpfrfiles = Directory.GetFiles(Path.Combine(oldManagerSettingsPath, "SADX"), "*.json", SearchOption.AllDirectories);
					foreach (string srcpfrfile in srcpfrfiles)
					{
						// Only copy files if the destination doesn't exist
						if (!File.Exists(Path.Combine(managerAppDataPath, "profiles", Path.GetFileName(srcpfrfile))))
							File.Copy(srcpfrfile, Path.Combine(managerAppDataPath, "profiles", Path.GetFileName(srcpfrfile)), true);
					}
					// Copy the extlib folder if it exists in the old folder but not in the new one
					if (Directory.Exists(Path.Combine(oldManagerSettingsPath, "extlib")) && !Directory.Exists(Path.Combine(managerAppDataPath, "extlib")))
					{
						CopyDirectory(Path.Combine(oldManagerSettingsPath, "extlib"), Path.Combine(managerAppDataPath, "extlib"), true);
					}
					// Copy the CrashDumps folder if it exists in the old folder but not in the new one
					if (Directory.Exists(Path.Combine(oldManagerSettingsPath, "CrashDump")) && !Directory.Exists(Path.Combine(managerAppDataPath, "CrashDump")))
					{
						CopyDirectory(Path.Combine(oldManagerSettingsPath, "CrashDump"), Path.Combine(managerAppDataPath, "CrashDump"), true);
					}
					// Copy the manager version info file if it exists in the old folder but not in the new one
					if (File.Exists(Path.Combine(oldManagerSettingsPath, "sadxmanagerver.txt")) && !File.Exists(Path.Combine(managerAppDataPath, "sadxmanagerver.txt")))
					{
						File.Copy(Path.Combine(oldManagerSettingsPath, "sadxmanagerver.txt"), Path.Combine(managerAppDataPath, "sadxmanagerver.txt"));
					}
					// Copy the manager settings file if it exists in the old folder but not in the new one
					if (File.Exists(Path.Combine(oldManagerSettingsPath, "ManagerClassic.json")) && !File.Exists(Path.Combine(managerAppDataPath, "ManagerClassic.json")))
					{
						File.Copy(Path.Combine(oldManagerSettingsPath, "ManagerClassic.json"), Path.Combine(managerAppDataPath, "ManagerClassic.json"));
					}
					// Finished
					return gameSettings.GamePath;
				}
				catch (Exception ex)
				{
					resultMigrate = MessageBox.Show(this, "Failed to migrate Mod Manager settings:\n" + ex.Message.ToString()
						+ "\n\nWould you like to retry?", "Settings Migration Failed", MessageBoxButtons.RetryCancel);
				}
			} while (resultMigrate == DialogResult.Retry);
			return string.Empty;
		}

		public MainForm()
		{
			Application.ThreadException += Application_ThreadException;
			this.Font = SystemFonts.MessageBoxFont;
			InitializeComponent();
			UpdateChecker.OneClickLinks = new List<string>();
			Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
			// ListView stuff
			lvwColumnSorter = new ListViewColumnSorter();
			listViewMods.ListViewItemSorter = lvwColumnSorter;
			listViewPatches.ListViewItemSorter = lvwColumnSorter;
			listViewCodes.ListViewItemSorter = lvwColumnSorter;
			// WORKAROUND: Windows 7's system fonts don't have
			// U+2912 or U+2913. Use Cambria instead.
			// TODO: Check the actual font to see if it has the glyphs.
			Font boldFont = null;
			OperatingSystem os = Environment.OSVersion;
			if ((os.Platform == PlatformID.Win32NT || os.Platform == PlatformID.Win32Windows) &&
				(os.Version.Major < 6 || (os.Version.Major == 6 && os.Version.Minor < 2)))
			{
				// Windows XP.
				if (os.Version.Major <= 5)
				{
					boldFont = new Font("Lucida Sans Unicode", this.Font.Size * 1.25f, FontStyle.Regular);
					buttonModTop.Text = "⇈";
					buttonModBottom.Text = "⇊";
				}
				else
				{
					// Windows 7 or earlier.
					// TODO: Make sure this font exists.
					// NOTE: U+2912 and U+2913 are missing in Bold, so use Regular.
					boldFont = new Font("Cambria", this.Font.Size * 1.25f, FontStyle.Regular);
				}
			}
			else
			{
				// Newer than Windows 7, or not Windows.
				// Use the default font.
				boldFont = new Font(this.Font.FontFamily, this.Font.Size * 1.25f, FontStyle.Bold);
			}
			buttonSelectAllMods.Text = Encoding.GetEncoding(Encoding.Default.CodePage).GetString(new byte[] { Convert.ToByte(0xFE) });
			buttonCheckModUpdates.Text = Encoding.GetEncoding(Encoding.Default.CodePage).GetString(new byte[] { Convert.ToByte(0xBF) });
			buttonRefreshModList.Text = Encoding.GetEncoding(Encoding.Default.CodePage).GetString(new byte[] { Convert.ToByte(0x71) });
			checkBoxSearchMod.Text = Encoding.GetEncoding(Encoding.Default.CodePage).GetString(new byte[] { Convert.ToByte(0x4C) });
			buttonModTop.Font = boldFont;
			buttonModUp.Font = boldFont;
			buttonModDown.Font = boldFont;
			buttonModBottom.Font = boldFont;
		}

		/// <summary>Enables double buffering for form controls.</summary>
		private static void SetDoubleBuffered(Control control, bool enable)
		{
			PropertyInfo doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			doubleBufferPropertyInfo?.SetValue(control, enable, null);
		}

		/// <summary>Locates the currently selected profile's JSON file, deserializes it and updates paths and game patches</summary>
		/// <param name="loadProfile">Indicates whether the user has selected a profile to load.</param>
		private void LoadCurrentProfile(bool loadProfile)
		{
			if (loadProfile)
				currentProfileJsonPath = Path.Combine(managerAppDataPath, "profiles", profilesJson.ProfilesList[Math.Min(profilesJson.ProfileIndex, profilesJson.ProfilesList.Count - 1)].Filename);
			else
				currentProfileJsonPath = Path.Combine(managerAppDataPath, "profiles", "Default.json");
			gameSettings = JsonDeserialize<GameSettings>(currentProfileJsonPath);
			// Override in single profile mode
			if (checkBoxSingleProfile.Checked)
				currentProfileJsonPath = Path.Combine(managerAppDataPath, "profiles", "Default.json");
			// Create a new profile if it doesn't exist
			if (gameSettings == null)
				gameSettings = new GameSettings();
			// Import old settings if they exist
			if (!File.Exists(currentProfileJsonPath))
			{
				bool cancel = CheckOldLoaderSettings(this);
				if (cancel)
					System.Environment.Exit(0);
				else
				{
					JsonSerialize(gameSettings, currentProfileJsonPath);
					JsonSerialize(managerClassicConfig, managerClassicConfigJsonPath);
					JsonSerialize(profilesJson, profilesListJsonPath);
				}
			}
			// Populate save list
			if (!Directory.Exists(Path.Combine(gameMainPath, "savedata")))
				Directory.CreateDirectory(Path.Combine(gameMainPath, "savedata"));
			string[] saveListAll = Directory.GetFiles(Path.Combine(gameMainPath, "savedata"), "*.snc");
			saveList = new Dictionary<int, string>();
			int savecount = 1;
			for (int ind = 0; ind < saveListAll.Length; ind++)
			{
				if (Path.GetFileNameWithoutExtension(saveListAll[ind]).ToUpperInvariant() != "SONICADVENTURE_DX_CHAOGARDEN" &&
					Path.GetFileNameWithoutExtension(saveListAll[ind]).ToUpperInvariant() != "SONICADVENTURECHAOGARDEN")
				{
					saveList.Add(savecount, Path.GetFileNameWithoutExtension(saveListAll[ind]));
					savecount++;
				}
			}
			// Set paths for stuff inside game folder
			sonicDxIniPath = Path.Combine(gameMainPath, "sonicDX.ini");
			datadllpath = Path.Combine(gameMainPath, "system", "CHRMODELS.dll");
			datadllorigpath = Path.Combine(gameMainPath, "system", "CHRMODELS_orig.dll");
			loaderdllpath = Path.Combine(gameMainPath, "mods", ".modloader", "SADXModLoader.dll");
			codelstpath = Path.Combine(gameMainPath, "mods", ".modloader", "Codes.lst");
			codexmlpath = Path.Combine(gameMainPath, "mods", ".modloader", "Codes.xml");
			codedatpath = Path.Combine(gameMainPath, "mods", ".modloader", "Codes.dat");
			patchdatpath = Path.Combine(gameMainPath, "mods", ".modloader", "Patches.dat");
			patchesJsonPath = Path.Combine(gameMainPath, "mods", ".modloader", "Patches.json");
			toolStripStatusLabelGameFolder.Text = "Game Folder: " + gameMainPath;
			InitPatches();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// Set debugger thing
			if (!Debugger.IsAttached)
				Environment.CurrentDirectory = Application.StartupPath;
			// Set UI to double buffered
			SetDoubleBuffered(listViewMods, true);
			// Set up paths and load configuration
			InitConfigAndPaths();
			// Load the current profile
			LoadCurrentProfile(!checkBoxSingleProfile.Checked);
			// Load window settings
			if (managerClassicConfig.LastMonitorResolution == new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
			{
				Location = managerClassicConfig.WindowPosition;
				Size = managerClassicConfig.WindowSize;
				if (managerClassicConfig.Maximized)
					WindowState = FormWindowState.Maximized;
			}
			// Load the profile list and update UI
			textBoxProfileName.BeginUpdate();
			textBoxProfileName.Items.Clear();
			foreach (var item in profilesJson.ProfilesList)
				textBoxProfileName.Items.Add(item.Name.Replace(".json", ""));
			textBoxProfileName.SelectedIndex = Math.Min(profilesJson.ProfileIndex, textBoxProfileName.Items.Count - 1);
			textBoxProfileName.EndUpdate();
			// Load sonicDX.ini
			sonicDxIni = File.Exists(sonicDxIniPath) ? IniSerializer.Deserialize<SonicDxIni>(sonicDxIniPath) : new SonicDxIni();
			if (sonicDxIni.GameConfig == null)
			{
				sonicDxIni.GameConfig = new GameConfig
				{
					FrameRate = (int)FrameRate.High,
					Sound3D = 1,
					SEVoice = 1,
					BGM = 1,
					BGMVolume = 100,
					VoiceVolume = 100
				};
			}
			if (sonicDxIni.Controllers == null)
				sonicDxIni.Controllers = new Dictionary<string, ControllerConfig>();
			// Load d3d8to11 config.ini
			d3d8to11ConfigIni = File.Exists(d3d8to11ConfigPath) ? IniSerializer.Deserialize<D3d8to11ConfigIni>(d3d8to11ConfigPath) : new D3d8to11ConfigIni { OIT = new D3d8to11ConfigIni.OITConfig() };
			// Load codes list
			try
			{
				if (File.Exists(codelstpath))
					mainCodes = CodeList.Load(codelstpath);
				else if (File.Exists(codexmlpath))
					mainCodes = CodeList.Load(codexmlpath);
				else
					mainCodes = new CodeList();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, $"Error loading code list: {ex.Message}", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				mainCodes = new CodeList();
			}
			// Update monitor list
			for (int i = 0; i < Screen.AllScreens.Length; i++)
			{
				Screen s = Screen.AllScreens[i];
				comboBoxScreenNumber.Items.Add($"{i + 1} {s.DeviceName} ({s.Bounds.Location.X},{s.Bounds.Y})"
					+ $" {s.Bounds.Width}x{s.Bounds.Height} {s.BitsPerPixel} bpp {(s.Primary ? "Primary" : "")}");
			}
			// Initialize UI
			comboBoxTestSpawnTime.SelectedIndex = 0;
			InitTestSpawnCutsceneList();
			InitTestSpawnGameModeList();
			LoadSettings();
			listViewMods.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent); // Mod name
			listViewMods.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.None); // Author
			listViewMods.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize); // Version
			listViewMods.Columns[3].Width = -2; // Category
		}

		/// <summary>Sets UI items according to the game settings in the currently loaded profile</summary>
		private void LoadSettings()
		{
			suppressEvent = true;
			// Load mods
			LoadModList();
			// Load Graphics settings
			// Load Display settings
			int screenNum = Math.Min(Screen.AllScreens.Length, gameSettings.Graphics.SelectedScreen);
			comboBoxBackend.SelectedIndex = Math.Max(0, Math.Min(2, gameSettings.Graphics.RenderBackend));
			comboBoxScreenNumber.SelectedIndex = screenNum;
			comboBoxScreenMode.SelectedIndex = gameSettings.Graphics.ScreenMode;
			checkBoxVsync.Checked = gameSettings.Graphics.EnableVsync;
			checkBoxForceAspectRatio.Checked = gameSettings.Graphics.Enable43ResolutionRatio;
			numericUpDownHorizontalResolution.Enabled = !gameSettings.Graphics.Enable43ResolutionRatio;
			numericUpDownHorizontalResolution.Value = Math.Max(numericUpDownHorizontalResolution.Minimum, Math.Min(numericUpDownHorizontalResolution.Maximum, gameSettings.Graphics.HorizontalResolution));
			numericUpDownVerticalResolution.Value = Math.Max(numericUpDownVerticalResolution.Minimum, Math.Min(numericUpDownVerticalResolution.Maximum, gameSettings.Graphics.VerticalResolution));
			Rectangle rect = Screen.PrimaryScreen.Bounds;
			foreach (Screen screen in Screen.AllScreens)
				rect = Rectangle.Union(rect, screen.Bounds);
			checkBoxWindowMaintainAspect.Enabled = gameSettings.Graphics.EnableKeepResolutionRatio;
			numericUpDownWindowWidth.Enabled = gameSettings.Graphics.ScreenMode == (int)(DisplayMode)DisplayMode.CustomWindow && !gameSettings.Graphics.EnableKeepResolutionRatio;
			numericUpDownWindowWidth.Maximum = rect.Width;
			numericUpDownWindowWidth.Value = Math.Max(numericUpDownWindowWidth.Minimum, Math.Min(rect.Width, gameSettings.Graphics.CustomWindowWidth));
			numericUpDownWindowHeight.Enabled = gameSettings.Graphics.ScreenMode == (int)(DisplayMode)DisplayMode.CustomWindow;
			numericUpDownWindowHeight.Maximum = rect.Height;
			numericUpDownWindowHeight.Value = Math.Max(numericUpDownWindowHeight.Minimum, Math.Min(rect.Height, gameSettings.Graphics.CustomWindowHeight));
			checkBoxWindowResizable.Checked = gameSettings.Graphics.EnableResizableWindow;
			// Load Visuals settings
			// Framerate
			if (sonicDxIni.GameConfig.FrameRate == (int)FrameRate.Invalid || sonicDxIni.GameConfig.FrameRate > (int)FrameRate.Low)
			{
				MessageBox.Show("Invalid framerate setting detected.\nDefaulting to \"High\".", "Invalid setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
				comboBoxFramerate.SelectedIndex = (int)FrameRate.High - 1;
			}
			else
			{
				comboBoxFramerate.SelectedIndex = sonicDxIni.GameConfig.FrameRate - 1;
			}
			comboBoxClipLevel.SelectedIndex = sonicDxIni.GameConfig.ClipLevel;
			comboBoxFogEmulation.SelectedIndex = sonicDxIni.GameConfig.FogEmulation;
			checkBoxEnableOIT.Enabled = comboBoxBackend.SelectedIndex == 2;
			checkBoxEnableOIT.Checked = d3d8to11ConfigIni.OIT.EnableOIT == true;
			checkBoxBorderImage.Checked = !gameSettings.Graphics.DisableBorderImage;
			checkBoxForceMipmapping.Checked = gameSettings.Graphics.EnableForcedMipmapping;
			checkBoxForceTextureFilter.Checked = gameSettings.Graphics.EnableForcedTextureFilter;
			// AA and AF settings
			switch (gameSettings.Graphics.Antialiasing)
			{
				case 2:
					comboBoxAntialiasing.SelectedIndex = 1;
					break;
				case 4:
					comboBoxAntialiasing.SelectedIndex = 2;
					break;
				case 8:
					comboBoxAntialiasing.SelectedIndex = 3;
					break;
				case 16:
					comboBoxAntialiasing.SelectedIndex = 4;
					break;
				case 0:
				default:
					comboBoxAntialiasing.SelectedIndex = 0;
					break;
			}
			switch (gameSettings.Graphics.Anisotropic)
			{
				case 1:
					comboBoxAnisotropic.SelectedIndex = 1;
					break;
				case 2:
					comboBoxAnisotropic.SelectedIndex = 2;
					break;
				case 4:
					comboBoxAnisotropic.SelectedIndex = 3;
					break;
				case 8:
					comboBoxAnisotropic.SelectedIndex = 4;
					break;
				case 16:
					comboBoxAnisotropic.SelectedIndex = 5;
					break;
				case 0:
				default:
					comboBoxAnisotropic.SelectedIndex = 0;
					break;
			}
			// Load Graphics/Other settings
			comboBoxBackgroundFill.SelectedIndex = gameSettings.Graphics.FillModeBackground;
			comboBoxFmvFill.SelectedIndex = gameSettings.Graphics.FillModeFMV;
			checkBoxScaleHud.Checked = gameSettings.Graphics.EnableUIScaling;
			checkBoxShowMouse.Checked = gameSettings.Graphics.ShowMouseInFullscreen;
			
			// Load Input settings
			radioButtonDInput.Checked = !gameSettings.Controller.EnabledInputMod;
			radioButtonSDL.Checked = gameSettings.Controller.EnabledInputMod;
			radioButtonMouseDisable.Visible = radioButtonMouseDisable.Enabled = false; // Not implemented
																					   // Load Mouse settings
			if (sonicDxIni.GameConfig.MouseMode == 0)
				radioButtonMouseHold.Checked = true;
			else
				radioButtonMouseDragAccelerate.Checked = true;
			comboBoxMouseAction.SelectedIndex = 0;
			// Load DInput controller settings
			directInput = new DirectInput();
			var list = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
			if (list.Count > 0)
			{
				inputDevice = new Joystick(directInput, list.First().InstanceGuid);
				tableLayoutPanelDInput.RowCount = actionNames.Length;
				for (int i = 0; i < actionNames.Length; i++)
				{
					tableLayoutPanelDInput.Controls.Add(new Label
					{
						AutoSize = true,
						Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top,
						Text = actionNames[i],
						TextAlign = ContentAlignment.MiddleLeft
					}, 0, i);
					ButtonControl buttonControl = new ButtonControl { Enabled = false };
					tableLayoutPanelDInput.Controls.Add(buttonControl, 1, i);
					buttonControls.Add(buttonControl);
					buttonControl.SetButtonClicked += buttonControl_SetButtonClicked;
					buttonControl.ClearButtonClicked += buttonControl_ClearButtonClicked;
					if (i == tableLayoutPanelDInput.RowStyles.Count)
						tableLayoutPanelDInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				}
				foreach (KeyValuePair<string, ControllerConfig> item in sonicDxIni.Controllers)
				{
					int[] cfg = Enumerable.Repeat(-1, buttonIDs.Length).ToArray();
					for (int i = 0; i < item.Value.ButtonSettings.Length; i++)
					{
						if (Array.IndexOf(buttonIDs, item.Value.ButtonSettings[i]) != -1)
						{
							cfg[Array.IndexOf(buttonIDs, item.Value.ButtonSettings[i])] = i;
						}
					}
					controllerConfig.Add(new ControllerConfigInternal { Name = item.Key, Buttons = cfg });
					comboBoxControllerProfile.Items.Add(item.Key);
				}
				if (inputDevice != null)
				{
					for (int i = 0; i < controllerConfig.Count; i++)
					{
						if (controllerConfig[i].Name == sonicDxIni.GameConfig.PadConfig)
						{
							comboBoxControllerProfile.SelectedIndex = i;
							break;
						}
					}
				}
			}
			else
				groupBoxControllerDInput.Visible = false;
			if (!radioButtonDInput.Checked)
				groupBoxControllerDInput.Visible = false;
			// Hide SDL controls for now
			ListControls();
			// Load Sound settings
			checkBoxEnableMusic.Checked = (sonicDxIni.GameConfig.BGM != 0);
			checkBoxEnableSound.Checked = (sonicDxIni.GameConfig.SEVoice != 0);
			checkBoxEnable3DSound.Checked = (sonicDxIni.GameConfig.Sound3D != 0);
			checkBoxUseBassMusic.Checked = gameSettings.Sound.EnableBassMusic;
			checkBoxUseBassSE.Checked = gameSettings.Sound.EnableBassSFX;
			trackBarMusicVol.Value = sonicDxIni.GameConfig.BGMVolume;
			trackBarVoiceVol.Value = sonicDxIni.GameConfig.VoiceVolume;
			trackBarSEVol.Value = gameSettings.Sound.SEVolume;
			labelVoiceVol.Text = trackBarVoiceVol.Value.ToString();
			labelMusicVol.Text = trackBarMusicVol.Value.ToString();
			labelSEVol.Text = trackBarSEVol.Value.ToString();
			// Load Debug settings
			checkBoxEnableDebugConsole.Checked = gameSettings.DebugSettings.EnableDebugConsole;
			checkBoxEnableDebugScreen.Checked = gameSettings.DebugSettings.EnableDebugScreen;
			checkBoxEnableDebugFile.Checked = gameSettings.DebugSettings.EnableDebugFile;
			checkBoxEnableDebugCrashHandler.Checked = gameSettings.DebugSettings.EnableDebugCrashLog;
			// Load Test Spawn settings
			checkBoxTestSpawnLevel.Checked = gameSettings.TestSpawn.UseLevel;
			comboBoxTestSpawnLevel.SelectedIndex = gameSettings.TestSpawn.LevelIndex;
			numericUpDownTestSpawnAct.Value = gameSettings.TestSpawn.ActIndex;
			checkBoxTestSpawnCharacter.Checked = gameSettings.TestSpawn.UseCharacter;
			comboBoxTestSpawnCharacter.SelectedIndex = gameSettings.TestSpawn.CharacterIndex;
			if (checkBoxTestSpawnLevel.Checked)
				checkBoxTestSpawnPosition.Checked = gameSettings.TestSpawn.UsePosition;
			else
				checkBoxTestSpawnPosition.Enabled = false;
			numericUpDownTestSpawnX.Value = (int)gameSettings.TestSpawn.XPosition;
			numericUpDownTestSpawnY.Value = (int)gameSettings.TestSpawn.YPosition;
			numericUpDownTestSpawnZ.Value = (int)gameSettings.TestSpawn.ZPosition;
			checkBoxTestSpawnAngleDeg.Checked = true;
			numericUpDownTestSpawnAngle.Value = gameSettings.TestSpawn.Rotation;
			checkBoxTestSpawnAngleDeg.Checked = managerClassicConfig.AngleDeg;
			checkBoxTestSpawnAngleHex.Checked = managerClassicConfig.AngleHex;
			checkBoxTestSpawnEvent.Checked = gameSettings.TestSpawn.UseEvent;
			comboBoxTestSpawnEvent.SelectedIndex = GetTestspawnEventIndex(gameSettings.TestSpawn.EventIndex, false);
			checkBoxTestSpawnGameMode.Checked = gameSettings.TestSpawn.UseGameMode;
			comboBoxTestSpawnGameMode.SelectedIndex = GetTestspawnGamemodeIndex(gameSettings.TestSpawn.GameModeIndex, false);
			checkBoxTestSpawnSave.Checked = gameSettings.TestSpawn.UseSave;
			comboBoxTestSpawnSave.Items.Clear();
			for (int ind = 1; ind < saveList.Count + 1; ind++)
			{
				comboBoxTestSpawnSave.Items.Add(saveList[ind]);
			}
			comboBoxTestSpawnSave.SelectedIndex = GetTestspawnSaveIndex(gameSettings.TestSpawn.SaveIndex, false);
			// Load Options/Update settings
			checkBoxCheckLoaderUpdatesStartup.Checked = managerClassicConfig.UpdateCheck;
			checkBoxCheckUpdateModsStartup.Checked = managerClassicConfig.ModUpdateCheck;
			checkBoxCheckManagerUpdateStartup.Checked = managerClassicConfig.ManagerUpdateCheck;
			checkBoxCheckLauncherUpdateStartup.Checked = managerClassicConfig.LauncherUpdateCheck;
			comboBoxUpdateUnit.SelectedIndex = (int)managerClassicConfig.UpdateUnit;
			numericUpDownUpdateFrequency.Value = managerClassicConfig.UpdateFrequency;
			// Load Options/Misc settings
			comboBoxVoiceLanguage.SelectedIndex = gameSettings.TestSpawn.GameVoiceLanguage;
			comboBoxTextLanguage.SelectedIndex = gameSettings.TestSpawn.GameTextLanguage;
			checkBoxPauseWhenInactive.Checked = gameSettings.Graphics.EnablePauseOnInactive;
			// Load Options/Manager settings
			checkBoxKeepManagerOpen.Checked = managerClassicConfig.KeepManagerOpen;
			checkBoxSingleProfile.Checked = managerClassicConfig.SingleProfileMode;
			suppressEvent = false;
		}

		// Moves Mod Loader files from 'mods' to 'mods/.modloader'
		private void MoveFileFromModsFolder(string filename, bool critical)
		{
			if (File.Exists(Path.Combine(gameMainPath, "mods", filename)))
			{
				File.Copy(Path.Combine(gameMainPath, "mods", filename), Path.Combine(gameMainPath, "mods", ".modloader", filename), false);
				File.Delete(Path.Combine(gameMainPath, "mods", filename));
			}
			else if (critical)
			{
				switch (MessageBox.Show(this, string.Format("Critical Mod Loader file '{0}' was not found. SADX Mod Manager cannot function without it. Download the Mod Loader?", filename), "SADX Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
				{
					case DialogResult.Yes:
						Hide();
						Form wizard = new InstallationWizard();
						wizard.ShowDialog();
						return;
					case DialogResult.No:
						Environment.Exit(0);
						return;
				}
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			// Check if the old settings were moved
			if (!string.IsNullOrEmpty(oldManagerSettingsPath))
			{
				MessageBox.Show(this, string.Format("Settings and mod lists have been migrated from '{0}' to '{1}'.\n\nIf you aren't using the SA Manager version 1.3.1 or below alongside the Classic SADX Mod Manager, you can delete the folder '{0}'.", oldManagerSettingsPath, managerAppDataPath), "SADX Mod Manager Classic", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			// Delete the updates folder
			string updateFolder = Path.Combine(managerAppDataPath, "updates");
			if (Directory.Exists(updateFolder))
			{
				try
				{ 
					Directory.Delete(updateFolder, true); 
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, string.Format("Error cleaning up the temporary update folder at {0}: {1}", updateFolder, ex.Message.ToString()));
				}
			}
			// Check and delete old version files
			if (managerExePath != gameMainPath) // This check needs to be done because the DLLs will be in use
				DeleteOldFiles(this, gameMainPath);
			else
				CheckOldFilesCritical(this, gameMainPath);
			// Check old path
			if (!File.Exists(loaderdllpath))
			{
				Directory.CreateDirectory(Path.Combine(gameMainPath, "mods", ".modloader"));
				// Critical files
				MoveFileFromModsFolder("SADXModLoader.dll", true);
				MoveFileFromModsFolder("Patches.json", true);
				MoveFileFromModsFolder("Border_Default.png", true);
				MoveFileFromModsFolder("Codes.lst", true);
				// Non-critical files
				MoveFileFromModsFolder("sadxmlver.txt", false);
				MoveFileFromModsFolder("Codes.xml", false);
				MoveFileFromModsFolder("Codes.dat", false);
				MoveFileFromModsFolder("Patches.dat", false);
				MoveFileFromModsFolder("Border.png", false);
				MoveFileFromModsFolder("sadxmanagerver.txt", false);
				MoveFileFromModsFolder("ManagerClassic.json", false);
				MoveFileFromModsFolder("SADXModLoader.log", false);
			}
			// Check Mod Loader installation state
			if (!File.Exists(datadllpath))
			{
				MessageBox.Show(this, "CHRMODELS.dll could not be found.\n\n" +
					"Cannot determine state of installation. Make sure you are running the Mod Manager from the game's main folder (where sonic.exe is).\n\n" +
					"If you are using the Steam version of the game, you need to convert it to the 2004 version first before you can use the Mod Loader.",
					Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Hide();
				Form wizard = new InstallationWizard();
				wizard.ShowDialog();
				return;
			}
			else if (File.Exists(datadllorigpath))
			{
				installed = true;
				buttonInstallLoader.Text = "Disable Loader";
				using (MD5 md5 = MD5.Create())
				{
					byte[] hash1 = md5.ComputeHash(File.ReadAllBytes(loaderdllpath));
					byte[] hash2 = md5.ComputeHash(File.ReadAllBytes(datadllpath));

					if (!hash1.SequenceEqual(hash2))
					{

						DialogResult result = MessageBox.Show(this, "Installed loader DLL differs from copy in mods folder."
							+ "\n\nWould you like to update the installed copy?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

						if (result == DialogResult.Yes)
							File.Copy(loaderdllpath, datadllpath, true);
					}
				}
			}

			List<string> uris = Program.UriQueue.GetUris();

			Program.UriQueue.UriEnqueued += UriQueueOnUriEnqueued;

			// Update check
			InitializeWorker();
			UpdateChecker.CheckMode = UpdateChecker.UpdateMode.Startup;
			UpdateChecker.UpdateItems items = UpdateChecker.UpdateItems.None;
			if (checkBoxCheckLoaderUpdatesStartup.Checked)
				items |= UpdateChecker.UpdateItems.Loader;
			if (checkBoxCheckManagerUpdateStartup.Checked)
				items |= UpdateChecker.UpdateItems.Manager;
			if (checkBoxCheckLauncherUpdateStartup.Checked)
				items |= UpdateChecker.UpdateItems.Launcher;
			if (checkBoxCheckUpdateModsStartup.Checked)
				items |= UpdateChecker.UpdateItems.Mods;
			if (uris != null && uris.Count > 0)
			{
				UpdateChecker.OneClickLinks = uris;
				items |= UpdateChecker.UpdateItems.OneClick;
			}
			UpdateChecker.ItemsToCheck = items;
			AutoUpdate();

			// If we've checked for updates, save the modified
			// last update times without requiring the user to
			// click the save button.
			if (checkedForUpdates)
			{
				JsonSerialize(managerClassicConfig, managerClassicConfigJsonPath);
			}
		}

		private void InitializeWorker()
		{
			if (updateWorker != null)
			{
				return;
			}

			updateWorker = new BackgroundWorker { WorkerSupportsCancellation = true };
			updateWorker.DoWork += UpdateChecker_DoWork;
			updateWorker.RunWorkerCompleted += UpdateChecker_RunWorkerCompleted;
		}

		private void AutoUpdate()
		{
			// Periodic update check but not enough time has passed since last check
			if (UpdateChecker.CheckMode == UpdateChecker.UpdateMode.Scheduled && !UpdateTimeElapsed(managerClassicConfig.UpdateUnit, managerClassicConfig.UpdateFrequency, DateTime.FromFileTimeUtc(managerClassicConfig.ModUpdateTime)))
				return;

			// Nothing to check
			if (UpdateChecker.ItemsToCheck == UpdateChecker.UpdateItems.None)
				return;

			if (updateWorker.IsBusy)
			{
				MessageBox.Show(this, "An update check is already taking place. Please wait a while and try again.", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			InitializeWorker();

			toolStripStatusLabel.Text = "Checking for updates...";
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.OneClick))
			{
				toolStripStatusLabel.Text = "Parsing URLs...";
			}
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.Mods) && (UpdateChecker.CheckMode == UpdateChecker.UpdateMode.Startup || UpdateChecker.CheckMode == UpdateChecker.UpdateMode.Scheduled))
			{
				checkedForUpdates = true;
				managerClassicConfig.ModUpdateTime = DateTime.UtcNow.ToFileTimeUtc();
			}
			Dictionary<string, SADXModInfo> infoNew = new Dictionary<string, SADXModInfo>();
			foreach (KeyValuePair<string, SADXModInfo> mod in mods)
			{
				if (!managerClassicConfig.IgnoredModUpdates.Contains(mod.Key))
					infoNew.Add(mod.Key, mod.Value);
			}
			updateWorker.RunWorkerAsync(infoNew.Select(x => new KeyValuePair<string, ModInfo>(x.Key, x.Value)).ToList());
			buttonCheckForUpdatesNow.Enabled = buttonCheckModUpdates.Enabled = false;
		}

		private void LoadModList()
		{
			buttonModTop.Enabled = buttonModUp.Enabled = buttonModDown.Enabled = buttonModBottom.Enabled = buttonModConfigure.Enabled = false;
			labelModDescription.Text = "Description: No mod selected.";
			listViewMods.Items.Clear();
			mods = new Dictionary<string, SADXModInfo>();
			codes = new List<Code>(mainCodes.Codes);
			string modDir = Path.Combine(gameMainPath, "mods");
			if (!Directory.Exists(modDir))
			{
				MessageBox.Show(this, "Mods directory not found.", "SADX Mod Manager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}

			if (File.Exists(Path.Combine(modDir, "mod.ini")))
			{
				MessageBox.Show(this, "There is a mod.ini in the mods folder."
							+ "\n\nEach mod must be placed in a subfolder in the mods folder. Do not extract mods directly to the mods folder." +
							"\n\nMove or delete mod.ini in the mods folder and run the Mod Manager again.", "SADX Mod Manager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}

			foreach (string filename in SADXModInfo.GetModFiles(new DirectoryInfo(modDir)))
			{
				SADXModInfo mod = IniSerializer.Deserialize<SADXModInfo>(filename);
				mods.Add((Path.GetDirectoryName(filename) ?? string.Empty).Substring(modDir.Length + 1), mod);
			}

			listViewMods.BeginUpdate();

			foreach (string mod in new List<string>(gameSettings.EnabledMods))
			{
				if (mods.ContainsKey(mod))
				{
					SADXModInfo inf = mods[mod];
					suppressEvent = true;
					listViewMods.Items.Add(new ListViewItem(new[] { inf.Name, inf.Author, inf.Version, inf.Category }) { Checked = true, Tag = mod, ForeColor = managerClassicConfig.IgnoredModUpdates.Contains(mod) ? SystemColors.GrayText : SystemColors.WindowText });
					suppressEvent = false;
					if (!string.IsNullOrEmpty(inf.Codes))
						codes.AddRange(CodeList.Load(Path.Combine(Path.Combine(modDir, mod), inf.Codes)).Codes);
				}
				else
				{
					MessageBox.Show(this, "Mod \"" + mod + "\" could not be found.\n\nThis mod will be removed from the list.",
						Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					gameSettings.EnabledMods.Remove(mod);
				}
			}

			foreach (KeyValuePair<string, SADXModInfo> inf in mods.OrderBy(x => x.Value.Name))
			{

				if (!gameSettings.EnabledMods.Contains(inf.Key))
					listViewMods.Items.Add(new ListViewItem(new[] { inf.Value.Name, inf.Value.Author, inf.Value.Version, inf.Value.Category }) { Tag = inf.Key });
			}

			listViewMods.EndUpdate();

			gameSettings.EnabledCodes = new List<string>(gameSettings.EnabledCodes.Where(a => codes.Any(c => c.Name == a)));
			foreach (Code item in codes.Where(a => a.Required && !gameSettings.EnabledCodes.Contains(a.Name)))
				gameSettings.EnabledCodes.Add(item.Name);

			RefreshCodes();
			toolStripStatusLabel.Text = string.Format("Loaded {0} mods, {1} enabled.", mods.Count, gameSettings.EnabledMods.Count);
		}

		private void RefreshCodes()
		{
			listViewCodes.BeginUpdate();
			listViewCodes.Items.Clear();

			foreach (Code item in codes)
			{
				ListViewItem lvitem = new ListViewItem(new[] { item.Name, item.Author, item.Category });
				lvitem.Checked = gameSettings.EnabledCodes.Contains(item.Name);
				listViewCodes.Items.Add(lvitem);
			}
			listViewCodes.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent); // Code name
			listViewCodes.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent); // Author
			listViewCodes.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent); // Category

			listViewCodes.EndUpdate();
		}

		private void listViewCodes_SelectedIndexChanged(object sender, EventArgs e)
		{
			string desc = "None";
			if (listViewCodes.SelectedIndices.Count == 1)
			{
				Code code = codes.Find(a => a.Name == listViewCodes.SelectedItems[0].Text);
				if (code.Description != null && code.Description != "")
					desc = code.Description;
			}
			labelCodeDescription.Text = "Description: " + desc;
		}

		#endregion

		#region Mod management and configuration
		private void modListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			int count = listViewMods.SelectedIndices.Count;
			if (count == 0)
			{
				buttonModTop.Enabled = buttonModUp.Enabled = buttonModDown.Enabled = buttonModBottom.Enabled = buttonModConfigure.Enabled = false;
				labelModDescription.Text = "Description: No mod selected.";
			}
			else if (count == 1)
			{
				labelModDescription.Text = "Description: " + mods[(string)listViewMods.SelectedItems[0].Tag].Description;
				buttonModTop.Enabled = listViewMods.SelectedIndices[0] != 0;
				buttonModUp.Enabled = listViewMods.SelectedIndices[0] > 0;
				buttonModDown.Enabled = listViewMods.SelectedIndices[0] < listViewMods.Items.Count - 1;
				buttonModBottom.Enabled = listViewMods.SelectedIndices[0] != listViewMods.Items.Count - 1;
				buttonModConfigure.Enabled = File.Exists(Path.Combine("mods", (string)listViewMods.SelectedItems[0].Tag, "configschema.xml"));
			}
			else if (count > 1)
			{
				labelModDescription.Text = "Description: Multiple mods selected.";
				buttonModTop.Enabled = buttonModUp.Enabled = buttonModDown.Enabled = buttonModBottom.Enabled = true;
				buttonModConfigure.Enabled = false;
			}
		}

		private void modTopButton_Click(object sender, EventArgs e)
		{
			if (listViewMods.SelectedItems.Count < 1)
				return;

			listViewMods.BeginUpdate();

			for (int i = 0; i < listViewMods.SelectedItems.Count; i++)
			{
				int index = listViewMods.SelectedItems[i].Index;

				if (index > 0)
				{
					ListViewItem item = listViewMods.SelectedItems[i];
					listViewMods.Items.Remove(item);
					listViewMods.Items.Insert(i, item);
				}
			}

			listViewMods.SelectedItems[0].EnsureVisible();
			listViewMods.EndUpdate();
		}

		private void modUpButton_Click(object sender, EventArgs e)
		{
			if (listViewMods.SelectedItems.Count < 1)
				return;

			listViewMods.BeginUpdate();

			for (int i = 0; i < listViewMods.SelectedItems.Count; i++)
			{
				int index = listViewMods.SelectedItems[i].Index;

				if (index-- > 0 && !listViewMods.Items[index].Selected)
				{
					ListViewItem item = listViewMods.SelectedItems[i];
					listViewMods.Items.Remove(item);
					listViewMods.Items.Insert(index, item);
				}
			}

			listViewMods.SelectedItems[0].EnsureVisible();
			listViewMods.EndUpdate();
		}

		private void modDownButton_Click(object sender, EventArgs e)
		{
			if (listViewMods.SelectedItems.Count < 1)
				return;

			listViewMods.BeginUpdate();

			for (int i = listViewMods.SelectedItems.Count - 1; i >= 0; i--)
			{
				int index = listViewMods.SelectedItems[i].Index + 1;

				if (index != listViewMods.Items.Count && !listViewMods.Items[index].Selected)
				{
					ListViewItem item = listViewMods.SelectedItems[i];
					listViewMods.Items.Remove(item);
					listViewMods.Items.Insert(index, item);
				}
			}

			listViewMods.SelectedItems[listViewMods.SelectedItems.Count - 1].EnsureVisible();
			listViewMods.EndUpdate();
		}

		private void modBottomButton_Click(object sender, EventArgs e)
		{
			if (listViewMods.SelectedItems.Count < 1)
				return;

			listViewMods.BeginUpdate();

			for (int i = listViewMods.SelectedItems.Count - 1; i >= 0; i--)
			{
				int index = listViewMods.SelectedItems[i].Index;

				if (index != listViewMods.Items.Count - 1)
				{
					ListViewItem item = listViewMods.SelectedItems[i];
					listViewMods.Items.Remove(item);
					listViewMods.Items.Insert(listViewMods.Items.Count, item);
				}
			}

			listViewMods.SelectedItems[listViewMods.SelectedItems.Count - 1].EnsureVisible();
			listViewMods.EndUpdate();
		}

		private void buttonRefreshModList_Click(object sender, EventArgs e)
		{
			LoadModList();
		}

		private void buttonNewMod_Click(object sender, EventArgs e)
		{
			contextMenuStripAddMod.Show(buttonModAdd, buttonModAdd.Width, 0);
		}

		private void codesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			Code code = codes[e.Index];
			if (code.Required)
				e.NewValue = CheckState.Checked;
			if (e.NewValue == CheckState.Unchecked)
			{
				if (gameSettings.EnabledCodes.Contains(code.Name))
					gameSettings.EnabledCodes.Remove(code.Name);
			}
			else
			{
				if (!gameSettings.EnabledCodes.Contains(code.Name))
					gameSettings.EnabledCodes.Add(code.Name);
			}
		}

		private void listViewMods_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (suppressEvent) return;
			codes = new List<Code>(mainCodes.Codes);
			string modDir = Path.Combine(Environment.CurrentDirectory, "mods");
			List<string> modlist = new List<string>();
			foreach (ListViewItem item in listViewMods.CheckedItems)
				modlist.Add((string)item.Tag);
			if (e.NewValue == CheckState.Unchecked)
				modlist.Remove((string)listViewMods.Items[e.Index].Tag);
			else
				modlist.Add((string)listViewMods.Items[e.Index].Tag);
			foreach (string mod in modlist)
				if (mods.ContainsKey(mod))
				{
					SADXModInfo inf = mods[mod];
					if (!string.IsNullOrEmpty(inf.Codes))
						codes.AddRange(CodeList.Load(Path.Combine(Path.Combine(modDir, mod), inf.Codes)).Codes);
				}
			gameSettings.EnabledCodes = new List<string>(gameSettings.EnabledCodes.Where(a => codes.Any(c => c.Name == a)));
			foreach (Code item in codes.Where(a => a.Required && !gameSettings.EnabledCodes.Contains(a.Name)))
				gameSettings.EnabledCodes.Add(item.Name);
			RefreshCodes();
		}

		private void listViewMods_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (suppressEvent)
				return;
			// Refresh the list of currently active mods in the JSON (memory)
			foreach (ListViewItem item in listViewMods.Items)
			{
				if (gameSettings.EnabledMods.Contains((string)item.Tag) && !item.Checked)
					gameSettings.EnabledMods.Remove((string)item.Tag);
				else if (!gameSettings.EnabledMods.Contains((string)item.Tag) && item.Checked)
					gameSettings.EnabledMods.Add((string)item.Tag);
			}
		}

		private void modListView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}

			if (listViewMods.FocusedItem.Bounds.Contains(e.Location))
			{
				disableUpdatesToolStripMenuItem.Checked = managerClassicConfig.IgnoredModUpdates.Contains((string)listViewMods.SelectedItems[0].Tag);
				configureToolStripMenuItem.Enabled = listViewMods.SelectedItems.Count == 1 && File.Exists(Path.Combine("mods", (string)listViewMods.SelectedItems[0].Tag, "configschema.xml"));
				contextMenuStripMod.Show(Cursor.Position);
			}
		}

		private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listViewMods.SelectedItems)
			{
				Process.Start(Path.Combine("mods", (string)item.Tag));
			}
		}

		private void configureModButton_Click(object sender, EventArgs e)
		{
			using (ModConfigDialog dlg = new ModConfigDialog(Path.Combine("mods", (string)listViewMods.SelectedItems[0].Tag), listViewMods.SelectedItems[0].Text))
			{
				dlg.StartPosition = FormStartPosition.CenterParent;
				dlg.ShowDialog(this);
			}
		}
		#endregion

		#region Drag and drop
		private void modListView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			listViewMods.DoDragDrop(new DataObject(moddropname, listViewMods.SelectedItems.Cast<ListViewItem>().ToArray()), DragDropEffects.Move | DragDropEffects.Scroll);
		}

		private void modListView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(moddropname))
				e.Effect = DragDropEffects.Move | DragDropEffects.Scroll;
			else
				e.Effect = DragDropEffects.None;
		}

		private void modListView_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(moddropname))
				e.Effect = DragDropEffects.Move | DragDropEffects.Scroll;
			else
				e.Effect = DragDropEffects.None;
		}

		private void modListView_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(moddropname))
			{
				Point clientPoint = listViewMods.PointToClient(new Point(e.X, e.Y));
				ListViewItem[] items = (ListViewItem[])e.Data.GetData(moddropname);
				int ind = listViewMods.GetItemAt(clientPoint.X, clientPoint.Y).Index;
				foreach (ListViewItem item in items)
					if (ind > item.Index)
						ind++;
				listViewMods.BeginUpdate();
				foreach (ListViewItem item in items)
					listViewMods.Items.Insert(ind++, (ListViewItem)item.Clone());
				foreach (ListViewItem item in items)
					listViewMods.Items.Remove(item);
				listViewMods.EndUpdate();
			}
		}
		#endregion

		#region Saving and Mod Loader installation
		private void SaveSettings(bool saveProfile)
		{
			// Clear and readd mods
			gameSettings.EnabledMods.Clear();
			foreach (ListViewItem item in listViewMods.CheckedItems)
			{
				gameSettings.EnabledMods.Add((string)item.Tag);
			}
			// Save codes
			List<Code> selectedCodes = new List<Code>();
			List<Code> selectedCodePatches = new List<Code>();
			gameSettings.EnabledCodes.Clear();
			foreach (Code item in listViewCodes.CheckedIndices.OfType<int>().Select(a => codes[a]))
			{
				if (item.Patch)
					selectedCodePatches.Add(item);
				else
					selectedCodes.Add(item);
				gameSettings.EnabledCodes.Add(item.Name);
			}
			CodeList.WriteDatFile(patchdatpath, selectedCodePatches);
			CodeList.WriteDatFile(codedatpath, selectedCodes);
			// Save graphics settings - Display
			gameSettings.Graphics.SelectedScreen = comboBoxScreenNumber.SelectedIndex;
			gameSettings.Graphics.ScreenMode = comboBoxScreenMode.SelectedIndex;
			gameSettings.Graphics.EnableVsync = checkBoxVsync.Checked;
			gameSettings.Graphics.HorizontalResolution = (int)numericUpDownHorizontalResolution.Value;
			gameSettings.Graphics.VerticalResolution = (int)numericUpDownVerticalResolution.Value;
			gameSettings.Graphics.Enable43ResolutionRatio = checkBoxForceAspectRatio.Checked;
			gameSettings.Graphics.CustomWindowWidth = (int)numericUpDownWindowWidth.Value;
			gameSettings.Graphics.CustomWindowHeight = (int)numericUpDownWindowHeight.Value;
			gameSettings.Graphics.EnableKeepResolutionRatio = checkBoxWindowMaintainAspect.Checked;
			gameSettings.Graphics.EnableResizableWindow = checkBoxWindowResizable.Checked;
			// Save graphics settings - Visuals
			gameSettings.Graphics.RenderBackend = Math.Max(0, comboBoxBackend.SelectedIndex);
			d3d8to11ConfigIni.OIT.EnableOIT = checkBoxEnableOIT.Checked;
			sonicDxIni.GameConfig.FullScreen = ((DisplayMode)(comboBoxScreenMode.SelectedIndex) == DisplayMode.Fullscreen ||
				(DisplayMode)(comboBoxScreenMode.SelectedIndex) == DisplayMode.Borderless) ? 1 : 0;
			sonicDxIni.GameConfig.ClipLevel = comboBoxClipLevel.SelectedIndex;
			sonicDxIni.GameConfig.FogEmulation = comboBoxFogEmulation.SelectedIndex;
			sonicDxIni.GameConfig.FrameRate = comboBoxFramerate.SelectedIndex + 1;
			gameSettings.Graphics.EnableForcedMipmapping = checkBoxForceMipmapping.Checked;
			gameSettings.Graphics.EnableForcedTextureFilter = checkBoxForceTextureFilter.Checked;
			gameSettings.Graphics.DisableBorderImage = !checkBoxBorderImage.Checked;
			// Save graphics settings - AA and AF
			switch (comboBoxAnisotropic.SelectedIndex)
			{
				case 0:
					gameSettings.Graphics.Anisotropic = 0;
					break;
				case 1:
					gameSettings.Graphics.Anisotropic = 1;
					break;
				case 2:
					gameSettings.Graphics.Anisotropic = 2;
					break;
				case 3:
					gameSettings.Graphics.Anisotropic = 4;
					break;
				case 4:
					gameSettings.Graphics.Anisotropic = 8;
					break;
				case 5:
					gameSettings.Graphics.Anisotropic = 16;
					break;
			}
			switch (comboBoxAntialiasing.SelectedIndex)
			{
				case 0:
					gameSettings.Graphics.Antialiasing = 0;
					break;
				case 1:
					gameSettings.Graphics.Antialiasing = 2;
					break;
				case 2:
					gameSettings.Graphics.Antialiasing = 4;
					break;
				case 3:
					gameSettings.Graphics.Antialiasing = 8;
					break;
				case 4:
					gameSettings.Graphics.Antialiasing = 16;
					break;
			}
			// Save graphics settings - Other
			gameSettings.Graphics.FillModeBackground = comboBoxBackgroundFill.SelectedIndex;
			gameSettings.Graphics.FillModeFMV = comboBoxFmvFill.SelectedIndex;
			gameSettings.Graphics.EnableUIScaling = checkBoxScaleHud.Checked;
			gameSettings.Graphics.ShowMouseInFullscreen = checkBoxShowMouse.Checked;
			// Save input settings
			gameSettings.Controller.EnabledInputMod = radioButtonSDL.Checked;
			// Not implemented: Disable mouse
			sonicDxIni.GameConfig.MouseMode = radioButtonMouseHold.Checked ? 0 : 1;
			// Other mouse settings are applied immediately
			// Save DirectInput settings
			if (inputDevice != null)
			{
				sonicDxIni.GameConfig.PadConfig = comboBoxControllerProfile.SelectedIndex == -1 ? null : controllerConfig[comboBoxControllerProfile.SelectedIndex].Name;
				sonicDxIni.Controllers.Clear();
				foreach (ControllerConfigInternal item in controllerConfig)
				{
					ControllerConfig config = new ControllerConfig { ButtonCount = item.Buttons.Max() + 1 };
					config.ButtonSettings = Enumerable.Repeat(-1, config.ButtonCount).ToArray();
					for (int i = 0; i < buttonIDs.Length; i++)
					{
						if (item.Buttons[i] != -1)
						{
							config.ButtonSettings[item.Buttons[i]] = buttonIDs[i];
						}
					}
					sonicDxIni.Controllers.Add(item.Name, config);
				}
			}
			// Save sound settings
			sonicDxIni.GameConfig.SEVoice = checkBoxEnableSound.Checked ? 1 : 0;
			sonicDxIni.GameConfig.BGM = checkBoxEnableMusic.Checked ? 1 : 0;
			sonicDxIni.GameConfig.Sound3D = checkBoxEnable3DSound.Checked ? 1 : 0;
			gameSettings.Sound.EnableBassMusic = checkBoxUseBassMusic.Checked;
			gameSettings.Sound.EnableBassSFX = checkBoxUseBassSE.Checked;
			sonicDxIni.GameConfig.VoiceVolume = trackBarVoiceVol.Value;
			sonicDxIni.GameConfig.BGMVolume = trackBarMusicVol.Value;
			gameSettings.Sound.SEVolume = trackBarSEVol.Value;
			// Patches saved immediately
			// Save debug settings
			gameSettings.DebugSettings.EnableDebugConsole = checkBoxEnableDebugConsole.Checked;
			gameSettings.DebugSettings.EnableDebugScreen = checkBoxEnableDebugScreen.Checked;
			gameSettings.DebugSettings.EnableDebugFile = checkBoxEnableDebugFile.Checked;
			gameSettings.DebugSettings.EnableDebugCrashLog = checkBoxEnableDebugCrashHandler.Checked;
			// Save Test Spawn settings
			gameSettings.TestSpawn.UseLevel = checkBoxTestSpawnLevel.Checked;
			gameSettings.TestSpawn.LevelIndex = comboBoxTestSpawnLevel.SelectedIndex;
			gameSettings.TestSpawn.ActIndex = (int)numericUpDownTestSpawnAct.Value;
			gameSettings.TestSpawn.UseCharacter = checkBoxTestSpawnCharacter.Checked;
			gameSettings.TestSpawn.CharacterIndex = comboBoxTestSpawnCharacter.SelectedIndex;
			gameSettings.TestSpawn.UsePosition = checkBoxTestSpawnPosition.Checked;
			gameSettings.TestSpawn.XPosition = (float)numericUpDownTestSpawnX.Value;
			gameSettings.TestSpawn.YPosition = (float)numericUpDownTestSpawnY.Value;
			gameSettings.TestSpawn.ZPosition = (float)numericUpDownTestSpawnZ.Value;
			if (checkBoxTestSpawnAngleDeg.Checked)
				gameSettings.TestSpawn.Rotation = (int)numericUpDownTestSpawnAngle.Value;
			else
				gameSettings.TestSpawn.Rotation = (int)Math.Round((float)numericUpDownTestSpawnAngle.Value * (360.0f / 65535.0f));
			gameSettings.TestSpawn.UseEvent = checkBoxTestSpawnEvent.Checked;
			gameSettings.TestSpawn.EventIndex = GetTestspawnEventIndex(comboBoxTestSpawnEvent.SelectedIndex, true);
			gameSettings.TestSpawn.UseGameMode = checkBoxTestSpawnGameMode.Checked;
			gameSettings.TestSpawn.GameModeIndex = GetTestspawnGamemodeIndex(comboBoxTestSpawnGameMode.SelectedIndex, true);
			gameSettings.TestSpawn.UseSave = checkBoxTestSpawnSave.Checked;
			gameSettings.TestSpawn.SaveIndex = GetTestspawnSaveIndex(comboBoxTestSpawnSave.SelectedIndex, true);
			managerClassicConfig.AngleDeg = checkBoxTestSpawnAngleDeg.Checked;
			managerClassicConfig.AngleHex = checkBoxTestSpawnAngleHex.Checked;
			// Save Options settings
			// Save Update settings
			managerClassicConfig.UpdateCheck = checkBoxCheckLoaderUpdatesStartup.Checked;
			managerClassicConfig.ModUpdateCheck = checkBoxCheckUpdateModsStartup.Checked;
			managerClassicConfig.ManagerUpdateCheck = checkBoxCheckManagerUpdateStartup.Checked;
			managerClassicConfig.LauncherUpdateCheck = checkBoxCheckLauncherUpdateStartup.Checked;
			managerClassicConfig.UpdateFrequency = (int)numericUpDownUpdateFrequency.Value;
			managerClassicConfig.UpdateUnit = (UpdateUnit)comboBoxUpdateUnit.SelectedIndex;
			// Save Misc settings
			gameSettings.Graphics.EnablePauseOnInactive = checkBoxPauseWhenInactive.Checked;
			gameSettings.TestSpawn.GameVoiceLanguage = comboBoxVoiceLanguage.SelectedIndex;
			gameSettings.TestSpawn.GameTextLanguage = comboBoxTextLanguage.SelectedIndex;
			// Save Manager Settings
			managerClassicConfig.KeepManagerOpen = checkBoxKeepManagerOpen.Checked;
			managerClassicConfig.SingleProfileMode = checkBoxSingleProfile.Checked;
			// Save window settings
			managerClassicConfig.LastMonitorResolution = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			managerClassicConfig.Maximized = WindowState == FormWindowState.Maximized;
			if (WindowState != FormWindowState.Maximized)
			{
				managerClassicConfig.WindowPosition = Location;
				managerClassicConfig.WindowSize = Size;
			}
			// Serialize sonicDX.ini
			IniSerializer.Serialize(sonicDxIni, sonicDxIniPath);
			// Create the profiles folder if it doesn't exist
			if (!Directory.Exists(Path.Combine(managerAppDataPath, "profiles")))
				Directory.CreateDirectory(Path.Combine(managerAppDataPath, "profiles"));
			// Set current profile filename
			if (!saveProfile && checkBoxSingleProfile.Checked)
				currentProfileJsonPath = Path.Combine(managerAppDataPath, "profiles", "Default.json");
			else
				currentProfileJsonPath = Path.Combine(managerAppDataPath, "profiles", textBoxProfileName.Text + ".json");
			// Serialize profile
			JsonSerialize(gameSettings, currentProfileJsonPath);
			// Serialize Profiles.json
			JsonSerialize(profilesJson, profilesListJsonPath);
			// Serialize manager configuration
			JsonSerialize(managerClassicConfig, managerClassicConfigJsonPath);
			// Create the d3d8to11 config folder if it doesn't exist
			if (!Directory.Exists(Path.GetDirectoryName(d3d8to11ConfigPath)))
				Directory.CreateDirectory(Path.GetDirectoryName(d3d8to11ConfigPath));
			// Serialize d3d8to11 config
			IniSerializer.Serialize(d3d8to11ConfigIni, d3d8to11ConfigPath);
		}

		private Dictionary<string, string> GetModReference()
		{
			Dictionary<string, string> activeMods = new Dictionary<string, string>();

			foreach (string mod in mods.Keys)
			{
				SADXModInfo modinfo = mods[mod];
				string id = mod;
				if (modinfo.ModID != null)
					id = modinfo.ModID;
				if (!activeMods.ContainsKey(id))
					activeMods.Add(id, mod);
				else
				{
					MessageBox.Show(this,
						"Mods with duplicate ID '" + id + "' have been detected.\n" +
						"Mod name: '" + modinfo.Name + "'.\n" +
						"Remove duplicate mods or edit the value 'ModID' in mod.ini to fix this error.\n",
						"SADX Mod Manager Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}

			return activeMods;
		}

		private bool CheckDependencies(string lMod, Dictionary<string, string> cMods)
		{
			bool check = false;
			SADXModInfo mod = mods[lMod];

			if (mod.Dependencies.Count > 0)
			{
				int mID = gameSettings.EnabledMods.IndexOf(lMod);
				foreach (string sDependency in mod.Dependencies)
				{
					ModDependency dependency = new ModDependency(sDependency);
					if (dependency.ID == "" && dependency.Folder == "")
						return false;

					string depName = dependency.GetDependencyName();

					bool modExists = false;
					if (cMods.ContainsKey(dependency.ID))
						modExists = true;
					else if (cMods.ContainsValue(dependency.Folder))
						modExists = true;
					else if (cMods.ContainsValue(dependency.Name))
					{
						dependency.Folder = dependency.Name;
						modExists = true;
					}

					if (modExists)
					{
						// If Dependency Mod Exists, check if mod is active.
						if (gameSettings.EnabledMods.Contains(dependency.Folder))
						{
							int cID = gameSettings.EnabledMods.IndexOf(dependency.Folder);
							if (mID < cID)
							{
								MessageBox.Show(depName + " needs to be placed above " + mod.Name, "Mod Order", MessageBoxButtons.OKCancel);
								check = true;
							}
						}
						else
						{
							MessageBox.Show(depName + " is not enabled. Please enable this mod and place it above " + mod.Name, "Mod Dependency", MessageBoxButtons.OKCancel);
							check = true;
						}
					}
					else
					{
						string msg = "Dependency " + depName + " is not installed. Please install " + depName + " and place it above " + mod.Name;
						if (dependency.Link == "")
						{
							MessageBox.Show(msg, "Missing Mod", MessageBoxButtons.OKCancel);
							check = true;
						}
						else
						{
							DialogResult dg = MessageBox.Show(msg + "\n\nWould you like to download this mod now?", "Missing Mod", MessageBoxButtons.YesNo);
							if (dg == DialogResult.Yes)
							{
								Process.Start(dependency.Link);
							}
							check = true;
						}
					}
				}
			}
			return check;
		}

		private void saveAndPlayButton_Click(object sender, EventArgs e)
		{
			if (updateWorker?.IsBusy == true)
			{
				var result = MessageBox.Show(this, "Mods are still being checked for updates. Continue anyway?",
					"Busy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.No)
				{
					return;
				}

				Enabled = false;

				updateWorker.CancelAsync();
				while (updateWorker.IsBusy)
				{
					Application.DoEvents();
				}

				Enabled = true;
			}

			SaveSettings(!checkBoxSingleProfile.Checked);
			if (!installed)
				switch (MessageBox.Show(this, "Looks like you're starting the game without the mod loader installed. Without the mod loader, the mods and codes you've selected won't be used, and some settings may not work.\n\nDo you want to install the mod loader now?", "SADX Mod Manager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
				{
					case DialogResult.Cancel:
						return;
					case DialogResult.Yes:
						File.Move(datadllpath, datadllorigpath);
						File.Copy(loaderdllpath, datadllpath);
						break;
				}

			// Check Mod Dependencies
			Dictionary<string, string> cMods = GetModReference();
			foreach (string mod in gameSettings.EnabledMods)
			{
				if (CheckDependencies(mod, cMods))
					return;
			}

			Process process = Process.Start(gameSettings.EnabledMods.Select((item) => mods[item].EXEFile)
												.FirstOrDefault((item) => !string.IsNullOrEmpty(item)) ?? "sonic.exe");
			process?.WaitForInputIdle(10000);
			if (!checkBoxKeepManagerOpen.Checked)
				Close();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveSettings(!checkBoxSingleProfile.Checked);
			LoadModList();
		}

		private void installButton_Click(object sender, EventArgs e)
		{
			if (installed)
			{
				File.Delete(datadllpath);
				File.Move(datadllorigpath, datadllpath);
				buttonInstallLoader.Text = "Enable Loader";
			}
			else
			{
				File.Move(datadllpath, datadllorigpath);
				File.Copy(loaderdllpath, datadllpath);
				buttonInstallLoader.Text = "Disable Loader";
			}
			installed = !installed;
		}
		#endregion

		#region Mod update related
		private static bool UpdateTimeElapsed(UpdateUnit unit, int amount, DateTime start)
		{
			if (unit == UpdateUnit.Always)
			{
				return true;
			}

			TimeSpan span = DateTime.UtcNow - start;

			switch (unit)
			{
				case UpdateUnit.Hours:
					return span.TotalHours >= amount;

				case UpdateUnit.Days:
					return span.TotalDays >= amount;

				case UpdateUnit.Weeks:
					return span.TotalDays / 7.0 >= amount;

				default:
					throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
			}
		}

		private void ButtonSwitchToSAManager_Click(object sender, System.EventArgs e)
		{
			switch (MessageBox.Show(this, "This will download and run the latest version of the SA Mod Manager by Sora & ItsEasyActually. You can use both this and the new Manager with the same game. Continue?", "SADX Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case DialogResult.No:
				default:
					return;
				case DialogResult.Yes:
					// Open the dialog
					List<DownloadItem> items = new List<DownloadItem>();
					items.Add(AddDotnetRuntimeDownload(this));
					items.Add(AddSAManagerDownload(this));
					using (UpdatesAvailableDialog uDialog = new UpdatesAvailableDialog(items, Path.Combine(managerAppDataPath, "updates"), false))
					{
						DialogResult result = uDialog.ShowDialog();
						switch (result)
						{
							// Downloads finished
							case DialogResult.OK:
								if (File.Exists(Path.Combine(Variables.gameMainPath, "SAModManager.exe")))
									Process.Start(Path.Combine(Variables.gameMainPath, "SAModManager.exe"));
								else
									return;
								Close();
								return;
							// No items to download
							case DialogResult.None:
								MessageBox.Show(this, "No items to download. Try again later.", "SADX Mod Manager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							// Downloads cancelled or critical error
							case DialogResult.Abort:
								return;
						}
					}
					break;
			}
		}

		private void UriQueueOnUriEnqueued(object sender, OnUriEnqueuedArgs args)
		{
			args.Handled = true;

			if (InvokeRequired)
			{
				Invoke((Action<object, OnUriEnqueuedArgs>)UriQueueOnUriEnqueued, sender, args);
				return;
			}

			if (args.Uri != null && !string.IsNullOrEmpty(args.Uri))
			{
				UpdateChecker.ItemsToCheck |= UpdateChecker.UpdateItems.OneClick;
				UpdateChecker.OneClickLinks.Add(args.Uri);
				AutoUpdate();
			}

		}

		private void UpdateChecker_EnableControls()
		{
			buttonCheckForUpdatesNow.Enabled = true;
			buttonCheckModUpdates.Enabled = true;
			checkForUpdatesToolStripMenuItem.Enabled = true;
			verifyToolStripMenuItem.Enabled = true;
			forceUpdateToolStripMenuItem.Enabled = true;
			uninstallToolStripMenuItem.Enabled = true;
			generateManifestToolStripMenuItem.Enabled = true;
		}

		private void UpdateChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (modUpdater.ForceUpdate)
			{
				toolStripStatusLabel.Text = "Update check completed.";
				updateWorker?.Dispose();
				updateWorker = null;
				modUpdater.ForceUpdate = false;
				modUpdater.Clear();
			}

			if (e.Cancelled)
			{
				toolStripStatusLabel.Text = "Update check cancelled.";
				UpdateChecker_EnableControls();
				return;
			}

			if (!(e.Result is Tuple<List<DownloadItem>, List<string>> data))
			{
				toolStripStatusLabel.Text = "Mod update format doesn't match.";
				UpdateChecker_EnableControls();
				return;
			}

			List<string> errors = data.Item2;
			if (errors.Count != 0)
			{
				MessageBox.Show(this, "The following errors occurred while checking for updates:\n\n" + string.Join("\n", errors),
					"Update Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				toolStripStatusLabel.Text = "Update check completed with errors.";
			}

			List<DownloadItem> items = data.Item1;

			if (items.Count == 0)
			{
				toolStripStatusLabel.Text = "No updates found.";
				UpdateChecker_EnableControls();
				return;
			}

			DialogResult result;

			do
			{
				try
				{
					result = DialogResult.Cancel;
					if (!Directory.Exists(updatesTempPath))
					{
						Directory.CreateDirectory(updatesTempPath);
					}
				}
				catch (Exception ex)
				{
					result = MessageBox.Show(this, "Failed to create temporary update directory:\n" + ex.Message
						+ "\n\nWould you like to retry?", "Directory Creation Failed", MessageBoxButtons.RetryCancel);
				}
			} while (result == DialogResult.Retry);

			if (updatesAvailableWindow != null)
			{
				MessageBox.Show(this, "The update check has been interrupted with another one. The dialog will be recreated to include new items.", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
				updatesAvailableWindow.Close();
				updatesAvailableWindow.Dispose();
				updatesAvailableWindow = null;
			}
			updatesAvailableWindow = new UpdatesAvailableDialog(items, updatesTempPath);

			DialogResult res = updatesAvailableWindow.ShowDialog(this);
			if (res == DialogResult.OK)
				toolStripStatusLabel.Text = "Mods updated successfully.";
			else
				toolStripStatusLabel.Text = "Mod update cancelled.";

			// Delete temporary folder
			do
			{
				try
				{
					result = DialogResult.Cancel;
					if (Directory.Exists(updatesTempPath))
						Directory.Delete(updatesTempPath, true);
				}
				catch (Exception ex)
				{
					result = MessageBox.Show(this, "Failed to remove temporary update directory:\n" + ex.Message
						+ "\n\nWould you like to retry? You can remove the directory manually later.",
						"Directory Deletion Failed", MessageBoxButtons.RetryCancel);
				}
			} while (result == DialogResult.Retry);

			UpdateChecker_EnableControls();
			LoadModList();
		}

		private void UpdateChecker_DoWork(object sender, DoWorkEventArgs e)
		{
			if (!(sender is BackgroundWorker worker))
			{
				throw new Exception("what");
			}

			Invoke(new Action(() =>
			{
				buttonCheckForUpdatesNow.Enabled = false;
				buttonCheckModUpdates.Enabled = false;
				checkForUpdatesToolStripMenuItem.Enabled = false;
				verifyToolStripMenuItem.Enabled = false;
				forceUpdateToolStripMenuItem.Enabled = false;
				uninstallToolStripMenuItem.Enabled = false;
				generateManifestToolStripMenuItem.Enabled = false;
			}));

			List<DownloadItem> items = new List<DownloadItem>();
			List<string> errors = new List<string>();

			// Mods (1-click)
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.OneClick))
			{
				foreach (string str in UpdateChecker.OneClickLinks)
				{
					DownloadItem item = HandleUri(str, this);
					if (item != null)
						items.Add(item);
				}
			}

			// Mods
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.Mods))
			{
				var updatableMods = e.Argument as List<KeyValuePair<string, ModInfo>>;

				if (updatableMods.Count > 0)
				{

					List<ModDownload> updates = null;

					var tokenSource = new CancellationTokenSource();
					CancellationToken token = tokenSource.Token;

					using (var task = new Task(() => modUpdater.GetModUpdates(updatableMods, out updates, out errors, token), token))
					{
						task.Start();

						while (!task.IsCompleted && !task.IsCanceled)
						{
							Application.DoEvents();

							if (worker.CancellationPending)
							{
								tokenSource.Cancel();
							}
						}

						task.Wait(token);
					}
					// Mod updates
					if (updates != null && updates.Count > 0)
						foreach (var upd in updates)
							items.Add(new DownloadItem(upd));
				}
			}
			// Loader update
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.Loader))
			{
				DownloadItem loaderItem = CheckLoaderUpdates(this);
				if (loaderItem != null)
					items.Add(loaderItem);
			}
			// Launcher update
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.Launcher))
			{
				DownloadItem launcherItem = CheckLauncherUpdates(this);
				if (launcherItem != null)
					items.Add(launcherItem);
			}
			// Manager update
			if (UpdateChecker.ItemsToCheck.HasFlag(UpdateChecker.UpdateItems.Manager))
			{
				DownloadItem managerItem = CheckManagerUpdates(this);
				if (managerItem != null)
					items.Add(managerItem);
			}
			e.Result = new Tuple<List<DownloadItem>, List<string>>(items, errors);
		}

		private void UpdateChecker_DoWorkForced(object sender, DoWorkEventArgs e)
		{
			if (!(sender is BackgroundWorker worker))
			{
				throw new Exception("what");
			}

			if (!(e.Argument is List<Tuple<string, ModInfo, List<ModManifestDiff>>> updatableMods) || updatableMods.Count == 0)
			{
				return;
			}

			var updates = new List<ModDownload>();
			List<DownloadItem> items = new List<DownloadItem>();
			var errors = new List<string>();

			foreach (Tuple<string, ModInfo, List<ModManifestDiff>> info in updatableMods)
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}

				ModInfo mod = info.Item2;
				if (!string.IsNullOrEmpty(mod.GitHubRepo))
				{
					if (string.IsNullOrEmpty(mod.GitHubAsset))
					{
						errors.Add($"[{mod.Name}] GitHubRepo specified, but GitHubAsset is missing.");
						continue;
					}

					ModDownload d = modUpdater.GetGitHubReleases(mod, info.Item1, webClient, errors);
					if (d != null)
					{
						updates.Add(d);
					}
				}
				else if (!string.IsNullOrEmpty(mod.GameBananaItemType) && mod.GameBananaItemId.HasValue)
				{
					ModDownload d = modUpdater.GetGameBananaReleases(mod, info.Item1, errors);
					if (d != null)
					{
						updates.Add(d);
					}
				}
				else if (!string.IsNullOrEmpty(mod.UpdateUrl))
				{
					List<ModManifestEntry> localManifest = info.Item3
						.Where(x => x.State == ModManifestState.Unchanged)
						.Select(x => x.Current).ToList();

					ModDownload d = modUpdater.CheckModularVersion(mod, info.Item1, localManifest, webClient, errors);
					if (d != null)
					{
						updates.Add(d);
					}
				}
			}

			// Mod updates
			if (updates != null && updates.Count > 0)
				foreach (var upd in updates)
					items.Add(new DownloadItem(upd));
			
			if (items.Count == 0)
				items = null;

			e.Result = new Tuple<List<DownloadItem>, List<string>>(items, errors);
		}

		private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(this, "This will uninstall all selected mods."
				+ "\n\nAre you sure you wish to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result != DialogResult.Yes)
			{
				return;
			}

			result = MessageBox.Show(this, "Would you like to keep mod user data where possible? (Save files, config files, etc)",
				"User Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

			if (result == DialogResult.Cancel)
			{
				return;
			}

			foreach (ListViewItem item in listViewMods.SelectedItems)
			{
				var dir = (string)item.Tag;
				var modDir = Path.Combine("mods", dir);
				var manpath = Path.Combine(modDir, "mod.manifest");

				try
				{
					if (result == DialogResult.Yes && File.Exists(manpath))
					{
						List<ModManifestEntry> manifest = ModManifest.FromFile(manpath);
						foreach (var entry in manifest)
						{
							var path = Path.Combine(modDir, entry.FilePath);
							if (File.Exists(path))
							{
								File.Delete(path);
							}
						}

						File.Delete(manpath);
						var version = Path.Combine(modDir, "mod.version");
						if (File.Exists(version))
						{
							File.Delete(version);
						}
					}
					else
					{
						if (result == DialogResult.Yes)
						{
							var retain = MessageBox.Show(this, $"The mod \"{mods[dir].Name}\" (\"mods\\{dir}\") does not have a manifest, so mod user data cannot be retained."
								+ " Do you want to uninstall it anyway?", "Cannot Retain User Data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

							if (retain == DialogResult.No)
							{
								continue;
							}
						}

						Directory.Delete(modDir, true);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, $"Failed to uninstall mod \"{mods[dir].Name}\" from \"{dir}\": {ex.Message}", "Failed",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			LoadModList();
		}

		private void generateManifestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!displayedManifestWarning)
			{
				DialogResult result = MessageBox.Show(this, generateManifestWarning,
					"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result != DialogResult.Yes)
				{
					return;
				}

				displayedManifestWarning = true;
			}

			foreach (ListViewItem item in listViewMods.SelectedItems)
			{
				var modPath = Path.Combine("mods", (string)item.Tag);
				var manifestPath = Path.Combine(modPath, "mod.manifest");

				List<ModManifestEntry> manifest;
				List<ModManifestDiff> diff;

				using (var progress = new ManifestDialog(modPath, $"Generating manifest: {(string)item.Tag}", true))
				{
					progress.SetTask("Generating file index...");
					if (progress.ShowDialog(this) == DialogResult.Cancel)
					{
						continue;
					}

					diff = progress.Diff;
				}

				if (diff == null)
				{
					continue;
				}

				if (diff.Count(x => x.State != ModManifestState.Unchanged) <= 0)
				{
					continue;
				}

				using (var dialog = new ManifestDiffDialog(diff))
				{
					if (dialog.ShowDialog(this) == DialogResult.Cancel)
					{
						continue;
					}

					manifest = dialog.MakeNewManifest();
				}

				ModManifest.ToFile(manifest, manifestPath);
			}
		}

		private void UpdateSelectedMods()
		{
			InitializeWorker();
			UpdateChecker.CheckMode = UpdateChecker.UpdateMode.User;
			UpdateChecker.ItemsToCheck = UpdateChecker.UpdateItems.Mods;

			List<KeyValuePair<string, ModInfo>> selected = listViewMods.SelectedItems.Cast<ListViewItem>()
				.Select(x => (string)x.Tag)
				.Select(x => new KeyValuePair<string, ModInfo>(x, mods[x]))
				.ToList();
			List<KeyValuePair<string, ModInfo>> infoNew = new List<KeyValuePair<string, ModInfo>>();
			foreach (KeyValuePair<string, ModInfo> mod in selected)
			{
				if (!managerClassicConfig.IgnoredModUpdates.Contains(mod.Key))
					infoNew.Add(mod);
			}
			updateWorker?.RunWorkerAsync(infoNew);
		}

		private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateSelectedMods();
		}

		private void forceUpdateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show(this, "This will force all selected mods to be completely re-downloaded."
				+ " Are you sure you want to continue?",
				"Force Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (result != DialogResult.Yes)
			{
				return;
			}

			modUpdater.ForceUpdate = true;
			UpdateSelectedMods();
		}

		private void verifyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<Tuple<string, ModInfo>> items = listViewMods.SelectedItems.Cast<ListViewItem>()
				.Select(x => (string)x.Tag)
				.Where(x => File.Exists(Path.Combine("mods", x, "mod.manifest")))
				.Select(x => new Tuple<string, ModInfo>(x, mods[x]))
				.ToList();

			if (items.Count < 1)
			{
				MessageBox.Show(this, "None of the selected mods have manifests, so they cannot be verified.",
					"Missing mod.manifest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (var progress = new VerifyModDialog(items))
			{
				var result = progress.ShowDialog(this);
				if (result == DialogResult.Cancel)
				{
					return;
				}

				List<Tuple<string, ModInfo, List<ModManifestDiff>>> failed = progress.Failed;
				if (failed.Count < 1)
				{
					MessageBox.Show(this, "All selected mods passed verification.", "Integrity Pass",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					result = MessageBox.Show(this, "The following mods failed verification:\n"
						+ string.Join("\n", failed.Select(x => $"{x.Item2.Name}: {x.Item3.Count(y => y.State != ModManifestState.Unchanged)} file(s)"))
						+ "\n\nWould you like to attempt repairs?",
						"Integrity Fail", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (result != DialogResult.Yes)
					{
						return;
					}

					InitializeWorker();

					updateWorker.DoWork -= UpdateChecker_DoWork;
					updateWorker.DoWork += UpdateChecker_DoWorkForced;

					UpdateChecker.CheckMode = UpdateChecker.UpdateMode.User;
					UpdateChecker.ItemsToCheck = UpdateChecker.UpdateItems.Mods;

					updateWorker.RunWorkerAsync(failed);

					modUpdater.ForceUpdate = true;
					buttonCheckForUpdatesNow.Enabled = false;
					buttonCheckModUpdates.Enabled = false;
				}
			}
		}

		private void comboUpdateFrequency_SelectedIndexChanged(object sender, EventArgs e)
		{
			numericUpDownUpdateFrequency.Enabled = comboBoxUpdateUnit.SelectedIndex > 0;
		}

		private void buttonCheckForUpdates_Click(object sender, EventArgs e)
		{
			buttonCheckForUpdatesNow.Enabled = false;
			buttonCheckModUpdates.Enabled = false;
			InitializeWorker();
			UpdateChecker.CheckMode = UpdateChecker.UpdateMode.User;
			UpdateChecker.ItemsToCheck = (UpdateChecker.UpdateItems.Mods | UpdateChecker.UpdateItems.Loader | UpdateChecker.UpdateItems.Manager | UpdateChecker.UpdateItems.Launcher);
			AutoUpdate();
		}

		private void installURLHandlerButton_Click(object sender, EventArgs e)
		{
			Process.Start(new ProcessStartInfo(Application.ExecutablePath, "urlhandler") { UseShellExecute = true, Verb = "runas" }).WaitForExit();
			MessageBox.Show(this, "1-Click installed!", Text);
		}
		#endregion

		#region Game settings

		private void screenNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Size oldsize = resolutionPresets[6];
			Rectangle rect = Screen.PrimaryScreen.Bounds;
			if (comboBoxScreenNumber.SelectedIndex > 0)
				rect = Screen.AllScreens[comboBoxScreenNumber.SelectedIndex - 1].Bounds;
			else
				foreach (Screen screen in Screen.AllScreens)
					rect = Rectangle.Union(rect, screen.Bounds);
			resolutionPresets[6] = rect.Size;
			resolutionPresets[7] = new Size(rect.Width / 2, rect.Height / 2);
			resolutionPresets[8] = new Size(rect.Width * 2, rect.Height * 2);
			if (comboBoxResolutionPreset.SelectedIndex > 4 && comboBoxResolutionPreset.SelectedIndex < 8 && rect.Size != oldsize)
				comboBoxResolutionPreset.SelectedIndex = -1;
		}

		private void forceAspectRatioCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxForceAspectRatio.Checked)
			{
				numericUpDownHorizontalResolution.Enabled = false;
				numericUpDownHorizontalResolution.Value = Math.Round(numericUpDownVerticalResolution.Value * ratio);
				comboBoxResolutionPreset.SelectedIndex = -1;
			}
			else if (!suppressEvent)
				numericUpDownHorizontalResolution.Enabled = true;
		}

		private void horizontalResolution_ValueChanged(object sender, EventArgs e)
		{
			if (!suppressEvent)
				comboBoxResolutionPreset.SelectedIndex = -1;
		}

		private void verticalResolution_ValueChanged(object sender, EventArgs e)
		{
			if (checkBoxForceAspectRatio.Checked)
				numericUpDownHorizontalResolution.Value = Math.Round(numericUpDownVerticalResolution.Value * ratio);
			if (!suppressEvent)
				comboBoxResolutionPreset.SelectedIndex = -1;
		}

		private void comboResolutionPreset_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxResolutionPreset.SelectedIndex == -1) return;
			suppressEvent = true;
			numericUpDownVerticalResolution.Value = resolutionPresets[comboBoxResolutionPreset.SelectedIndex].Height;
			if (!checkBoxForceAspectRatio.Checked)
				numericUpDownHorizontalResolution.Value = resolutionPresets[comboBoxResolutionPreset.SelectedIndex].Width;
			suppressEvent = false;
		}

		private void maintainWindowAspectRatioCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxWindowMaintainAspect.Checked)
			{
				numericUpDownWindowWidth.Enabled = false;
				numericUpDownWindowWidth.Value = Math.Round(numericUpDownWindowHeight.Value * (numericUpDownHorizontalResolution.Value / numericUpDownVerticalResolution.Value));
			}
			else if (!suppressEvent)
				numericUpDownWindowWidth.Enabled = true;
		}

		private void windowHeight_ValueChanged(object sender, EventArgs e)
		{
			if (checkBoxWindowMaintainAspect.Checked)
				numericUpDownWindowWidth.Value = Math.Round(numericUpDownWindowHeight.Value * (numericUpDownHorizontalResolution.Value / numericUpDownVerticalResolution.Value));
		}

		private void trackBarVoiceVol_ValueChanged(object sender, EventArgs e)
		{
			labelVoiceVol.Text = trackBarVoiceVol.Value.ToString();
		}

		private void trackBarMusicVol_ValueChanged(object sender, EventArgs e)
		{
			labelMusicVol.Text = trackBarMusicVol.Value.ToString();
		}

		private void trackBarSEVol_ValueChanged(object sender, EventArgs e)
		{
			labelSEVol.Text = trackBarSEVol.Value.ToString();
		}

		private void checkBassSE_CheckedChanged(object sender, EventArgs e)
		{
			labelSEVol.Enabled = trackBarSEVol.Enabled = labelSEVolume.Enabled = checkBoxUseBassSE.Checked;
		}

		#endregion

		#region TestSpawn
		private void checkBoxTestSpawnPosition_CheckedChanged(object sender, EventArgs e)
		{
			labelTestSpawnX.Enabled = labelTestSpawnY.Enabled = labelTestSpawnZ.Enabled = labelTestSpawnAngle.Enabled =
				numericUpDownTestSpawnX.Enabled = numericUpDownTestSpawnY.Enabled = numericUpDownTestSpawnZ.Enabled =
				numericUpDownTestSpawnAngle.Enabled = checkBoxTestSpawnAngleHex.Enabled = checkBoxTestSpawnPosition.Checked;
		}

		private void checkBoxTestSpawnLevel_CheckedChanged(object sender, EventArgs e)
		{
			comboBoxTestSpawnLevel.Enabled = checkBoxTestSpawnPosition.Enabled = numericUpDownTestSpawnAct.Enabled = labelTestSpawnAct.Enabled = checkBoxTestSpawnLevel.Checked;
			if (comboBoxTestSpawnLevel.SelectedIndex == -1)
				comboBoxTestSpawnLevel.SelectedIndex = 0;
			if (!checkBoxTestSpawnPosition.Enabled)
				checkBoxTestSpawnPosition.Checked = false;
			ShowOrHideTestSpawnEventWarning();
		}

		private void checkBoxTestSpawnCharacter_CheckedChanged(object sender, EventArgs e)
		{
			comboBoxTestSpawnCharacter.Enabled = checkBoxTestSpawnCharacter.Checked;
			if (comboBoxTestSpawnCharacter.SelectedIndex == -1)
				comboBoxTestSpawnCharacter.SelectedIndex = 0;
			ShowOrHideTestSpawnEventWarning();
		}

		private void checkBoxTestSpawnEvent_CheckedChanged(object sender, EventArgs e)
		{
			comboBoxTestSpawnEvent.Enabled = checkBoxTestSpawnEvent.Checked;
			if (comboBoxTestSpawnEvent.SelectedIndex == -1)
				comboBoxTestSpawnEvent.SelectedIndex = 0;
			ShowOrHideTestSpawnEventWarning();
		}
		private void checkBoxTestSpawnGameMode_CheckedChanged(object sender, EventArgs e)
		{
			comboBoxTestSpawnGameMode.Enabled = checkBoxTestSpawnGameMode.Checked;

			if (comboBoxTestSpawnGameMode.SelectedIndex == -1)
				comboBoxTestSpawnGameMode.SelectedIndex = 0;

		}

		private void checkBoxTestSpawnSave_CheckStateChanged(object sender, EventArgs e)
		{
			comboBoxTestSpawnSave.Enabled = checkBoxTestSpawnSave.Checked;
		}

		private int GetTestSpawnRotation()
		{
			int result;
			if (checkBoxTestSpawnAngleDeg.Checked)
				result = (int)Math.Round((float)numericUpDownTestSpawnAngle.Value / (360.0f / 65535.0f));
			else
				result = (int)numericUpDownTestSpawnAngle.Value;
			return (-1 * result + 0x4000);
		}

		private string GetTestSpawnCommandLine()
		{
			List<string> cmdline = new List<string>();
			if (checkBoxTestSpawnLevel.Checked)
				cmdline.Add("-l " + comboBoxTestSpawnLevel.SelectedIndex.ToString() + " -a " + numericUpDownTestSpawnAct.Value.ToString());
			if (checkBoxTestSpawnCharacter.Checked)
				cmdline.Add("-c " + comboBoxTestSpawnCharacter.SelectedIndex.ToString());
			if (checkBoxTestSpawnPosition.Checked)
				cmdline.Add("-p " + numericUpDownTestSpawnX.Value.ToString() + " " +
					numericUpDownTestSpawnY.Value.ToString() + " " +
					numericUpDownTestSpawnZ.Value.ToString() + " -r " +
					GetTestSpawnRotation().ToString());
			if (checkBoxTestSpawnEvent.Checked)
			{
				int ev = 0;
				int ev_result = 0;
				foreach (var item in TestSpawnCutsceneList)
				{
					if (ev == comboBoxTestSpawnEvent.SelectedIndex)
					{
						ev_result = item.Key;
						break;
					}
					ev++;
				}
				cmdline.Add("-e " + ev_result.ToString());
			}
			if (comboBoxTestSpawnTime.SelectedIndex > 0)
				cmdline.Add("-t " + (comboBoxTestSpawnTime.SelectedIndex - 1).ToString());

			if (checkBoxTestSpawnGameMode.Checked)
			{
				uint gm = 0;
				int gm_result = 0;
				foreach (var item in TestSpawnGameModeList)
				{
					if (gm == comboBoxTestSpawnGameMode.SelectedIndex)
					{
						gm_result = item.Key;
						break;
					}
					gm++;
				}
				cmdline.Add("-g " + gm_result.ToString());
			}
			if (checkBoxTestSpawnSave.Checked)
				cmdline.Add("-s " + comboBoxTestSpawnSave.Text);
			return string.Join(" ", cmdline);
		}

		private void buttonTestSpawnPlay_Click(object sender, EventArgs e)
		{
			//toolStripStatusLabel.Text = "sonic.exe " + GetTestSpawnCommandLine(); 
			Process process = Process.Start(gameSettings.EnabledMods.Select((item) => mods[item].EXEFile)
												.FirstOrDefault((item) => !string.IsNullOrEmpty(item)) ?? "sonic.exe", GetTestSpawnCommandLine());
		}

		public int GetTestspawnGamemodeIndex(int index, bool fromcombo)
		{
			foreach (var mode in TestSpawnGameModeList)
			{
				if (fromcombo && mode.Value == comboBoxTestSpawnGameMode.Text)
					return mode.Key;
				if (!fromcombo && mode.Key == index)
					return comboBoxTestSpawnGameMode.FindString(mode.Value);
			}
			return -1;
		}

		public int GetTestspawnEventIndex(int index, bool fromcombo)
		{
			foreach (var scene in TestSpawnCutsceneList)
			{
				if (fromcombo && scene.Value == comboBoxTestSpawnEvent.Text)
					return scene.Key;
				if (!fromcombo && scene.Key == index)
					return comboBoxTestSpawnEvent.FindString("EV" + scene.Key.ToString("X4"));
			}
			return -1;
		}

		public int GetTestspawnSaveIndex(int index, bool fromcombo)
		{
			foreach (var save in saveList)
			{
				if (fromcombo && save.Value == comboBoxTestSpawnSave.Text)
				{
					return save.Key;
				}
				if (!fromcombo && save.Key == index)
				{
					return comboBoxTestSpawnSave.FindString(save.Value);
				}
			}
			return -1;
		}

		private void InitTestSpawnCutsceneList()
		{
			comboBoxTestSpawnEvent.Items.Clear();
			foreach (var item in TestSpawnCutsceneList)
			{
				comboBoxTestSpawnEvent.Items.Add("EV" + item.Key.ToString("X4") + ": " + item.Value);
			}
		}

		private void InitTestSpawnGameModeList()
		{
			comboBoxTestSpawnGameMode.Items.Clear();
			foreach (var item in TestSpawnGameModeList)
			{
				comboBoxTestSpawnGameMode.Items.Add(item.Value);
			}
		}

		private void checkBoxTestSpawnAngleHex_CheckedChanged(object sender, EventArgs e)
		{
			numericUpDownTestSpawnAngle.Hexadecimal = checkBoxTestSpawnAngleHex.Checked;
		}

		private void ShowOrHideTestSpawnEventWarning()
		{
			if (!checkBoxTestSpawnEvent.Checked)
				labelTestSpawnWarning.Visible = false;
			else
				labelTestSpawnWarning.Visible = checkBoxTestSpawnCharacter.Checked || checkBoxTestSpawnLevel.Checked;
		}
		#endregion

		#region Backends

		private void comboBoxBackend_SelectedIndexChanged(object sender, EventArgs e)
		{
			checkBoxEnableOIT.Enabled = comboBoxBackend.SelectedIndex == 2;
		}

		#endregion

		#region Mod profiles
		private void profileNameBox_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxProfileName.Text) || textBoxProfileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
			{
				buttonSaveProfile.Enabled = false;
				buttonLoadProfile.Enabled = false;
			}
			else
			{
				buttonSaveProfile.Enabled = true;
				buttonLoadProfile.Enabled = File.Exists(Path.Combine(managerAppDataPath, "profiles", textBoxProfileName.Text + ".json"));
			}
		}

		private void buttonLoadProfile_Click(object sender, EventArgs e)
		{
			LoadCurrentProfile(true);
			LoadSettings();
		}

		private void buttonSaveProfile_Click(object sender, EventArgs e)
		{
			using (SaveProfileDialog prd = new SaveProfileDialog())
			{
				if (prd.ShowDialog() == DialogResult.OK)
				{
					// Check if the specified name already exists
					bool exists = false;
					foreach (ProfileData data in Variables.profilesJson.ProfilesList)
						if (data.Name == prd.ProfileName)
							exists = true;
					if (!exists)
					{
						profilesJson.ProfilesList.Add(new ProfileData { Name = prd.ProfileName, Filename = prd.ProfileName + ".json" });
						textBoxProfileName.Items.Add(prd.ProfileName);
						textBoxProfileName.SelectedIndex = textBoxProfileName.Items.Count - 1;
					}
					SaveSettings(true);
					buttonLoadProfile.Enabled = true;
				}
			}
		}
		#endregion

		#region Input settings
		private void comboMouseButtons_SelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			 * Here, we take the newly selected Button,
			 * and assign it to the selected Action.
			*/
			ushort selected = (ushort)comboBoxMouseButtonAssignment.SelectedIndex;

			switch (comboBoxMouseAction.SelectedIndex)
			{
				case 0:
					sonicDxIni.GameConfig.MouseStart = IntToMouse(selected);
					break;
				case 1:
					sonicDxIni.GameConfig.MouseAttack = IntToMouse(selected);
					break;
				case 2:
					sonicDxIni.GameConfig.MouseJump = IntToMouse(selected);
					break;
				case 3:
					sonicDxIni.GameConfig.MouseAction = IntToMouse(selected);
					break;
				case 4:
					sonicDxIni.GameConfig.MouseFlute = IntToMouse(selected);
					break;
			}
		}

		private static ushort MouseToInt(ushort n)
		{
			switch (n)
			{
				case 258:
					return 5;
				case 513:
					return 6;
				default:
					return n;
			}
		}

		private static ushort IntToMouse(ushort n)
		{
			switch (n)
			{
				case 5:
					return 258;
				case 6:
					return 513;
				default:
					return n;
			}
		}

		private void comboMouseActions_SelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			 * Here, we take the selected Action index, get the Button
			 * assignment, and select it in comboMouseButtons.
			*/
			ushort selected;

			switch (comboBoxMouseAction.SelectedIndex)
			{
				case 0:
					selected = sonicDxIni.GameConfig.MouseStart;
					break;
				case 1:
					selected = sonicDxIni.GameConfig.MouseAttack;
					break;
				case 2:
					selected = sonicDxIni.GameConfig.MouseJump;
					break;
				case 3:
					selected = sonicDxIni.GameConfig.MouseAction;
					break;
				case 4:
					selected = sonicDxIni.GameConfig.MouseFlute;
					break;

				default:
					selected = 0;
					break;
			}

			comboBoxMouseButtonAssignment.SelectedIndex = MouseToInt(selected);
		}

		void buttonControl_SetButtonClicked(object sender, EventArgs e)
		{
			Enabled = false;
			currentAction = buttonControls.IndexOf((ButtonControl)sender);
			controllerThread = new System.Threading.Thread(GetControllerInput);
			controllerThread.Start();
			((ButtonControl)sender).Text = "Waiting...";
		}

		private void GetControllerInput()
		{
			System.Threading.AutoResetEvent inputevent = new System.Threading.AutoResetEvent(false);
			inputDevice.SetNotification(inputevent);
			inputDevice.Acquire();
			int pressed = -1;
			while (pressed == -1)
			{
				if (!inputevent.WaitOne(20000))
					break;
				bool[] buttons = inputDevice.GetCurrentState().Buttons;
				for (int i = 0; i < buttons.Length; i++)
				{
					if (buttons[i])
					{
						pressed = i;
						break;
					}
				}
			}
			inputDevice.Unacquire();
			inputDevice.SetNotification(null);
			Invoke(new Action<int>(ButtonPressed), pressed);
		}

		void ButtonPressed(int button)
		{
			ControllerConfigInternal config = controllerConfig[comboBoxControllerProfile.SelectedIndex];
			if (button != -1)
			{
				if (Array.IndexOf(config.Buttons, button) != -1)
				{
					int i = Array.IndexOf(config.Buttons, button);
					buttonControls[i].Text = "Unassigned";
					config.Buttons[i] = -1;
				}
				buttonControls[currentAction].Text = "Button " + (button + 1);
				config.Buttons[currentAction] = button;
			}
			else
			{
				buttonControls[currentAction].Text = config.Buttons[currentAction] == -1
					? "Unassigned"
					: "Button " + (config.Buttons[currentAction] + 1);
			}
			Enabled = true;
		}

		void buttonControl_ClearButtonClicked(object sender, EventArgs e)
		{
			int i = buttonControls.IndexOf((ButtonControl)sender);
			buttonControls[i].Text = "Unassigned";
			controllerConfig[comboBoxControllerProfile.SelectedIndex].Buttons[i] = -1;
		}


		private void comboBoxControllerProfile_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxControllerProfile.SelectedIndex == -1)
			{
				buttonControllerProfileRemove.Enabled = comboBoxControllerName.Enabled = false;
				foreach (ButtonControl control in buttonControls)
					control.Enabled = false;
			}
			else
			{
				buttonControllerProfileRemove.Enabled = comboBoxControllerName.Enabled = true;
				ControllerConfigInternal config = controllerConfig[comboBoxControllerProfile.SelectedIndex];
				comboBoxControllerName.Text = config.Name;
				for (int i = 0; i < buttonControls.Count; i++)
				{
					buttonControls[i].Enabled = true;
					buttonControls[i].Text = config.Buttons[i] == -1 ? "Unassigned" : "Button " + (config.Buttons[i] + 1).ToString("D2");
				}
			}
		}

		private void comboBoxControllerName_TextChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < controllerConfig.Count; i++)
			{
				if (i != comboBoxControllerProfile.SelectedIndex && controllerConfig[i].Name == comboBoxControllerName.Text)
				{
					comboBoxControllerName.BackColor = Color.Red;
					return;
				}
			}

			comboBoxControllerName.BackColor = SystemColors.Window;
			controllerConfig[comboBoxControllerProfile.SelectedIndex].Name = comboBoxControllerName.Text;
			comboBoxControllerProfile.Items[comboBoxControllerProfile.SelectedIndex] = comboBoxControllerName.Text;
		}

		private void buttonControllerProfileAdd_Click(object sender, EventArgs e)
		{
			controllerConfig.Add(new ControllerConfigInternal
			{
				Name = "*NEW*",
				Buttons = Enumerable.Repeat(-1, buttonIDs.Length).ToArray()
			});
			comboBoxControllerProfile.Items.Add("*NEW*");
			comboBoxControllerProfile.SelectedIndex = comboBoxControllerProfile.Items.Count - 1;
		}

		private void buttonControllerProfileRemove_Click(object sender, EventArgs e)
		{
			controllerConfig.RemoveAt(comboBoxControllerProfile.SelectedIndex);
			comboBoxControllerProfile.Items.RemoveAt(comboBoxControllerProfile.SelectedIndex);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Reset DirectInput
			directInput?.Dispose();
			directInput = null;
			inputDevice?.Dispose();
			inputDevice = null;
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape && controllerThread != null && controllerThread.IsAlive)
			{
				controllerThread.Abort();
				inputDevice.Unacquire();
				inputDevice.SetNotification(null);
				ControllerConfigInternal config = controllerConfig[comboBoxControllerProfile.SelectedIndex];
				buttonControls[currentAction].Text = config.Buttons[currentAction] == -1
					? "Unassigned"
					: "Button " + (config.Buttons[currentAction] + 1).ToString("D2");
				Enabled = true;
			}
		}

		#endregion

		#region Game Patches
		public void InitPatches()
		{
			if (File.Exists(patchesJsonPath))
			{
				patchesJson = GamePatchesJson.Deserialize(patchesJsonPath);
				bool sup = suppressEvent == true;
				if (!sup)
					suppressEvent = true;
				listViewPatches.BeginUpdate();
				listViewPatches.Items.Clear();
				// Move from the old patches list
				if (gameSettings.EnabledGamePatches != null)
				{
					foreach (string str in gameSettings.EnabledGamePatches)
					{
						if (!gameSettings.Patches.ContainsKey(str))
							gameSettings.Patches.Add(str, true);
						else
							gameSettings.Patches[str] = true;
					}
				}
				foreach (GamePatchData patchData in patchesJson.Patches)
				{
					ListViewItem item = new ListViewItem(new[] { patchData.InternalName, patchData.Author, patchData.Category });
					if (gameSettings.Patches.ContainsKey(patchData.Name))
						item.Checked = gameSettings.Patches[patchData.Name] == true;
					else
						item.Checked = patchData.IsChecked;
					listViewPatches.Items.Add(item);
				}
				gameSettings.EnabledGamePatches = null; // Setting it to null removes it from the JSON
				listViewPatches.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent); // Patch name
				listViewPatches.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent); // Author
				listViewPatches.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent); // Category
				listViewPatches.EndUpdate();
				if (!sup)
					suppressEvent = false;
			}
			else
				tabControlGameConfig.TabPages.Remove(tabPagePatches);
		}

		private void listViewPatches_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (suppressEvent)
				return;
			foreach (ListViewItem item in listViewPatches.Items)
			{
				GamePatchData pdata = patchesJson.Patches.Find(a => a.InternalName == item.Text);
				if (gameSettings.Patches.ContainsKey(pdata.Name))
					gameSettings.Patches[pdata.Name] = item.Checked;
				else
					gameSettings.Patches.Add(pdata.Name, item.Checked);
			}
		}

		#endregion

		private void FilterModList(string filterString)
		{
			suppressEvent = true;
			listViewMods.BeginUpdate();
			listViewMods.Items.Clear();

			foreach (KeyValuePair<string, SADXModInfo> inf in mods.OrderBy(x => x.Value.Name))
			{
				if (inf.Value.Name.ToLowerInvariant().Contains(filterString.ToLowerInvariant()))
					listViewMods.Items.Add(new ListViewItem(new[] { inf.Value.Name, inf.Value.Author, inf.Value.Version, inf.Value.Category }) { Checked = gameSettings.EnabledMods.Contains(inf.Key), Tag = inf.Key });
			}

			listViewMods.EndUpdate();
			suppressEvent = false;
		}

		private void checkBoxSearchMod_CheckedChanged(object sender, EventArgs e)
		{
			textBoxSearchMod.Visible = checkBoxSearchMod.Checked;
			textBoxProfileName.Visible = buttonSaveProfile.Visible = buttonLoadProfile.Visible = !checkBoxSearchMod.Checked;
			labelModProfile.Text = checkBoxSearchMod.Checked ? "Search Mods:" : "Profile:";
			if (!checkBoxSearchMod.Checked)
				FilterModList("");
			else
				textBoxSearchMod.Focus();
		}

		private void buttonSelectAllMods_Click(object sender, EventArgs e)
		{
			bool unselect = listViewMods.CheckedItems.Count > 0;
			foreach (ListViewItem item in listViewMods.Items)
				item.Checked = !unselect;
		}

		private void listViewPatches_SelectedIndexChanged(object sender, EventArgs e)
		{
			string desc = "None";
			if (listViewPatches.SelectedIndices.Count == 1)
			{
				GamePatchData patch = patchesJson.Patches.Find(a => a.InternalName == listViewPatches.SelectedItems[0].Text);
				if (patch.Description != null && patch.Description != "")
					desc = patch.Description;
			}
			labelPatchDescription.Text = "Description: " + desc;
		}

		private void textBoxSearchMod_TextChanged(object sender, EventArgs e)
		{
			if (checkBoxSearchMod.Checked)
				FilterModList(textBoxSearchMod.Text);
		}

		private void textBoxSearchMod_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				checkBoxSearchMod.Checked = false;
		}

		private void buttonCheckModUpdates_Click(object sender, EventArgs e)
		{
			UpdateChecker.ItemsToCheck = UpdateChecker.UpdateItems.Mods;
			UpdateChecker.CheckMode = UpdateChecker.UpdateMode.User;
			AutoUpdate();
		}

		private void newModToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var ModDialog = new NewModDialog())
			{
				if (ModDialog.ShowDialog() == DialogResult.OK)
					LoadModList();
			}
		}

		private void ListControls()
		{
			tabControlGameConfig.TabPages.Remove(tabPageController);
			return;
			listViewSDLDevices.Columns[0].Width = listViewSDLDevices.Width - 8;
			InputControls.SDLInit(managerAppDataPath);
			Task.Factory.StartNew(SDLUILoop);	
		}

		public void SDLUILoop()
		{
			while (true)
			{
				if (InputControls.UpdateRequired)
				{
					InputControls.UpdateRequired = false;
					listViewSDLDevices.Items.Clear();
					listViewSDLDevices.Items.Add("Keyboard Layout 1");
					listViewSDLDevices.Items.Add("Keyboard Layout 2");
					listViewSDLDevices.Items.Add("Keyboard Layout 3");
					foreach (Controller controller in InputControls.Controllers)
					{
						if (controller.Connected)
							listViewSDLDevices.Items.Add(controller.DeviceName);
					}
				}
			}
		}

		private void radioButtonDInput_CheckedChanged(object sender, EventArgs e)
		{
			radioButtonMouseDisable.Enabled = radioButtonSDL.Checked;
			if (!radioButtonMouseDisable.Enabled && radioButtonMouseDisable.Checked)
			{
				radioButtonMouseDisable.Checked = false;
				radioButtonMouseDragAccelerate.Checked = true;
			}
			if (radioButtonDInput.Checked && directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly).Count > 0)
				groupBoxControllerDInput.Visible = true;
			else
				groupBoxControllerDInput.Visible = false;
		}

		private void comboBoxScreenMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			numericUpDownWindowHeight.Enabled = checkBoxWindowMaintainAspect.Enabled = (DisplayMode)comboBoxScreenMode.SelectedIndex == DisplayMode.CustomWindow;
			numericUpDownWindowWidth.Enabled = (DisplayMode)comboBoxScreenMode.SelectedIndex == DisplayMode.CustomWindow && !checkBoxWindowMaintainAspect.Checked;
		}

		private void toolStripMenuItemDeleteProfile_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Would you like to delete profile " + textBoxProfileName.Text + "?", "SADX Mod Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				suppressEvent = true;
				// Delete profile file
				File.Delete(Path.Combine(managerAppDataPath, "profiles", textBoxProfileName.Text + ".json"));
				// Set default profile
				profilesJson.ProfileIndex = 0;
				// Delete entries for profiles that don't exist
				List<ProfileData> deleteProfiles = new List<ProfileData>();
				foreach (ProfileData data in profilesJson.ProfilesList)
					if (!File.Exists(Path.Combine(managerAppDataPath, "profiles", data.Filename)))
						deleteProfiles.Add(data);
				foreach (ProfileData data in deleteProfiles)
					profilesJson.ProfilesList.Remove(data);
				// Save profiles list
				JsonSerialize(profilesJson, profilesListJsonPath);
				// Delete profile item in text box
				textBoxProfileName.Items.Remove(textBoxProfileName.Text);
				textBoxProfileName.SelectedIndex = 0;
				textBoxProfileName.Text = "Default";
				suppressEvent = false;
				// Reload current (default) profile
				LoadCurrentProfile(false);
			}
		}

		private void textBoxProfileName_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right || textBoxProfileName.Text == "Default")
			{
				return;
			}
			contextMenuStripProfile.Show(Cursor.Position);
		}

		private void textBoxProfileName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (suppressEvent)
				return;
			profilesJson.ProfileIndex = textBoxProfileName.SelectedIndex;
		}

				private void SortList(object sender, ColumnClickEventArgs e)
		{
			suppressEvent = true;
			ListView lv = (ListView)sender;
			lv.ListViewItemSorter = lvwColumnSorter;
			// https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/sort-listview-by-column
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvwColumnSorter.SortColumn)
			{

				// Reverse the current sort direction for this column.
				if (lvwColumnSorter.Order == SortOrder.Ascending)
				{
					lvwColumnSorter.Order = SortOrder.Descending;
				}
				else
				{
					lvwColumnSorter.Order = SortOrder.Ascending;
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvwColumnSorter.SortColumn = e.Column;
				lvwColumnSorter.Order = SortOrder.Ascending;
			}
			// Perform the sort with these new sort options.
			lv.Sort();
			lv.ListViewItemSorter = null;
			foreach (ListViewItem item in lv.CheckedItems)
			{
				lv.Items.Remove(item);
				lv.Items.Insert(0, item);
			}
			suppressEvent = false;
		}

		private void listViewCodes_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortList(sender, e);
		}

		private void listViewMods_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortList(sender, e);
		}

		private void listViewPatches_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortList(sender, e);
		}

		private void checkBoxTestSpawnAngleDeg_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxTestSpawnAngleDeg.Checked)
				numericUpDownTestSpawnAngle.Value = (int)Math.Round((float)numericUpDownTestSpawnAngle.Value * (360.0f / 65535.0f));
			else
				numericUpDownTestSpawnAngle.Value = (int)Math.Round((float)numericUpDownTestSpawnAngle.Value / (360.0f / 65535.0f));
		}

		void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			string errDesc = "SADX Mod Manager has crashed with the following error:\n" + e.Exception.GetType().Name + ".\n\n" +
				"If you wish to report a bug, please include the following in your report:";

			StackTrace st = new StackTrace(e.Exception, true);
			// Get the first stack frame
			StackFrame frame = st.GetFrame(0);
			// Get the file name
			string fileName = frame.GetFileName();
			// Get the method name
			string methodName = frame.GetMethod().Name;
			// Get the line number from the stack frame
			int line = frame.GetFileLineNumber();
			// Get the column number
			int col = frame.GetFileColumnNumber();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(e.Exception.ToString());
			ErrorDialog report = new ErrorDialog("SADX Mod Manager", errDesc, stringBuilder.ToString());
			DialogResult dgresult = report.ShowDialog();
			switch (dgresult)
			{
				case DialogResult.OK:
				case DialogResult.Abort:
					Environment.Exit(0);
					break;
			}
		}

		private void disableUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listViewMods.SelectedItems)
			{
				string tag = (string)item.Tag;
				if (managerClassicConfig.IgnoredModUpdates.Contains(tag))
				{
					managerClassicConfig.IgnoredModUpdates.Remove(tag);
					item.ForeColor = SystemColors.WindowText;
				}
				else
				{
					managerClassicConfig.IgnoredModUpdates.Add(tag);
					item.ForeColor = SystemColors.GrayText;
				}
			}
		}

		private void configureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			configureModButton_Click(sender, e);
		}

		private void fromURLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (ModUrlDialog dialog = new ModUrlDialog())
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (dialog.Downloads.Count > 0)
					{
						using (UpdatesAvailableDialog avd = new UpdatesAvailableDialog(dialog.Downloads, updatesTempPath))
						{
							if (avd.ShowDialog() == DialogResult.OK)
								LoadModList();
						}
					}
				}
			}
		}

		private void buttonResetGameSettings_Click(object sender, EventArgs e)
		{
			contextMenuStripResetGameSettings.Show(buttonResetGameSettings, buttonResetGameSettings.Width, 0);
		}

		private void toolStripMenuItemResetOptimal_Click(object sender, EventArgs e)
		{
			comboBoxScreenNumber.SelectedIndex = 0;
			numericUpDownHorizontalResolution.Value = Screen.PrimaryScreen.Bounds.Width;
			numericUpDownVerticalResolution.Value = Screen.PrimaryScreen.Bounds.Height;
			comboBoxAnisotropic.SelectedIndex = 5;
			comboBoxScreenMode.SelectedIndex = 2;
			comboBoxBackend.SelectedIndex = 1;			
			checkBoxForceMipmapping.Checked = true;
			checkBoxForceTextureFilter.Checked = true;
			checkBoxBorderImage.Checked = true;
			comboBoxFramerate.SelectedIndex = 0;
			comboBoxFogEmulation.SelectedIndex = 0;
			comboBoxClipLevel.SelectedIndex = 0;
			comboBoxBackgroundFill.SelectedIndex = 2;
			comboBoxFmvFill.SelectedIndex = 1;
			checkBoxScaleHud.Checked = true;
			checkBoxShowMouse.Checked = false;
			checkBoxVsync.Checked = true;
			checkBoxWindowResizable.Checked = false;
			MessageBox.Show(this, "The settings will be applied once you click 'Save' or 'Save & Play'.", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void toolStripMenuItemResetSafe_Click(object sender, EventArgs e)
		{
			comboBoxScreenNumber.SelectedIndex = Math.Min(1, comboBoxScreenNumber.Items.Count - 1);
			numericUpDownHorizontalResolution.Value = 640;
			numericUpDownVerticalResolution.Value = 480;
			comboBoxAnisotropic.SelectedIndex = 0;
			comboBoxScreenMode.SelectedIndex = 0;
			comboBoxBackend.SelectedIndex = 0;
			checkBoxEnableOIT.Checked = false;			
			checkBoxForceMipmapping.Checked = true;
			checkBoxForceTextureFilter.Checked = true;
			checkBoxBorderImage.Checked = false;
			comboBoxFramerate.SelectedIndex = 0;
			comboBoxFogEmulation.SelectedIndex = 0;
			comboBoxClipLevel.SelectedIndex = 0;
			comboBoxBackgroundFill.SelectedIndex = 0;
			comboBoxFmvFill.SelectedIndex = 0;
			checkBoxScaleHud.Checked = false;
			checkBoxShowMouse.Checked = true;
			checkBoxVsync.Checked = false;
			checkBoxWindowResizable.Checked = false;
			MessageBox.Show(this, "The settings will be applied once you click 'Save' or 'Save & Play'.", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void listViewSDLDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			listViewControlBindings.SuspendLayout();
			// No selection
			if (listViewSDLDevices.SelectedIndices.Count == 0)
			{
				groupBoxDeadzones.Enabled = groupBoxDeviceSettings.Enabled = groupBoxRumble.Enabled = listViewControlBindings.Enabled =
					buttonBindingSet.Enabled = buttonBindingReset.Enabled = buttonBindingReset.Enabled = false;
				return;
			}
			switch (listViewSDLDevices.SelectedIndices[0])
			{
				// Nothing
				case -1:
					return;
				// Keyboard 1
				case 0:
					groupBoxDeadzones.Enabled = false;
					groupBoxRumble.Enabled = false;
					groupBoxDeviceSettings.Enabled = true;
					listViewControlBindings.Enabled = true;
					buttonBindingSet.Enabled = buttonBindingReset.Enabled = buttonBindingReset.Enabled = true;
					listViewControlBindings.Items.Clear();
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Forward (Left Stick Up)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.LeftYMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Backward (Left Stick Down)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.LeftYPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Left (Left Stick Left)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.LeftXMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Right (Left Stick Right)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.LeftXPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Jump (A)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonA).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Attack (B)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonB).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Action (X)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonX).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Whistle (Y)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonY).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Start", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonStart).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Turn Camera Left (Left Trigger)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.LeftTrigger).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Turn Camera Right (Right Trigger)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.RightTrigger).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Up (Right Stick Up)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.RightYMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Down (Right Stick Down)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.RightYPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Left (Right Stick Left)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.RightXMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Right (Right Stick Right)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.RightXPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Z Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonRightShoulder).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "C Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonLeftShoulder).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "D Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonBack).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Center Camera", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonLeftStick).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Slow Walk", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout1.ButtonRightStick).ToString() }));
					break;
				// Keyboard 2
				case 1:
					groupBoxDeadzones.Enabled = false;
					groupBoxRumble.Enabled = false;
					groupBoxDeviceSettings.Enabled = true;
					listViewControlBindings.Enabled = true;
					buttonBindingSet.Enabled = buttonBindingReset.Enabled = buttonBindingReset.Enabled = true;
					listViewControlBindings.Items.Clear();
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Forward (Left Stick Up)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.LeftYMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Backward (Left Stick Down)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.LeftYPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Left (Left Stick Left)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.LeftXMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Right (Left Stick Right)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.LeftXPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Jump (A)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonA).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Attack (B)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonB).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Action (X)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonX).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Whistle (Y)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonY).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Start", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonStart).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Turn Camera Left (Left Trigger)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.LeftTrigger).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Turn Camera Right (Right Trigger)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.RightTrigger).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Up (Right Stick Up)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.RightYMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Down (Right Stick Down)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.RightYPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Left (Right Stick Left)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.RightXMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Right (Right Stick Right)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.RightXPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Z Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonRightShoulder).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "C Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonLeftShoulder).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "D Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonBack).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Center Camera", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonLeftStick).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Slow Walk", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout2.ButtonRightStick).ToString() }));
					break;
				// Keyboard 3
				case 2:
					groupBoxDeadzones.Enabled = false;
					groupBoxRumble.Enabled = false;
					groupBoxDeviceSettings.Enabled = true;
					listViewControlBindings.Enabled = true;
					buttonBindingSet.Enabled = buttonBindingReset.Enabled = buttonBindingReset.Enabled = true;
					listViewControlBindings.Items.Clear();
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Forward (Left Stick Up)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.LeftYMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Backward (Left Stick Down)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.LeftYPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Left (Left Stick Left)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.LeftXMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Right (Left Stick Right)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.LeftXPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Jump (A)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonA).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Attack (B)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonB).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Action (X)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonX).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Whistle (Y)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonY).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Start", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonStart).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Turn Camera Left (Left Trigger)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.LeftTrigger).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Turn Camera Right (Right Trigger)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.RightTrigger).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Up (Right Stick Up)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.RightYMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Down (Right Stick Down)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.RightYPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Left (Right Stick Left)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.RightXMinus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Look Right (Right Stick Right)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.RightXPlus).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Z Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonRightShoulder).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "C Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonLeftShoulder).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "D Button (for mods)", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonBack).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Center Camera", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonLeftStick).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Slow Walk", KeyInterop.KeyFromVirtualKey(InputControls.ConfigFile.KeyboardLayout3.ButtonRightStick).ToString() }));
					break;
				// Controllers
				default:
					groupBoxDeadzones.Enabled = groupBoxDeviceSettings.Enabled = groupBoxRumble.Enabled = listViewControlBindings.Enabled =
					buttonBindingSet.Enabled = buttonBindingReset.Enabled = buttonBindingReset.Enabled = true;
					listViewControlBindings.Items.Clear();
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Forward (Left Stick Up)", InputControls.Controllers[listViewSDLDevices.SelectedIndices[0]-3].GetBindForAxis(SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Backward (Left Stick Down)", InputControls.Controllers[listViewSDLDevices.SelectedIndices[0]-3].GetBindForAxis(SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Left (Left Stick Left)", InputControls.Controllers[listViewSDLDevices.SelectedIndices[0] - 3].GetBindForAxis(SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX).ToString() }));
					listViewControlBindings.Items.Add(new ListViewItem(new[] { "Right (Left Stick Right)", InputControls.Controllers[listViewSDLDevices.SelectedIndices[0] - 3].GetBindForAxis(SDL2.SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX).ToString() }));
					break;
			}
			listViewControlBindings.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent); // Control name
			listViewControlBindings.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent); // Control binding
			listViewControlBindings.ResumeLayout(true);
		}
	}
}