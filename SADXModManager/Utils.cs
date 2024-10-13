using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using SADXModManager.DataClasses;
using static SADXModManager.Variables;

namespace SADXModManager
{
	public static class Utils
	{
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
		public static long GetDownloadSize(string url)
		{
			long result = 0;
			WebRequest req = WebRequest.Create(url);
			req.Method = "HEAD";
			using (WebResponse resp = req.GetResponse())
			{
				if (long.TryParse(resp.Headers.Get("Content-Length"), out long contentLength))
				{
					result = contentLength;
				}
			}
			return result;
		}

		/// <summary>Makes a WebRequest to retrieve the modified date of a download.</summary>
		public static DateTime GetDownloadDate(string url)
		{
			// Get last modified date
			WebRequest req = WebRequest.Create(url);
			using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
				return res.LastModified;
		}

		/// <summary>Retrieves a download for an update for SADX Mod Loader from direct links (null if no update).</summary>
		public static DownloadItem CheckLoaderUpdates(Form parent)
		{
			string mlverfile = Path.Combine(managerAppDataPath, "sadxmlver.txt");
			try
			{
				// Read version info
				string msg = webClient.DownloadString("http://mm.reimuhakurei.net/toolchangelog.php?tool=sadxml&rev=" + (File.Exists(mlverfile) ? File.ReadAllText(mlverfile) : "590"));
				// If there's no info, there's no update
				if (msg.Length == 0 && File.Exists(Path.Combine(gameSettings.GamePath, "mods", "SADXModLoader.dll")))
					return null;
				string targetver = msg[12] == ' ' ? msg.Substring(9, 3) : msg.Substring(9, 4);
				long size = GetDownloadSize(loaderUpdateUrl);
				// If the URL doesn't work, output an error
				if (size == 0)
				{
					MessageBox.Show(parent, "Could not retrieve SADX Mod Loader update information: size is 0", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}
				// Get last modified date
				DateTime modifiedDate = GetDownloadDate(loaderUpdateUrl);
				return new DownloadItem("Mod Loader", loaderUpdateUrl, size, msg.Replace("\n", "\r\n"), DownloadItem.DownloadItemType.Loader, targetver, modifiedDate);
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
				// Get download size
				size = GetDownloadSize(launcherUpdateUrl);
				// Get last modified date
				modifiedDate = GetDownloadDate(launcherUpdateUrl);
				// Create a version string
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve SADX Launcher size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			string ver = string.Format("{0}/{1}/{2} {3}:{4}", modifiedDate.Year, modifiedDate.Month, modifiedDate.Day, modifiedDate.Hour, modifiedDate.Minute);
			return new DownloadItem("Steam Launcher", launcherUpdateUrl, size, "No changelog available", DownloadItem.DownloadItemType.Launcher, ver, modifiedDate);
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
				// Get size
				long size = GetDownloadSize(managerUpdateUrl);
				// If the URL doesn't work, output an error
				if (size == 0)
				{
					MessageBox.Show(parent, "Could not retrieve SADX Mod Manager Classic update information: size is 0", "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}
				// Get last modified date
				DateTime modifiedDate = GetDownloadDate(managerUpdateUrl);
				try
				{
					changelog = webClient.DownloadString(managerChangelogUrl);
				}
				catch (Exception ex)
				{
					changelog = "Error retrieving Mod Manager Classic changelog: " + ex.Message.ToString();
				}
				return new DownloadItem("Mod Manager Classic", managerUpdateUrl, size, changelog, DownloadItem.DownloadItemType.Manager, msg_remote, modifiedDate);
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
						case "6e2e64ebf62787af47ed813221040898": // JP
						case "ad6388fa1a703e90d0fc693c5cdb4c5d": // EU original
						case "57f987014504e0f0dcfc154dfd48fead": // EU Best Buy
						case "9c1184502ad6d1bed8b2833822e3a477": // EU Sonic PC Collection
						case "6b3c7a0013cbfd9b12c3765e9ba3a73e": // KR
							break;
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
				// Get download size
				size = GetDownloadSize(steamToolsUpdateUrl);
				// Get last modified date
				modifiedDate = GetDownloadDate(steamToolsUpdateUrl);
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve Steam conversion tools size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// Create a version string
			string ver = string.Format("{0}/{1}/{2} {3}:{4}", modifiedDate.Year, modifiedDate.Month, modifiedDate.Day, modifiedDate.Hour, modifiedDate.Minute);
			return new DownloadItem("Conversion Tools", steamToolsUpdateUrl, size, "These tools will convert your SADX installation for Mod Loader compatibility.", DownloadItem.DownloadItemType.SteamTools, ver, modifiedDate);
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
				// Get download size
				size = GetDownloadSize(downloadUrl);
				// Get last modified date
				modifiedDate = GetDownloadDate(downloadUrl);
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve Visual C++ runtime size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return new DownloadItem("Visual C++ Runtime", downloadUrl, size, "No changelog available", DownloadItem.DownloadItemType.VisualCppRuntime, version, modifiedDate);
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
				// Get download size
				size = GetDownloadSize(downloadUrl);
				// Get last modified date
				modifiedDate = GetDownloadDate(downloadUrl);
			}
			catch (Exception ex)
			{
				MessageBox.Show(parent, "Could not retrieve DirectX 9.0c runtime size or modified date: " + ex.Message.ToString(), "SADX Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return new DownloadItem("DirectX", downloadUrl, size, "No changelog available", DownloadItem.DownloadItemType.DirectXRuntime, "9.0c", modifiedDate);
		}
	}
}