using System.Collections.Generic;
using System.ComponentModel;
using IniFile;

// SA Mod Manager profile in SAManager\SADX containing the list of mods, codes etc. and game settings

namespace SADXModManager
{
	public class GraphicsSettings
	{
		public enum FillMode
		{
			Stretch = 0,
			Fit = 1,
			Fill = 2
		}

		public enum TextureFilter
		{
			temp = 0,
		}

		public enum DisplayMode
		{
			Windowed,
			Fullscreen,
			Borderless,
			CustomWindow
		}

		[DefaultValue(1)]
		public int SelectedScreen { get; set; } = 1;             // SADXLoaderInfo.ScreenNum

		[DefaultValue(640)]
		public int HorizontalResolution { get; set; } = 640;    // SADXLoaderInfo.HorizontalResolution

		[DefaultValue(480)]
		public int VerticalResolution { get; set; } = 480;      // SADXLoaderInfo.VerticalResolution

		[DefaultValue(false)]
		public bool Enable43ResolutionRatio { get; set; } = false;          // SADXLoaderInfo.ForseAspectRatio

		[DefaultValue(true)]
		public bool EnableVsync { get; set; } = true;           // SADXLoaderInfo.EnableVSync

		[DefaultValue(true)]
		public bool EnablePauseOnInactive { get; set; } = true;     // SADXLoaderInfo.PauseWhenInactive

		[DefaultValue(640)]
		public int CustomWindowWidth { get; set; } = 640;             // SADXLoaderInfo.WindowWidth

		[DefaultValue(480)]
		public int CustomWindowHeight { get; set; } = 480;            // SADXLoaderInfo.WindowHeight

		[DefaultValue(false)]
		public bool EnableKeepResolutionRatio { get; set; }     // SADXLoaderInfo.MaintainWindowAspectRatio

		[DefaultValue(false)]
		public bool EnableResizableWindow { get; set; }               // SADXLoaderInfo.ResizableWindow

		[DefaultValue((int)FillMode.Fill)]
		public int FillModeBackground { get; set; } = (int)FillMode.Fill;   // SADXLoaderInfo.BackgroundFillMode

		[DefaultValue((int)FillMode.Fit)]
		public int FillModeFMV { get; set; } = (int)FillMode.Fit;           // SADXLoaderInfo.FmvFillMode

		[DefaultValue(TextureFilter.temp)]
		public TextureFilter ModeTextureFiltering { get; set; }

		[DefaultValue(TextureFilter.temp)]
		public TextureFilter ModeUIFiltering { get; set; }

		[DefaultValue(true)]
		public bool EnableUIScaling { get; set; } = true;              // SADXLoaderInfo.ScaleHud

		[DefaultValue(true)]
		public bool EnableForcedMipmapping { get; set; } = true;            // SADXLoaderInfo.AutoMipmap

		[DefaultValue(true)]
		public bool EnableForcedTextureFilter { get; set; } = true; // SADXLoaderInfo.TextureFilter

		[DefaultValue(DisplayMode.Borderless)]
		public int ScreenMode { get; set; } = (int)DisplayMode.Borderless;

		[DefaultValue(false)]
		public bool ShowMouseInFullscreen { get; set; }

		[DefaultValue(false)]
		public bool DisableBorderImage { get; set; }

		[DefaultValue(0)]
		public int Antialiasing { get; set; }

		[DefaultValue(0)]
		public int Anisotropic { get; set; }
		[DefaultValue(0)]
		public int RenderBackend { get; set; }
	}

	public class ControllerSettings
	{
		[DefaultValue(true)]
		public bool EnabledInputMod { get; set; } = true;   // SADXLoaderInfo.InputModEnabled
	}

	public class SoundSettings
	{
		[DefaultValue(true)]
		public bool EnableBassMusic { get; set; } = true;             // SADXLoaderInfo.EnableBassMusic

		[DefaultValue(false)]
		public bool EnableBassSFX { get; set; } = true;              // SADXLoaderInfo.EnableBassSFX

		[DefaultValue(100)]
		public int SEVolume { get; set; } = 100;                // SADXLoaderInfo.SEVolume
	}

	public class TestSpawnSettings
	{
		public enum GameLanguage
		{
			Japanese = 0,
			English = 1,
			French = 2,
			Spanish = 3,
			German = 4
		}

		/// <summary>
		/// Enables Character options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseCharacter { get; set; } = false;

		/// <summary>
		/// Enables the Level, Act, and Time of Day options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseLevel { get; set; } = false;

		/// <summary>
		/// Enables the Event options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseEvent { get; set; } = false;

		/// <summary>
		/// Enables the GameMode options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseGameMode { get; set; } = false;

		/// <summary>
		/// Enables the Save options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseSave { get; set; } = false;

		/// <summary>
		/// Selected index for the level used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int LevelIndex { get; set; } = -1;       // SADXLoaderInfo.TestSpawnLevel

		/// <summary>
		/// Selected index for the act used by test spawn.
		/// </summary>
		[DefaultValue(0)]
		public int ActIndex { get; set; } = 0;          // SADXLoaderInfo.TestSpawnAct

		/// <summary>
		/// Selected index for the character used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int CharacterIndex { get; set; } = -1;   // SADXLoaderInfo.TestSpawnCharacter

		/// <summary>
		/// Selected index of an event used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int EventIndex { get; set; } = -1;       // SADXLoaderInfo.TestSpawnEvent

		/// <summary>
		/// Selected index for the GameMode used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int GameModeIndex { get; set; } = -1;    // SADXLoaderInfo.TestSpawnGameMode

