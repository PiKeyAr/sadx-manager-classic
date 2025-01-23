using IniFile;
using System.ComponentModel;

namespace SADXModManager.DataClasses
{
	public class D3d8to11ConfigIni
	{
		public class OITConfig
		{
			[IniAlwaysInclude]
			[DefaultValue(false)]
			[IniName("enabled")]
			public bool EnableOIT;
		}

		[IniAlwaysInclude]
		[IniName("OIT")]
		public OITConfig OIT { get; set; }
	}
}
