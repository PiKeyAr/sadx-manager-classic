﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using ModManagerCommon;
using Newtonsoft.Json;
using SADXModManager.DataClasses;
using static SADXModManager.Variables;

namespace SADXModManager
{
	public static class Utils
	{
		private enum OneClickType
		{
			DirectLink,
			GitHub, // Welp, can't fetch it directly from the repo without knowing the asset name
			GameBanana,
		}

		private static Dictionary<string, string> GameBananaItemTypes = new Dictionary<string, string>()
		{
			{  "mods", "Mod" },
			{  "wips", "Wip" },
			{  "tools", "Tool" },
			{  "sounds", "Sound" }
		};

		/// <summary>Retrieves a value from a registry subkey.</summary>
		public static RegistryKey GetRegistryKey(string key)
		{
			RegistryKey hkcu32 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry32);
			RegistryKey hklm32 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
			RegistryKey hkcu64 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
			RegistryKey hklm64 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
			RegistryKey result = hklm32.OpenSubKey(key);
			if (result == null)
				result = hklm64.OpenSubKey(key);
			if (result == null)
				result = hkcu32.OpenSubKey(key);
			if (result == null)
				result = hkcu64.OpenSubKey(key);
			return result;
		}

		/// <summary>Deserializes a class from a JSON file.</summary>
		public static T JsonDeserialize<T>(string path)
		{
			if (!File.Exists(path))
				return default(T);
			using (TextReader tr = File.OpenText(path))
			using (JsonTextReader jtr = new JsonTextReader(tr))
				return jsonSerializer.Deserialize<T>(jtr);
		}

