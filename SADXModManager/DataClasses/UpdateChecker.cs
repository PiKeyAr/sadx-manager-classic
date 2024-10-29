using System;
using System.Collections.Generic;

// This class stores global settings related to the updates system.

namespace SADXModManager.DataClasses
{
	public static class UpdateChecker
	{
		[Flags]
		public enum UpdateItems
		{
			None = 0,
			Mods = 0x1,
			OneClick = 0x2,
			Loader = 0x4,
			Manager = 0x8,
			Launcher = 0x10,
		}

		public enum UpdateMode
		{
			Startup,
			Scheduled,
			User
		}

		public static UpdateMode CheckMode;

		public static UpdateItems ItemsToCheck { get; set; }

		public static List<string> OneClickLinks { get; set; }
	}
}