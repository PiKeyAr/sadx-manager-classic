using System.Text;

// SDL mapping string like in gamecontrollerdb.txt
namespace SADXModManager.DataClasses
{
	public class SDLBind
	{
		public enum AxisDirection
		{
			Plus = 1,
			Minus = -1
		}

		public enum HatPosition
		{
			Center = 0,
			Up = 1,
			Right = 2,
			Down = 4,
			Left = 8
		}

		public enum SDLBindType
		{
			None,
			Button,
			Axis,
			Hat,
		}
		public SDLBindType Type;
		public int ItemID; // Button, axis or hat ID
		public int ItemValue; // Hat position (1, 2, 4 or 8) or axis direction (1 or -1), not used for buttons

		public SDLBind(string bind)
		{
			switch (bind[0])
			{
				case '+':
				case '-':
					if (bind.Length > 2 && bind[1] == 'a')
					{
						Type = SDLBindType.Axis;
						ItemValue = bind[0] == '+' ? (int)AxisDirection.Plus : (int)AxisDirection.Minus;
						ItemID = int.Parse(bind[2].ToString());
					}
					break;
				case 'b':
					Type = SDLBindType.Button;
					ItemID = int.Parse(bind[1].ToString());
					ItemValue = 0;
					break;
				case 'h':
					Type = SDLBindType.Hat;
					ItemID = int.Parse(bind[1].ToString());
					ItemValue = int.Parse(bind[3].ToString());
					break;
				default:
					Type = SDLBindType.None;
					break;
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			switch (Type)
			{ 
				case SDLBindType.Button:
					sb.Append("b");
					sb.Append(ItemID.ToString());
					break;
				case SDLBindType.Axis:
					sb.Append((AxisDirection)ItemValue == AxisDirection.Minus ? "-" : "+");
					sb.Append("a");
					sb.Append(ItemID.ToString());
					break;
				case SDLBindType.Hat:
					sb.Append("h");
					sb.Append(ItemID.ToString());
					sb.Append(".");
					sb.Append(ItemValue.ToString());
					break;
			}
			return sb.ToString();
		}
	}

	public class SDLMapping
	{
		public string GUID;
		public string Name;
		
		public SDLBind ButtonA;
		public SDLBind ButtonB;
		public SDLBind ButtonBack;
		
		public SDLBind DPadDown;
		public SDLBind DPadLeft;
		public SDLBind DPadRight;
		public SDLBind DPadUp;

		public SDLBind ButtonGuide;
		
		public SDLBind ButtonLeftShoulder;
		public SDLBind ButtonLeftStick;
		public SDLBind TriggerLeft;

		public SDLBind StickLeftXPlus;
		public SDLBind StickLeftYPlus;

		public SDLBind ButtonRightShoulder;
		public SDLBind ButtonRightStick;
		public SDLBind TriggerRight;
		public SDLBind StickRightXPlus;
		public SDLBind StickRightYPlus;

		public SDLBind ButtonStart;
		public SDLBind ButtonX;
		public SDLBind ButtonY;

		public SDLBind StickLeftXMinus;
		public SDLBind StickLeftYMinus;

		public SDLBind StickRightXMinus;
		public SDLBind StickRightYMinus;

		public string Platform;

		public SDLMapping(string mapping)
		{
			string[] fields = mapping.Split(',');
			if (fields.Length < 3)
			{
				Name = "Error";
				return;
			}
			GUID = fields[0];
			Name = fields[1];
			for (int i = 2; i < fields.Length; i++)
			{
				string[] split = fields[i].Split(':');
				if (split.Length != 2)
				{
					Name = "Error";
					return;
				}
				switch (split[0])
				{
					case "platform":
						Platform = split[1];
						break;
					// Buttons
					case "a":
						ButtonA = new SDLBind(split[1]);
						break;
					case "b":
						ButtonB = new SDLBind(split[1]);
						break;
					case "x":
						ButtonX = new SDLBind(split[1]);
						break;
					case "y":
						ButtonY = new SDLBind(split[1]);
						break;
					case "start":
						ButtonStart = new SDLBind(split[1]);
						break;
					case "back":
						ButtonBack = new SDLBind(split[1]);
						break;
					case "guide":
						ButtonGuide = new SDLBind(split[1]);
						break;
					case "leftstick":
						ButtonLeftStick = new SDLBind(split[1]);
						break;
					case "rightstick":
						ButtonRightStick = new SDLBind(split[1]);
						break;
					case "leftshoulder":
						ButtonLeftShoulder = new SDLBind(split[1]);
						break;
					case "rightshoulder":
						ButtonRightShoulder = new SDLBind(split[1]);
						break;
					// Triggers
					case "lefttrigger":
						TriggerLeft = new SDLBind(split[1]);
						break;
					case "righttrigger":
						TriggerRight = new SDLBind(split[1]);
						break;
					// D-Pad
					case "dpdown":
						DPadDown = new SDLBind(split[1]);
						break;
					case "dpleft":
						DPadLeft = new SDLBind(split[1]);
						break;
					case "dpup":
						DPadUp = new SDLBind(split[1]);
						break;
					case "dpright":
						DPadRight = new SDLBind(split[1]);
						break;
					// Analog Left
					case "leftx":
						StickLeftXMinus = new SDLBind("-" + split[1]);
						StickLeftXPlus = new SDLBind("+" + split[1]);
						break;
					case "lefty":
						StickLeftYMinus = new SDLBind("-" + split[1]);
						StickLeftYPlus = new SDLBind("+" + split[1]);
						break;
					case "-leftx":
						StickLeftXMinus = new SDLBind(split[1]);
						break;
					case "-lefty":
						StickLeftYMinus = new SDLBind(split[1]);
						break;
					case "+leftx":
						StickLeftXPlus = new SDLBind(split[1]);
						break;
					case "+lefty":
						StickLeftYPlus = new SDLBind(split[1]);
						break;
					// Analog Right
					case "rightx":
						StickRightXMinus = new SDLBind("-" + split[1]);
						StickRightXPlus = new SDLBind("+" + split[1]);
						break;
					case "righty":
						StickRightYMinus = new SDLBind("-" + split[1]);
						StickRightYPlus = new SDLBind("+" + split[1]);
						break;
					case "-rightx":
						StickRightXMinus = new SDLBind(split[1]);
						break;
					case "-righty":
						StickRightYMinus = new SDLBind(split[1]);
						break;
					case "+rightx":
						StickRightXPlus = new SDLBind(split[1]);
						break;
					case "+righty":
						StickRightYPlus = new SDLBind(split[1]);
						break;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(GUID + ",");
			sb.Append(Name + ",");
			if (ButtonA.Type != SDLBind.SDLBindType.None)
				sb.Append(ButtonA.ToString() + ",");
			if (ButtonB.Type != SDLBind.SDLBindType.None)
				sb.Append(ButtonB.ToString() + ",");
			if (ButtonBack.Type != SDLBind.SDLBindType.None)
				sb.Append(ButtonBack.ToString() + ",");
			if (ButtonGuide.Type != SDLBind.SDLBindType.None)
				sb.Append(ButtonGuide.ToString() + ",");

			sb.Append("platform:" + Platform + ",");
			return sb.ToString();
		}
	}
}