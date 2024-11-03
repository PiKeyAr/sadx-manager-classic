﻿using System.Collections.Generic;
using System.ComponentModel;
using IniFile;
using ModManagerCommon;

// SADXModLoader.ini in the mods folder (from old versions of the Mod Manager)

namespace SADXModManager
{
	public enum FillMode
	{
		Stretch = 0,
		Fit = 1,
		Fill = 2
	}

	public class SADXLoaderInfo : LoaderInfo
	{
		public bool DebugConsole { get; set; }

		public bool DebugScreen { get; set; }

		public bool DebugFile { get; set; }

		[DefaultValue(true)]
		public bool DebugCrashLog { get; set; } = true;

		public bool? ShowConsole { get { return null; } set { if (value.HasValue) DebugConsole = value.Value; } }


		[DefaultValue(640)]
		public int HorizontalResolution { get; set; } = 640;

		[DefaultValue(480)]
		public int VerticalResolution { get; set; } = 480;

		public bool ForceAspectRatio { get; set; }

		[DefaultValue(true)]
		public bool WindowedFullscreen { get; set; } = true;

		[DefaultValue(true)]
		public bool EnableVsync { get; set; } = true;

		[DefaultValue(true)]
		public bool AutoMipmap { get; set; } = true;

		[DefaultValue(true)]
		public bool TextureFilter { get; set; } = true;

		[DefaultValue(true)]
		public bool PauseWhenInactive { get; set; } = true;

		[DefaultValue(true)]
		public bool StretchFullscreen { get; set; } = true;

		[DefaultValue(1)]
		public int ScreenNum { get; set; } = 1;

		[DefaultValue(1)]
		public int VoiceLanguage { get; set; } = 1;

		[DefaultValue(1)]
		public int TextLanguage { get; set; } = 1;

		public bool CustomWindowSize { get; set; }

		[DefaultValue(640)]
		public int WindowWidth { get; set; } = 640;

		[DefaultValue(480)]
		public int WindowHeight { get; set; } = 480;

		public bool MaintainWindowAspectRatio { get; set; }

		public bool ResizableWindow { get; set; }

		[IniAlwaysInclude]
		[DefaultValue(true)]
		public bool ScaleHud { get; set; } = true;

		[DefaultValue((int)FillMode.Fill)]
		public int BackgroundFillMode { get; set; } = (int)FillMode.Fill;

		[DefaultValue((int)FillMode.Fit)]
		public int FmvFillMode { get; set; } = (int)FillMode.Fit;

		[DefaultValue(true)]
		public bool EnableBassMusic { get; set; }

		[DefaultValue(false)]
		public bool EnableBassSFX { get; set; }

		[DefaultValue(100)]
		public int SEVolume { get; set; } = 100;

		[DefaultValue(false)]
		public bool DisableMaterialColorFix { get; set; }
		[DefaultValue(false)]
		public bool DisableInterpolationFix { get; set; }

		#region Manager Settings
		public int Theme { get; set; } = 0;
		[DefaultValue(0)]
		public int Language { get; set; } = 0;
		[DefaultValue(true)]
		public bool InputModEnabled { get; set; }
		[DefaultValue(true)]
		public bool managerOpen { get; set; }
		[DefaultValue(false)]
		public bool devMode { get; set; }

		#endregion

		#region TestSpawn

		[DefaultValue(-1)]
		public int TestSpawnLevel { get; set; } = -1;

		[DefaultValue(0)]
		public int TestSpawnAct { get; set; } = 0;

		[DefaultValue(-1)]
		public int TestSpawnCharacter { get; set; } = -1;

		[DefaultValue(false)]
		public bool TestSpawnPositionEnabled { get; set; } = false;

		[DefaultValue(false)]
		public bool TestSpawnRotationHex { get; set; } = false;

		[DefaultValue(0)]
		public int TestSpawnX { get; set; } = 0;

		[DefaultValue(0)]
		public int TestSpawnY { get; set; } = 0;

		[DefaultValue(0)]
		public int TestSpawnZ { get; set; } = 0;

		[DefaultValue(0)]
		public int TestSpawnRotation { get; set; } = 0;

		[DefaultValue(-1)]
		public int TestSpawnEvent { get; set; } = -1;
		[DefaultValue(-1)]
		public int TestSpawnGameMode { get; set; } = -1;

		[DefaultValue(-1)]
		public int TestSpawnSaveID { get; set; } = -1;
		#endregion

		#region Patches
		[DefaultValue(true)]
		public bool HRTFSound { get; set; }
		[DefaultValue(true)]
		public bool CCEF { get; set; }
		[DefaultValue(true)]
		public bool PolyBuff { get; set; } //vertex color 
		[DefaultValue(true)]
		public bool MaterialColorFix { get; set; }
		[DefaultValue(true)]
		public bool NodeLimit { get; set; }
		[DefaultValue(true)]
		public bool FovFix { get; set; }
		[DefaultValue(true)]
		public bool SCFix { get; set; }
		[DefaultValue(true)]
		public bool Chaos2CrashFix { get; set; }
		[DefaultValue(true)]
		public bool ChunkSpecFix { get; set; }
		[DefaultValue(true)]
		public bool E102PolyFix { get; set; }
		[DefaultValue(true)]
		public bool ChaoPanelFix { get; set; }
		[DefaultValue(true)]
		public bool PixelOffSetFix { get; set; }
		[DefaultValue(true)]
		public bool LightFix { get; set; }
		[DefaultValue(true)]
		public bool KillGbix { get; set; }
		public bool DisableCDCheck { get; set; }
		[DefaultValue(true)]
		public bool ExtendedSaveSupport { get; set; }
		[DefaultValue(true)]
		public bool CrashGuard { get; set; }
		[DefaultValue(false)]
		public bool XInputFix { get; set; }

		#endregion

		public SADXLoaderInfo()
		{
			Mods = new List<string>();
			EnabledCodes = new List<string>();
		}
	}
}