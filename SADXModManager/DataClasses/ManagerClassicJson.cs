﻿using System.Collections.Generic;
using System.ComponentModel;
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
		[DefaultValue(true)]
		public bool ManagerUpdateCheck { get; set; }
		[DefaultValue(true)]
		public bool LauncherUpdateCheck { get; set; }
		[DefaultValue(true)]
		public bool KeepManagerOpen { get; set; }
		public string ModAuthor { get; set; }
		public bool AngleHex { get; set; }
		public bool AngleDeg { get; set; }
		public bool SingleProfileMode { get; set; }
		public List<string> IgnoredModUpdates { get; set; }

		public ClassicManagerJson()
		{
			// Just DefaultValue doesn't work when reading a JSON that doesn't have the value at all
			ManagerUpdateCheck = true;
			LauncherUpdateCheck = true;
			KeepManagerOpen = true;
		}
	}
}
