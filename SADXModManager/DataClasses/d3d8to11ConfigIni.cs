using IniFile;
using System.ComponentModel;

namespace SADXModManager.DataClasses
{
	public class D3d8to11ConfigIni
	{
		public class OITConfig
		{
			[IniAlwaysInclude]
			[DefaultValue("false")] // Had to make it string because it doesn't read "True" as "true"
			[IniName("enabled")]
			public string EnableOIT;
		}

		[IniAlwaysInclude]
		[IniName("OIT")]
		public OITConfig OIT { get; set; }
	}
}
