using System.Collections.Generic;
using ModManagerCommon;
using Newtonsoft.Json;
using SADXModManager.DataClasses;

namespace SADXModManager
{
	public static class Variables
	{
		// Variables
		/// <summary>When this is true, the program will try to close as soon as possible</summary>
		public static bool criticalError;
		// Paths
		/// <summary>Path to the folder containing SADXModManager.exe</summary>
		public static string managerExePath;
		/// <summary>Path to the temporary folder used for mod and program updates</summary>
		public static string updatesTempPath;
		/// <summary>Path to the SAManager folder in AppData or game folder</summary>
		public static string managerAppDataPath;
		/// <summary>Path to the folder where sonic.exe is located</summary>
		public static string gameMainPath;
		/// <summary>Path to the file ManagerClassic.json</summary>
		public static string managerConfigJsonPath;
		/// <summary>Path to the file Profiles.json</summary>
		public static string profilesListJsonPath;
		/// <summary>Path to the current profile JSON file containing mods, game settings etc.</summary>
		public static string currentProfileJsonPath;
		/// <summary>Path to the file CHRMODELS.dll</summary>
		public static string datadllpath = "system/CHRMODELS.dll";
		/// <summary>Path to the file CHRMODELS_orig.dll</summary>
		public static string datadllorigpath = "system/CHRMODELS_orig.dll";
		/// <summary>Path to the file SADXModLoader.dll</summary>
		public static string loaderdllpath = "mods/SADXModLoader.dll";
		/// <summary>Path to d3d8to11 configuration file</summary>
		public static string d3d8to11ConfigPath;

		/// <summary>JSON serializer</summary>
		public static readonly JsonSerializer jsonSerializer = new JsonSerializer() { Culture = System.Globalization.CultureInfo.InvariantCulture, Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore, };

		/// <summary>WebClient instance</summary>
		public static readonly UpdaterWebClient webClient = new UpdaterWebClient();

		// Serializable structs
		/// <summary>Deserialized profile containing mod list, game settings etc.</summary>
		public static GameSettings gameSettings;
		/// <summary>Deserialized ManagerClassic.json</summary>
		public static ClassicManagerJson managerConfig;
		/// <summary>Deserialized Profiles.json</summary>
		public static ProfilesJson profilesJson;

		// URLs
		/// <summary>URL of Steam Launcher archive</summary>
		public static string launcherUpdateUrl = "https://dcmods.unreliable.network/owncloud/data/PiKeyAr/files/Setup/data/AppLauncher.7z";
		/// <summary>URL of Steam conversion tools archive</summary>
		public static string steamToolsUpdateUrl = "https://dcmods.unreliable.network/owncloud/data/PiKeyAr/files/Setup/data/steam_tools.7z";
		/// <summary>URL of 2004 conversion tools archive</summary>
		public static string dx2004ToolsUpdateUrl = "https://dcmods.unreliable.network/owncloud/data/PiKeyAr/files/Setup/data/2004_tools.7z";

		// Lists
		/// <summary>List of files to delete from old Loader/Manager versions</summary>
		public static List<string> cleanupFilesToDelete = new List<string>()
		{
			"d3d8.dll",
			"7z.dll",
			"7z.exe",
			"7za.exe",
			"avcodec-vgmstream-58.dll",
			"avformat-vgmstream-58.dll",
			"avutil-vgmstream-56.dll",
			"bass.dll",
			"bass_vgmstream.dll",
			"COPYING_BASS_VGMSTREAM",
			"COPYING_D3D8TO9",
			"COPYING_VGMSTREAM",
			"d3d8m.dll",
			"jansson.dll",
			"libatrac9.dll",
			"libcelt-0061.dll",
			"libcelt-0110.dll",
			"libg719_decode.dll",
			"libg7221_decode.dll",
			"libmpg123-0.dll",
			"libogg.dll",
			"libspeex.dll",
			"libvorbis.dll",
			"libvorbisfile.dll",
			"loader.manifest",
			"ModManagerCommon.dll",
			"ModManagerCommon.pdb",
			"sadxmlver.txt",
			"Newtonsoft.Json.dll",
			"SADXModManager.exe.config",
			"SharpDX.DirectInput.dll",
			"SharpDX.DirectInput.xml",
			"SharpDX.dll",
			"swresample-vgmstream-3.dll",
			"SDL2.dll"
		};

