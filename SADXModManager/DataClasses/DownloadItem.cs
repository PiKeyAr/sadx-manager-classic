using ModManagerCommon;
using System;

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
			Mod
		}

		public string Name;
		public string URL;
		public string Path;
		public string Version;
		public long Size;
		public string Changelog;
		public DownloadItemType Type;
		public ModDownload ModDownloadInfo;
		public DateTime Published;

		public DownloadItem(string name, string url, long size, string changelog, DownloadItemType type, string version, DateTime published, ModDownload modDownload = null)
		{
			Name = name;
			URL = url;
			Size = size;
			Changelog = changelog;
			Type = type;
			Version = version;
			ModDownloadInfo = modDownload;
			Published = published;
		}

		public DownloadItem(ModDownload modDownload)
		{
			Name = modDownload.Info.Name;
			URL = modDownload.Url;
			Size = modDownload.Size;
			Changelog = modDownload.Changes.Trim();
			Type = DownloadItemType.Mod;
			Version = modDownload.Version;
			ModDownloadInfo = modDownload;
			Published = modDownload.Published;
		}
	};
}