using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using ModManagerCommon;
using SADXModManager.Forms;

namespace SADXModManager
{
	static class Program
	{
		public static Form primaryForm;
		private const string pipeName = "sadx-mod-manager";
		private const string protocol = "sadxmm:";
		private static readonly Mutex mutex = new Mutex(true, pipeName);
		public static UriQueue UriQueue;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Utils.CheckOldFilesCritical(null, System.Environment.CurrentDirectory);
			Init();
			RealMain(args); // Needed to split for assembly resolving
		}

		static void Init()
		{
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}

		static void RealMain(string[] args)
		{
			// Try to use TLS 1.2
			try { ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; } catch { }
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			// URL handler
			if (args.Length > 0 && args[0] == "urlhandler")
			{
				using (var hkcr = Registry.ClassesRoot)
				using (var key = hkcr.CreateSubKey("sadxmm"))
				{
					key.SetValue(null, "URL:SADX Mod Manager Protocol");
					key.SetValue("URL Protocol", string.Empty);
					using (var k2 = key.CreateSubKey("DefaultIcon"))
						k2.SetValue(null, Application.ExecutablePath + ",1");
					using (var k3 = key.CreateSubKey("shell"))
					using (var k4 = k3.CreateSubKey("open"))
					using (var k5 = k4.CreateSubKey("command"))
						k5.SetValue(null, $"\"{Application.ExecutablePath}\" \"%1\"");
				}
				return;
			}

			// Check if already running
			bool alreadyRunning;
			try { alreadyRunning = !mutex.WaitOne(0, true); }
			catch (AbandonedMutexException) { alreadyRunning = false; }

			// Update EXE
			if (args.Length > 1 && args[0] == "update")
			{
				if (alreadyRunning)
					try { mutex.WaitOne(); }
					catch (AbandonedMutexException) { }
				alreadyRunning = false;
				Thread.Sleep(300);
				DialogResult result = DialogResult.Cancel;
				int attempt = 0;
				do
				{
					try
					{
						string finalpath = args[1].Replace("\"", "");
						// Copy Manager.exe
						File.Copy(Application.ExecutablePath, Path.Combine(finalpath, "SADXModManager.exe"), true);
						// Delete old Loader/Manager files if they exist
						Utils.DeleteOldFiles(null, finalpath);
						// Get path to sadxmanagerver.txt
						string destAppDataPath = Path.Combine(finalpath, "mods", ".modloader");
						// Copy sadxmanagerver.txt
						File.Copy(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "sadxmanagerver.txt"), Path.Combine(destAppDataPath, "sadxmanagerver.txt"), true);
						// Cleanup
						Process.Start(Path.Combine(finalpath, "SADXModManager.exe"), "clean \"" + AppDomain.CurrentDomain.BaseDirectory + "\"");
						Environment.Exit(0);
					}
					catch (Exception ex)
					{
						result = DialogResult.Retry;
						attempt++;
						if (attempt > 10)
							result = MessageBox.Show(null, string.Format("Unable to update SADX Mod Manager: {0}. Try again?", ex.Message.ToString()), "SADX Mod Manager Update Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					}
				}
				while (result == DialogResult.Retry);
				return;
			}

			// Clean update
			if (args.Length > 1 && args[0] == "clean")
			{
				if (alreadyRunning)
					try { mutex.WaitOne(); }
					catch (AbandonedMutexException) { }
				alreadyRunning = false;
				DialogResult result = DialogResult.Cancel;
				int attempt = 0;
				do
				{
					try
					{
						Thread.Sleep(300);
						string cleanpath = args[1].Replace("\"", "");
						Directory.Delete(cleanpath.Replace("\"", ""), true);
					}
					catch (Exception ex)
					{
						attempt++;
						result = DialogResult.Retry;
						if (attempt > 10)
							result = MessageBox.Show(null, string.Format("Unable to clean up the update folder: {0}. Try again?", ex.Message.ToString()), "SADX Mod Manager Update Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
					}
				}
				while (result == DialogResult.Retry);
			}
			
			if (!alreadyRunning)
			{
				UriQueue = new UriQueue(pipeName);
			}

			List<string> uris = args
				.Where(x => x.Length > protocol.Length && x.StartsWith(protocol, StringComparison.Ordinal))
				.ToList();

			if (uris.Count > 0)
			{
				using (var pipe = new NamedPipeClientStream(".", pipeName, PipeDirection.Out))
				{
					pipe.Connect();

					var writer = new StreamWriter(pipe);
					foreach (string s in uris)
					{
						writer.WriteLine(s);
					}
					writer.Flush();
				}
			}

			if (alreadyRunning)
			{
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// Detect if running for the first time
			// Set the base folder
			string exePath = AppDomain.CurrentDomain.BaseDirectory;
			// Locate the manager data folder (portable mode or otherwise)
			bool newdata = Directory.Exists(Path.Combine(exePath, "mods", ".modloader"));
			bool portable = Directory.Exists(Path.Combine(exePath, "SAManager"));
			bool appdata = Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SAManager"));
			bool legacy = File.Exists(Path.Combine(exePath, "mods", "SADXModLoader.ini"));
			if (!newdata && !portable && !appdata && !legacy)
				primaryForm = new InstallationWizard();
			else
				primaryForm = new MainForm();
			Application.Run(primaryForm);
			UriQueue.Close();
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			var executingAssembly = Assembly.GetExecutingAssembly();
			var assemblyName = new AssemblyName(args.Name);

			var path = assemblyName.Name + ".dll";
			if (!assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture))
			{
				path = $"{assemblyName.CultureInfo}\\${path}";
			}

			using (var stream = executingAssembly.GetManifestResourceStream(path))
			{
				if (stream == null)
					return null;

				var assemblyRawBytes = new byte[stream.Length];
				stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
				return Assembly.Load(assemblyRawBytes);
			}
		}

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			if (primaryForm != null)
			{
				Exception ex = (Exception)e.ExceptionObject;
				string errDesc = "SADX Mod Manager has crashed with the following error:\n" + ex.GetType().Name + ".\n\n" +
					"If you wish to report a bug, please include the following in your report:";
				ErrorDialog report = new ErrorDialog("SADX Mod Manager", errDesc, ex.ToString() + "\n\n" + ex.Message.ToString());
				DialogResult dgresult = report.ShowDialog(primaryForm);
				switch (dgresult)
				{
					case DialogResult.Abort:
					case DialogResult.OK:
						Environment.Exit(0);
						break;
				}
			}
			else
			{
				string logPath = System.IO.Path.Combine(Environment.CurrentDirectory, "SADXModManager.log");
				if (!Directory.Exists(Path.GetDirectoryName(logPath)))
					Directory.CreateDirectory(Path.GetDirectoryName(logPath));
				File.WriteAllText(logPath, e.ExceptionObject.ToString());
				MessageBox.Show("Unhandled Exception " + e.ExceptionObject.GetType().Name + "\nLog file has been saved to:\n" + logPath + ".", "SADX Mod Manager Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}