using System.ComponentModel;
using IniFile;

// SDLconfig.ini in SAManager\extlib\SDL2 or config.ini in the input mod

namespace SADXModManager.DataClasses
{
	public class ControllerConfig
	{
		[IniAlwaysInclude]
		[DefaultValue(100)]
		public int TriggerThreshold; // 0-32767

		[IniAlwaysInclude]
		[DefaultValue(true)]
		public bool RadialL;

		[IniAlwaysInclude]
		[DefaultValue(false)]
		public bool RadialR;

		[IniAlwaysInclude]
		[DefaultValue(false)]
		public bool MegaRumble;

		[IniAlwaysInclude]
		[DefaultValue(7849)]
		public int DeadzoneL; // 0-32767

		[IniAlwaysInclude]
		[DefaultValue(8689)]
		public int DeadzoneR;

		[IniAlwaysInclude]
		[DefaultValue(0)]
		public int RumbleMinTime; // 0-32767

		[IniAlwaysInclude]
		[DefaultValue(1.0f)]
		public float RumbleFactor; // 0 to 1

		[DefaultValue("00000000000000000000000000000000")]
		public string GUID;
	}

	public class MainConfig
	{
		[IniAlwaysInclude]
		[DefaultValue(0)]
		public int KeyboardPlayer;

		[IniAlwaysInclude]
		[DefaultValue(false)]
		public bool DisableMouse;
	}

	public class KeyboardConfig
	{
		// Analog 1

		[IniAlwaysInclude]
		[IniName("-leftx")]
		public int LeftXMinus;

		[IniAlwaysInclude]
		[IniName("+leftx")]
		public int LeftXPlus;

		[IniAlwaysInclude]
		[IniName("-lefty")]
		public int LeftYMinus;

		[IniAlwaysInclude]
		[IniName("+lefty")]
		public int LeftYPlus;

		// Analog 2

		[IniAlwaysInclude]
		[IniName("-rightx")]
		public int RightXMinus;

		[IniAlwaysInclude]
		[IniName("+rightx")]
		public int RightXPlus;

		[IniAlwaysInclude]
		[IniName("-righty")]
		public int RightYMinus;

		[IniAlwaysInclude]
		[IniName("+righty")]
		public int RightYPlus;

		// Triggers

		[IniAlwaysInclude]
		[IniName("lefttrigger")]
		public int LeftTrigger;

		[IniAlwaysInclude]
		[IniName("righttrigger")]
		public int RightTrigger;

		// D-Pad

		[IniAlwaysInclude]
		[IniName("dpleft")]
		public int DPadLeft;

		[IniAlwaysInclude]
		[IniName("dpright")]
		public int DPadRight;

		[IniAlwaysInclude]
		[IniName("dpup")]
		public int DPadUp;

		[IniAlwaysInclude]
		[IniName("dpdown")]
		public int DPadDown;

		// Buttons

		[IniAlwaysInclude]
		[IniName("a")]
		public int ButtonA;

		[IniAlwaysInclude]
		[IniName("b")]
		public int ButtonB;

		[IniAlwaysInclude]
		[IniName("x")]
		public int ButtonX;

		[IniAlwaysInclude]
		[IniName("y")]
		public int ButtonY;

		[IniAlwaysInclude]
		[IniName("start")]
		public int ButtonStart;

		[IniAlwaysInclude]
		[IniName("leftshoulder")]
		public int ButtonLeftShoulder;

		[IniAlwaysInclude]
		[IniName("rightshoulder")]
		public int ButtonRightShoulder;

		[IniAlwaysInclude]
		[IniName("back")]
		public int ButtonBack;

		[IniAlwaysInclude]
		[IniName("leftstick")]
		public int ButtonLeftStick;

		[IniAlwaysInclude]
		[IniName("rightstick")]
		public int ButtonRightStick;
	}

	public class SDLConfigIni
	{
		[IniAlwaysInclude]
		[IniName("Config")]
		public MainConfig Config;

		[IniAlwaysInclude]
		[IniName("Keyboard")]
		public KeyboardConfig KeyboardLayout1;

		[IniName("Keyboard 2")]
		public KeyboardConfig KeyboardLayout2;

		[IniName("Keyboard 3")]
		public KeyboardConfig KeyboardLayout3;

		[IniName("Controller 1")]
		public ControllerConfig Controller1;

		[IniName("Controller 2")]
		public ControllerConfig Controller2;

		[IniName("Controller 3")]
		public ControllerConfig Controller3;

		[IniName("Controller 4")]
		public ControllerConfig Controller4;

		[IniName("Controller 5")]
		public ControllerConfig Controller5;

		[IniName("Controller 6")]
		public ControllerConfig Controller6;

		[IniName("Controller 7")]
		public ControllerConfig Controller7;

		[IniName("Controller 8")]
		public ControllerConfig Controller8;
	}
}