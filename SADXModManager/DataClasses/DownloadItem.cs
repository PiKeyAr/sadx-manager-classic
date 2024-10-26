using ModManagerCommon;
using System;
using System.Collections.Generic;

// Downloads for the 'Updates are available' dialog

namespace SADXModManager.DataClasses
{
	public class DownloadItem
	{
		public enum DownloadItemType
		{
			Loader,
			Manager,
			Launcher,
			Mod,
			SteamTools,
			VisualCppRuntime,
			DirectXRuntime
		}

		public bool Required;
		public bool GameBanana;

		public string Name;
		public string Authors;
		public string Version;
		public DateTime ReleaseDate;
		public DateTime UploadDate;
		public long DownloadSize;
		public int FileCount;
		public string HomepageUrl;
		public string DownloadUrl;
		public string ReleaseName;
		public string ReleaseTag;
		public string Description;
		public List<Tuple<string, string, long>> Files;
		public string Changelog;

		public DownloadItemType Type;
		public ModDownload ModDownloadInfo;

		public DownloadItem()
		{
		}

		public DownloadItem(ModDownload modDownload)
		{
			ModDownloadInfo = modDownload;
			Type = DownloadItemType.Mod;
			Name = modDownload.Info.Name;
			Authors = modDownload.Info.Author;
			Version = modDownload.Version;
			ReleaseDate = modDownload.Published;
			UploadDate = modDownload.Updated;
			DownloadSize = modDownload.Size;
			FileCount = modDownload.FilesToDownload;
			HomepageUrl = !string.IsNullOrEmpty(modDownload.HomePage) ? modDownload.HomePage : modDownload.ReleaseUrl;
			DownloadUrl = modDownload.Url;
			ReleaseName = modDownload.Name;
			ReleaseTag = !string.IsNullOrEmpty(modDownload.ReleaseUrl) ? modDownload.Version : "";
			Description = modDownload.Info.Description;
			Files = new List<Tuple<string, string, long>>();
			if (modDownload.ChangedFiles != null)
				foreach (var file in modDownload.ChangedFiles)
					Files.Add(new Tuple<string,string,long>(file.State.ToString(), file.Current.FilePath, file.Current.FileSize));
			Changelog = modDownload.Changes.Trim();
		}
	};
}