using Microsoft.Win32;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SADXModManager.Forms
{
	public partial class InstallationWizard : Form
	{
		public InstallationWizard()
		{
			InitializeComponent();
			Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
			pictureBoxManagerIcon.Image = Icon.ToBitmap();
			textBoxGameFolder.Text = LocateGameFolder();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		public RegistryKey GetRegistryKey(string key)
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

		public string LocateGameFolder()
		{
			string result = "";
			
			RegistryKey key;
			// Steam
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 71250");
			if (key != null)
			{
				string val = (string)key.GetValue("InstallLocation", "");
				if (val != null && val.Length > 0)
				{
					if (File.Exists(Path.Combine(val, "Sonic Adventure DX.exe")))
						return val;
					else if (File.Exists(Path.Combine(val, "sonic.exe")))
						return val;
				}
			}
			// SADX 2004
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\SONICADVDX");
			if (key != null)
			{
				string val = (string)key.GetValue("UninstallString", "");
				if (val != null && val.Length > 12)
				{
					string path = val.Substring(0, val.Length - 12);
					if (File.Exists(Path.Combine(path, "Sonic Adventure DX.exe")))
						return path;
					else if (File.Exists(Path.Combine(path, "sonic.exe")))
						return path;
				}
			}
			// Dreamcast Collection (original)
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\SEGA\\Dreamcast Collection");
			if (key != null)
			{
				string val = (string)key.GetValue("DisplayIcon", "");
				if (val != null && val.Length > 13)
				{
					string path = val.Substring(0, val.Length - 13) + "\\Sonic Adventure DX";
					if (File.Exists(Path.Combine(path, "Sonic Adventure DX.exe")))
						return path;
					else if (File.Exists(Path.Combine(path, "sonic.exe")))
						return path;
				}
			}
			// Dreamcast Collection (remastered)
			key = GetRegistryKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Dreamcast Collection Remastered_is1");
			if (key != null)
			{
				string val = (string)key.GetValue("Inno Setup: App Path", "");
				if (val != null && val.Length > 0)
				{
					string path = val + "\\Sonic Adventure DX";
					if (File.Exists(Path.Combine(path, "Sonic Adventure DX.exe")))
						return path;
					else if (File.Exists(Path.Combine(path, "sonic.exe")))
						return path;
				}
			}
			return result;
		}

		bool ValidateGameFolder(string path)
		{
			return File.Exists(Path.Combine(path, "sonic.exe")) || File.Exists(Path.Combine(path,"Sonic Adventure DX.exe"));
		}

		private void textBoxGameFolder_TextChanged(object sender, EventArgs e)
		{
			buttonInstall.Enabled = ValidateGameFolder(textBoxGameFolder.Text);
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog
			{
				Title = "Select the location of sonic.exe",
				InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
				Filter = "SADX EXE|sonic.exe;Sonic Adventure DX.exe",
				AutoUpgradeEnabled = true,
				CheckFileExists = true,
				CheckPathExists = true,
				Multiselect = false,
				RestoreDirectory = true
			})
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					textBoxGameFolder.Text = Path.GetDirectoryName(dialog.FileName);
				}
			}
		}

		private void pictureBoxManagerIcon_Click(object sender, EventArgs e)
		{
			MessageBox.Show(this, "Ты пидор.");
		}

		private void buttonInstall_Click(object sender, EventArgs e)
		{
			string managerExePath = AppDomain.CurrentDomain.BaseDirectory;
			string managerAppDataPath = Path.GetFullPath(radioButtonGameFolder.Checked ? Path.Combine(managerExePath, "SAManager") : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SAManager"));
			Directory.CreateDirectory(managerAppDataPath);

		}
	}
}
