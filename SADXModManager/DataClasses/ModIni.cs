using IniFile;
using ModManagerCommon;
using System;
using System.Collections.Generic;
using System.IO;

// mod.ini

namespace SADXModManager
{
	public class SADXModInfo : ModInfo
	{
		public string EXEFile { get; set; }
		public bool RedirectMainSave { get; set; }
		public bool RedirectChaoSave { get; set; }

		[IniName("Config", "IncludeDir")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 0)]
		public List<string> IncludeDirs { get; set; }

		[IniName("Config", "IncludeDirCount")]
		public string IncludeDirCount { get; set; }

		public static new IEnumerable<string> GetModFiles(DirectoryInfo directoryInfo)
		{
			string modini = Path.Combine(directoryInfo.FullName, "mod.ini");
			if (File.Exists(modini))
			{
				yield return modini;
				yield break;
			}

			foreach (DirectoryInfo item in directoryInfo.GetDirectories())
			{
				if (item.Name.Equals("system", StringComparison.OrdinalIgnoreCase) || item.Name[0] == '.')
				{
					continue;
				}

				foreach (string filename in GetModFiles(item))
					yield return filename;
			}
		}
	}
}