		// Strings
		public static string generateManifestWarning = "This can cause MOD USER DATA (SAVE FILES, CONFIG FILES) TO BE LOST upon next update! To prevent this, you should never run this on mods you did not develop.\r\n\r\nAre you sure you wish to continue?";
		public static string sonicExeMd5Error = "Setup has detected that sonic.exe is incompatible with the Mod Loader.\r\n\nThe following versions are not supported:\n\nSold Out Software (SafeDisc DRM)\nJapanese release (SafeDisc DRM)\nCracked copies of the European version\nOther hacked EXEs (pirate translations etc.)\n\nIf your version of the game is different from the above, please contact PkR on the x-hax Discord\n\nsonic.exe MD5: {0}";

		// Dictionaries
		public static Dictionary<int, string> saveList = new Dictionary<int, string>();

		public static Dictionary<int, string> TestSpawnGameModeList = new Dictionary<int, string>
		{
			{ 4, "Action Stage" },
			{ 5, "Adventure" },
			{ 9, "Trial" },
			{ 10, "Mission" }
		};
	
		public static Dictionary<int, string> TestSpawnCutsceneList = new Dictionary<int, string>
		{
			{ 1, "Sonic intro" },
			{ 2, "Sonic defeats Chaos 0" },
			{ 3, "Sonic sees Tails crash" },
			{ 6, "Sonic and Tails poolside" },
			{ 7, "Sonic faces off with the Egg Hornet" },
			{ 8, "Sonic sees Chaos 1 emerge" },
			{ 9, "Sonic and Tails are gassed" },
			{ 11, "Sonic sees Chaos 4 transformation" },
			{ 12, "Sonic and Tails part ways with Knuckles" },
			{ 13, "Sonic and Tails take off on the Tornado 1" },
			{ 17, "Sonic falling into Station Square" },
			{ 18, "Sonic is found by Amy" },
			{ 19, "Sonic and Amy go to Twinkle Park" },
			{ 20, "Sonic goes looking for Amy" },
			{ 21, "Sonic sees Zero and Amy at the station" },
			{ 22, "Sonic sees Zero transported to the Egg Carrier" },
			{ 23, "Sonic catches up with Tails on the Tornado 2" },
			{ 26, "Sonic sees Eggman take Birdie's Emerald" },
			{ 27, "Sonic defeats Gamma" },
			{ 28, "Sonic finds Chaos 6" },
			{ 29, "Sonic jumps from the Egg Carrier into the jungle" },
			{ 30, "Sonic sees the temple come out of the ground" },
			{ 32, "Sonic looks at the Perfect Chaos mural" },
			{ 33, "Sonic enters the Past" },
			{ 34, "Sonic listens to Tikal in the Past" },
			{ 35, "Sonic sees Eggman heading to his base" },
			{ 36, "Sonic faces the Egg Viper" },
			{ 38, "Sonic's outro" },
			{ 40, "Sonic vs. Knuckles" },
			{ 41, "Sonic and Tails land on the Egg Carrier" },
			{ 42, "Sonic and Tails awaken after being gassed" },
			{ 43, "Sonic meets Chaos 0" },
			{ 48, "Tails intro" },
			{ 49, "Tails is rescued by Sonic" },
			{ 50, "Tails and Sonic poolside" },
			{ 51, "Tails faces off with the Egg Hornet" },
			{ 52, "Tails sees Chaos 1 emerge" },
			{ 53, "Tails and Sonic are gassed at Casinopolis" },
			{ 56, "Tails vs. Knuckles" },
			{ 57, "Tails sees Chaos 4 emerge" },
			{ 58, "Tails and Sonic part ways with Knuckles" },
			{ 59, "Tails and Sonic depart on the Tornado 1" },
			{ 62, "Tails' flashback" },
			{ 64, "Tails wakes up from his dream" },
			{ 66, "Tails chases Froggy" },
			{ 68, "Tails enters the Past" },
			{ 69, "Tails talks to Tikal" },
			{ 70, "Tails meets Big and lets go of Froggy" },
			{ 71, "Tails takes off on the Tornado 2" },
			{ 72, "Tails finds Sonic in Red Mountain" },
			{ 75, "Tails faces off with Gamma" },
			{ 76, "Tails and Amy escape from the Egg Carrier" },
			{ 77, "Tails sees Eggman launching his missile attack" },
			{ 78, "Tails follows Eggman after the missile" },
			{ 80, "Tails takes on the Egg Walker" },
			{ 81, "Tails defeated the Egg Walker" },
			{ 82, "Tails outro" },
			{ 83, "Error" },
			{ 84, "Tails and Sonic landing on the Egg Carrier" },
			{ 85, "Tails and Froggy go to the Past" },
			{ 86, "Tails and Sonic awake after being gassed" },
			{ 88, "Unused" },
			{ 96, "Amy intro" },
			{ 97, "Amy meets Birdie" },
			{ 98, "Amy meets up with Sonic" },
			{ 99, "Amy and Sonic visit Twinkle Park" },
			{ 100, "Amy is kidnapped by Zero" },
			{ 101, "Amy is released by Gamma" },
			{ 102, "Amy escapes Hot Shelter" },
			{ 103, "Amy finds herself in the Past" },
			{ 104, "Amy meets Tikal" },
			{ 105, "Amy sees Eggman take Birdie's Emerald" },
			{ 106, "Amy and Tails escape the Egg Carrier" },
			{ 107, "Error" },
			{ 108, "Amy returns to the present" },
			{ 109, "Amy decides to help find Birdie's family" },
			{ 110, "Amy discovers the Final Egg Base" },
			{ 111, "Amy chased by Zero in Final Egg" },
			{ 112, "Amy and Birdie head back to the Egg Carrier" },
			{ 113, "Amy is confronted by Zero" },
			{ 114, "Amy outro" },
			{ 117, "Amy is kidnapped to the Mystic Ruins" },
			{ 128, "Knuckles intro" },
			{ 130, "Knuckles goes hunting for the Master Emerald" },
			{ 131, "Knuckles taken to the Past from Casinopolis" },
			{ 132, "Knuckles finds himself in the Past" },
			{ 133, "Knuckles sees Tikal talk to her father" },
			{ 134, "Knuckles returns from the Past to Station Square" },
			{ 135, "Knuckles and Chaos 2 face off" },
			{ 136, "Knuckles is tricked by Eggman" },
			{ 137, "Knuckles goes after Sonic" },
			{ 138, "Knuckles vs. Sonic" },
			{ 139, "Knuckles sees Chaos 4 emerge" },
			{ 140, "Knuckles parts ways with Sonic and Tails" },
			{ 141, "Knuckles goes to the Past from the temple" },
			{ 142, "Knuckles at the Master Emerald Altar" },
			{ 143, "Knuckles sees Tikal talking to Chaos" },
			{ 145, "Knuckles restores most of the Master Emerald" },
			{ 146, "Knuckles follows Gamma" },
			{ 148, "Knuckles arrives on the Egg Carrier" },
			{ 149, "Knuckles finds the last missing piece" },
			{ 150, "Knuckles sees the Master Emerald Altar on fire" },
			{ 151, "Knuckles witnesses the aftermath of Tikal's plight" },
			{ 152, "Knuckles is back to the Egg Carrier" },
			{ 153, "Knuckles fights Chaos 6" },
			{ 154, "Knuckles has collected the final shards" },
			{ 155, "Knuckles defeats Chaos 6" },
			{ 156, "Error" },
			{ 157, "Knuckles restores the Master Emerald" },
			{ 159, "Knuckles outro" },
			{ 160, "Knuckles follows Eggman in Station Square hotel" },
			{ 176, "Gamma intro" },
			{ 177, "Gamma enters Final Egg" },
			{ 178, "Gamma completes his first objective at Final Egg" },
			{ 179, "Gamma is told that he is a useless machine" },
			{ 180, "Gamma's first fight with Beta" },
			{ 181, "Gamma defeats Beta" },
			{ 183, "Gamma and other E Series briefing" },
			{ 184, "Gamma and Froggy go to the Past" },
			{ 185, "Gamma cannot determine location" },
			{ 186, "Gamma meets Tikal" },
			{ 187, "Gamma brings Froggy to Eggman" },
			{ 188, "Gamma goes to the wrong room" },
			{ 189, "Gamma witnesses Beta being rebuilt" },
			{ 190, "Gamma leaves Beta's room" },
			{ 191, "Gamma meets and releases Amy" },
			{ 192, "Gamma heading to the rear of the ship" },
			{ 193, "Gamma emerges to fight Sonic" },
			{ 194, "Gamma leaves the Egg Carrier" },
			{ 195, "Gamma's objectives changed" },
			{ 197, "Gamma sets out to rescue Zeta and Beta" },
			{ 199, "Gamma outro" },
			{ 208, "Big intro" },
			{ 209, "Big goes searching for Froggy" },
			{ 210, "Big sees Froggy heading into the sewers" },
			{ 211, "Big finds Froggy and Tails" },
			{ 212, "Big loses Froggy to Gamma" },
			{ 216, "Big enters Hot Shelter" },
			{ 217, "Big spots Froggy inside the tanks" },
			{ 218, "Big saves Froggy in Hot Shelter" },
			{ 219, "Big finds himself in the Past" },
			{ 220, "Big sees Tikal and the Master Emerald" },
			{ 221, "Big returns to the Egg Carrier" },
			{ 222, "Big sees Froggy taken by Chaos 6" },
			{ 223, "Big thanks Sonic for saving Froggy" },
			{ 224, "Big and Froggy escape on the Tornado 2" },
			{ 225, "Error" },
			{ 226, "Big outro" },
			{ 227, "Big sees Froggy heading to the beach" },
			{ 240, "Crashed Tornado 2 in the jungle" },
			{ 242, "Eggman heading to the Mystic Ruins base" },
			{ 243, "Knuckles at the Master Emerald" },
			{ 244, "Tails tells Sonic about Angel Island falling" },
			{ 245, "Sonic and Tails find Eggman and Knuckles" },
			{ 246, "Sonic travels to the Master Emerald Altar" },
			{ 247, "Tikal pleads with her father" },
			{ 248, "Tikal seals Chaos" },
			{ 249, "Sonic returns to the present" },
			{ 250, "Sonic and Tails find the Tornado 2" },
			{ 251, "Sonic checks on Tikal in the past" },
			{ 253, "Perfect Chaos reveals himself" },
			{ 254, "Last Story outro" },
			{ 255, "Everyone brings Sonic the emeralds" },
			{ 256, "Sonic and Tails after landing on the Egg Carrier" },
			{ 257, "Don't get too many ideas you fools! (Sonic)" },
			{ 258, "The Egg Carrier has changed chape (Sonic)" },
			{ 259, "Sonic at the Sky Deck entrance" },
			{ 260, "Sonic got into the Egg Carrier (Is that it?)" },
			{ 262, "Sonic heading to transform the Egg Carrier" },
			{ 263, "Emergency alert cancelled (Sonic)" },
			{ 272, "Tails and Sonic after landing on the Egg Carrier" },
			{ 273, "Don't get too many ideas (Tails)" },
			{ 274, "The Egg Carrier has changed shape (Tails)" },
			{ 275, "Tails at the Sky Deck entrance" },
			{ 276, "Tails got into the Egg Carrier (Is that it?)" },
			{ 288, "The Egg Carrier changes shape (Knuckles)" },
			{ 289, "The Egg Carrier transforms again (Knuckles)" },
			{ 290, "Knuckles sensing the emeralds on the Egg Carrier" },
			{ 304, "Amy in the Hedgehog Hammer room" },
			{ 305, "Amy wins Hedgehog Hammer" },
			{ 320, "Gamma is told to find the Jet Booster" },
			{ 321, "Gamma heads to Hot Shelter" },
			{ 322, "Gamma spots E-101 R" },
			{ 336, "Emergency alert cancelled (Big)" },
			{ 352, "The Echidna tribe faces Chaos" },
			{ 357, "Sonic gets the Crystal Ring" },
			{ 358, "Sonic gets the Light Speed Shoes" },
			{ 359, "Sonic gets the Ancient Light" },
			{ 360, "Tails gets the Jet Anklet" },
			{ 361, "Tails gets the Rhythm Badge" },
			{ 362, "Knuckles gets the Fighting Gloves" },
			{ 363, "Knuckles gets the Shovel Claw" },
			{ 364, "Amy gets the Long Hammer" },
			{ 365, "Amy gets the Warrior Feather" },
			{ 366, "Gamma gets the Laser Blaster" },
			{ 367, "Gamma gets the Jet Booster" },
			{ 368, "Big gets the Power Rod" },
			{ 369, "Big gets the Life Belt" },
			{ 374, "Ice Stone appears (Sonic)" },
			{ 375, "Ice Stone appears (Tails)" },
			{ 376, "Ice Stone appears (Big)" },
			{ 377, "Employee Card appears (Sonic)" },
			{ 378, "Passage to Angel Island opens (Sonic)" },
			{ 379, "Passage to Angel Island opens (Tails)" },
			{ 380, "Passage to Angel Island opens (Gamma)" },
			{ 384, "Sonic sees the Egg Carrier in Red Mountain" }
		};
	}
}