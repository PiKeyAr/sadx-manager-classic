using IniFile;
using SADXModManager.DataClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace SADXModManager
{
	public class Controller
	{
		public int ControllerID; // 'which' in SDL device events
		public bool Connected;
		public string DeviceName;
		public Guid DeviceGuid;
		public IntPtr Joystick;
		public int[] Axes;
		public bool[] Buttons;
		public byte[] Hats;

		public void Open(int which)
		{
			if (Connected)
				Close();
			Joystick = SDL_JoystickOpen(which);
			if (Joystick == IntPtr.Zero)
			{
				Connected = false;
				return;
			}
			Axes = new int[SDL_JoystickNumAxes(Joystick)];
			Buttons = new bool[SDL_JoystickNumButtons(Joystick)];
			Hats = new byte[SDL_JoystickNumHats(Joystick)];
			DeviceName = SDL_JoystickName(Joystick);
			DeviceGuid = SDL_JoystickGetDeviceGUID(which);
			ControllerID = which;
			Connected = true;
		}

		public void Close()
		{
			if (!Connected)
				return;
			if (Joystick != IntPtr.Zero)
			{
				SDL_GameControllerClose(Joystick);
				Joystick = IntPtr.Zero;
			}
			Axes = null;
			Buttons = null;
			Hats = null;
			DeviceName = "";
			DeviceGuid = new Guid();
			ControllerID = -1;
			Connected = false;
		}

		public void Poll()
		{
			for (int i = 0; i < Axes.Length; i++)
			{
				Axes[i] = SDL_JoystickGetAxis(Joystick, i);
			}
			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i] = SDL_JoystickGetButton(Joystick, i) != 0;
			}
			for (int i = 0; i < Hats.Length; i++)
			{
				Hats[i] = SDL_JoystickGetHat(Joystick, i);
			}
		}

		public int GetBindForButton(SDL_GameControllerButton button)
		{
			return SDL_GameControllerGetBindForButton(Joystick, button).button;
		}

		public int GetBindForAxis(SDL_GameControllerAxis axis)
		{
			return SDL_GameControllerGetBindForAxis(Joystick, axis).axis;
		}
	}

	public static class InputControls
	{
		public static bool UpdateRequired;
		public static Controller[] Controllers;
		public static SDLConfigIni ConfigFile;

		[DllImport("Kernel32.dll")]
		private static extern IntPtr LoadLibrary(string path);

		public static void SDLInit(string managerAppDataPath)
		{
			string configpath = Path.Combine(managerAppDataPath, "extlib", "SDL2", "SDLConfig.ini");
			string dbpath = Path.Combine(managerAppDataPath, "extlib", "SDL2", "gamecontrollerdb.txt");
			if (File.Exists(configpath))
				ConfigFile = IniSerializer.Deserialize<SDLConfigIni>(configpath);
			else
				ConfigFile = new SDLConfigIni();
			LoadLibrary(Path.Combine(managerAppDataPath, "extlib", "SDL2", "SDL2.dll"));
			int res = SDL_Init(SDL_INIT_JOYSTICK | SDL_INIT_GAMECONTROLLER);
			if (res != 0)
				throw new Exception("Error initializing SDL2 library: error code " + res.ToString());
			Controllers = new Controller[8];
			for (int i = 0; i < Controllers.Length; i++)
			{
				Controllers[i] = new Controller();
				Controllers[i].Connected = false;
				Controllers[i].ControllerID = -1;
			}
			if (File.Exists(dbpath))
				SDL_GameControllerAddMappingsFromFile(dbpath);
			Task.Factory.StartNew(SDLLoop);
		}

		public static void SDLLoop()
		{
			while (true)
			{
				int res = SDL_PollEvent(out SDL_Event ev);
				if (res != 0)
				{
					int which = ev.cdevice.which;
					switch (ev.type)
					{
						case SDL_EventType.SDL_JOYDEVICEADDED:
							foreach (Controller controller in Controllers)
							{
								if (!controller.Connected || controller.ControllerID == which)
								{
									controller.Open(which);
									UpdateRequired = true;
									break;
								}
							}
							break;
						case SDL_EventType.SDL_JOYDEVICEREMOVED:
							foreach (Controller controller in Controllers)
							{
								if (controller.Connected && controller.ControllerID == which)
								{
									controller.Close();
									UpdateRequired = true;
									break;
								}
							}
							break;
					}
				}
				SDL_GameControllerUpdate();
				foreach (Controller controller in Controllers)
				{
					if (controller.Connected)
						controller.Poll();
				}
			}
		}
	}
}