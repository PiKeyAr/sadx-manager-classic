using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// Patches.json in the mods folder

namespace SADXModManager.DataClasses
{
	public class GamePatchData
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public bool IsChecked { get; set; }
		public string InternalName { get; set; }
	}

	public class GamePatchesJson
	{
		public List<GamePatchData> Patches { get; set; } = new List<GamePatchData>();
		public static GamePatchesJson Deserialize(string path)
		{
			if (File.Exists(path))
			{
				JsonSerializer js = new JsonSerializer() { Culture = System.Globalization.CultureInfo.InvariantCulture };
				using (TextReader tr = File.OpenText(path))
				using (JsonTextReader jtr = new JsonTextReader(tr))
					return js.Deserialize<GamePatchesJson>(jtr);
			}

			return null;
		}
	}
}