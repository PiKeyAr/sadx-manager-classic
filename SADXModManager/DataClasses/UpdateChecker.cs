using System.ComponentModel;

namespace SADXModManager.DataClasses
{
	public class UpdateChecker : BackgroundWorker
	{
		public enum UpdateItems
		{
			AllMods,
			SelectedMods,
			OneClick,
			Loader,
			Manager,
			Launcher
		}

		public UpdateItems ItemsToCheck { get; set; }
	}
}
