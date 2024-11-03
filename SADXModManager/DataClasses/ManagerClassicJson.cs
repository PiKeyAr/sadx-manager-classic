using System.Collections.Generic;
using System.Drawing;
using ModManagerCommon;

// ManagerClassic.json in SAManager

namespace SADXModManager.DataClasses
{
	public class ClassicManagerJson : LoaderInfo
	{
		public Size WindowSize { get; set; }
		public Point WindowPosition { get; set; }
		public Point LastMonitorResolution { get; set; }
		public bool Maximized { get; set; }
		public bool ManagerUpdateCheck { get; set; }
		public bool KeepManagerOpen { get; set; }
		public string ModAuthor { get; set; }
		public bool AngleHex { get; set; }
		public bool AngleDeg { get; set; }
		public bool SingleProfileMode { get; set; }
		public List<string> IgnoredModUpdates { get; set; }
	}
}
