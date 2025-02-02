using System.Collections.Generic;

// Manager.json in SAManager.
// Only the bare minimum is implemented for reading the SADX game folder from the new SA Mod Manager settings file.

namespace SADXModManager.DataClasses
{
	public class GameEntry
	{
		public enum GameType
		{
			Unsupported = 0,
			SADX = 1,
			SA2 = 2,
		}

		// Game name such as "Sonic Adventure DX"
		public string Name { get; set; }

		// Full path to the game folder
		public string Directory { get; set; }

		// Game EXE name, such as "sonic.exe"
		public string Executable { get; set; }

		// SADX or SA2
		public GameType Type { get; set; }

		public GameEntry() { }
	}

	public class ManagerJson
	{
		public List<GameEntry> GameEntries { get; set; }
	}
}