		/// <summary>Serializes a class to a JSON file.</summary>
		public static void JsonSerialize(object t, string path)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			using (TextWriter tr = File.CreateText(path))
				jsonSerializer.Serialize(tr, t);
		}

		/// <summary>Makes a WebRequest to retrieve the size of a download.</summary>
		public static long GetDownloadSize(WebResponse resp)
		{
			long result = 0;
			if (long.TryParse(resp.Headers.Get("Content-Length"), out long contentLength))
			{
				result = contentLength;
			}
			return result;
		}

		/// <summary>Makes a WebRequest to retrieve the modified date of a download.</summary>
		public static DateTime GetDownloadDate(WebResponse res)
		{
			HttpWebResponse httpWebResponse = res as HttpWebResponse;
			return httpWebResponse.LastModified;
		}

		/// <summary>Retrieves a download for an update for SADX Mod Loader from direct links (null if no update).</summary>
		public static DownloadItem CheckLoaderUpdates(Form parent, bool xp)
		{
			string loaderUpdateUrl = xp ? loaderUpdatePkRUrl : loaderUpdateOriginalUrl;
			string mlverfile = Path.Combine(managerAppDataPath, "sadxmlver.txt");
			try
			{
				// Read version info
				string msg = webClient.DownloadString("http://mm.reimuhakurei.net/toolchangelog.php?tool=sadxml&rev=" + (File.Exists(mlverfile) ? File.ReadAllText(mlverfile) : "590"));
				// If there's no info, there's no update
				if (msg.Length == 0 && File.Exists(Path.Combine(gameSettings.GamePath, "mods", "SADXModLoader.dll")))
					return null;
				string targetver = msg[12] == ' ' ? msg.Substring(9, 3) : msg.Substring(9, 4);
				// Get request
				WebRequest req = WebRequest.Create(loaderUpdateUrl);
				req.Method = "HEAD";
				using (WebResponse resp = req.GetResponse())
				{
					// Get size
					long size = GetDownloadSize(resp);
					// If the URL doesn't work, output an error
					if (size == 0)
					{
						MessageBox.Show(parent, "Could not retrieve SADX Mod Loader update information: size is 0", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
					// Get last modified date
					DateTime modifiedDate = GetDownloadDate((HttpWebResponse)resp);
					return new DownloadItem()
					{
						Name = "SADX Mod Loader",
						Authors = "MainMemory && x-hax",
						Version = targetver,
						ReleaseDate = modifiedDate,
						UploadDate = modifiedDate,
						DownloadSize = size,
						FileCount = 1,
						HomepageUrl = "https://github.com/X-Hax/sadx-mod-loader",
						DownloadUrl = loaderUpdateUrl,
						ReleaseName = "Revision " + targetver,
						ReleaseTag = "",
						Description = "The main tool that makes modding possible. Always keep it up to date.",
						Files = new List<Tuple<string, string, long>> { new Tuple<string, string, long>("Download", "SADXModLoader.7z", size) },
						Changelog = msg.Replace("\n", "\r\n"),
						Type = DownloadItem.DownloadItemType.Loader
					};
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve SADX Mod Loader update information: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>Retrieves a download for an update for the Steam launcher from a direct link (null if no update).</summary>
		public static DownloadItem CheckLauncherUpdates(Form parent)
		{
			long size = 0;
			DateTime modifiedDate = DateTime.Now;
			string appLauncherExe = Path.Combine(Path.Combine(gameSettings.GamePath, "AppLauncher.exe"));
			if (File.Exists(appLauncherExe))
			{
				string localcrc = "AppLauncher.exe," + Force.Crc32.Crc32Algorithm.Compute(File.ReadAllBytes(appLauncherExe)).ToString("X") + "\r\n";
				string remotecrc = webClient.DownloadString("https://dcmods.unreliable.network/owncloud/data/PiKeyAr/files/AppLauncher/AppLauncher.crc");
				// If CRC matches, exit
				if (localcrc == remotecrc)
					return null;
			}
			try
			{
				// Get request
				WebRequest req = WebRequest.Create(launcherUpdateUrl);
				req.Method = "HEAD";
				using (WebResponse resp = req.GetResponse())
				{
					// Get download size
					size = GetDownloadSize(resp);
					// Get last modified date
					modifiedDate = GetDownloadDate(resp);
					// Create a version string
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve SADX Launcher size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			string ver = string.Format("{0}/{1}/{2} {3}:{4}", modifiedDate.Year, modifiedDate.Month, modifiedDate.Day, modifiedDate.Hour, modifiedDate.Minute);
			return new DownloadItem()
			{
				Name = "AppLauncher for Steam",
				Authors = "PkR",
				Version = ver,
				ReleaseDate = modifiedDate,
				UploadDate = modifiedDate,
				DownloadSize = size,
				FileCount = 1,
				HomepageUrl = "https://sadxmodinstaller.unreliable.network/index.php/tools/",
				DownloadUrl = launcherUpdateUrl,
				ReleaseName = "",
				ReleaseTag = "",
				Description = "This tool replaces the Steam version's launcher. It can be used to configure keyboard and gamepad controls.",
				Files = new List<Tuple<string, string, long>> { new Tuple<string, string, long>("Download", "AppLauncher.7z", size) },
				Changelog = "",
				Type = DownloadItem.DownloadItemType.Launcher
			};
		}

		/// <summary>Retrieves a download for an update for SADX Mod Manager Classic from a direct link (null if no update).</summary>
		public static DownloadItem CheckManagerUpdates(Form parent)
		{
			string changelog;
			string mlverfile = Path.Combine(managerAppDataPath, "sadxmanagerver.txt");
			try
			{
				// Read remote and local version info
				string msg_remote = webClient.DownloadString("https://dcmods.unreliable.network/owncloud/data/PiKeyAr/files/sadx-manager-classic/sadxmanagerver.txt");
				string msg_local = File.Exists(mlverfile) ? File.ReadAllText(mlverfile) : "1.00";
				// If there's no difference, there's no update
				if (msg_remote == msg_local && File.Exists(Path.Combine(managerExePath, "SADXModManager.exe")))
					return null;
				// Get request
				WebRequest req = WebRequest.Create(managerUpdateUrl);
				req.Method = "HEAD";
				using (WebResponse resp = req.GetResponse())
				{
					// Get size
					long size = GetDownloadSize(resp);
					// If the URL doesn't work, output an error
					if (size == 0)
					{
						MessageBox.Show(parent, "Could not retrieve SADX Mod Manager Classic update information: size is 0", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
					// Get last modified date
					DateTime modifiedDate = GetDownloadDate(resp);
					try
					{
						changelog = webClient.DownloadString(managerChangelogUrl);
					}
					catch (Exception ex)
					{
						changelog = "Error retrieving Mod Manager Classic changelog: " + ex.Message.ToString();
					}
					return new DownloadItem()
					{
						Name = "SADX Mod Manager Classic",
						Authors = "PkR",
						Version = msg_remote,
						ReleaseDate = modifiedDate,
						UploadDate = modifiedDate,
						DownloadSize = size,
						FileCount = 1,
						HomepageUrl = "https://sadxmodinstaller.unreliable.network/index.php/tools/",
						DownloadUrl = managerUpdateUrl,
						ReleaseName = "",
						ReleaseTag = "",
						Description = "This tool replaces the Steam version's launcher. It can be used to configure keyboard and gamepad controls.",
						Files = new List<Tuple<string, string, long>> { new Tuple<string, string, long>("Download", "SADXModManager.exe", size) },
						Changelog = changelog,
						Type = DownloadItem.DownloadItemType.Manager
					};
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve SADX Mod Manager Classic update information: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>Retrieves a download for an update for the Steam conversion tools from a direct link (null if not requred).</summary>
		public static DownloadItem CheckSteamToolUpdates(Form parent)
		{
			long size = 0;
			DateTime modifiedDate = DateTime.Now;
			MD5 md5 = MD5.Create();
			string sonicexe = Path.Combine(gameSettings.GamePath, "Sonic Adventure DX.exe");
			// Steam
			if (File.Exists(sonicexe))
			{
				byte[] filehash_bytes = md5.ComputeHash(File.ReadAllBytes(sonicexe));
				string filehash = string.Empty;
				foreach (byte item in filehash_bytes)
					filehash += item.ToString("x2");
				// Wrong Steam EXE hash
				if (filehash != "d526786ad2e3967d084c0b3e1f92cb47")
				{
					MessageBox.Show(parent, "Critical error: SADX Steam EXE file has a wrong checksum. Reinstall the game on Steam and try again.", "SADX Mod Manager Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					criticalError = true;
					return null;
				}
			}
			// Not Steam
			else
			{
				sonicexe = Path.Combine(gameSettings.GamePath, "sonic.exe");
				if (File.Exists(sonicexe))
				{
					byte[] filehash_bytes = md5.ComputeHash(File.ReadAllBytes(sonicexe));
					string filehash = string.Empty;
					foreach (byte item in filehash_bytes)
						filehash += item.ToString("x2");
					switch (filehash)
					{
						case "c6d65712475602252bfce53d0d8b7d6f": // US cracked
						case "3cd8ce57f5e1946762e7526a429e572f": // US original
						case "4d9b59aea4ee361e4f25475df1447bfd": // US cracked + manifest
						case "e46580fc390285174acae895a90c5c84": // US cracked SA1 save icon + manifest
						case "b215d5dfc16514c0cc354449c101c7d0": // US cracked SA1 box icon + manifest
						case "f8c0b356519d7c459f7b726d63462791": // US cracked SA1 HD icon + manifest
						case "a35eb183684e3eb964351de391db82e8": // US cracked SADX icon + manifest
							return null;
						case "ad6388fa1a703e90d0fc693c5cdb4c5d": // EU original
						case "57f987014504e0f0dcfc154dfd48fead": // EU Best Buy
						case "9c1184502ad6d1bed8b2833822e3a477": // EU Sonic PC Collection
						case "6b3c7a0013cbfd9b12c3765e9ba3a73e": // KR
							break;
						case "6e2e64ebf62787af47ed813221040898": // JP
						case "1b65b196137b5a853d781ba93a3046a2": // Sold Out
						default:
							MessageBox.Show(parent, string.Format(sonicExeMd5Error, filehash), "SADX Mod Manager Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							criticalError = true;
							return null;
					}
				}
				else
				// No EXE found
				{
					MessageBox.Show(parent, "Critical error: no SADX executable was found.", "SADX Mod Manager Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					criticalError = true;
					return null;
				}
			}
			try
			{
				// Get request
				WebRequest req = WebRequest.Create(steamToolsUpdateUrl);
				req.Method = "HEAD";
				using (WebResponse resp = req.GetResponse())
				{
					// Get download size
					size = GetDownloadSize(resp);
					// Get last modified date
					modifiedDate = GetDownloadDate(resp);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve Steam conversion tools size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// Create a version string
			string ver = string.Format("{0}/{1}/{2} {3}:{4}", modifiedDate.Year, modifiedDate.Month, modifiedDate.Day, modifiedDate.Hour, modifiedDate.Minute);
			return new DownloadItem()
			{
				Required = true,
				Name = "Conversion Tools",
				Authors = "PkR",
				Version = ver,
				ReleaseDate = modifiedDate,
				UploadDate = modifiedDate,
				DownloadSize = size,
				FileCount = 1,
				HomepageUrl = "https://sadxmodinstaller.unreliable.network/index.php/tools/",
				DownloadUrl = steamToolsUpdateUrl,
				ReleaseName = "",
				ReleaseTag = "",
				Description = "These tools will convert your SADX installation for Mod Loader compatibility.",
				Files = new List<Tuple<string, string, long>> { new Tuple<string, string, long>("Download", "steam_tools.7z", size) },
				Changelog = "",
				Type = DownloadItem.DownloadItemType.SteamTools
			};
		}

		/// <summary>Retrieves a download for Visual C++ runtime (null if no update).</summary>
		public static DownloadItem CheckVisualCppRuntimeUpdate(Form parent, string registryKey, string downloadUrl, string version)
		{
			long size = 0;
			DateTime modifiedDate = DateTime.Now;
			RegistryKey key = GetRegistryKey(registryKey);
			if (key != null)
			{
				int val = (int)key.GetValue("Installed", 0);
				if (val == 1)
					return null;
			}
			try
			{
				// Get request
				WebRequest req = WebRequest.Create(downloadUrl);
				req.Method = "HEAD";
				using (WebResponse resp = req.GetResponse())
				{
					// Get download size
					size = GetDownloadSize(resp);
					// Get last modified date
					modifiedDate = GetDownloadDate(resp);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve Visual C++ runtime size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return new DownloadItem()
			{
				Name = "Visual C++ Runtime",
				Authors = "Microsoft",
				Version = version,
				ReleaseDate = modifiedDate,
				UploadDate = modifiedDate,
				DownloadSize = size,
				FileCount = 1,
				HomepageUrl = "https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170/",
				DownloadUrl = downloadUrl,
				ReleaseName = "",
				ReleaseTag = "",
				Description = "These runtimes are required for C++ programs and DLLs compiled with Visual Studio. You need them for mods to work.",
				Files = new List<Tuple<string, string, long>> { new Tuple<string, string, long>("Download", GetFilenameFromUrl(downloadUrl), size) },
				Changelog = "",
				Type = DownloadItem.DownloadItemType.VisualCppRuntime
			};
		}

		/// <summary>Retrieves a list of downloads for Visual C++ runtimes (empty list if no update).</summary>
		public static List<DownloadItem> CheckVisualCRuntimeUpdates(Form parent)
		{
			List<DownloadItem> result = new List<DownloadItem>();
			result.Add(CheckVisualCppRuntimeUpdate(parent, "SOFTWARE\\Microsoft\\VisualStudio\\10.0\\VC\\VCRedist\\x86", "https://download.microsoft.com/download/C/6/D/C6D0FD4E-9E53-4897-9B91-836EBA2AACD3/vcredist_x86.exe", "2010 SP1"));
			result.Add(CheckVisualCppRuntimeUpdate(parent, "SOFTWARE\\Microsoft\\VisualStudio\\11.0\\VC\\Runtimes\\x86", "https://download.microsoft.com/download/1/6/B/16B06F60-3B20-4FF2-B699-5E9B7962F9AE/VSU_4/vcredist_x86.exe", "2012"));
			result.Add(CheckVisualCppRuntimeUpdate(parent, "SOFTWARE\\Microsoft\\VisualStudio\\12.0\\VC\\Runtimes\\x86", "http://download.microsoft.com/download/0/5/6/056dcda9-d667-4e27-8001-8a0c6971d6b1/vcredist_x86.exe", "2013"));
			result.Add(CheckVisualCppRuntimeUpdate(parent, "SOFTWARE\\Microsoft\\VisualStudio\\14.0\\VC\\Runtimes\\x86", "https://aka.ms/vs/17/release/vc_redist.x86.exe", "2015-2022"));
			return result;
		}

		/// <summary>Returns a download item for DirectX 9.0c 2010 end-user runtime.</summary>
		public static DownloadItem GetDirectXDownload(Form parent)
		{
			long size = 0;
			DateTime modifiedDate = DateTime.Now;
			string downloadUrl = "https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe";
			try
			{
				// Get request
				WebRequest req = WebRequest.Create(downloadUrl);
				req.Method = "HEAD";
				using (WebResponse resp = req.GetResponse())
				{
					// Get download size
					size = GetDownloadSize(resp);
					// Get last modified date
					modifiedDate = GetDownloadDate(resp);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve DirectX 9.0c runtime size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return new DownloadItem()
			{
				Name = "DirectX",
				Authors = "Microsoft",
				Version = "9.0c",
				ReleaseDate = modifiedDate,
				UploadDate = modifiedDate,
				DownloadSize = size,
				FileCount = 1,
				HomepageUrl = "https://www.microsoft.com/en-us/download/details.aspx?id=35",
				DownloadUrl = downloadUrl,
				ReleaseName = "",
				ReleaseTag = "",
				Description = "Enables Direct3D 9 (and earlier) games to run. This runtime is required to run the base game.",
				Files = new List<Tuple<string, string, long>> { new Tuple<string, string, long>("Download", "dxwebsetup.exe", size) },
				Changelog = "",
				Type = DownloadItem.DownloadItemType.DirectXRuntime
			};
		}

		/// <summary>Retrieves the name of the file from a link.</summary>
		public static string GetFilenameFromUrl(string url)
		{
			Uri uri = new Uri(url);
			string result = uri.Segments.Last();
			if (result.Contains("."))
				return result;
			else
				return string.Empty;
		}

		/// <summary>Extracts .gz streams.</summary>
		public static void ExtractGz(byte[] data, string path)
		{
			MemoryStream sourceFileStream = new MemoryStream(data);
			FileStream destFileStream = File.Create(path);

			GZipStream decompressingStream = new GZipStream(sourceFileStream,
				CompressionMode.Decompress);
			int byteRead;
			while ((byteRead = decompressingStream.ReadByte()) != -1)
			{
				destFileStream.WriteByte((byte)byteRead);
			}

			decompressingStream.Close();
			sourceFileStream.Close();
			destFileStream.Close();
		}

		/// <summary>Returns a 1-click download type from an URL.</summary>
		private static OneClickType GetOneClickDownloadType(string url)
		{
			if (url.Contains("github.com"))
				return OneClickType.GitHub;
			if (url.Contains("gamebanana.com"))
				return OneClickType.GameBanana;
			return OneClickType.DirectLink;
		}

		/// <summary>Parses an URL and returns a DownloadItem for a mod (null if invalid).</summary>
		/// <param name="uri">URL to parse</param>
		/// <param name="parent">Form where URL parsing takes place</param>
		public static DownloadItem HandleUri(string uri, Form parent)
		{
			// Variables used to create the mod download
			string name = "";
			string author = "";
			string info = "";
			string desc = "";
			long size = 0; // Download size
			DateTime date = DateTime.Now; // Upload date
			Uri url; // Temporary link
			ModInfo dummyInfo; // ModInfo for download
			string dummyPath; // Destination mod folder
			ModDownload download;

			// Activate original form if it's out of focus
			if (parent.WindowState == FormWindowState.Minimized)
				parent.WindowState = FormWindowState.Normal;
			parent.Activate();

			// Split the URL
			string[] split;
			if (uri.Contains("sadxmm:"))
				split = uri.Substring("sadxmm:".Length).Split(',');
			else
				split = uri.Split(',');
			url = new Uri(split[0]);
			Dictionary<string, string> fields = new Dictionary<string, string>(split.Length - 1);
			for (int i = 1; i < split.Length; i++)
			{
				int ind = split[i].IndexOf(':');
				fields.Add(split[i].Substring(0, ind).ToLowerInvariant(), split[i].Substring(ind + 1));
			}			
			// Get link type
			OneClickType linkType = GetOneClickDownloadType(uri);

			// Parse link
			switch (linkType)
			{
				case OneClickType.GameBanana:
					GameBananaItem gbi;
					string itemType = "";
					long itemId = 0;
					try
					{
						if (fields.ContainsKey("gb_itemtype") && fields.ContainsKey("gb_itemid"))
						{
							itemType = fields["gb_itemtype"];
							itemId = long.Parse(fields["gb_itemid"]);
						}
						else
						{
							bool found = false;
							foreach (KeyValuePair<string, string> pair in GameBananaItemTypes)
							{
								if (uri.Contains(pair.Key))
								{
									string[] uriparts = uri.TrimEnd('/').Split('/');
									itemType = pair.Value;
									itemId = long.Parse(uriparts[uriparts.Length - 1]);
									found = true;
									break;
								}
							}
							if (!found)
							{
								MessageBox.Show(parent,
										$"Unable to find a compatible GameBanana item type for URI: \"{uri}\"",
										"URI Parse Failure",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);
								return null;
							}
						}
						if (string.IsNullOrEmpty(itemType) || itemId == 0)
						{
							MessageBox.Show(parent,
										$"Unable to get GameBanana item type or ID for URI: \"{uri}\"",
										"URI Parse Failure",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);
							return null;
						}
						gbi = GameBananaItem.Load(itemType, itemId);
						if (gbi is null)
							throw new Exception("GameBananaItem was unexpectedly null");
						name = gbi.Name;
						author = gbi.OwnerName;
						info = gbi.Body;
						desc = gbi.Subtitle;
						url = new Uri(gbi.Files.First().Value.DownloadUrl);
					}
					catch (Exception ex)
					{
						MessageBox.Show(parent,
										$"Malformed One-Click Install URI \"{uri}\" caused parse failure:\n{ex.Message}",
										"URI Parse Failure",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);
						return null;
					}
					break;
				case OneClickType.GitHub:
					string assetName = GetFilenameFromUrl(uri);
					string repoName = string.Empty;
					string[] githubsplit = uri.Replace("sadxmm:", "").Split('/');
					if (githubsplit.Length >= 5 && githubsplit[2].Contains("github.com"))
						repoName = githubsplit[3] + "/" + githubsplit[4];
					else
						throw new Exception("Unable to retrieve GitHub info from link: " + uri);

					List<GitHubRelease> releases;
					// Get name and author
					string url_repo = "https://api.github.com/repos/" + repoName;
					string url_releases = "https://api.github.com/repos/" + repoName + "/releases";
					string text_repo = string.Empty;
					string text_releases = string.Empty;
					try
					{
						text_repo = webClient.DownloadString(url_repo);
						text_releases = webClient.DownloadString(url_releases);
					}
					catch (Exception e)
					{
						MessageBox.Show(parent, string.Format("Error downloading GitHub repo data from\n`{0}`.\n{1}\n\nIf this is a 403 error, you may be hitting a rate limit. Wait a while and try again.", url_repo, e.Message.ToString()), "SADX Mod Manager Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return null;
					}
					GitHubRepo repo = JsonConvert.DeserializeObject<GitHubRepo>(text_repo);
					name = repo.Name;
					author = repo.Owner.Name;
					desc = repo.Description;

					// Override name/author if they are specified in the URL
					if (fields.ContainsKey("name") && fields.ContainsKey("author"))
					{
						name = Uri.UnescapeDataString(fields["name"]);
						author = Uri.UnescapeDataString(fields["author"]);
					}

					releases = JsonConvert.DeserializeObject<List<GitHubRelease>>(text_releases)
					.Where(x => !x.Draft && !x.PreRelease).ToList();
					if (releases == null || releases.Count == 0)
						throw new Exception("No GitHub releases found for URL " + uri);

					GitHubRelease latestRelease = null;
					GitHubAsset latestAsset = null;

					DateTime dateCheck = DateTime.MinValue;

					foreach (GitHubRelease release in releases)
					{
						GitHubAsset asset;
						if (string.IsNullOrEmpty(assetName) || release.Assets.Length == 1)
							asset = release.Assets[0];
						else asset = release.Assets
							.FirstOrDefault(x => x.Name.Equals(assetName, StringComparison.OrdinalIgnoreCase));

						if (asset == null)
							continue;

						DateTime uploaded = DateTime.Parse(asset.Uploaded, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
						if (uploaded > dateCheck)
						{
							latestRelease = release;
							latestAsset = asset;
							dateCheck = uploaded;
						}
					}

					if (latestRelease == null || latestAsset == null)
					{
						throw new Exception("No releases with matching asset could be found in release(s).");
					}

					string body = Regex.Replace(latestRelease.Body, "(?<!\r)\n", "\r\n");

					dummyInfo = new ModInfo
					{
						Name = name,
						Author = author,
						Description = desc
					};

					dummyPath = dummyInfo.Name;

					if (fields.ContainsKey("folder"))
						dummyPath = fields["folder"];

					foreach (char c in Path.GetInvalidFileNameChars())
					{
						dummyPath = dummyPath.Replace(c, '_');
					}

					dummyPath = Path.Combine("mods", dummyPath);

					download = new ModDownload(dummyInfo, dummyPath, latestAsset.DownloadUrl, info, size);

					DownloadItem item = new DownloadItem(download);
					item.HomepageUrl = "https://github.com/" + repoName;
					item.ReleaseTag = latestRelease.TagName;
					item.Version = latestRelease.TagName;
					item.ReleaseDate = DateTime.Parse(latestRelease.Published, DateTimeFormatInfo.InvariantInfo);
					item.UploadDate = DateTime.Parse(latestAsset.Uploaded, DateTimeFormatInfo.InvariantInfo);
					item.DownloadSize = latestAsset.Size;
					item.Changelog = latestRelease.Body;
					return item;
				case OneClickType.DirectLink:
				default:
					// Add name/author if they are included in the URI
					if (fields.ContainsKey("name") && fields.ContainsKey("author"))
					{
						name = Uri.UnescapeDataString(fields["name"]);
						author = Uri.UnescapeDataString(fields["author"]);
					}
					// If not, the direct link can't be processed
					if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author))
					{
						MessageBox.Show(parent,
										$"One-Click Install direct link \"{uri}\" did not contain 'name' and/or 'author' fields.",
										"URI Parse Failure",
										MessageBoxButtons.OK,
										MessageBoxIcon.Error);
						return null;
					}
					break;
			}

			dummyInfo = new ModInfo
			{
				Name = name,
				Author = author,
			};

			dummyPath = dummyInfo.Name;

			if (fields.ContainsKey("folder"))
				dummyPath = fields["folder"];

			foreach (char c in Path.GetInvalidFileNameChars())
			{
				dummyPath = dummyPath.Replace(c, '_');
			}

			dummyPath = Path.Combine("mods", dummyPath);

			try
			{
				// Get request
				WebRequest req = WebRequest.Create(url.AbsoluteUri);
				req.Method = "HEAD";

				using (WebResponse resp = req.GetResponse())
				{
					size = GetDownloadSize(resp);
					date = GetDownloadDate(resp);
				}
				download = new ModDownload(dummyInfo, dummyPath, url.AbsoluteUri, info, size);

				DownloadItem item = new DownloadItem(download);
				item.GameBanana = linkType == OneClickType.GameBanana;
				item.UploadDate = date;
				item.Description = desc;
				return item;
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent,
									$"1-click download failed:\n{ex.Message}",
									"SADX Mod Manager",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				return null;
			}
		}

		/// <summary>Imports settings from SADXModLoader.ini.</summary>
		public static void ImportOldLoaderSettings(SADXLoaderInfo info)
		{
			// Debug settings
			gameSettings.DebugSettings.EnableDebugScreen = info.DebugScreen;
			gameSettings.DebugSettings.EnableDebugCrashLog = info.DebugCrashLog;
			gameSettings.DebugSettings.EnableDebugConsole = info.DebugConsole;
			gameSettings.DebugSettings.EnableDebugFile = info.DebugFile;
			// Test Spawn settings
			gameSettings.TestSpawn.UseCharacter = info.TestSpawnCharacter != -1;
			gameSettings.TestSpawn.UseSave = info.TestSpawnSaveID != -1;
			gameSettings.TestSpawn.UseGameMode = info.TestSpawnGameMode != -1;
			gameSettings.TestSpawn.ActIndex = info.TestSpawnAct;
			gameSettings.TestSpawn.LevelIndex = info.TestSpawnLevel;
			gameSettings.TestSpawn.CharacterIndex = info.TestSpawnCharacter;
			gameSettings.TestSpawn.GameTextLanguage = info.TextLanguage;
			gameSettings.TestSpawn.GameVoiceLanguage = info.VoiceLanguage;
			gameSettings.TestSpawn.GameModeIndex = info.TestSpawnGameMode;
			gameSettings.TestSpawn.EventIndex = info.TestSpawnEvent;
			gameSettings.TestSpawn.Rotation = info.TestSpawnRotation;
			managerConfig.AngleHex = info.TestSpawnRotationHex;
			gameSettings.TestSpawn.SaveIndex = info.TestSpawnSaveID;
			gameSettings.TestSpawn.XPosition = (float)info.TestSpawnX;
			gameSettings.TestSpawn.YPosition = (float)info.TestSpawnY;
			gameSettings.TestSpawn.ZPosition = (float)info.TestSpawnZ;
			// Mods
			gameSettings.EnabledMods = info.Mods;
			// Codes
			gameSettings.EnabledCodes = info.EnabledCodes;
			// Patches
			gameSettings.EnabledGamePatches = new List<string>();
			//if (info.CCEF)
				//gameSettings.EnabledGamePatches.Add("")
		}
	}
}