		/// <summary>
		/// Selected save file index used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int SaveIndex { get; set; } = -1;      // SADXLoaderInfo.TestSpawnSaveID

		/// <summary>
		/// Sets the game's Text Language.
		/// </summary>
		[DefaultValue((int)GameLanguage.English)]
		public int GameTextLanguage { get; set; } = 1;      // SADXLoaderInfo.TextLanguage

		/// <summary>
		/// Sets the game's Voice Language.
		/// </summary>
		[DefaultValue((int)GameLanguage.English)]
		public int GameVoiceLanguage { get; set; } = 1;     // SADXLoaderInfo.VoiceLanguage

		/// <summary>
		/// Enables the Manual settings for Character, Level, and Act.
		/// </summary>
		[DefaultValue(false)]
		public bool UseManual { get; set; } = false;

		/// <summary>
		/// Enables manually modifying the start position when using test spawn.
		/// </summary>
		[DefaultValue(false)]
		public bool UsePosition { get; set; } = false; // SADXLoaderInfo.TestSpawnPositionEnabled

		/// <summary>
		/// X Position where the player will spawn using test spawn.
		/// </summary>
		[DefaultValue(0f)]
		public float XPosition { get; set; } = 0f;            // SADXLoaderInfo.TestSpawnX

		/// <summary>
		/// Y Position where the player will spawn using test spawn.
		/// </summary>
		[DefaultValue(0f)]
		public float YPosition { get; set; } = 0f;            // SADXLoaderInfo.TestSpawnY

		/// <summary>
		/// Z Position where the player will spawn using test spawn.
		/// </summary>
		[DefaultValue(0f)]
		public float ZPosition { get; set; } = 0f;            // SADXLoaderInfo.TestSpawnZ

		/// <summary>
		/// Initial Y Rotation for the player when using test spawn.
		/// </summary>
		[DefaultValue(0)]
		public int Rotation { get; set; } = 0;     // SADXLoaderInfo.TestSpawnRotation
	}
	
	public class DebugSettings
	{
		/// <summary>
		/// Enables debug printing to the console window.
		/// </summary>
		[DefaultValue(false)]
		public bool EnableDebugConsole { get; set; }      // SADXLoaderInfo.DebugConsole

		/// <summary>
		/// Enables debug printing in the game window.
		/// </summary>
		[DefaultValue(false)]
		public bool EnableDebugScreen { get; set; }       // SADXLoaderInfo.DebugScreen

		/// <summary>
		/// Enables debug printing to a file.
		/// </summary>
		[DefaultValue(false)]
		public bool EnableDebugFile { get; set; }         // SADXLoaderInfo.DebugFile

		/// <summary>
		/// Enables crash log mini dump creation.
		/// </summary>
		[DefaultValue(true)]
		public bool EnableDebugCrashLog { get; set; } = true;    // SADXLoaderInfo.DebugCrashLog
	}

	public class GameSettings
	{
		/// <summary>
		/// Versioning. Please comment a brief on the changes to the version.
		/// </summary>
		public enum SADXSettingsVersions
		{
			v0,     // Version 0: Original LoaderInfo version
			v1,     // Version 1: Initial version at launch
			v2,     // Version 2: Updated to include all settings, intended to be used as the only loaded file, now writes SADXLoaderInfo and SADXConfigFile.
			v3,     // Version 3: Added Graphics.StretchToWindow and Graphics.DisableBorderWindow.

			MAX,    // Do Not Modify, new versions are placed above this.
		}

		/// <summary>
		/// Versioning for the SADX Settings file.
		/// </summary>
		[DefaultValue((int)(SADXSettingsVersions.MAX - 1))]
		public int SettingsVersion { get; set; } = (int)(SADXSettingsVersions.MAX - 1);

		/// <summary>
		/// Graphics Settings for SADX.
		/// </summary>
		public GraphicsSettings Graphics { get; set; } = new GraphicsSettings();

		/// <summary>
		/// Controller Settings for SADX.
		/// </summary>
		public ControllerSettings Controller { get; set; } = new ControllerSettings();

		/// <summary>
		/// Sound Settings for SADX.
		/// </summary>
		public SoundSettings Sound { get; set; } = new SoundSettings();

		/// <summary>
		/// TestSpawn Settings for SADX.
		/// </summary>
		public TestSpawnSettings TestSpawn { get; set; } = new TestSpawnSettings();

		/// <summary>
		/// Patches for SADX.
		/// </summary>
		public Dictionary<string, bool> Patches { get; set; } = new Dictionary<string, bool>();

		/// <summary>
		/// Debug Settings.
		/// </summary>
		public DebugSettings DebugSettings { get; set; } = new DebugSettings();

		/// <summary>
		/// This is only used for retrieving the game path when migrating from the old Manager settings location (SAManager folder).
		/// </summary>
		public string GamePath { get; set; } = string.Empty;

		/// <summary>
		/// Enabled Mods for SADX.
		/// </summary>
		[IniName("Mod")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<string> EnabledMods { get; set; } = new List<string>();       // SADXLoaderInfo.Mods

		/// <summary>
		/// Enabled Game Patches for SADX.
		/// </summary>
		[IniName("Patch")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<string> EnabledGamePatches { get; set; }

		/// <summary>
		/// Enabled Codes for SADX.
		/// </summary>
		[IniName("Code")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<string> EnabledCodes { get; set; } = new List<string>();      // SADXLoaderInfo.EnabledCodes
	}
}