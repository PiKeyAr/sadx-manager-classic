namespace SADXModManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label labelGameScreen;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label labelRenderResolution;
            System.Windows.Forms.Label labelControllerProfile;
            System.Windows.Forms.Label labelControllerName;
            System.Windows.Forms.GroupBox groupBoxMiscOptions;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBoxTextLanguage = new System.Windows.Forms.ComboBox();
            this.comboBoxVoiceLanguage = new System.Windows.Forms.ComboBox();
            this.labelGameTextLang = new System.Windows.Forms.Label();
            this.labelGameVoiceLang = new System.Windows.Forms.Label();
            this.checkBoxPauseWhenInactive = new System.Windows.Forms.CheckBox();
            this.checkBoxKeepManagerOpen = new System.Windows.Forms.CheckBox();
            this.buttonInstallURLHandler = new System.Windows.Forms.Button();
            this.comboBoxScreenNumber = new System.Windows.Forms.ComboBox();
            this.checkBoxForceAspectRatio = new System.Windows.Forms.CheckBox();
            this.numericUpDownVerticalResolution = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHorizontalResolution = new System.Windows.Forms.NumericUpDown();
            this.buttonRefreshModList = new System.Windows.Forms.Button();
            this.labelModDescription = new System.Windows.Forms.Label();
            this.listViewMods = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSaveAndPlay = new System.Windows.Forms.Button();
            this.buttonInstallLoader = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMods = new System.Windows.Forms.TabPage();
            this.checkBoxSearchMod = new System.Windows.Forms.CheckBox();
            this.labelModProfile = new System.Windows.Forms.Label();
            this.buttonSaveProfile = new System.Windows.Forms.Button();
            this.textBoxSearchMod = new System.Windows.Forms.TextBox();
            this.buttonLoadProfile = new System.Windows.Forms.Button();
            this.buttonCheckModUpdates = new System.Windows.Forms.Button();
            this.textBoxProfileName = new System.Windows.Forms.ComboBox();
            this.buttonSelectAllMods = new System.Windows.Forms.Button();
            this.buttonModConfigure = new System.Windows.Forms.Button();
            this.buttonModBottom = new System.Windows.Forms.Button();
            this.buttonModTop = new System.Windows.Forms.Button();
            this.buttonModAdd = new System.Windows.Forms.Button();
            this.buttonModDown = new System.Windows.Forms.Button();
            this.buttonModUp = new System.Windows.Forms.Button();
            this.tabPageCodes = new System.Windows.Forms.TabPage();
            this.labelCodeDescription = new System.Windows.Forms.Label();
            this.listViewCodes = new System.Windows.Forms.ListView();
            this.columnHeaderCodeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCodeAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCodeCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageGameConfig = new System.Windows.Forms.TabPage();
            this.tabControlGameConfig = new System.Windows.Forms.TabControl();
            this.tabPageGraphics = new System.Windows.Forms.TabPage();
            this.buttonResetGameSettings = new System.Windows.Forms.Button();
            this.groupBoxGraphicsOther = new System.Windows.Forms.GroupBox();
            this.checkBoxShowMouse = new System.Windows.Forms.CheckBox();
            this.checkBoxScaleHud = new System.Windows.Forms.CheckBox();
            this.comboBoxBackgroundFill = new System.Windows.Forms.ComboBox();
            this.comboBoxFmvFill = new System.Windows.Forms.ComboBox();
            this.labeFmvFillMode = new System.Windows.Forms.Label();
            this.labelBgFillMode = new System.Windows.Forms.Label();
            this.groupBoxVisuals = new System.Windows.Forms.GroupBox();
            this.comboBoxAntialiasing = new System.Windows.Forms.ComboBox();
            this.comboBoxAnisotropic = new System.Windows.Forms.ComboBox();
            this.labelAnisotropic = new System.Windows.Forms.Label();
            this.labelAntiAliasing = new System.Windows.Forms.Label();
            this.checkBoxEnableD3D9 = new System.Windows.Forms.CheckBox();
            this.checkBoxBorderImage = new System.Windows.Forms.CheckBox();
            this.comboBoxFogEmulation = new System.Windows.Forms.ComboBox();
            this.comboBoxClipLevel = new System.Windows.Forms.ComboBox();
            this.labelFogEmulation = new System.Windows.Forms.Label();
            this.labelDetail = new System.Windows.Forms.Label();
            this.labelFramerate = new System.Windows.Forms.Label();
            this.comboBoxFramerate = new System.Windows.Forms.ComboBox();
            this.checkBoxForceMipmapping = new System.Windows.Forms.CheckBox();
            this.checkBoxForceTextureFilter = new System.Windows.Forms.CheckBox();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.checkBoxWindowResizable = new System.Windows.Forms.CheckBox();
            this.labelCustomWindowSize = new System.Windows.Forms.Label();
            this.checkBoxWindowMaintainAspect = new System.Windows.Forms.CheckBox();
            this.comboBoxScreenMode = new System.Windows.Forms.ComboBox();
            this.numericUpDownWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWindowWidth = new System.Windows.Forms.NumericUpDown();
            this.labelScreenMode = new System.Windows.Forms.Label();
            this.comboBoxResolutionPreset = new System.Windows.Forms.ComboBox();
            this.checkBoxVsync = new System.Windows.Forms.CheckBox();
            this.tabPageInput = new System.Windows.Forms.TabPage();
            this.groupBoxControllerDInput = new System.Windows.Forms.GroupBox();
            this.comboBoxControllerName = new System.Windows.Forms.TextBox();
            this.comboBoxControllerProfile = new System.Windows.Forms.ComboBox();
            this.buttonControllerProfileAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanelDInput = new System.Windows.Forms.TableLayoutPanel();
            this.buttonControllerProfileRemove = new System.Windows.Forms.Button();
            this.groupBoxInputMode = new System.Windows.Forms.GroupBox();
            this.radioButtonSDL = new System.Windows.Forms.RadioButton();
            this.radioButtonDInput = new System.Windows.Forms.RadioButton();
            this.groupBoxMouseMode = new System.Windows.Forms.GroupBox();
            this.radioButtonMouseDisable = new System.Windows.Forms.RadioButton();
            this.labelMouseButtonAssignment = new System.Windows.Forms.Label();
            this.comboBoxMouseButtonAssignment = new System.Windows.Forms.ComboBox();
            this.radioButtonMouseDragAccelerate = new System.Windows.Forms.RadioButton();
            this.radioButtonMouseHold = new System.Windows.Forms.RadioButton();
            this.comboBoxMouseAction = new System.Windows.Forms.ComboBox();
            this.labelMouseAction = new System.Windows.Forms.Label();
            this.tabPageController = new System.Windows.Forms.TabPage();
            this.groupBoxControlsSDL = new System.Windows.Forms.GroupBox();
            this.labelSdlDevice = new System.Windows.Forms.Label();
            this.comboBoxSdlDevice = new System.Windows.Forms.ComboBox();
            this.buttonBindingReset = new System.Windows.Forms.Button();
            this.buttonBindingClear = new System.Windows.Forms.Button();
            this.buttonBindingSet = new System.Windows.Forms.Button();
            this.groupBoxRumble = new System.Windows.Forms.GroupBox();
            this.numericUpDownRumbleMultiplier = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRumbleMinTime = new System.Windows.Forms.NumericUpDown();
            this.labelRumpleMultiplier = new System.Windows.Forms.Label();
            this.labelMinRumbleTime = new System.Windows.Forms.Label();
            this.checkBoxMegaRumble = new System.Windows.Forms.CheckBox();
            this.groupBoxDeadzones = new System.Windows.Forms.GroupBox();
            this.checkBoxRadialMotionRight = new System.Windows.Forms.CheckBox();
            this.checkBoxRadialMotionLeft = new System.Windows.Forms.CheckBox();
            this.numericUpDownTriggersDeadzone = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRightStickDeadzone = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLeftStickDeadzone = new System.Windows.Forms.NumericUpDown();
            this.labelTriggersDeadzone = new System.Windows.Forms.Label();
            this.labelRightStickDeadzone = new System.Windows.Forms.Label();
            this.labelLeftStickDeadzone = new System.Windows.Forms.Label();
            this.labelKeyboardPlayer = new System.Windows.Forms.Label();
            this.comboBoxKeyboardPlayer = new System.Windows.Forms.ComboBox();
            this.listViewControlBindings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageSound = new System.Windows.Forms.TabPage();
            this.groupBoxSoundVolume = new System.Windows.Forms.GroupBox();
            this.labelSEVol = new System.Windows.Forms.Label();
            this.trackBarSEVol = new System.Windows.Forms.TrackBar();
            this.labelSEVolume = new System.Windows.Forms.Label();
            this.labelVoiceVol = new System.Windows.Forms.Label();
            this.labelMusicVol = new System.Windows.Forms.Label();
            this.trackBarVoiceVol = new System.Windows.Forms.TrackBar();
            this.labelMusicVolume = new System.Windows.Forms.Label();
            this.trackBarMusicVol = new System.Windows.Forms.TrackBar();
            this.labelVoiceVolume = new System.Windows.Forms.Label();
            this.groupBoxSound = new System.Windows.Forms.GroupBox();
            this.checkBoxUseBassMusic = new System.Windows.Forms.CheckBox();
            this.checkBoxUseBassSE = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableMusic = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableSound = new System.Windows.Forms.CheckBox();
            this.checkBoxEnable3DSound = new System.Windows.Forms.CheckBox();
            this.tabPagePatches = new System.Windows.Forms.TabPage();
            this.labelPatchDescription = new System.Windows.Forms.Label();
            this.listViewPatches = new System.Windows.Forms.ListView();
            this.columnHeaderPatchName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPatchAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPatchCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageGameOptions = new System.Windows.Forms.TabPage();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.groupBoxDebugMessages = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableDebugCrashHandler = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableDebugConsole = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableDebugScreen = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableDebugFile = new System.Windows.Forms.CheckBox();
            this.groupBoxTestSpawn = new System.Windows.Forms.GroupBox();
            this.checkBoxTestSpawnAngleDeg = new System.Windows.Forms.CheckBox();
            this.comboBoxTestSpawnSave = new System.Windows.Forms.ComboBox();
            this.comboBoxTestSpawnGameMode = new System.Windows.Forms.ComboBox();
            this.checkBoxTestSpawnGameMode = new System.Windows.Forms.CheckBox();
            this.labelTestSpawnWarning = new System.Windows.Forms.Label();
            this.labelTestSpawnTime = new System.Windows.Forms.Label();
            this.comboBoxTestSpawnTime = new System.Windows.Forms.ComboBox();
            this.checkBoxTestSpawnAngleHex = new System.Windows.Forms.CheckBox();
            this.checkBoxTestSpawnPosition = new System.Windows.Forms.CheckBox();
            this.buttonTestSpawnPlay = new System.Windows.Forms.Button();
            this.comboBoxTestSpawnEvent = new System.Windows.Forms.ComboBox();
            this.checkBoxTestSpawnEvent = new System.Windows.Forms.CheckBox();
            this.checkBoxTestSpawnCharacter = new System.Windows.Forms.CheckBox();
            this.checkBoxTestSpawnLevel = new System.Windows.Forms.CheckBox();
            this.comboBoxTestSpawnCharacter = new System.Windows.Forms.ComboBox();
            this.numericUpDownTestSpawnAngle = new System.Windows.Forms.NumericUpDown();
            this.labelTestSpawnAngle = new System.Windows.Forms.Label();
            this.labelTestSpawnY = new System.Windows.Forms.Label();
            this.checkBoxTestSpawnSave = new System.Windows.Forms.CheckBox();
            this.labelTestSpawnX = new System.Windows.Forms.Label();
            this.labelTestSpawnAct = new System.Windows.Forms.Label();
            this.labelTestSpawnZ = new System.Windows.Forms.Label();
            this.numericUpDownTestSpawnAct = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTestSpawnZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTestSpawnY = new System.Windows.Forms.NumericUpDown();
            this.comboBoxTestSpawnLevel = new System.Windows.Forms.ComboBox();
            this.numericUpDownTestSpawnX = new System.Windows.Forms.NumericUpDown();
            this.tabPageManagerConfig = new System.Windows.Forms.TabPage();
            this.groupBoxManagerOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxSingleProfile = new System.Windows.Forms.CheckBox();
            this.buttonCheckGameHealth = new System.Windows.Forms.Button();
            this.groupBoxUpdates = new System.Windows.Forms.GroupBox();
            this.buttonSwitchToSAManager = new System.Windows.Forms.Button();
            this.checkBoxCheckLoaderUpdatesStartup = new System.Windows.Forms.CheckBox();
            this.buttonCheckForUpdatesNow = new System.Windows.Forms.Button();
            this.labelUpdateFrequency = new System.Windows.Forms.Label();
            this.checkBoxCheckUpdateModsStartup = new System.Windows.Forms.CheckBox();
            this.numericUpDownUpdateFrequency = new System.Windows.Forms.NumericUpDown();
            this.comboBoxUpdateUnit = new System.Windows.Forms.ComboBox();
            this.checkBoxCheckManagerUpdateStartup = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripMod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.disableUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.generateManifestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStripAddMod = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addModArchivetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripManager = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelGameFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDeleteProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripResetGameSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemResetOptimal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResetSafe = new System.Windows.Forms.ToolStripMenuItem();
            labelGameScreen = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            labelRenderResolution = new System.Windows.Forms.Label();
            labelControllerProfile = new System.Windows.Forms.Label();
            labelControllerName = new System.Windows.Forms.Label();
            groupBoxMiscOptions = new System.Windows.Forms.GroupBox();
            groupBoxMiscOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVerticalResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorizontalResolution)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageMods.SuspendLayout();
            this.tabPageCodes.SuspendLayout();
            this.tabPageGameConfig.SuspendLayout();
            this.tabControlGameConfig.SuspendLayout();
            this.tabPageGraphics.SuspendLayout();
            this.groupBoxGraphicsOther.SuspendLayout();
            this.groupBoxVisuals.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowWidth)).BeginInit();
            this.tabPageInput.SuspendLayout();
            this.groupBoxControllerDInput.SuspendLayout();
            this.groupBoxInputMode.SuspendLayout();
            this.groupBoxMouseMode.SuspendLayout();
            this.tabPageController.SuspendLayout();
            this.groupBoxControlsSDL.SuspendLayout();
            this.groupBoxRumble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRumbleMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRumbleMinTime)).BeginInit();
            this.groupBoxDeadzones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTriggersDeadzone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightStickDeadzone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftStickDeadzone)).BeginInit();
            this.tabPageSound.SuspendLayout();
            this.groupBoxSoundVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSEVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVoiceVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVol)).BeginInit();
            this.groupBoxSound.SuspendLayout();
            this.tabPagePatches.SuspendLayout();
            this.tabPageGameOptions.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            this.groupBoxDebugMessages.SuspendLayout();
            this.groupBoxTestSpawn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnAct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnX)).BeginInit();
            this.tabPageManagerConfig.SuspendLayout();
            this.groupBoxManagerOptions.SuspendLayout();
            this.groupBoxUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpdateFrequency)).BeginInit();
            this.contextMenuStripMod.SuspendLayout();
            this.contextMenuStripAddMod.SuspendLayout();
            this.statusStripManager.SuspendLayout();
            this.contextMenuStripProfile.SuspendLayout();
            this.contextMenuStripResetGameSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGameScreen
            // 
            labelGameScreen.AutoSize = true;
            labelGameScreen.Location = new System.Drawing.Point(7, 22);
            labelGameScreen.Name = "labelGameScreen";
            labelGameScreen.Size = new System.Drawing.Size(75, 13);
            labelGameScreen.TabIndex = 0;
            labelGameScreen.Text = "Game Screen:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(190, 78);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(12, 13);
            label1.TabIndex = 7;
            label1.Text = "x";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(190, 108);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(12, 13);
            label2.TabIndex = 13;
            label2.Text = "x";
            // 
            // labelRenderResolution
            // 
            labelRenderResolution.AutoSize = true;
            labelRenderResolution.Location = new System.Drawing.Point(7, 78);
            labelRenderResolution.Name = "labelRenderResolution";
            labelRenderResolution.Size = new System.Drawing.Size(98, 13);
            labelRenderResolution.TabIndex = 17;
            labelRenderResolution.Text = "Render Resolution:";
            // 
            // labelControllerProfile
            // 
            labelControllerProfile.AutoSize = true;
            labelControllerProfile.Location = new System.Drawing.Point(269, 15);
            labelControllerProfile.Name = "labelControllerProfile";
            labelControllerProfile.Size = new System.Drawing.Size(39, 13);
            labelControllerProfile.TabIndex = 8;
            labelControllerProfile.Text = "Profile:";
            // 
            // labelControllerName
            // 
            labelControllerName.AutoSize = true;
            labelControllerName.Location = new System.Drawing.Point(270, 60);
            labelControllerName.Name = "labelControllerName";
            labelControllerName.Size = new System.Drawing.Size(38, 13);
            labelControllerName.TabIndex = 12;
            labelControllerName.Text = "Name:";
            // 
            // groupBoxMiscOptions
            // 
            groupBoxMiscOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBoxMiscOptions.Controls.Add(this.comboBoxTextLanguage);
            groupBoxMiscOptions.Controls.Add(this.comboBoxVoiceLanguage);
            groupBoxMiscOptions.Controls.Add(this.labelGameTextLang);
            groupBoxMiscOptions.Controls.Add(this.labelGameVoiceLang);
            groupBoxMiscOptions.Controls.Add(this.checkBoxPauseWhenInactive);
            groupBoxMiscOptions.Location = new System.Drawing.Point(6, 6);
            groupBoxMiscOptions.Name = "groupBoxMiscOptions";
            groupBoxMiscOptions.Size = new System.Drawing.Size(452, 104);
            groupBoxMiscOptions.TabIndex = 0;
            groupBoxMiscOptions.TabStop = false;
            groupBoxMiscOptions.Text = "Miscellaneous Game Options";
            // 
            // comboBoxTextLanguage
            // 
            this.comboBoxTextLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTextLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxTextLanguage.FormattingEnabled = true;
            this.comboBoxTextLanguage.Items.AddRange(new object[] {
            "Japanese",
            "English",
            "French",
            "Spanish",
            "German"});
            this.comboBoxTextLanguage.Location = new System.Drawing.Point(134, 73);
            this.comboBoxTextLanguage.Name = "comboBoxTextLanguage";
            this.comboBoxTextLanguage.Size = new System.Drawing.Size(97, 21);
            this.comboBoxTextLanguage.TabIndex = 3;
            this.toolTip.SetToolTip(this.comboBoxTextLanguage, "Text language at startup. Loading a save file overrides this.");
            // 
            // comboBoxVoiceLanguage
            // 
            this.comboBoxVoiceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVoiceLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxVoiceLanguage.FormattingEnabled = true;
            this.comboBoxVoiceLanguage.Items.AddRange(new object[] {
            "Japanese",
            "English"});
            this.comboBoxVoiceLanguage.Location = new System.Drawing.Point(133, 43);
            this.comboBoxVoiceLanguage.Name = "comboBoxVoiceLanguage";
            this.comboBoxVoiceLanguage.Size = new System.Drawing.Size(98, 21);
            this.comboBoxVoiceLanguage.TabIndex = 2;
            this.toolTip.SetToolTip(this.comboBoxVoiceLanguage, "Voice language at startup. Loading a save file overrides this.");
            // 
            // labelGameTextLang
            // 
            this.labelGameTextLang.AutoSize = true;
            this.labelGameTextLang.Location = new System.Drawing.Point(14, 76);
            this.labelGameTextLang.Name = "labelGameTextLang";
            this.labelGameTextLang.Size = new System.Drawing.Size(113, 13);
            this.labelGameTextLang.TabIndex = 4;
            this.labelGameTextLang.Text = "Game Text Language:";
            // 
            // labelGameVoiceLang
            // 
            this.labelGameVoiceLang.AutoSize = true;
            this.labelGameVoiceLang.Location = new System.Drawing.Point(8, 47);
            this.labelGameVoiceLang.Name = "labelGameVoiceLang";
            this.labelGameVoiceLang.Size = new System.Drawing.Size(119, 13);
            this.labelGameVoiceLang.TabIndex = 3;
            this.labelGameVoiceLang.Text = "Game Voice Language:";
            // 
            // checkBoxPauseWhenInactive
            // 
            this.checkBoxPauseWhenInactive.AutoSize = true;
            this.checkBoxPauseWhenInactive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxPauseWhenInactive.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPauseWhenInactive.Name = "checkBoxPauseWhenInactive";
            this.checkBoxPauseWhenInactive.Size = new System.Drawing.Size(215, 18);
            this.checkBoxPauseWhenInactive.TabIndex = 0;
            this.checkBoxPauseWhenInactive.Text = "Pause when Game Window is Inactive";
            this.toolTip.SetToolTip(this.checkBoxPauseWhenInactive, "Uncheck to allow the game to run in the background.");
            this.checkBoxPauseWhenInactive.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeepManagerOpen
            // 
            this.checkBoxKeepManagerOpen.AutoSize = true;
            this.checkBoxKeepManagerOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxKeepManagerOpen.Location = new System.Drawing.Point(9, 19);
            this.checkBoxKeepManagerOpen.Name = "checkBoxKeepManagerOpen";
            this.checkBoxKeepManagerOpen.Size = new System.Drawing.Size(213, 18);
            this.checkBoxKeepManagerOpen.TabIndex = 0;
            this.checkBoxKeepManagerOpen.Text = "Keep Manager Open during Gameplay";
            this.toolTip.SetToolTip(this.checkBoxKeepManagerOpen, "Don\'t close the Manager after clicking \'Save and Play\'.");
            this.checkBoxKeepManagerOpen.UseVisualStyleBackColor = true;
            // 
            // buttonInstallURLHandler
            // 
            this.buttonInstallURLHandler.AutoSize = true;
            this.buttonInstallURLHandler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonInstallURLHandler.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonInstallURLHandler.Location = new System.Drawing.Point(6, 68);
            this.buttonInstallURLHandler.Name = "buttonInstallURLHandler";
            this.buttonInstallURLHandler.Size = new System.Drawing.Size(119, 22);
            this.buttonInstallURLHandler.TabIndex = 2;
            this.buttonInstallURLHandler.Text = "Enable 1-Click Install";
            this.toolTip.SetToolTip(this.buttonInstallURLHandler, "Install the URL handler which will enable the Manager to parse 1-click install li" +
        "nks on GitHub, GameBanana etc.");
            this.buttonInstallURLHandler.UseVisualStyleBackColor = true;
            this.buttonInstallURLHandler.Click += new System.EventHandler(this.installURLHandlerButton_Click);
            // 
            // comboBoxScreenNumber
            // 
            this.comboBoxScreenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxScreenNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScreenNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxScreenNumber.FormattingEnabled = true;
            this.comboBoxScreenNumber.Items.AddRange(new object[] {
            "All Screens"});
            this.comboBoxScreenNumber.Location = new System.Drawing.Point(87, 19);
            this.comboBoxScreenNumber.Name = "comboBoxScreenNumber";
            this.comboBoxScreenNumber.Size = new System.Drawing.Size(352, 21);
            this.comboBoxScreenNumber.TabIndex = 0;
            this.toolTip.SetToolTip(this.comboBoxScreenNumber, "The screen to put the game on.");
            this.comboBoxScreenNumber.SelectedIndexChanged += new System.EventHandler(this.screenNumComboBox_SelectedIndexChanged);
            // 
            // checkBoxForceAspectRatio
            // 
            this.checkBoxForceAspectRatio.AutoSize = true;
            this.checkBoxForceAspectRatio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxForceAspectRatio.Location = new System.Drawing.Point(367, 78);
            this.checkBoxForceAspectRatio.Name = "checkBoxForceAspectRatio";
            this.checkBoxForceAspectRatio.Size = new System.Drawing.Size(77, 18);
            this.checkBoxForceAspectRatio.TabIndex = 6;
            this.checkBoxForceAspectRatio.Text = "Force 4:3";
            this.checkBoxForceAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxForceAspectRatio.CheckedChanged += new System.EventHandler(this.forceAspectRatioCheckBox_CheckedChanged);
            // 
            // numericUpDownVerticalResolution
            // 
            this.numericUpDownVerticalResolution.Location = new System.Drawing.Point(207, 76);
            this.numericUpDownVerticalResolution.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownVerticalResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVerticalResolution.Name = "numericUpDownVerticalResolution";
            this.numericUpDownVerticalResolution.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownVerticalResolution.TabIndex = 4;
            this.numericUpDownVerticalResolution.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numericUpDownVerticalResolution.ValueChanged += new System.EventHandler(this.verticalResolution_ValueChanged);
            // 
            // numericUpDownHorizontalResolution
            // 
            this.numericUpDownHorizontalResolution.Location = new System.Drawing.Point(122, 76);
            this.numericUpDownHorizontalResolution.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownHorizontalResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHorizontalResolution.Name = "numericUpDownHorizontalResolution";
            this.numericUpDownHorizontalResolution.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownHorizontalResolution.TabIndex = 3;
            this.numericUpDownHorizontalResolution.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.numericUpDownHorizontalResolution.ValueChanged += new System.EventHandler(this.horizontalResolution_ValueChanged);
            // 
            // buttonRefreshModList
            // 
            this.buttonRefreshModList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshModList.AutoSize = true;
            this.buttonRefreshModList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRefreshModList.Location = new System.Drawing.Point(439, 248);
            this.buttonRefreshModList.Name = "buttonRefreshModList";
            this.buttonRefreshModList.Size = new System.Drawing.Size(33, 29);
            this.buttonRefreshModList.TabIndex = 7;
            this.buttonRefreshModList.Text = "🗘";
            this.toolTip.SetToolTip(this.buttonRefreshModList, "Refresh Mod List");
            this.buttonRefreshModList.UseVisualStyleBackColor = true;
            this.buttonRefreshModList.Click += new System.EventHandler(this.buttonRefreshModList_Click);
            // 
            // labelModDescription
            // 
            this.labelModDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelModDescription.Location = new System.Drawing.Point(3, 358);
            this.labelModDescription.Name = "labelModDescription";
            this.labelModDescription.Size = new System.Drawing.Size(469, 60);
            this.labelModDescription.TabIndex = 6;
            this.labelModDescription.Text = "Description: No mod selected.";
            // 
            // listViewMods
            // 
            this.listViewMods.AllowDrop = true;
            this.listViewMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMods.CheckBoxes = true;
            this.listViewMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderAuthor,
            this.columnHeaderVersion,
            this.columnHeaderCategory});
            this.listViewMods.FullRowSelect = true;
            this.listViewMods.HideSelection = false;
            this.listViewMods.Location = new System.Drawing.Point(3, 3);
            this.listViewMods.Name = "listViewMods";
            this.listViewMods.Size = new System.Drawing.Size(432, 317);
            this.listViewMods.TabIndex = 0;
            this.listViewMods.UseCompatibleStateImageBehavior = false;
            this.listViewMods.View = System.Windows.Forms.View.Details;
            this.listViewMods.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewMods_ColumnClick);
            this.listViewMods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewMods_ItemCheck);
            this.listViewMods.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewMods_ItemChecked);
            this.listViewMods.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.modListView_ItemDrag);
            this.listViewMods.SelectedIndexChanged += new System.EventHandler(this.modListView_SelectedIndexChanged);
            this.listViewMods.DragDrop += new System.Windows.Forms.DragEventHandler(this.modListView_DragDrop);
            this.listViewMods.DragEnter += new System.Windows.Forms.DragEventHandler(this.modListView_DragEnter);
            this.listViewMods.DragOver += new System.Windows.Forms.DragEventHandler(this.modListView_DragOver);
            this.listViewMods.MouseClick += new System.Windows.Forms.MouseEventHandler(this.modListView_MouseClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 152;
            // 
            // columnHeaderAuthor
            // 
            this.columnHeaderAuthor.Text = "Author";
            this.columnHeaderAuthor.Width = 130;
            // 
            // columnHeaderVersion
            // 
            this.columnHeaderVersion.Text = "Version";
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 94;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.AutoSize = true;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSave.Location = new System.Drawing.Point(88, 453);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 22);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // buttonSaveAndPlay
            // 
            this.buttonSaveAndPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveAndPlay.AutoSize = true;
            this.buttonSaveAndPlay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSaveAndPlay.Location = new System.Drawing.Point(4, 453);
            this.buttonSaveAndPlay.Name = "buttonSaveAndPlay";
            this.buttonSaveAndPlay.Size = new System.Drawing.Size(78, 22);
            this.buttonSaveAndPlay.TabIndex = 1;
            this.buttonSaveAndPlay.Text = "Save && &Play";
            this.buttonSaveAndPlay.UseVisualStyleBackColor = true;
            this.buttonSaveAndPlay.Click += new System.EventHandler(this.saveAndPlayButton_Click);
            // 
            // buttonInstallLoader
            // 
            this.buttonInstallLoader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonInstallLoader.AutoSize = true;
            this.buttonInstallLoader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonInstallLoader.Location = new System.Drawing.Point(168, 453);
            this.buttonInstallLoader.Name = "buttonInstallLoader";
            this.buttonInstallLoader.Size = new System.Drawing.Size(84, 22);
            this.buttonInstallLoader.TabIndex = 3;
            this.buttonInstallLoader.Text = "Install Loader";
            this.buttonInstallLoader.UseVisualStyleBackColor = true;
            this.buttonInstallLoader.Click += new System.EventHandler(this.installButton_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageMods);
            this.tabControlMain.Controls.Add(this.tabPageCodes);
            this.tabControlMain.Controls.Add(this.tabPageGameConfig);
            this.tabControlMain.Controls.Add(this.tabPageDebug);
            this.tabControlMain.Controls.Add(this.tabPageManagerConfig);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(486, 447);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageMods
            // 
            this.tabPageMods.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPageMods.Controls.Add(this.checkBoxSearchMod);
            this.tabPageMods.Controls.Add(this.labelModProfile);
            this.tabPageMods.Controls.Add(this.buttonSaveProfile);
            this.tabPageMods.Controls.Add(this.textBoxSearchMod);
            this.tabPageMods.Controls.Add(this.buttonLoadProfile);
            this.tabPageMods.Controls.Add(this.buttonCheckModUpdates);
            this.tabPageMods.Controls.Add(this.textBoxProfileName);
            this.tabPageMods.Controls.Add(this.buttonSelectAllMods);
            this.tabPageMods.Controls.Add(this.buttonModConfigure);
            this.tabPageMods.Controls.Add(this.buttonModBottom);
            this.tabPageMods.Controls.Add(this.buttonModTop);
            this.tabPageMods.Controls.Add(this.buttonModAdd);
            this.tabPageMods.Controls.Add(this.buttonRefreshModList);
            this.tabPageMods.Controls.Add(this.labelModDescription);
            this.tabPageMods.Controls.Add(this.buttonModDown);
            this.tabPageMods.Controls.Add(this.buttonModUp);
            this.tabPageMods.Controls.Add(this.listViewMods);
            this.tabPageMods.Location = new System.Drawing.Point(4, 22);
            this.tabPageMods.Name = "tabPageMods";
            this.tabPageMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMods.Size = new System.Drawing.Size(478, 421);
            this.tabPageMods.TabIndex = 0;
            this.tabPageMods.Text = "Mods";
            // 
            // checkBoxSearchMod
            // 
            this.checkBoxSearchMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSearchMod.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSearchMod.AutoSize = true;
            this.checkBoxSearchMod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxSearchMod.Location = new System.Drawing.Point(439, 283);
            this.checkBoxSearchMod.MinimumSize = new System.Drawing.Size(33, 29);
            this.checkBoxSearchMod.Name = "checkBoxSearchMod";
            this.checkBoxSearchMod.Size = new System.Drawing.Size(33, 29);
            this.checkBoxSearchMod.TabIndex = 8;
            this.checkBoxSearchMod.Text = "🔍︎";
            this.checkBoxSearchMod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxSearchMod, "Filter Mod List");
            this.checkBoxSearchMod.UseVisualStyleBackColor = true;
            this.checkBoxSearchMod.CheckedChanged += new System.EventHandler(this.checkBoxSearchMod_CheckedChanged);
            // 
            // labelModProfile
            // 
            this.labelModProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelModProfile.AutoSize = true;
            this.labelModProfile.Location = new System.Drawing.Point(208, 331);
            this.labelModProfile.Name = "labelModProfile";
            this.labelModProfile.Size = new System.Drawing.Size(39, 13);
            this.labelModProfile.TabIndex = 12;
            this.labelModProfile.Text = "Profile:";
            // 
            // buttonSaveProfile
            // 
            this.buttonSaveProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveProfile.Enabled = false;
            this.buttonSaveProfile.Location = new System.Drawing.Point(418, 326);
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.Size = new System.Drawing.Size(54, 23);
            this.buttonSaveProfile.TabIndex = 13;
            this.buttonSaveProfile.Text = "Save...";
            this.toolTip.SetToolTip(this.buttonSaveProfile, "Saves all current settings to the profile with the selected name.");
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // textBoxSearchMod
            // 
            this.textBoxSearchMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchMod.Location = new System.Drawing.Point(281, 328);
            this.textBoxSearchMod.Name = "textBoxSearchMod";
            this.textBoxSearchMod.Size = new System.Drawing.Size(191, 20);
            this.textBoxSearchMod.TabIndex = 14;
            this.textBoxSearchMod.Visible = false;
            this.textBoxSearchMod.TextChanged += new System.EventHandler(this.textBoxSearchMod_TextChanged);
            this.textBoxSearchMod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchMod_KeyDown);
            // 
            // buttonLoadProfile
            // 
            this.buttonLoadProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadProfile.Enabled = false;
            this.buttonLoadProfile.Location = new System.Drawing.Point(358, 326);
            this.buttonLoadProfile.Name = "buttonLoadProfile";
            this.buttonLoadProfile.Size = new System.Drawing.Size(54, 23);
            this.buttonLoadProfile.TabIndex = 12;
            this.buttonLoadProfile.Text = "Load";
            this.toolTip.SetToolTip(this.buttonLoadProfile, "Loads the profile with the selected name.");
            this.buttonLoadProfile.UseVisualStyleBackColor = true;
            this.buttonLoadProfile.Click += new System.EventHandler(this.buttonLoadProfile_Click);
            // 
            // buttonCheckModUpdates
            // 
            this.buttonCheckModUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckModUpdates.AutoSize = true;
            this.buttonCheckModUpdates.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCheckModUpdates.Location = new System.Drawing.Point(439, 213);
            this.buttonCheckModUpdates.Name = "buttonCheckModUpdates";
            this.buttonCheckModUpdates.Size = new System.Drawing.Size(33, 29);
            this.buttonCheckModUpdates.TabIndex = 6;
            this.buttonCheckModUpdates.Text = "🕒︎";
            this.toolTip.SetToolTip(this.buttonCheckModUpdates, "Check for Mod Updates");
            this.buttonCheckModUpdates.UseVisualStyleBackColor = true;
            this.buttonCheckModUpdates.Click += new System.EventHandler(this.buttonCheckModUpdates_Click);
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProfileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProfileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.textBoxProfileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBoxProfileName.Location = new System.Drawing.Point(253, 328);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(99, 21);
            this.textBoxProfileName.TabIndex = 11;
            this.toolTip.SetToolTip(this.textBoxProfileName, "Select the name of a profile to load. Right click to delete the currently selecte" +
        "d profile. The Default profile cannot be deleted.");
            this.textBoxProfileName.SelectedIndexChanged += new System.EventHandler(this.textBoxProfileName_SelectedIndexChanged);
            this.textBoxProfileName.TextChanged += new System.EventHandler(this.profileNameBox_TextChanged);
            this.textBoxProfileName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxProfileName_MouseDown);
            // 
            // buttonSelectAllMods
            // 
            this.buttonSelectAllMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAllMods.AutoSize = true;
            this.buttonSelectAllMods.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectAllMods.Location = new System.Drawing.Point(439, 178);
            this.buttonSelectAllMods.Name = "buttonSelectAllMods";
            this.buttonSelectAllMods.Size = new System.Drawing.Size(33, 29);
            this.buttonSelectAllMods.TabIndex = 5;
            this.buttonSelectAllMods.Text = "🗹";
            this.toolTip.SetToolTip(this.buttonSelectAllMods, "Select or Deselect All Mods");
            this.buttonSelectAllMods.UseVisualStyleBackColor = true;
            this.buttonSelectAllMods.Click += new System.EventHandler(this.buttonSelectAllMods_Click);
            // 
            // buttonModConfigure
            // 
            this.buttonModConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModConfigure.Enabled = false;
            this.buttonModConfigure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonModConfigure.Location = new System.Drawing.Point(6, 326);
            this.buttonModConfigure.Name = "buttonModConfigure";
            this.buttonModConfigure.Size = new System.Drawing.Size(112, 23);
            this.buttonModConfigure.TabIndex = 9;
            this.buttonModConfigure.Text = "Configure...";
            this.buttonModConfigure.UseVisualStyleBackColor = true;
            this.buttonModConfigure.Click += new System.EventHandler(this.configureModButton_Click);
            // 
            // buttonModBottom
            // 
            this.buttonModBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModBottom.AutoSize = true;
            this.buttonModBottom.Enabled = false;
            this.buttonModBottom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonModBottom.Location = new System.Drawing.Point(439, 114);
            this.buttonModBottom.Name = "buttonModBottom";
            this.buttonModBottom.Size = new System.Drawing.Size(33, 29);
            this.buttonModBottom.TabIndex = 4;
            this.buttonModBottom.Text = "⤓";
            this.toolTip.SetToolTip(this.buttonModBottom, "Move to Bottom");
            this.buttonModBottom.UseVisualStyleBackColor = true;
            this.buttonModBottom.Click += new System.EventHandler(this.modBottomButton_Click);
            // 
            // buttonModTop
            // 
            this.buttonModTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModTop.AutoSize = true;
            this.buttonModTop.Enabled = false;
            this.buttonModTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonModTop.Location = new System.Drawing.Point(439, 6);
            this.buttonModTop.Name = "buttonModTop";
            this.buttonModTop.Size = new System.Drawing.Size(33, 29);
            this.buttonModTop.TabIndex = 1;
            this.buttonModTop.Text = "⤒";
            this.toolTip.SetToolTip(this.buttonModTop, "Move to Top");
            this.buttonModTop.UseVisualStyleBackColor = true;
            this.buttonModTop.Click += new System.EventHandler(this.modTopButton_Click);
            // 
            // buttonModAdd
            // 
            this.buttonModAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonModAdd.Location = new System.Drawing.Point(124, 326);
            this.buttonModAdd.Name = "buttonModAdd";
            this.buttonModAdd.Size = new System.Drawing.Size(76, 23);
            this.buttonModAdd.TabIndex = 10;
            this.buttonModAdd.Text = "Add Mod...";
            this.buttonModAdd.UseVisualStyleBackColor = true;
            this.buttonModAdd.Click += new System.EventHandler(this.buttonNewMod_Click);
            // 
            // buttonModDown
            // 
            this.buttonModDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModDown.AutoSize = true;
            this.buttonModDown.Enabled = false;
            this.buttonModDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonModDown.Location = new System.Drawing.Point(439, 78);
            this.buttonModDown.Name = "buttonModDown";
            this.buttonModDown.Size = new System.Drawing.Size(33, 29);
            this.buttonModDown.TabIndex = 3;
            this.buttonModDown.Text = "↓";
            this.toolTip.SetToolTip(this.buttonModDown, "Move Down");
            this.buttonModDown.UseVisualStyleBackColor = true;
            this.buttonModDown.Click += new System.EventHandler(this.modDownButton_Click);
            // 
            // buttonModUp
            // 
            this.buttonModUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModUp.AutoSize = true;
            this.buttonModUp.Enabled = false;
            this.buttonModUp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonModUp.Location = new System.Drawing.Point(439, 42);
            this.buttonModUp.Name = "buttonModUp";
            this.buttonModUp.Size = new System.Drawing.Size(33, 29);
            this.buttonModUp.TabIndex = 2;
            this.buttonModUp.Text = "↑";
            this.toolTip.SetToolTip(this.buttonModUp, "Move Up");
            this.buttonModUp.UseVisualStyleBackColor = true;
            this.buttonModUp.Click += new System.EventHandler(this.modUpButton_Click);
            // 
            // tabPageCodes
            // 
            this.tabPageCodes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPageCodes.Controls.Add(this.labelCodeDescription);
            this.tabPageCodes.Controls.Add(this.listViewCodes);
            this.tabPageCodes.Location = new System.Drawing.Point(4, 22);
            this.tabPageCodes.Name = "tabPageCodes";
            this.tabPageCodes.Size = new System.Drawing.Size(478, 421);
            this.tabPageCodes.TabIndex = 1;
            this.tabPageCodes.Text = "Codes";
            // 
            // labelCodeDescription
            // 
            this.labelCodeDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCodeDescription.Location = new System.Drawing.Point(3, 360);
            this.labelCodeDescription.Name = "labelCodeDescription";
            this.labelCodeDescription.Size = new System.Drawing.Size(470, 61);
            this.labelCodeDescription.TabIndex = 1;
            this.labelCodeDescription.Text = "Description: None";
            // 
            // listViewCodes
            // 
            this.listViewCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCodes.AutoArrange = false;
            this.listViewCodes.CheckBoxes = true;
            this.listViewCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCodeName,
            this.columnHeaderCodeAuthor,
            this.columnHeaderCodeCategory});
            this.listViewCodes.FullRowSelect = true;
            this.listViewCodes.HideSelection = false;
            this.listViewCodes.LabelWrap = false;
            this.listViewCodes.Location = new System.Drawing.Point(3, 3);
            this.listViewCodes.MultiSelect = false;
            this.listViewCodes.Name = "listViewCodes";
            this.listViewCodes.ShowGroups = false;
            this.listViewCodes.Size = new System.Drawing.Size(469, 354);
            this.listViewCodes.TabIndex = 0;
            this.listViewCodes.UseCompatibleStateImageBehavior = false;
            this.listViewCodes.View = System.Windows.Forms.View.Details;
            this.listViewCodes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewCodes_ColumnClick);
            this.listViewCodes.SelectedIndexChanged += new System.EventHandler(this.listViewCodes_SelectedIndexChanged);
            // 
            // columnHeaderCodeName
            // 
            this.columnHeaderCodeName.Text = "Code";
            this.columnHeaderCodeName.Width = 246;
            // 
            // columnHeaderCodeAuthor
            // 
            this.columnHeaderCodeAuthor.Text = "Author";
            this.columnHeaderCodeAuthor.Width = 118;
            // 
            // columnHeaderCodeCategory
            // 
            this.columnHeaderCodeCategory.Text = "Category";
            this.columnHeaderCodeCategory.Width = 95;
            // 
            // tabPageGameConfig
            // 
            this.tabPageGameConfig.Controls.Add(this.tabControlGameConfig);
            this.tabPageGameConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageGameConfig.Name = "tabPageGameConfig";
            this.tabPageGameConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGameConfig.Size = new System.Drawing.Size(478, 421);
            this.tabPageGameConfig.TabIndex = 7;
            this.tabPageGameConfig.Text = "Game Settings";
            this.tabPageGameConfig.UseVisualStyleBackColor = true;
            // 
            // tabControlGameConfig
            // 
            this.tabControlGameConfig.Controls.Add(this.tabPageGraphics);
            this.tabControlGameConfig.Controls.Add(this.tabPageInput);
            this.tabControlGameConfig.Controls.Add(this.tabPageController);
            this.tabControlGameConfig.Controls.Add(this.tabPageSound);
            this.tabControlGameConfig.Controls.Add(this.tabPagePatches);
            this.tabControlGameConfig.Controls.Add(this.tabPageGameOptions);
            this.tabControlGameConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlGameConfig.Location = new System.Drawing.Point(3, 3);
            this.tabControlGameConfig.Name = "tabControlGameConfig";
            this.tabControlGameConfig.SelectedIndex = 0;
            this.tabControlGameConfig.Size = new System.Drawing.Size(472, 415);
            this.tabControlGameConfig.TabIndex = 0;
            // 
            // tabPageGraphics
            // 
            this.tabPageGraphics.AutoScroll = true;
            this.tabPageGraphics.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPageGraphics.Controls.Add(this.buttonResetGameSettings);
            this.tabPageGraphics.Controls.Add(this.groupBoxGraphicsOther);
            this.tabPageGraphics.Controls.Add(this.groupBoxVisuals);
            this.tabPageGraphics.Controls.Add(this.groupBoxDisplay);
            this.tabPageGraphics.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraphics.Name = "tabPageGraphics";
            this.tabPageGraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraphics.Size = new System.Drawing.Size(464, 389);
            this.tabPageGraphics.TabIndex = 2;
            this.tabPageGraphics.Text = "Graphics";
            // 
            // buttonResetGameSettings
            // 
            this.buttonResetGameSettings.Location = new System.Drawing.Point(6, 352);
            this.buttonResetGameSettings.Name = "buttonResetGameSettings";
            this.buttonResetGameSettings.Size = new System.Drawing.Size(75, 22);
            this.buttonResetGameSettings.TabIndex = 3;
            this.buttonResetGameSettings.Text = "Reset...";
            this.buttonResetGameSettings.UseVisualStyleBackColor = true;
            this.buttonResetGameSettings.Click += new System.EventHandler(this.buttonResetGameSettings_Click);
            // 
            // groupBoxGraphicsOther
            // 
            this.groupBoxGraphicsOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGraphicsOther.Controls.Add(this.checkBoxShowMouse);
            this.groupBoxGraphicsOther.Controls.Add(this.checkBoxScaleHud);
            this.groupBoxGraphicsOther.Controls.Add(this.comboBoxBackgroundFill);
            this.groupBoxGraphicsOther.Controls.Add(this.comboBoxFmvFill);
            this.groupBoxGraphicsOther.Controls.Add(this.labeFmvFillMode);
            this.groupBoxGraphicsOther.Controls.Add(this.labelBgFillMode);
            this.groupBoxGraphicsOther.Location = new System.Drawing.Point(7, 271);
            this.groupBoxGraphicsOther.Name = "groupBoxGraphicsOther";
            this.groupBoxGraphicsOther.Size = new System.Drawing.Size(469, 75);
            this.groupBoxGraphicsOther.TabIndex = 2;
            this.groupBoxGraphicsOther.TabStop = false;
            this.groupBoxGraphicsOther.Text = "Other Settings";
            // 
            // checkBoxShowMouse
            // 
            this.checkBoxShowMouse.AutoSize = true;
            this.checkBoxShowMouse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxShowMouse.Location = new System.Drawing.Point(199, 47);
            this.checkBoxShowMouse.Name = "checkBoxShowMouse";
            this.checkBoxShowMouse.Size = new System.Drawing.Size(189, 18);
            this.checkBoxShowMouse.TabIndex = 3;
            this.checkBoxShowMouse.Text = "Show Mouse Cursor in Fullscreen";
            this.toolTip.SetToolTip(this.checkBoxShowMouse, "Prevents the mouse cursor from being hidden in Full Screen modes.");
            this.checkBoxShowMouse.UseVisualStyleBackColor = true;
            // 
            // checkBoxScaleHud
            // 
            this.checkBoxScaleHud.AutoSize = true;
            this.checkBoxScaleHud.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxScaleHud.Location = new System.Drawing.Point(199, 19);
            this.checkBoxScaleHud.Name = "checkBoxScaleHud";
            this.checkBoxScaleHud.Size = new System.Drawing.Size(117, 18);
            this.checkBoxScaleHud.TabIndex = 2;
            this.checkBoxScaleHud.Text = "Enable UI Scaling";
            this.toolTip.SetToolTip(this.checkBoxScaleHud, "Enable scaling for UI elements (recommended).");
            this.checkBoxScaleHud.UseVisualStyleBackColor = true;
            // 
            // comboBoxBackgroundFill
            // 
            this.comboBoxBackgroundFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackgroundFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxBackgroundFill.FormattingEnabled = true;
            this.comboBoxBackgroundFill.Items.AddRange(new object[] {
            "Stretch [Default]",
            "Fit",
            "Fill"});
            this.comboBoxBackgroundFill.Location = new System.Drawing.Point(95, 19);
            this.comboBoxBackgroundFill.Name = "comboBoxBackgroundFill";
            this.comboBoxBackgroundFill.Size = new System.Drawing.Size(88, 21);
            this.comboBoxBackgroundFill.TabIndex = 0;
            this.toolTip.SetToolTip(this.comboBoxBackgroundFill, resources.GetString("comboBoxBackgroundFill.ToolTip"));
            // 
            // comboBoxFmvFill
            // 
            this.comboBoxFmvFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFmvFill.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxFmvFill.FormattingEnabled = true;
            this.comboBoxFmvFill.Items.AddRange(new object[] {
            "Stretch [Default]",
            "Fit",
            "Fill"});
            this.comboBoxFmvFill.Location = new System.Drawing.Point(95, 46);
            this.comboBoxFmvFill.Name = "comboBoxFmvFill";
            this.comboBoxFmvFill.Size = new System.Drawing.Size(88, 21);
            this.comboBoxFmvFill.TabIndex = 1;
            this.toolTip.SetToolTip(this.comboBoxFmvFill, resources.GetString("comboBoxFmvFill.ToolTip"));
            // 
            // labeFmvFillMode
            // 
            this.labeFmvFillMode.AutoSize = true;
            this.labeFmvFillMode.Location = new System.Drawing.Point(12, 49);
            this.labeFmvFillMode.Name = "labeFmvFillMode";
            this.labeFmvFillMode.Size = new System.Drawing.Size(77, 13);
            this.labeFmvFillMode.TabIndex = 3;
            this.labeFmvFillMode.Text = "FMV Fill Mode:";
            // 
            // labelBgFillMode
            // 
            this.labelBgFillMode.AutoSize = true;
            this.labelBgFillMode.Location = new System.Drawing.Point(19, 22);
            this.labelBgFillMode.Name = "labelBgFillMode";
            this.labelBgFillMode.Size = new System.Drawing.Size(70, 13);
            this.labelBgFillMode.TabIndex = 1;
            this.labelBgFillMode.Text = "BG Fill Mode:";
            // 
            // groupBoxVisuals
            // 
            this.groupBoxVisuals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVisuals.Controls.Add(this.comboBoxAntialiasing);
            this.groupBoxVisuals.Controls.Add(this.comboBoxAnisotropic);
            this.groupBoxVisuals.Controls.Add(this.labelAnisotropic);
            this.groupBoxVisuals.Controls.Add(this.labelAntiAliasing);
            this.groupBoxVisuals.Controls.Add(this.checkBoxEnableD3D9);
            this.groupBoxVisuals.Controls.Add(this.checkBoxBorderImage);
            this.groupBoxVisuals.Controls.Add(this.comboBoxFogEmulation);
            this.groupBoxVisuals.Controls.Add(this.comboBoxClipLevel);
            this.groupBoxVisuals.Controls.Add(this.labelFogEmulation);
            this.groupBoxVisuals.Controls.Add(this.labelDetail);
            this.groupBoxVisuals.Controls.Add(this.labelFramerate);
            this.groupBoxVisuals.Controls.Add(this.comboBoxFramerate);
            this.groupBoxVisuals.Controls.Add(this.checkBoxForceMipmapping);
            this.groupBoxVisuals.Controls.Add(this.checkBoxForceTextureFilter);
            this.groupBoxVisuals.Location = new System.Drawing.Point(6, 148);
            this.groupBoxVisuals.Name = "groupBoxVisuals";
            this.groupBoxVisuals.Size = new System.Drawing.Size(469, 117);
            this.groupBoxVisuals.TabIndex = 1;
            this.groupBoxVisuals.TabStop = false;
            this.groupBoxVisuals.Text = "Visuals";
            // 
            // comboBoxAntialiasing
            // 
            this.comboBoxAntialiasing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAntialiasing.FormattingEnabled = true;
            this.comboBoxAntialiasing.Items.AddRange(new object[] {
            "None",
            "2x",
            "4x",
            "8x",
            "16x"});
            this.comboBoxAntialiasing.Location = new System.Drawing.Point(217, 82);
            this.comboBoxAntialiasing.Name = "comboBoxAntialiasing";
            this.comboBoxAntialiasing.Size = new System.Drawing.Size(52, 21);
            this.comboBoxAntialiasing.TabIndex = 7;
            this.toolTip.SetToolTip(this.comboBoxAntialiasing, "Make polygons look less jagged. May cause stuttering.");
            // 
            // comboBoxAnisotropic
            // 
            this.comboBoxAnisotropic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnisotropic.FormattingEnabled = true;
            this.comboBoxAnisotropic.Items.AddRange(new object[] {
            "None",
            "1x",
            "2x",
            "4x",
            "8x",
            "16x"});
            this.comboBoxAnisotropic.Location = new System.Drawing.Point(344, 82);
            this.comboBoxAnisotropic.Name = "comboBoxAnisotropic";
            this.comboBoxAnisotropic.Size = new System.Drawing.Size(51, 21);
            this.comboBoxAnisotropic.TabIndex = 8;
            this.toolTip.SetToolTip(this.comboBoxAnisotropic, "Make textures look smoother. 16x is recommended.");
            // 
            // labelAnisotropic
            // 
            this.labelAnisotropic.AutoSize = true;
            this.labelAnisotropic.Location = new System.Drawing.Point(322, 66);
            this.labelAnisotropic.Name = "labelAnisotropic";
            this.labelAnisotropic.Size = new System.Drawing.Size(101, 13);
            this.labelAnisotropic.TabIndex = 27;
            this.labelAnisotropic.Text = "Anisotropic Filtering:";
            // 
            // labelAntiAliasing
            // 
            this.labelAntiAliasing.AutoSize = true;
            this.labelAntiAliasing.Location = new System.Drawing.Point(214, 66);
            this.labelAntiAliasing.Name = "labelAntiAliasing";
            this.labelAntiAliasing.Size = new System.Drawing.Size(67, 13);
            this.labelAntiAliasing.TabIndex = 26;
            this.labelAntiAliasing.Text = "Anti-Aliasing:";
            // 
            // checkBoxEnableD3D9
            // 
            this.checkBoxEnableD3D9.AutoSize = true;
            this.checkBoxEnableD3D9.Enabled = false;
            this.checkBoxEnableD3D9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableD3D9.Location = new System.Drawing.Point(200, 17);
            this.checkBoxEnableD3D9.Name = "checkBoxEnableD3D9";
            this.checkBoxEnableD3D9.Size = new System.Drawing.Size(105, 18);
            this.checkBoxEnableD3D9.TabIndex = 3;
            this.checkBoxEnableD3D9.Text = "Use Direct3D 9";
            this.toolTip.SetToolTip(this.checkBoxEnableD3D9, "Use Direct3D 8 to 9 wrapper (recommended). Required for the Lantern Engine mod.");
            this.checkBoxEnableD3D9.UseVisualStyleBackColor = true;
            this.checkBoxEnableD3D9.Click += new System.EventHandler(this.checkBoxEnableD3D9_Click);
            // 
            // checkBoxBorderImage
            // 
            this.checkBoxBorderImage.AutoSize = true;
            this.checkBoxBorderImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxBorderImage.Location = new System.Drawing.Point(200, 41);
            this.checkBoxBorderImage.Name = "checkBoxBorderImage";
            this.checkBoxBorderImage.Size = new System.Drawing.Size(117, 18);
            this.checkBoxBorderImage.TabIndex = 4;
            this.checkBoxBorderImage.Text = "Use Border Image";
            this.toolTip.SetToolTip(this.checkBoxBorderImage, "Display a frame instead of black bars for 4:3 content.");
            this.checkBoxBorderImage.UseVisualStyleBackColor = true;
            // 
            // comboBoxFogEmulation
            // 
            this.comboBoxFogEmulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFogEmulation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxFogEmulation.FormattingEnabled = true;
            this.comboBoxFogEmulation.Items.AddRange(new object[] {
            "Auto",
            "Emulation"});
            this.comboBoxFogEmulation.Location = new System.Drawing.Point(96, 71);
            this.comboBoxFogEmulation.Name = "comboBoxFogEmulation";
            this.comboBoxFogEmulation.Size = new System.Drawing.Size(88, 21);
            this.comboBoxFogEmulation.TabIndex = 2;
            this.toolTip.SetToolTip(this.comboBoxFogEmulation, "Sets fog mode. Recommended: Auto\r\nOnly set to emulation if you have an archaic vi" +
        "deo card from\r\nbefore 2003.");
            // 
            // comboBoxClipLevel
            // 
            this.comboBoxClipLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClipLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxClipLevel.FormattingEnabled = true;
            this.comboBoxClipLevel.Items.AddRange(new object[] {
            "High (best)",
            "Low",
            "Lowest"});
            this.comboBoxClipLevel.Location = new System.Drawing.Point(96, 44);
            this.comboBoxClipLevel.Name = "comboBoxClipLevel";
            this.comboBoxClipLevel.Size = new System.Drawing.Size(88, 21);
            this.comboBoxClipLevel.TabIndex = 1;
            this.toolTip.SetToolTip(this.comboBoxClipLevel, "Sets detail level. Recommended: High.\r\nAt lower detail level the game skips drawi" +
        "ng distant\r\nobjects, disables some effects and pauses some animations.");
            // 
            // labelFogEmulation
            // 
            this.labelFogEmulation.AutoSize = true;
            this.labelFogEmulation.Location = new System.Drawing.Point(13, 74);
            this.labelFogEmulation.Name = "labelFogEmulation";
            this.labelFogEmulation.Size = new System.Drawing.Size(77, 13);
            this.labelFogEmulation.TabIndex = 8;
            this.labelFogEmulation.Text = "Fog Emulation:";
            // 
            // labelDetail
            // 
            this.labelDetail.AutoSize = true;
            this.labelDetail.Location = new System.Drawing.Point(24, 47);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(66, 13);
            this.labelDetail.TabIndex = 7;
            this.labelDetail.Text = "Detail Level:";
            // 
            // labelFramerate
            // 
            this.labelFramerate.AutoSize = true;
            this.labelFramerate.Location = new System.Drawing.Point(33, 20);
            this.labelFramerate.Name = "labelFramerate";
            this.labelFramerate.Size = new System.Drawing.Size(57, 13);
            this.labelFramerate.TabIndex = 6;
            this.labelFramerate.Text = "Framerate:";
            // 
            // comboBoxFramerate
            // 
            this.comboBoxFramerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFramerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxFramerate.FormattingEnabled = true;
            this.comboBoxFramerate.Items.AddRange(new object[] {
            "60 FPS",
            "30 FPS",
            "15 FPS"});
            this.comboBoxFramerate.Location = new System.Drawing.Point(96, 17);
            this.comboBoxFramerate.Name = "comboBoxFramerate";
            this.comboBoxFramerate.Size = new System.Drawing.Size(88, 21);
            this.comboBoxFramerate.TabIndex = 0;
            this.toolTip.SetToolTip(this.comboBoxFramerate, "Sets the target framerate. Recommended: 60 FPS.\r\nHigher framerate is recommended " +
        "for smoother gameplay.");
            // 
            // checkBoxForceMipmapping
            // 
            this.checkBoxForceMipmapping.AutoSize = true;
            this.checkBoxForceMipmapping.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxForceMipmapping.Location = new System.Drawing.Point(325, 17);
            this.checkBoxForceMipmapping.Name = "checkBoxForceMipmapping";
            this.checkBoxForceMipmapping.Size = new System.Drawing.Size(119, 18);
            this.checkBoxForceMipmapping.TabIndex = 5;
            this.checkBoxForceMipmapping.Text = "Force Mipmapping";
            this.toolTip.SetToolTip(this.checkBoxForceMipmapping, "Generates mipmaps for all textures that don\'t have them. Improves the look of dis" +
        "tant objects with vanilla SADX textures and texture packs.");
            this.checkBoxForceMipmapping.UseVisualStyleBackColor = true;
            // 
            // checkBoxForceTextureFilter
            // 
            this.checkBoxForceTextureFilter.AutoSize = true;
            this.checkBoxForceTextureFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxForceTextureFilter.Location = new System.Drawing.Point(325, 41);
            this.checkBoxForceTextureFilter.Name = "checkBoxForceTextureFilter";
            this.checkBoxForceTextureFilter.Size = new System.Drawing.Size(98, 18);
            this.checkBoxForceTextureFilter.TabIndex = 6;
            this.checkBoxForceTextureFilter.Text = "Force Filtering";
            this.toolTip.SetToolTip(this.checkBoxForceTextureFilter, "Forces all Point Filtered textures to use Linear filtering. This makes UI texture" +
        "s smoother.");
            this.checkBoxForceTextureFilter.UseVisualStyleBackColor = true;
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDisplay.Controls.Add(this.checkBoxWindowResizable);
            this.groupBoxDisplay.Controls.Add(this.labelCustomWindowSize);
            this.groupBoxDisplay.Controls.Add(this.checkBoxWindowMaintainAspect);
            this.groupBoxDisplay.Controls.Add(this.comboBoxScreenMode);
            this.groupBoxDisplay.Controls.Add(label2);
            this.groupBoxDisplay.Controls.Add(this.numericUpDownWindowHeight);
            this.groupBoxDisplay.Controls.Add(this.numericUpDownWindowWidth);
            this.groupBoxDisplay.Controls.Add(this.labelScreenMode);
            this.groupBoxDisplay.Controls.Add(this.comboBoxResolutionPreset);
            this.groupBoxDisplay.Controls.Add(labelRenderResolution);
            this.groupBoxDisplay.Controls.Add(this.checkBoxVsync);
            this.groupBoxDisplay.Controls.Add(labelGameScreen);
            this.groupBoxDisplay.Controls.Add(this.comboBoxScreenNumber);
            this.groupBoxDisplay.Controls.Add(this.checkBoxForceAspectRatio);
            this.groupBoxDisplay.Controls.Add(this.numericUpDownHorizontalResolution);
            this.groupBoxDisplay.Controls.Add(label1);
            this.groupBoxDisplay.Controls.Add(this.numericUpDownVerticalResolution);
            this.groupBoxDisplay.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(469, 136);
            this.groupBoxDisplay.TabIndex = 0;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display";
            // 
            // checkBoxWindowResizable
            // 
            this.checkBoxWindowResizable.AutoSize = true;
            this.checkBoxWindowResizable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxWindowResizable.Location = new System.Drawing.Point(366, 106);
            this.checkBoxWindowResizable.Name = "checkBoxWindowResizable";
            this.checkBoxWindowResizable.Size = new System.Drawing.Size(78, 18);
            this.checkBoxWindowResizable.TabIndex = 10;
            this.checkBoxWindowResizable.Text = "Resizable";
            this.toolTip.SetToolTip(this.checkBoxWindowResizable, "Allows the window to be resized and dynamically adjusts resolution to match.");
            this.checkBoxWindowResizable.UseVisualStyleBackColor = true;
            // 
            // labelCustomWindowSize
            // 
            this.labelCustomWindowSize.AutoSize = true;
            this.labelCustomWindowSize.Location = new System.Drawing.Point(7, 108);
            this.labelCustomWindowSize.Name = "labelCustomWindowSize";
            this.labelCustomWindowSize.Size = new System.Drawing.Size(110, 13);
            this.labelCustomWindowSize.TabIndex = 16;
            this.labelCustomWindowSize.Text = "Custom Window Size:";
            // 
            // checkBoxWindowMaintainAspect
            // 
            this.checkBoxWindowMaintainAspect.AutoSize = true;
            this.checkBoxWindowMaintainAspect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxWindowMaintainAspect.Location = new System.Drawing.Point(276, 106);
            this.checkBoxWindowMaintainAspect.Name = "checkBoxWindowMaintainAspect";
            this.checkBoxWindowMaintainAspect.Size = new System.Drawing.Size(85, 18);
            this.checkBoxWindowMaintainAspect.TabIndex = 9;
            this.checkBoxWindowMaintainAspect.Text = "Keep Ratio";
            this.toolTip.SetToolTip(this.checkBoxWindowMaintainAspect, "Forces the window\'s aspect ratio to match the current custom resolution\'s.");
            this.checkBoxWindowMaintainAspect.UseVisualStyleBackColor = true;
            this.checkBoxWindowMaintainAspect.CheckedChanged += new System.EventHandler(this.maintainWindowAspectRatioCheckBox_CheckedChanged);
            // 
            // comboBoxScreenMode
            // 
            this.comboBoxScreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScreenMode.FormattingEnabled = true;
            this.comboBoxScreenMode.Items.AddRange(new object[] {
            "Windowed",
            "Exclusive Fullscreen",
            "Borderless Fullscreen",
            "Custom Window"});
            this.comboBoxScreenMode.Location = new System.Drawing.Point(87, 46);
            this.comboBoxScreenMode.Name = "comboBoxScreenMode";
            this.comboBoxScreenMode.Size = new System.Drawing.Size(182, 21);
            this.comboBoxScreenMode.TabIndex = 1;
            this.comboBoxScreenMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxScreenMode_SelectedIndexChanged);
            // 
            // numericUpDownWindowHeight
            // 
            this.numericUpDownWindowHeight.Location = new System.Drawing.Point(207, 106);
            this.numericUpDownWindowHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownWindowHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWindowHeight.Name = "numericUpDownWindowHeight";
            this.numericUpDownWindowHeight.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownWindowHeight.TabIndex = 8;
            this.numericUpDownWindowHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.numericUpDownWindowHeight.ValueChanged += new System.EventHandler(this.windowHeight_ValueChanged);
            // 
            // numericUpDownWindowWidth
            // 
            this.numericUpDownWindowWidth.Location = new System.Drawing.Point(122, 106);
            this.numericUpDownWindowWidth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownWindowWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWindowWidth.Name = "numericUpDownWindowWidth";
            this.numericUpDownWindowWidth.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownWindowWidth.TabIndex = 7;
            this.numericUpDownWindowWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // labelScreenMode
            // 
            this.labelScreenMode.AutoSize = true;
            this.labelScreenMode.Location = new System.Drawing.Point(7, 49);
            this.labelScreenMode.Name = "labelScreenMode";
            this.labelScreenMode.Size = new System.Drawing.Size(74, 13);
            this.labelScreenMode.TabIndex = 18;
            this.labelScreenMode.Text = "Screen Mode:";
            // 
            // comboBoxResolutionPreset
            // 
            this.comboBoxResolutionPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResolutionPreset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxResolutionPreset.FormattingEnabled = true;
            this.comboBoxResolutionPreset.Items.AddRange(new object[] {
            "640x480",
            "800x600",
            "1024x768",
            "1152x864",
            "1280x960",
            "1280x1024",
            "Native",
            "1/2x Native",
            "2x Native",
            "720p",
            "1080p",
            "4K",
            "8K"});
            this.comboBoxResolutionPreset.Location = new System.Drawing.Point(276, 76);
            this.comboBoxResolutionPreset.Name = "comboBoxResolutionPreset";
            this.comboBoxResolutionPreset.Size = new System.Drawing.Size(84, 21);
            this.comboBoxResolutionPreset.TabIndex = 5;
            this.toolTip.SetToolTip(this.comboBoxResolutionPreset, "Allows you to select pre-set values for the resolution.");
            this.comboBoxResolutionPreset.SelectedIndexChanged += new System.EventHandler(this.comboResolutionPreset_SelectedIndexChanged);
            // 
            // checkBoxVsync
            // 
            this.checkBoxVsync.AutoSize = true;
            this.checkBoxVsync.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxVsync.Location = new System.Drawing.Point(275, 47);
            this.checkBoxVsync.Name = "checkBoxVsync";
            this.checkBoxVsync.Size = new System.Drawing.Size(99, 18);
            this.checkBoxVsync.TabIndex = 2;
            this.checkBoxVsync.Text = "Enable VSync";
            this.toolTip.SetToolTip(this.checkBoxVsync, "Limit the game\'s framerate by the monitor refresh rate.");
            this.checkBoxVsync.UseVisualStyleBackColor = true;
            // 
            // tabPageInput
            // 
            this.tabPageInput.Controls.Add(this.groupBoxControllerDInput);
            this.tabPageInput.Controls.Add(this.groupBoxInputMode);
            this.tabPageInput.Controls.Add(this.groupBoxMouseMode);
            this.tabPageInput.Location = new System.Drawing.Point(4, 22);
            this.tabPageInput.Name = "tabPageInput";
            this.tabPageInput.Size = new System.Drawing.Size(464, 366);
            this.tabPageInput.TabIndex = 8;
            this.tabPageInput.Text = "Input";
            this.tabPageInput.UseVisualStyleBackColor = true;
            // 
            // groupBoxControllerDInput
            // 
            this.groupBoxControllerDInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxControllerDInput.Controls.Add(labelControllerProfile);
            this.groupBoxControllerDInput.Controls.Add(this.comboBoxControllerName);
            this.groupBoxControllerDInput.Controls.Add(this.comboBoxControllerProfile);
            this.groupBoxControllerDInput.Controls.Add(labelControllerName);
            this.groupBoxControllerDInput.Controls.Add(this.buttonControllerProfileAdd);
            this.groupBoxControllerDInput.Controls.Add(this.tableLayoutPanelDInput);
            this.groupBoxControllerDInput.Controls.Add(this.buttonControllerProfileRemove);
            this.groupBoxControllerDInput.Location = new System.Drawing.Point(3, 129);
            this.groupBoxControllerDInput.Name = "groupBoxControllerDInput";
            this.groupBoxControllerDInput.Size = new System.Drawing.Size(458, 265);
            this.groupBoxControllerDInput.TabIndex = 2;
            this.groupBoxControllerDInput.TabStop = false;
            this.groupBoxControllerDInput.Text = "Controller (DirectInput)";
            // 
            // comboBoxControllerName
            // 
            this.comboBoxControllerName.Enabled = false;
            this.comboBoxControllerName.Location = new System.Drawing.Point(272, 76);
            this.comboBoxControllerName.Name = "comboBoxControllerName";
            this.comboBoxControllerName.Size = new System.Drawing.Size(155, 20);
            this.comboBoxControllerName.TabIndex = 2;
            this.comboBoxControllerName.TextChanged += new System.EventHandler(this.comboBoxControllerName_TextChanged);
            // 
            // comboBoxControllerProfile
            // 
            this.comboBoxControllerProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxControllerProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxControllerProfile.FormattingEnabled = true;
            this.comboBoxControllerProfile.Location = new System.Drawing.Point(272, 31);
            this.comboBoxControllerProfile.Name = "comboBoxControllerProfile";
            this.comboBoxControllerProfile.Size = new System.Drawing.Size(155, 21);
            this.comboBoxControllerProfile.TabIndex = 1;
            this.comboBoxControllerProfile.SelectedIndexChanged += new System.EventHandler(this.comboBoxControllerProfile_SelectedIndexChanged);
            // 
            // buttonControllerProfileAdd
            // 
            this.buttonControllerProfileAdd.AutoSize = true;
            this.buttonControllerProfileAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonControllerProfileAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonControllerProfileAdd.Location = new System.Drawing.Point(272, 102);
            this.buttonControllerProfileAdd.Name = "buttonControllerProfileAdd";
            this.buttonControllerProfileAdd.Size = new System.Drawing.Size(40, 22);
            this.buttonControllerProfileAdd.TabIndex = 3;
            this.buttonControllerProfileAdd.Text = "Add";
            this.buttonControllerProfileAdd.UseVisualStyleBackColor = true;
            this.buttonControllerProfileAdd.Click += new System.EventHandler(this.buttonControllerProfileAdd_Click);
            // 
            // tableLayoutPanelDInput
            // 
            this.tableLayoutPanelDInput.AutoSize = true;
            this.tableLayoutPanelDInput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDInput.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelDInput.ColumnCount = 2;
            this.tableLayoutPanelDInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDInput.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanelDInput.Name = "tableLayoutPanelDInput";
            this.tableLayoutPanelDInput.RowCount = 1;
            this.tableLayoutPanelDInput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDInput.Size = new System.Drawing.Size(3, 2);
            this.tableLayoutPanelDInput.TabIndex = 0;
            this.tableLayoutPanelDInput.TabStop = true;
            // 
            // buttonControllerProfileRemove
            // 
            this.buttonControllerProfileRemove.AutoSize = true;
            this.buttonControllerProfileRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonControllerProfileRemove.Enabled = false;
            this.buttonControllerProfileRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonControllerProfileRemove.Location = new System.Drawing.Point(323, 102);
            this.buttonControllerProfileRemove.Name = "buttonControllerProfileRemove";
            this.buttonControllerProfileRemove.Size = new System.Drawing.Size(61, 22);
            this.buttonControllerProfileRemove.TabIndex = 4;
            this.buttonControllerProfileRemove.Text = "Remove";
            this.buttonControllerProfileRemove.UseVisualStyleBackColor = true;
            this.buttonControllerProfileRemove.Click += new System.EventHandler(this.buttonControllerProfileRemove_Click);
            // 
            // groupBoxInputMode
            // 
            this.groupBoxInputMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInputMode.Controls.Add(this.radioButtonSDL);
            this.groupBoxInputMode.Controls.Add(this.radioButtonDInput);
            this.groupBoxInputMode.Location = new System.Drawing.Point(4, 4);
            this.groupBoxInputMode.Name = "groupBoxInputMode";
            this.groupBoxInputMode.Size = new System.Drawing.Size(457, 44);
            this.groupBoxInputMode.TabIndex = 0;
            this.groupBoxInputMode.TabStop = false;
            this.groupBoxInputMode.Text = "Input Mode";
            // 
            // radioButtonSDL
            // 
            this.radioButtonSDL.AutoSize = true;
            this.radioButtonSDL.Location = new System.Drawing.Point(132, 19);
            this.radioButtonSDL.Name = "radioButtonSDL";
            this.radioButtonSDL.Size = new System.Drawing.Size(110, 17);
            this.radioButtonSDL.TabIndex = 1;
            this.radioButtonSDL.Text = "Better Input (SDL)";
            this.toolTip.SetToolTip(this.radioButtonSDL, "Use the SDL library for input, which supports modern controllers and remapping.\r\n" +
        "Keyboard controls can also be remapped in this mode.");
            this.radioButtonSDL.UseVisualStyleBackColor = true;
            // 
            // radioButtonDInput
            // 
            this.radioButtonDInput.AutoSize = true;
            this.radioButtonDInput.Checked = true;
            this.radioButtonDInput.Location = new System.Drawing.Point(6, 19);
            this.radioButtonDInput.Name = "radioButtonDInput";
            this.radioButtonDInput.Size = new System.Drawing.Size(117, 17);
            this.radioButtonDInput.TabIndex = 0;
            this.radioButtonDInput.TabStop = true;
            this.radioButtonDInput.Text = "DirectInput (Vanilla)";
            this.toolTip.SetToolTip(this.radioButtonDInput, "Use the game\'s original input system.\r\nIt does not support axis remapping and may" +
        " not work well with some controllers.");
            this.radioButtonDInput.UseVisualStyleBackColor = true;
            this.radioButtonDInput.CheckedChanged += new System.EventHandler(this.radioButtonDInput_CheckedChanged);
            // 
            // groupBoxMouseMode
            // 
            this.groupBoxMouseMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMouseMode.Controls.Add(this.radioButtonMouseDisable);
            this.groupBoxMouseMode.Controls.Add(this.labelMouseButtonAssignment);
            this.groupBoxMouseMode.Controls.Add(this.comboBoxMouseButtonAssignment);
            this.groupBoxMouseMode.Controls.Add(this.radioButtonMouseDragAccelerate);
            this.groupBoxMouseMode.Controls.Add(this.radioButtonMouseHold);
            this.groupBoxMouseMode.Controls.Add(this.comboBoxMouseAction);
            this.groupBoxMouseMode.Controls.Add(this.labelMouseAction);
            this.groupBoxMouseMode.Location = new System.Drawing.Point(4, 54);
            this.groupBoxMouseMode.Name = "groupBoxMouseMode";
            this.groupBoxMouseMode.Size = new System.Drawing.Size(457, 69);
            this.groupBoxMouseMode.TabIndex = 1;
            this.groupBoxMouseMode.TabStop = false;
            this.groupBoxMouseMode.Text = "Mouse";
            // 
            // radioButtonMouseDisable
            // 
            this.radioButtonMouseDisable.AutoSize = true;
            this.radioButtonMouseDisable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonMouseDisable.Location = new System.Drawing.Point(226, 18);
            this.radioButtonMouseDisable.Name = "radioButtonMouseDisable";
            this.radioButtonMouseDisable.Size = new System.Drawing.Size(101, 18);
            this.radioButtonMouseDisable.TabIndex = 2;
            this.radioButtonMouseDisable.TabStop = true;
            this.radioButtonMouseDisable.Text = "Disable Mouse";
            this.radioButtonMouseDisable.UseVisualStyleBackColor = true;
            // 
            // labelMouseButtonAssignment
            // 
            this.labelMouseButtonAssignment.AutoSize = true;
            this.labelMouseButtonAssignment.Location = new System.Drawing.Point(156, 44);
            this.labelMouseButtonAssignment.Name = "labelMouseButtonAssignment";
            this.labelMouseButtonAssignment.Size = new System.Drawing.Size(98, 13);
            this.labelMouseButtonAssignment.TabIndex = 3;
            this.labelMouseButtonAssignment.Text = "Button Assignment:";
            // 
            // comboBoxMouseButtonAssignment
            // 
            this.comboBoxMouseButtonAssignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMouseButtonAssignment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxMouseButtonAssignment.FormattingEnabled = true;
            this.comboBoxMouseButtonAssignment.Items.AddRange(new object[] {
            "[None]",
            "Left Mouse Button",
            "Right Mouse Button",
            "Middle Mouse Button",
            "Other Mouse Button 1",
            "Left + Right Mouse Button",
            "Right + Left Mouse Button"});
            this.comboBoxMouseButtonAssignment.Location = new System.Drawing.Point(261, 42);
            this.comboBoxMouseButtonAssignment.Name = "comboBoxMouseButtonAssignment";
            this.comboBoxMouseButtonAssignment.Size = new System.Drawing.Size(184, 21);
            this.comboBoxMouseButtonAssignment.TabIndex = 4;
            this.comboBoxMouseButtonAssignment.SelectedIndexChanged += new System.EventHandler(this.comboMouseButtons_SelectedIndexChanged);
            // 
            // radioButtonMouseDragAccelerate
            // 
            this.radioButtonMouseDragAccelerate.AutoSize = true;
            this.radioButtonMouseDragAccelerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonMouseDragAccelerate.Location = new System.Drawing.Point(6, 18);
            this.radioButtonMouseDragAccelerate.Name = "radioButtonMouseDragAccelerate";
            this.radioButtonMouseDragAccelerate.Size = new System.Drawing.Size(120, 18);
            this.radioButtonMouseDragAccelerate.TabIndex = 0;
            this.radioButtonMouseDragAccelerate.TabStop = true;
            this.radioButtonMouseDragAccelerate.Text = "Drag to Accelerate";
            this.radioButtonMouseDragAccelerate.UseVisualStyleBackColor = true;
            // 
            // radioButtonMouseHold
            // 
            this.radioButtonMouseHold.AutoSize = true;
            this.radioButtonMouseHold.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonMouseHold.Location = new System.Drawing.Point(132, 18);
            this.radioButtonMouseHold.Name = "radioButtonMouseHold";
            this.radioButtonMouseHold.Size = new System.Drawing.Size(88, 18);
            this.radioButtonMouseHold.TabIndex = 1;
            this.radioButtonMouseHold.TabStop = true;
            this.radioButtonMouseHold.Text = "Drag && Hold";
            this.radioButtonMouseHold.UseVisualStyleBackColor = true;
            // 
            // comboBoxMouseAction
            // 
            this.comboBoxMouseAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMouseAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxMouseAction.FormattingEnabled = true;
            this.comboBoxMouseAction.Items.AddRange(new object[] {
            "Start",
            "Attack/Cancel",
            "Jump/Confirm",
            "Action",
            "Flute"});
            this.comboBoxMouseAction.Location = new System.Drawing.Point(47, 42);
            this.comboBoxMouseAction.Name = "comboBoxMouseAction";
            this.comboBoxMouseAction.Size = new System.Drawing.Size(92, 21);
            this.comboBoxMouseAction.TabIndex = 3;
            this.comboBoxMouseAction.SelectedIndexChanged += new System.EventHandler(this.comboMouseActions_SelectedIndexChanged);
            // 
            // labelMouseAction
            // 
            this.labelMouseAction.AutoSize = true;
            this.labelMouseAction.Location = new System.Drawing.Point(3, 44);
            this.labelMouseAction.Name = "labelMouseAction";
            this.labelMouseAction.Size = new System.Drawing.Size(40, 13);
            this.labelMouseAction.TabIndex = 0;
            this.labelMouseAction.Text = "Action:";
            // 
            // tabPageController
            // 
            this.tabPageController.Controls.Add(this.groupBoxControlsSDL);
            this.tabPageController.Location = new System.Drawing.Point(4, 22);
            this.tabPageController.Name = "tabPageController";
            this.tabPageController.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageController.Size = new System.Drawing.Size(464, 366);
            this.tabPageController.TabIndex = 9;
            this.tabPageController.Text = "Controls";
            this.tabPageController.UseVisualStyleBackColor = true;
            // 
            // groupBoxControlsSDL
            // 
            this.groupBoxControlsSDL.Controls.Add(this.labelSdlDevice);
            this.groupBoxControlsSDL.Controls.Add(this.comboBoxSdlDevice);
            this.groupBoxControlsSDL.Controls.Add(this.buttonBindingReset);
            this.groupBoxControlsSDL.Controls.Add(this.buttonBindingClear);
            this.groupBoxControlsSDL.Controls.Add(this.buttonBindingSet);
            this.groupBoxControlsSDL.Controls.Add(this.groupBoxRumble);
            this.groupBoxControlsSDL.Controls.Add(this.groupBoxDeadzones);
            this.groupBoxControlsSDL.Controls.Add(this.labelKeyboardPlayer);
            this.groupBoxControlsSDL.Controls.Add(this.comboBoxKeyboardPlayer);
            this.groupBoxControlsSDL.Controls.Add(this.listViewControlBindings);
            this.groupBoxControlsSDL.Location = new System.Drawing.Point(3, 6);
            this.groupBoxControlsSDL.Name = "groupBoxControlsSDL";
            this.groupBoxControlsSDL.Size = new System.Drawing.Size(452, 385);
            this.groupBoxControlsSDL.TabIndex = 2;
            this.groupBoxControlsSDL.TabStop = false;
            this.groupBoxControlsSDL.Text = "Controls (SDL)";
            // 
            // labelSdlDevice
            // 
            this.labelSdlDevice.AutoSize = true;
            this.labelSdlDevice.Location = new System.Drawing.Point(24, 21);
            this.labelSdlDevice.Name = "labelSdlDevice";
            this.labelSdlDevice.Size = new System.Drawing.Size(44, 13);
            this.labelSdlDevice.TabIndex = 29;
            this.labelSdlDevice.Text = "Device:";
            // 
            // comboBoxSdlDevice
            // 
            this.comboBoxSdlDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSdlDevice.FormattingEnabled = true;
            this.comboBoxSdlDevice.Items.AddRange(new object[] {
            "Keyboard",
            "Controller 1",
            "Controller 2",
            "Controller 3",
            "Controller 4",
            "Controller 5",
            "Controller 6",
            "Controller 7",
            "Controller 8"});
            this.comboBoxSdlDevice.Location = new System.Drawing.Point(68, 18);
            this.comboBoxSdlDevice.Name = "comboBoxSdlDevice";
            this.comboBoxSdlDevice.Size = new System.Drawing.Size(202, 21);
            this.comboBoxSdlDevice.TabIndex = 0;
            // 
            // buttonBindingReset
            // 
            this.buttonBindingReset.Location = new System.Drawing.Point(399, 359);
            this.buttonBindingReset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBindingReset.Name = "buttonBindingReset";
            this.buttonBindingReset.Size = new System.Drawing.Size(51, 21);
            this.buttonBindingReset.TabIndex = 7;
            this.buttonBindingReset.Text = "Reset";
            this.buttonBindingReset.UseVisualStyleBackColor = true;
            // 
            // buttonBindingClear
            // 
            this.buttonBindingClear.Location = new System.Drawing.Point(337, 359);
            this.buttonBindingClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBindingClear.Name = "buttonBindingClear";
            this.buttonBindingClear.Size = new System.Drawing.Size(51, 21);
            this.buttonBindingClear.TabIndex = 6;
            this.buttonBindingClear.Text = "Clear";
            this.buttonBindingClear.UseVisualStyleBackColor = true;
            // 
            // buttonBindingSet
            // 
            this.buttonBindingSet.Location = new System.Drawing.Point(276, 359);
            this.buttonBindingSet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBindingSet.Name = "buttonBindingSet";
            this.buttonBindingSet.Size = new System.Drawing.Size(51, 21);
            this.buttonBindingSet.TabIndex = 5;
            this.buttonBindingSet.Text = "Set...";
            this.buttonBindingSet.UseVisualStyleBackColor = true;
            // 
            // groupBoxRumble
            // 
            this.groupBoxRumble.Controls.Add(this.numericUpDownRumbleMultiplier);
            this.groupBoxRumble.Controls.Add(this.numericUpDownRumbleMinTime);
            this.groupBoxRumble.Controls.Add(this.labelRumpleMultiplier);
            this.groupBoxRumble.Controls.Add(this.labelMinRumbleTime);
            this.groupBoxRumble.Controls.Add(this.checkBoxMegaRumble);
            this.groupBoxRumble.Location = new System.Drawing.Point(5, 173);
            this.groupBoxRumble.Name = "groupBoxRumble";
            this.groupBoxRumble.Size = new System.Drawing.Size(265, 70);
            this.groupBoxRumble.TabIndex = 3;
            this.groupBoxRumble.TabStop = false;
            this.groupBoxRumble.Text = "Rumble";
            // 
            // numericUpDownRumbleMultiplier
            // 
            this.numericUpDownRumbleMultiplier.Location = new System.Drawing.Point(75, 40);
            this.numericUpDownRumbleMultiplier.Name = "numericUpDownRumbleMultiplier";
            this.numericUpDownRumbleMultiplier.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownRumbleMultiplier.TabIndex = 1;
            // 
            // numericUpDownRumbleMinTime
            // 
            this.numericUpDownRumbleMinTime.Location = new System.Drawing.Point(75, 14);
            this.numericUpDownRumbleMinTime.Name = "numericUpDownRumbleMinTime";
            this.numericUpDownRumbleMinTime.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownRumbleMinTime.TabIndex = 0;
            // 
            // labelRumpleMultiplier
            // 
            this.labelRumpleMultiplier.AutoSize = true;
            this.labelRumpleMultiplier.Location = new System.Drawing.Point(5, 42);
            this.labelRumpleMultiplier.Name = "labelRumpleMultiplier";
            this.labelRumpleMultiplier.Size = new System.Drawing.Size(62, 13);
            this.labelRumpleMultiplier.TabIndex = 2;
            this.labelRumpleMultiplier.Text = "Multiplier %:";
            // 
            // labelMinRumbleTime
            // 
            this.labelMinRumbleTime.AutoSize = true;
            this.labelMinRumbleTime.Location = new System.Drawing.Point(16, 16);
            this.labelMinRumbleTime.Name = "labelMinRumbleTime";
            this.labelMinRumbleTime.Size = new System.Drawing.Size(53, 13);
            this.labelMinRumbleTime.TabIndex = 1;
            this.labelMinRumbleTime.Text = "Min Time:";
            // 
            // checkBoxMegaRumble
            // 
            this.checkBoxMegaRumble.AutoSize = true;
            this.checkBoxMegaRumble.Location = new System.Drawing.Point(148, 29);
            this.checkBoxMegaRumble.Name = "checkBoxMegaRumble";
            this.checkBoxMegaRumble.Size = new System.Drawing.Size(92, 17);
            this.checkBoxMegaRumble.TabIndex = 2;
            this.checkBoxMegaRumble.Text = "Mega Rumble";
            this.checkBoxMegaRumble.UseVisualStyleBackColor = true;
            // 
            // groupBoxDeadzones
            // 
            this.groupBoxDeadzones.Controls.Add(this.checkBoxRadialMotionRight);
            this.groupBoxDeadzones.Controls.Add(this.checkBoxRadialMotionLeft);
            this.groupBoxDeadzones.Controls.Add(this.numericUpDownTriggersDeadzone);
            this.groupBoxDeadzones.Controls.Add(this.numericUpDownRightStickDeadzone);
            this.groupBoxDeadzones.Controls.Add(this.numericUpDownLeftStickDeadzone);
            this.groupBoxDeadzones.Controls.Add(this.labelTriggersDeadzone);
            this.groupBoxDeadzones.Controls.Add(this.labelRightStickDeadzone);
            this.groupBoxDeadzones.Controls.Add(this.labelLeftStickDeadzone);
            this.groupBoxDeadzones.Location = new System.Drawing.Point(5, 67);
            this.groupBoxDeadzones.Name = "groupBoxDeadzones";
            this.groupBoxDeadzones.Size = new System.Drawing.Size(265, 100);
            this.groupBoxDeadzones.TabIndex = 2;
            this.groupBoxDeadzones.TabStop = false;
            this.groupBoxDeadzones.Text = "Deadzones";
            // 
            // checkBoxRadialMotionRight
            // 
            this.checkBoxRadialMotionRight.AutoSize = true;
            this.checkBoxRadialMotionRight.Location = new System.Drawing.Point(148, 48);
            this.checkBoxRadialMotionRight.Name = "checkBoxRadialMotionRight";
            this.checkBoxRadialMotionRight.Size = new System.Drawing.Size(102, 17);
            this.checkBoxRadialMotionRight.TabIndex = 3;
            this.checkBoxRadialMotionRight.Text = "Radial Motion R";
            this.checkBoxRadialMotionRight.UseVisualStyleBackColor = true;
            // 
            // checkBoxRadialMotionLeft
            // 
            this.checkBoxRadialMotionLeft.AutoSize = true;
            this.checkBoxRadialMotionLeft.Location = new System.Drawing.Point(148, 22);
            this.checkBoxRadialMotionLeft.Name = "checkBoxRadialMotionLeft";
            this.checkBoxRadialMotionLeft.Size = new System.Drawing.Size(100, 17);
            this.checkBoxRadialMotionLeft.TabIndex = 1;
            this.checkBoxRadialMotionLeft.Text = "Radial Motion L";
            this.checkBoxRadialMotionLeft.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTriggersDeadzone
            // 
            this.numericUpDownTriggersDeadzone.Location = new System.Drawing.Point(75, 71);
            this.numericUpDownTriggersDeadzone.Name = "numericUpDownTriggersDeadzone";
            this.numericUpDownTriggersDeadzone.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownTriggersDeadzone.TabIndex = 4;
            // 
            // numericUpDownRightStickDeadzone
            // 
            this.numericUpDownRightStickDeadzone.Location = new System.Drawing.Point(75, 45);
            this.numericUpDownRightStickDeadzone.Name = "numericUpDownRightStickDeadzone";
            this.numericUpDownRightStickDeadzone.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownRightStickDeadzone.TabIndex = 2;
            // 
            // numericUpDownLeftStickDeadzone
            // 
            this.numericUpDownLeftStickDeadzone.Location = new System.Drawing.Point(75, 19);
            this.numericUpDownLeftStickDeadzone.Name = "numericUpDownLeftStickDeadzone";
            this.numericUpDownLeftStickDeadzone.Size = new System.Drawing.Size(67, 20);
            this.numericUpDownLeftStickDeadzone.TabIndex = 0;
            // 
            // labelTriggersDeadzone
            // 
            this.labelTriggersDeadzone.AutoSize = true;
            this.labelTriggersDeadzone.Location = new System.Drawing.Point(21, 73);
            this.labelTriggersDeadzone.Name = "labelTriggersDeadzone";
            this.labelTriggersDeadzone.Size = new System.Drawing.Size(48, 13);
            this.labelTriggersDeadzone.TabIndex = 2;
            this.labelTriggersDeadzone.Text = "Triggers:";
            // 
            // labelRightStickDeadzone
            // 
            this.labelRightStickDeadzone.AutoSize = true;
            this.labelRightStickDeadzone.Location = new System.Drawing.Point(7, 47);
            this.labelRightStickDeadzone.Name = "labelRightStickDeadzone";
            this.labelRightStickDeadzone.Size = new System.Drawing.Size(62, 13);
            this.labelRightStickDeadzone.TabIndex = 1;
            this.labelRightStickDeadzone.Text = "Right Stick:";
            // 
            // labelLeftStickDeadzone
            // 
            this.labelLeftStickDeadzone.AutoSize = true;
            this.labelLeftStickDeadzone.Location = new System.Drawing.Point(14, 21);
            this.labelLeftStickDeadzone.Name = "labelLeftStickDeadzone";
            this.labelLeftStickDeadzone.Size = new System.Drawing.Size(55, 13);
            this.labelLeftStickDeadzone.TabIndex = 0;
            this.labelLeftStickDeadzone.Text = "Left Stick:";
            // 
            // labelKeyboardPlayer
            // 
            this.labelKeyboardPlayer.AutoSize = true;
            this.labelKeyboardPlayer.Location = new System.Drawing.Point(12, 46);
            this.labelKeyboardPlayer.Name = "labelKeyboardPlayer";
            this.labelKeyboardPlayer.Size = new System.Drawing.Size(56, 13);
            this.labelKeyboardPlayer.TabIndex = 21;
            this.labelKeyboardPlayer.Text = "KB Player:";
            // 
            // comboBoxKeyboardPlayer
            // 
            this.comboBoxKeyboardPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKeyboardPlayer.FormattingEnabled = true;
            this.comboBoxKeyboardPlayer.Items.AddRange(new object[] {
            "Player 1",
            "Player 2",
            "Player 3",
            "Player 4",
            "Player 5",
            "Player 6",
            "Player 7",
            "Player 8"});
            this.comboBoxKeyboardPlayer.Location = new System.Drawing.Point(68, 43);
            this.comboBoxKeyboardPlayer.Name = "comboBoxKeyboardPlayer";
            this.comboBoxKeyboardPlayer.Size = new System.Drawing.Size(107, 21);
            this.comboBoxKeyboardPlayer.TabIndex = 1;
            // 
            // listViewControlBindings
            // 
            this.listViewControlBindings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewControlBindings.HideSelection = false;
            this.listViewControlBindings.Location = new System.Drawing.Point(276, 18);
            this.listViewControlBindings.Name = "listViewControlBindings";
            this.listViewControlBindings.Size = new System.Drawing.Size(175, 336);
            this.listViewControlBindings.TabIndex = 4;
            this.listViewControlBindings.UseCompatibleStateImageBehavior = false;
            this.listViewControlBindings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Control";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Binding";
            this.columnHeader2.Width = 68;
            // 
            // tabPageSound
            // 
            this.tabPageSound.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPageSound.Controls.Add(this.groupBoxSoundVolume);
            this.tabPageSound.Controls.Add(this.groupBoxSound);
            this.tabPageSound.Location = new System.Drawing.Point(4, 22);
            this.tabPageSound.Name = "tabPageSound";
            this.tabPageSound.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSound.Size = new System.Drawing.Size(464, 366);
            this.tabPageSound.TabIndex = 4;
            this.tabPageSound.Text = "Sound";
            // 
            // groupBoxSoundVolume
            // 
            this.groupBoxSoundVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSoundVolume.Controls.Add(this.labelSEVol);
            this.groupBoxSoundVolume.Controls.Add(this.trackBarSEVol);
            this.groupBoxSoundVolume.Controls.Add(this.labelSEVolume);
            this.groupBoxSoundVolume.Controls.Add(this.labelVoiceVol);
            this.groupBoxSoundVolume.Controls.Add(this.labelMusicVol);
            this.groupBoxSoundVolume.Controls.Add(this.trackBarVoiceVol);
            this.groupBoxSoundVolume.Controls.Add(this.labelMusicVolume);
            this.groupBoxSoundVolume.Controls.Add(this.trackBarMusicVol);
            this.groupBoxSoundVolume.Controls.Add(this.labelVoiceVolume);
            this.groupBoxSoundVolume.Location = new System.Drawing.Point(6, 77);
            this.groupBoxSoundVolume.Name = "groupBoxSoundVolume";
            this.groupBoxSoundVolume.Size = new System.Drawing.Size(452, 171);
            this.groupBoxSoundVolume.TabIndex = 1;
            this.groupBoxSoundVolume.TabStop = false;
            this.groupBoxSoundVolume.Text = "Volume";
            // 
            // labelSEVol
            // 
            this.labelSEVol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSEVol.AutoSize = true;
            this.labelSEVol.Enabled = false;
            this.labelSEVol.Location = new System.Drawing.Point(420, 116);
            this.labelSEVol.Name = "labelSEVol";
            this.labelSEVol.Size = new System.Drawing.Size(25, 13);
            this.labelSEVol.TabIndex = 10;
            this.labelSEVol.Text = "100";
            // 
            // trackBarSEVol
            // 
            this.trackBarSEVol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSEVol.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarSEVol.Enabled = false;
            this.trackBarSEVol.Location = new System.Drawing.Point(87, 116);
            this.trackBarSEVol.Margin = new System.Windows.Forms.Padding(0);
            this.trackBarSEVol.Maximum = 100;
            this.trackBarSEVol.Name = "trackBarSEVol";
            this.trackBarSEVol.Size = new System.Drawing.Size(329, 45);
            this.trackBarSEVol.TabIndex = 2;
            this.trackBarSEVol.TickFrequency = 10;
            this.trackBarSEVol.Value = 100;
            this.trackBarSEVol.ValueChanged += new System.EventHandler(this.trackBarSEVol_ValueChanged);
            // 
            // labelSEVolume
            // 
            this.labelSEVolume.AutoSize = true;
            this.labelSEVolume.Enabled = false;
            this.labelSEVolume.Location = new System.Drawing.Point(15, 116);
            this.labelSEVolume.Name = "labelSEVolume";
            this.labelSEVolume.Size = new System.Drawing.Size(68, 13);
            this.labelSEVolume.TabIndex = 8;
            this.labelSEVolume.Text = "SFX Volume:";
            // 
            // labelVoiceVol
            // 
            this.labelVoiceVol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVoiceVol.AutoSize = true;
            this.labelVoiceVol.Location = new System.Drawing.Point(420, 70);
            this.labelVoiceVol.Name = "labelVoiceVol";
            this.labelVoiceVol.Size = new System.Drawing.Size(25, 13);
            this.labelVoiceVol.TabIndex = 7;
            this.labelVoiceVol.Text = "100";
            // 
            // labelMusicVol
            // 
            this.labelMusicVol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMusicVol.AutoSize = true;
            this.labelMusicVol.Location = new System.Drawing.Point(420, 24);
            this.labelMusicVol.Name = "labelMusicVol";
            this.labelMusicVol.Size = new System.Drawing.Size(25, 13);
            this.labelMusicVol.TabIndex = 6;
            this.labelMusicVol.Text = "100";
            // 
            // trackBarVoiceVol
            // 
            this.trackBarVoiceVol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVoiceVol.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarVoiceVol.Location = new System.Drawing.Point(87, 68);
            this.trackBarVoiceVol.Margin = new System.Windows.Forms.Padding(0);
            this.trackBarVoiceVol.Maximum = 100;
            this.trackBarVoiceVol.Name = "trackBarVoiceVol";
            this.trackBarVoiceVol.Size = new System.Drawing.Size(329, 45);
            this.trackBarVoiceVol.TabIndex = 1;
            this.trackBarVoiceVol.TickFrequency = 10;
            this.trackBarVoiceVol.Value = 100;
            this.trackBarVoiceVol.ValueChanged += new System.EventHandler(this.trackBarVoiceVol_ValueChanged);
            // 
            // labelMusicVolume
            // 
            this.labelMusicVolume.AutoSize = true;
            this.labelMusicVolume.Location = new System.Drawing.Point(9, 24);
            this.labelMusicVolume.Name = "labelMusicVolume";
            this.labelMusicVolume.Size = new System.Drawing.Size(76, 13);
            this.labelMusicVolume.TabIndex = 3;
            this.labelMusicVolume.Text = "Music Volume:";
            // 
            // trackBarMusicVol
            // 
            this.trackBarMusicVol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarMusicVol.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trackBarMusicVol.LargeChange = 10;
            this.trackBarMusicVol.Location = new System.Drawing.Point(87, 21);
            this.trackBarMusicVol.Margin = new System.Windows.Forms.Padding(0);
            this.trackBarMusicVol.Maximum = 100;
            this.trackBarMusicVol.Name = "trackBarMusicVol";
            this.trackBarMusicVol.Size = new System.Drawing.Size(329, 45);
            this.trackBarMusicVol.TabIndex = 0;
            this.trackBarMusicVol.TickFrequency = 10;
            this.trackBarMusicVol.Value = 100;
            this.trackBarMusicVol.ValueChanged += new System.EventHandler(this.trackBarMusicVol_ValueChanged);
            // 
            // labelVoiceVolume
            // 
            this.labelVoiceVolume.AutoSize = true;
            this.labelVoiceVolume.Location = new System.Drawing.Point(10, 68);
            this.labelVoiceVolume.Name = "labelVoiceVolume";
            this.labelVoiceVolume.Size = new System.Drawing.Size(75, 13);
            this.labelVoiceVolume.TabIndex = 2;
            this.labelVoiceVolume.Text = "Voice Volume:";
            // 
            // groupBoxSound
            // 
            this.groupBoxSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSound.Controls.Add(this.checkBoxUseBassMusic);
            this.groupBoxSound.Controls.Add(this.checkBoxUseBassSE);
            this.groupBoxSound.Controls.Add(this.checkBoxEnableMusic);
            this.groupBoxSound.Controls.Add(this.checkBoxEnableSound);
            this.groupBoxSound.Controls.Add(this.checkBoxEnable3DSound);
            this.groupBoxSound.Location = new System.Drawing.Point(6, 6);
            this.groupBoxSound.Name = "groupBoxSound";
            this.groupBoxSound.Size = new System.Drawing.Size(452, 65);
            this.groupBoxSound.TabIndex = 0;
            this.groupBoxSound.TabStop = false;
            this.groupBoxSound.Text = "Sound";
            // 
            // checkBoxUseBassMusic
            // 
            this.checkBoxUseBassMusic.AutoSize = true;
            this.checkBoxUseBassMusic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxUseBassMusic.Location = new System.Drawing.Point(125, 19);
            this.checkBoxUseBassMusic.Name = "checkBoxUseBassMusic";
            this.checkBoxUseBassMusic.Size = new System.Drawing.Size(128, 18);
            this.checkBoxUseBassMusic.TabIndex = 1;
            this.checkBoxUseBassMusic.Text = "Use BASS for Music";
            this.toolTip.SetToolTip(this.checkBoxUseBassMusic, "Use the BASS audio library for music and voice playback.\r\nRequired for ADX music " +
        "and voices.");
            this.checkBoxUseBassMusic.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseBassSE
            // 
            this.checkBoxUseBassSE.AutoSize = true;
            this.checkBoxUseBassSE.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxUseBassSE.Location = new System.Drawing.Point(125, 42);
            this.checkBoxUseBassSE.Name = "checkBoxUseBassSE";
            this.checkBoxUseBassSE.Size = new System.Drawing.Size(167, 18);
            this.checkBoxUseBassSE.TabIndex = 3;
            this.checkBoxUseBassSE.Text = "Use BASS for Sound Effects";
            this.toolTip.SetToolTip(this.checkBoxUseBassSE, "Experimental option to replace DirectSound with BASS.\r\nAdds a global volume contr" +
        "ol and improves sound effects volume.\r\nRequired for SADX installations converted" +
        " from the Steam version.");
            this.checkBoxUseBassSE.UseVisualStyleBackColor = true;
            this.checkBoxUseBassSE.CheckedChanged += new System.EventHandler(this.checkBassSE_CheckedChanged);
            // 
            // checkBoxEnableMusic
            // 
            this.checkBoxEnableMusic.AutoSize = true;
            this.checkBoxEnableMusic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableMusic.Location = new System.Drawing.Point(5, 19);
            this.checkBoxEnableMusic.Name = "checkBoxEnableMusic";
            this.checkBoxEnableMusic.Size = new System.Drawing.Size(96, 18);
            this.checkBoxEnableMusic.TabIndex = 0;
            this.checkBoxEnableMusic.Text = "Enable Music";
            this.checkBoxEnableMusic.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableSound
            // 
            this.checkBoxEnableSound.AutoSize = true;
            this.checkBoxEnableSound.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableSound.Location = new System.Drawing.Point(5, 42);
            this.checkBoxEnableSound.Name = "checkBoxEnableSound";
            this.checkBoxEnableSound.Size = new System.Drawing.Size(104, 18);
            this.checkBoxEnableSound.TabIndex = 2;
            this.checkBoxEnableSound.Text = "Enable Sounds";
            this.checkBoxEnableSound.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnable3DSound
            // 
            this.checkBoxEnable3DSound.AutoSize = true;
            this.checkBoxEnable3DSound.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnable3DSound.Location = new System.Drawing.Point(301, 19);
            this.checkBoxEnable3DSound.Name = "checkBoxEnable3DSound";
            this.checkBoxEnable3DSound.Size = new System.Drawing.Size(116, 18);
            this.checkBoxEnable3DSound.TabIndex = 4;
            this.checkBoxEnable3DSound.Text = "Enable 3D Sound";
            this.toolTip.SetToolTip(this.checkBoxEnable3DSound, "Enable or disable surround sound.");
            this.checkBoxEnable3DSound.UseVisualStyleBackColor = true;
            // 
            // tabPagePatches
            // 
            this.tabPagePatches.Controls.Add(this.labelPatchDescription);
            this.tabPagePatches.Controls.Add(this.listViewPatches);
            this.tabPagePatches.Location = new System.Drawing.Point(4, 22);
            this.tabPagePatches.Name = "tabPagePatches";
            this.tabPagePatches.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePatches.Size = new System.Drawing.Size(464, 366);
            this.tabPagePatches.TabIndex = 7;
            this.tabPagePatches.Text = "Patches";
            this.tabPagePatches.UseVisualStyleBackColor = true;
            // 
            // labelPatchDescription
            // 
            this.labelPatchDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPatchDescription.Location = new System.Drawing.Point(6, 304);
            this.labelPatchDescription.Name = "labelPatchDescription";
            this.labelPatchDescription.Size = new System.Drawing.Size(452, 49);
            this.labelPatchDescription.TabIndex = 1;
            this.labelPatchDescription.Text = "Description: None";
            // 
            // listViewPatches
            // 
            this.listViewPatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPatches.AutoArrange = false;
            this.listViewPatches.CheckBoxes = true;
            this.listViewPatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPatchName,
            this.columnHeaderPatchAuthor,
            this.columnHeaderPatchCategory});
            this.listViewPatches.FullRowSelect = true;
            this.listViewPatches.HideSelection = false;
            this.listViewPatches.LabelWrap = false;
            this.listViewPatches.Location = new System.Drawing.Point(3, 6);
            this.listViewPatches.MultiSelect = false;
            this.listViewPatches.Name = "listViewPatches";
            this.listViewPatches.ShowGroups = false;
            this.listViewPatches.Size = new System.Drawing.Size(456, 295);
            this.listViewPatches.TabIndex = 0;
            this.listViewPatches.UseCompatibleStateImageBehavior = false;
            this.listViewPatches.View = System.Windows.Forms.View.Details;
            this.listViewPatches.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewPatches_ColumnClick);
            this.listViewPatches.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewPatches_ItemChecked);
            this.listViewPatches.SelectedIndexChanged += new System.EventHandler(this.listViewPatches_SelectedIndexChanged);
            // 
            // columnHeaderPatchName
            // 
            this.columnHeaderPatchName.Text = "Patch";
            this.columnHeaderPatchName.Width = 221;
            // 
            // columnHeaderPatchAuthor
            // 
            this.columnHeaderPatchAuthor.Text = "Author";
            this.columnHeaderPatchAuthor.Width = 120;
            // 
            // columnHeaderPatchCategory
            // 
            this.columnHeaderPatchCategory.Text = "Category";
            this.columnHeaderPatchCategory.Width = 82;
            // 
            // tabPageGameOptions
            // 
            this.tabPageGameOptions.Controls.Add(groupBoxMiscOptions);
            this.tabPageGameOptions.Location = new System.Drawing.Point(4, 22);
            this.tabPageGameOptions.Name = "tabPageGameOptions";
            this.tabPageGameOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGameOptions.Size = new System.Drawing.Size(464, 366);
            this.tabPageGameOptions.TabIndex = 10;
            this.tabPageGameOptions.Text = "Options";
            this.tabPageGameOptions.UseVisualStyleBackColor = true;
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPageDebug.Controls.Add(this.groupBoxDebugMessages);
            this.tabPageDebug.Controls.Add(this.groupBoxTestSpawn);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebug.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Size = new System.Drawing.Size(478, 421);
            this.tabPageDebug.TabIndex = 5;
            this.tabPageDebug.Text = "Debug";
            // 
            // groupBoxDebugMessages
            // 
            this.groupBoxDebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDebugMessages.Controls.Add(this.checkBoxEnableDebugCrashHandler);
            this.groupBoxDebugMessages.Controls.Add(this.checkBoxEnableDebugConsole);
            this.groupBoxDebugMessages.Controls.Add(this.checkBoxEnableDebugScreen);
            this.groupBoxDebugMessages.Controls.Add(this.checkBoxEnableDebugFile);
            this.groupBoxDebugMessages.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDebugMessages.Name = "groupBoxDebugMessages";
            this.groupBoxDebugMessages.Size = new System.Drawing.Size(465, 42);
            this.groupBoxDebugMessages.TabIndex = 0;
            this.groupBoxDebugMessages.TabStop = false;
            this.groupBoxDebugMessages.Text = "Debug Messages";
            // 
            // checkBoxEnableDebugCrashHandler
            // 
            this.checkBoxEnableDebugCrashHandler.AutoSize = true;
            this.checkBoxEnableDebugCrashHandler.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableDebugCrashHandler.Location = new System.Drawing.Point(208, 19);
            this.checkBoxEnableDebugCrashHandler.Name = "checkBoxEnableDebugCrashHandler";
            this.checkBoxEnableDebugCrashHandler.Size = new System.Drawing.Size(99, 18);
            this.checkBoxEnableDebugCrashHandler.TabIndex = 3;
            this.checkBoxEnableDebugCrashHandler.Text = "Crash Handler";
            this.toolTip.SetToolTip(this.checkBoxEnableDebugCrashHandler, "Displays the crash address and generates a crash dump when the game crashes.");
            this.checkBoxEnableDebugCrashHandler.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableDebugConsole
            // 
            this.checkBoxEnableDebugConsole.AutoSize = true;
            this.checkBoxEnableDebugConsole.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableDebugConsole.Location = new System.Drawing.Point(6, 19);
            this.checkBoxEnableDebugConsole.Name = "checkBoxEnableDebugConsole";
            this.checkBoxEnableDebugConsole.Size = new System.Drawing.Size(70, 18);
            this.checkBoxEnableDebugConsole.TabIndex = 0;
            this.checkBoxEnableDebugConsole.Text = "Console";
            this.toolTip.SetToolTip(this.checkBoxEnableDebugConsole, "Prints debug messages to a separate console window.");
            this.checkBoxEnableDebugConsole.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableDebugScreen
            // 
            this.checkBoxEnableDebugScreen.AutoSize = true;
            this.checkBoxEnableDebugScreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableDebugScreen.Location = new System.Drawing.Point(82, 19);
            this.checkBoxEnableDebugScreen.Name = "checkBoxEnableDebugScreen";
            this.checkBoxEnableDebugScreen.Size = new System.Drawing.Size(66, 18);
            this.checkBoxEnableDebugScreen.TabIndex = 1;
            this.checkBoxEnableDebugScreen.Text = "Screen";
            this.toolTip.SetToolTip(this.checkBoxEnableDebugScreen, "Displays debug messages ingame.");
            this.checkBoxEnableDebugScreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableDebugFile
            // 
            this.checkBoxEnableDebugFile.AutoSize = true;
            this.checkBoxEnableDebugFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEnableDebugFile.Location = new System.Drawing.Point(154, 19);
            this.checkBoxEnableDebugFile.Name = "checkBoxEnableDebugFile";
            this.checkBoxEnableDebugFile.Size = new System.Drawing.Size(48, 18);
            this.checkBoxEnableDebugFile.TabIndex = 2;
            this.checkBoxEnableDebugFile.Text = "File";
            this.toolTip.SetToolTip(this.checkBoxEnableDebugFile, "Logs debug messages to mods/SADXModLoader.log");
            this.checkBoxEnableDebugFile.UseVisualStyleBackColor = true;
            // 
            // groupBoxTestSpawn
            // 
            this.groupBoxTestSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnAngleDeg);
            this.groupBoxTestSpawn.Controls.Add(this.comboBoxTestSpawnSave);
            this.groupBoxTestSpawn.Controls.Add(this.comboBoxTestSpawnGameMode);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnGameMode);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnWarning);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnTime);
            this.groupBoxTestSpawn.Controls.Add(this.comboBoxTestSpawnTime);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnAngleHex);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnPosition);
            this.groupBoxTestSpawn.Controls.Add(this.buttonTestSpawnPlay);
            this.groupBoxTestSpawn.Controls.Add(this.comboBoxTestSpawnEvent);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnEvent);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnCharacter);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnLevel);
            this.groupBoxTestSpawn.Controls.Add(this.comboBoxTestSpawnCharacter);
            this.groupBoxTestSpawn.Controls.Add(this.numericUpDownTestSpawnAngle);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnAngle);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnY);
            this.groupBoxTestSpawn.Controls.Add(this.checkBoxTestSpawnSave);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnX);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnAct);
            this.groupBoxTestSpawn.Controls.Add(this.labelTestSpawnZ);
            this.groupBoxTestSpawn.Controls.Add(this.numericUpDownTestSpawnAct);
            this.groupBoxTestSpawn.Controls.Add(this.numericUpDownTestSpawnZ);
            this.groupBoxTestSpawn.Controls.Add(this.numericUpDownTestSpawnY);
            this.groupBoxTestSpawn.Controls.Add(this.comboBoxTestSpawnLevel);
            this.groupBoxTestSpawn.Controls.Add(this.numericUpDownTestSpawnX);
            this.groupBoxTestSpawn.Location = new System.Drawing.Point(6, 55);
            this.groupBoxTestSpawn.Name = "groupBoxTestSpawn";
            this.groupBoxTestSpawn.Size = new System.Drawing.Size(465, 279);
            this.groupBoxTestSpawn.TabIndex = 1;
            this.groupBoxTestSpawn.TabStop = false;
            this.groupBoxTestSpawn.Text = "Test Spawn";
            // 
            // checkBoxTestSpawnAngleDeg
            // 
            this.checkBoxTestSpawnAngleDeg.AutoSize = true;
            this.checkBoxTestSpawnAngleDeg.Location = new System.Drawing.Point(205, 120);
            this.checkBoxTestSpawnAngleDeg.Name = "checkBoxTestSpawnAngleDeg";
            this.checkBoxTestSpawnAngleDeg.Size = new System.Drawing.Size(66, 17);
            this.checkBoxTestSpawnAngleDeg.TabIndex = 12;
            this.checkBoxTestSpawnAngleDeg.Text = "Degrees";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnAngleDeg, "Display character Y rotation in degrees instead of BAMS.");
            this.checkBoxTestSpawnAngleDeg.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnAngleDeg.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnAngleDeg_CheckedChanged);
            // 
            // comboBoxTestSpawnSave
            // 
            this.comboBoxTestSpawnSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestSpawnSave.Enabled = false;
            this.comboBoxTestSpawnSave.FormattingEnabled = true;
            this.comboBoxTestSpawnSave.Location = new System.Drawing.Point(109, 176);
            this.comboBoxTestSpawnSave.Name = "comboBoxTestSpawnSave";
            this.comboBoxTestSpawnSave.Size = new System.Drawing.Size(290, 21);
            this.comboBoxTestSpawnSave.TabIndex = 16;
            // 
            // comboBoxTestSpawnGameMode
            // 
            this.comboBoxTestSpawnGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestSpawnGameMode.Enabled = false;
            this.comboBoxTestSpawnGameMode.FormattingEnabled = true;
            this.comboBoxTestSpawnGameMode.Items.AddRange(new object[] {
            "Adventure",
            "Action Stage",
            "Trial",
            "Mission"});
            this.comboBoxTestSpawnGameMode.Location = new System.Drawing.Point(109, 204);
            this.comboBoxTestSpawnGameMode.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestSpawnGameMode.Name = "comboBoxTestSpawnGameMode";
            this.comboBoxTestSpawnGameMode.Size = new System.Drawing.Size(149, 21);
            this.comboBoxTestSpawnGameMode.TabIndex = 18;
            this.toolTip.SetToolTip(this.comboBoxTestSpawnGameMode, "Start the game on a specific GameMode.");
            // 
            // checkBoxTestSpawnGameMode
            // 
            this.checkBoxTestSpawnGameMode.AutoSize = true;
            this.checkBoxTestSpawnGameMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTestSpawnGameMode.Location = new System.Drawing.Point(6, 205);
            this.checkBoxTestSpawnGameMode.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnGameMode.Name = "checkBoxTestSpawnGameMode";
            this.checkBoxTestSpawnGameMode.Size = new System.Drawing.Size(93, 18);
            this.checkBoxTestSpawnGameMode.TabIndex = 17;
            this.checkBoxTestSpawnGameMode.Text = "Game Mode:";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnGameMode, "Start the game on a specific GameMode.");
            this.checkBoxTestSpawnGameMode.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnGameMode.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnGameMode_CheckedChanged);
            // 
            // labelTestSpawnWarning
            // 
            this.labelTestSpawnWarning.AutoSize = true;
            this.labelTestSpawnWarning.Location = new System.Drawing.Point(166, 244);
            this.labelTestSpawnWarning.Name = "labelTestSpawnWarning";
            this.labelTestSpawnWarning.Size = new System.Drawing.Size(293, 13);
            this.labelTestSpawnWarning.TabIndex = 36;
            this.labelTestSpawnWarning.Text = "Overriding levels or characters in events may cause crashes.";
            this.labelTestSpawnWarning.Visible = false;
            // 
            // labelTestSpawnTime
            // 
            this.labelTestSpawnTime.AutoSize = true;
            this.labelTestSpawnTime.Location = new System.Drawing.Point(300, 46);
            this.labelTestSpawnTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTestSpawnTime.Name = "labelTestSpawnTime";
            this.labelTestSpawnTime.Size = new System.Drawing.Size(33, 13);
            this.labelTestSpawnTime.TabIndex = 35;
            this.labelTestSpawnTime.Text = "Time:";
            this.labelTestSpawnTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.labelTestSpawnTime, "Act ID (zero-based).");
            // 
            // comboBoxTestSpawnTime
            // 
            this.comboBoxTestSpawnTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestSpawnTime.FormattingEnabled = true;
            this.comboBoxTestSpawnTime.Items.AddRange(new object[] {
            "Unset",
            "Day",
            "Evening",
            "Night"});
            this.comboBoxTestSpawnTime.Location = new System.Drawing.Point(338, 43);
            this.comboBoxTestSpawnTime.Name = "comboBoxTestSpawnTime";
            this.comboBoxTestSpawnTime.Size = new System.Drawing.Size(61, 21);
            this.comboBoxTestSpawnTime.TabIndex = 5;
            // 
            // checkBoxTestSpawnAngleHex
            // 
            this.checkBoxTestSpawnAngleHex.AutoSize = true;
            this.checkBoxTestSpawnAngleHex.Enabled = false;
            this.checkBoxTestSpawnAngleHex.Location = new System.Drawing.Point(154, 120);
            this.checkBoxTestSpawnAngleHex.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnAngleHex.Name = "checkBoxTestSpawnAngleHex";
            this.checkBoxTestSpawnAngleHex.Size = new System.Drawing.Size(45, 17);
            this.checkBoxTestSpawnAngleHex.TabIndex = 11;
            this.checkBoxTestSpawnAngleHex.Text = "Hex";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnAngleHex, "Display character Y rotation as hexadecimal.");
            this.checkBoxTestSpawnAngleHex.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnAngleHex.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnAngleHex_CheckedChanged);
            // 
            // checkBoxTestSpawnPosition
            // 
            this.checkBoxTestSpawnPosition.AutoSize = true;
            this.checkBoxTestSpawnPosition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTestSpawnPosition.Location = new System.Drawing.Point(6, 71);
            this.checkBoxTestSpawnPosition.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnPosition.Name = "checkBoxTestSpawnPosition";
            this.checkBoxTestSpawnPosition.Size = new System.Drawing.Size(72, 18);
            this.checkBoxTestSpawnPosition.TabIndex = 6;
            this.checkBoxTestSpawnPosition.Text = "Position:";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnPosition, "Force character spawn position.");
            this.checkBoxTestSpawnPosition.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnPosition.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnPosition_CheckedChanged);
            // 
            // buttonTestSpawnPlay
            // 
            this.buttonTestSpawnPlay.Location = new System.Drawing.Point(6, 237);
            this.buttonTestSpawnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestSpawnPlay.Name = "buttonTestSpawnPlay";
            this.buttonTestSpawnPlay.Size = new System.Drawing.Size(82, 26);
            this.buttonTestSpawnPlay.TabIndex = 19;
            this.buttonTestSpawnPlay.Text = "Play";
            this.toolTip.SetToolTip(this.buttonTestSpawnPlay, "Run the game with the above Test Spawn settings.");
            this.buttonTestSpawnPlay.UseVisualStyleBackColor = true;
            this.buttonTestSpawnPlay.Click += new System.EventHandler(this.buttonTestSpawnPlay_Click);
            // 
            // comboBoxTestSpawnEvent
            // 
            this.comboBoxTestSpawnEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestSpawnEvent.Enabled = false;
            this.comboBoxTestSpawnEvent.FormattingEnabled = true;
            this.comboBoxTestSpawnEvent.Location = new System.Drawing.Point(109, 149);
            this.comboBoxTestSpawnEvent.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestSpawnEvent.Name = "comboBoxTestSpawnEvent";
            this.comboBoxTestSpawnEvent.Size = new System.Drawing.Size(290, 21);
            this.comboBoxTestSpawnEvent.TabIndex = 14;
            this.toolTip.SetToolTip(this.comboBoxTestSpawnEvent, "Start the game on a specific cutscene.");
            // 
            // checkBoxTestSpawnEvent
            // 
            this.checkBoxTestSpawnEvent.AutoSize = true;
            this.checkBoxTestSpawnEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTestSpawnEvent.Location = new System.Drawing.Point(6, 152);
            this.checkBoxTestSpawnEvent.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnEvent.Name = "checkBoxTestSpawnEvent";
            this.checkBoxTestSpawnEvent.Size = new System.Drawing.Size(63, 18);
            this.checkBoxTestSpawnEvent.TabIndex = 13;
            this.checkBoxTestSpawnEvent.Text = "Event:";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnEvent, "Start the game on a specific cutscene.");
            this.checkBoxTestSpawnEvent.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnEvent.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnEvent_CheckedChanged);
            // 
            // checkBoxTestSpawnCharacter
            // 
            this.checkBoxTestSpawnCharacter.AutoSize = true;
            this.checkBoxTestSpawnCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTestSpawnCharacter.Location = new System.Drawing.Point(6, 46);
            this.checkBoxTestSpawnCharacter.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnCharacter.Name = "checkBoxTestSpawnCharacter";
            this.checkBoxTestSpawnCharacter.Size = new System.Drawing.Size(81, 18);
            this.checkBoxTestSpawnCharacter.TabIndex = 3;
            this.checkBoxTestSpawnCharacter.Text = "Character:";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnCharacter, "Start the game with a specific character.");
            this.checkBoxTestSpawnCharacter.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnCharacter.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnCharacter_CheckedChanged);
            // 
            // checkBoxTestSpawnLevel
            // 
            this.checkBoxTestSpawnLevel.AutoSize = true;
            this.checkBoxTestSpawnLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTestSpawnLevel.Location = new System.Drawing.Point(6, 21);
            this.checkBoxTestSpawnLevel.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnLevel.Name = "checkBoxTestSpawnLevel";
            this.checkBoxTestSpawnLevel.Size = new System.Drawing.Size(61, 18);
            this.checkBoxTestSpawnLevel.TabIndex = 0;
            this.checkBoxTestSpawnLevel.Text = "Level:";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnLevel, "Start the game on a specific level.");
            this.checkBoxTestSpawnLevel.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnLevel.CheckedChanged += new System.EventHandler(this.checkBoxTestSpawnLevel_CheckedChanged);
            // 
            // comboBoxTestSpawnCharacter
            // 
            this.comboBoxTestSpawnCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestSpawnCharacter.Enabled = false;
            this.comboBoxTestSpawnCharacter.FormattingEnabled = true;
            this.comboBoxTestSpawnCharacter.Items.AddRange(new object[] {
            "Sonic",
            "Eggman (unused)",
            "Tails",
            "Knuckles",
            "Tikal (unused)",
            "Amy",
            "Gamma",
            "Big",
            "Metal Sonic"});
            this.comboBoxTestSpawnCharacter.Location = new System.Drawing.Point(93, 44);
            this.comboBoxTestSpawnCharacter.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestSpawnCharacter.Name = "comboBoxTestSpawnCharacter";
            this.comboBoxTestSpawnCharacter.Size = new System.Drawing.Size(201, 21);
            this.comboBoxTestSpawnCharacter.TabIndex = 4;
            this.toolTip.SetToolTip(this.comboBoxTestSpawnCharacter, "Start the game with a specific character.");
            // 
            // numericUpDownTestSpawnAngle
            // 
            this.numericUpDownTestSpawnAngle.Enabled = false;
            this.numericUpDownTestSpawnAngle.Location = new System.Drawing.Point(51, 117);
            this.numericUpDownTestSpawnAngle.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTestSpawnAngle.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDownTestSpawnAngle.Name = "numericUpDownTestSpawnAngle";
            this.numericUpDownTestSpawnAngle.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownTestSpawnAngle.TabIndex = 10;
            this.toolTip.SetToolTip(this.numericUpDownTestSpawnAngle, "Character Y rotation in degrees or BAMS.");
            // 
            // labelTestSpawnAngle
            // 
            this.labelTestSpawnAngle.AutoSize = true;
            this.labelTestSpawnAngle.Enabled = false;
            this.labelTestSpawnAngle.Location = new System.Drawing.Point(10, 120);
            this.labelTestSpawnAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTestSpawnAngle.Name = "labelTestSpawnAngle";
            this.labelTestSpawnAngle.Size = new System.Drawing.Size(37, 13);
            this.labelTestSpawnAngle.TabIndex = 29;
            this.labelTestSpawnAngle.Text = "Angle:";
            this.toolTip.SetToolTip(this.labelTestSpawnAngle, "Character Y Rotation.");
            // 
            // labelTestSpawnY
            // 
            this.labelTestSpawnY.AutoSize = true;
            this.labelTestSpawnY.Enabled = false;
            this.labelTestSpawnY.Location = new System.Drawing.Point(135, 95);
            this.labelTestSpawnY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTestSpawnY.Name = "labelTestSpawnY";
            this.labelTestSpawnY.Size = new System.Drawing.Size(17, 13);
            this.labelTestSpawnY.TabIndex = 24;
            this.labelTestSpawnY.Text = "Y:";
            this.toolTip.SetToolTip(this.labelTestSpawnY, "Character Y Position.");
            // 
            // checkBoxTestSpawnSave
            // 
            this.checkBoxTestSpawnSave.AutoSize = true;
            this.checkBoxTestSpawnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTestSpawnSave.Location = new System.Drawing.Point(6, 179);
            this.checkBoxTestSpawnSave.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTestSpawnSave.Name = "checkBoxTestSpawnSave";
            this.checkBoxTestSpawnSave.Size = new System.Drawing.Size(79, 18);
            this.checkBoxTestSpawnSave.TabIndex = 15;
            this.checkBoxTestSpawnSave.Text = "Save File:";
            this.toolTip.SetToolTip(this.checkBoxTestSpawnSave, "Force the game to load a specific save file.");
            this.checkBoxTestSpawnSave.UseVisualStyleBackColor = true;
            this.checkBoxTestSpawnSave.CheckStateChanged += new System.EventHandler(this.checkBoxTestSpawnSave_CheckStateChanged);
            // 
            // labelTestSpawnX
            // 
            this.labelTestSpawnX.AutoSize = true;
            this.labelTestSpawnX.Enabled = false;
            this.labelTestSpawnX.Location = new System.Drawing.Point(30, 95);
            this.labelTestSpawnX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTestSpawnX.Name = "labelTestSpawnX";
            this.labelTestSpawnX.Size = new System.Drawing.Size(17, 13);
            this.labelTestSpawnX.TabIndex = 23;
            this.labelTestSpawnX.Text = "X:";
            this.toolTip.SetToolTip(this.labelTestSpawnX, "Character X Position.");
            // 
            // labelTestSpawnAct
            // 
            this.labelTestSpawnAct.AutoSize = true;
            this.labelTestSpawnAct.Enabled = false;
            this.labelTestSpawnAct.Location = new System.Drawing.Point(307, 20);
            this.labelTestSpawnAct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTestSpawnAct.Name = "labelTestSpawnAct";
            this.labelTestSpawnAct.Size = new System.Drawing.Size(26, 13);
            this.labelTestSpawnAct.TabIndex = 5;
            this.labelTestSpawnAct.Text = "Act:";
            this.toolTip.SetToolTip(this.labelTestSpawnAct, "Act ID (zero-based).");
            // 
            // labelTestSpawnZ
            // 
            this.labelTestSpawnZ.AutoSize = true;
            this.labelTestSpawnZ.Enabled = false;
            this.labelTestSpawnZ.Location = new System.Drawing.Point(242, 95);
            this.labelTestSpawnZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTestSpawnZ.Name = "labelTestSpawnZ";
            this.labelTestSpawnZ.Size = new System.Drawing.Size(17, 13);
            this.labelTestSpawnZ.TabIndex = 25;
            this.labelTestSpawnZ.Text = "Z:";
            this.toolTip.SetToolTip(this.labelTestSpawnZ, "Character Z Position.");
            // 
            // numericUpDownTestSpawnAct
            // 
            this.numericUpDownTestSpawnAct.Enabled = false;
            this.numericUpDownTestSpawnAct.Location = new System.Drawing.Point(338, 19);
            this.numericUpDownTestSpawnAct.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTestSpawnAct.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownTestSpawnAct.Name = "numericUpDownTestSpawnAct";
            this.numericUpDownTestSpawnAct.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownTestSpawnAct.TabIndex = 2;
            this.toolTip.SetToolTip(this.numericUpDownTestSpawnAct, "Act ID (zero-based).");
            // 
            // numericUpDownTestSpawnZ
            // 
            this.numericUpDownTestSpawnZ.Enabled = false;
            this.numericUpDownTestSpawnZ.Location = new System.Drawing.Point(263, 93);
            this.numericUpDownTestSpawnZ.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTestSpawnZ.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownTestSpawnZ.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDownTestSpawnZ.Name = "numericUpDownTestSpawnZ";
            this.numericUpDownTestSpawnZ.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownTestSpawnZ.TabIndex = 9;
            this.toolTip.SetToolTip(this.numericUpDownTestSpawnZ, "Character Z Position.");
            // 
            // numericUpDownTestSpawnY
            // 
            this.numericUpDownTestSpawnY.Enabled = false;
            this.numericUpDownTestSpawnY.Location = new System.Drawing.Point(156, 93);
            this.numericUpDownTestSpawnY.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTestSpawnY.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownTestSpawnY.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDownTestSpawnY.Name = "numericUpDownTestSpawnY";
            this.numericUpDownTestSpawnY.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownTestSpawnY.TabIndex = 8;
            this.toolTip.SetToolTip(this.numericUpDownTestSpawnY, "Character Y Position.");
            // 
            // comboBoxTestSpawnLevel
            // 
            this.comboBoxTestSpawnLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTestSpawnLevel.Enabled = false;
            this.comboBoxTestSpawnLevel.FormattingEnabled = true;
            this.comboBoxTestSpawnLevel.Items.AddRange(new object[] {
            "Hedgehog Hammer",
            "Emerald Coast",
            "Windy Valley",
            "Twinkle Park",
            "Speed Highway",
            "Red Mountain",
            "Sky Deck",
            "Lost World",
            "Ice Cap",
            "Casinopolis",
            "Final Egg",
            "Unused (11)",
            "Hot Shelter",
            "Unused (13)",
            "Unused (14)",
            "Chaos 0",
            "Chaos 2",
            "Chaos 4",
            "Chaos 6",
            "Perfect Chaos",
            "Egg Hornet",
            "Egg Walker",
            "Egg Viper",
            "ZERO",
            "E-101",
            "E-101R",
            "Station Square",
            "Station Square Unused (27)",
            "Station Square Unused (28)",
            "Egg Carrier Outside",
            "Unused (30)",
            "Unused (31)",
            "Egg Carrier Inside",
            "Mystic Ruins",
            "Past",
            "Twinkle Circuit",
            "Sky Chase 1",
            "Sky Chase 2",
            "Sand Hill",
            "Station Square Garden",
            "Egg Carrier Garden",
            "Mystic Ruins Garden",
            "Chao Race"});
            this.comboBoxTestSpawnLevel.Location = new System.Drawing.Point(93, 19);
            this.comboBoxTestSpawnLevel.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTestSpawnLevel.Name = "comboBoxTestSpawnLevel";
            this.comboBoxTestSpawnLevel.Size = new System.Drawing.Size(201, 21);
            this.comboBoxTestSpawnLevel.TabIndex = 1;
            this.toolTip.SetToolTip(this.comboBoxTestSpawnLevel, "Start the game on a specific level.");
            // 
            // numericUpDownTestSpawnX
            // 
            this.numericUpDownTestSpawnX.Enabled = false;
            this.numericUpDownTestSpawnX.Location = new System.Drawing.Point(51, 93);
            this.numericUpDownTestSpawnX.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTestSpawnX.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownTestSpawnX.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.numericUpDownTestSpawnX.Name = "numericUpDownTestSpawnX";
            this.numericUpDownTestSpawnX.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownTestSpawnX.TabIndex = 7;
            this.toolTip.SetToolTip(this.numericUpDownTestSpawnX, "Character X Position.");
            // 
            // tabPageManagerConfig
            // 
            this.tabPageManagerConfig.Controls.Add(this.groupBoxManagerOptions);
            this.tabPageManagerConfig.Controls.Add(this.groupBoxUpdates);
            this.tabPageManagerConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageManagerConfig.Name = "tabPageManagerConfig";
            this.tabPageManagerConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageManagerConfig.Size = new System.Drawing.Size(478, 421);
            this.tabPageManagerConfig.TabIndex = 8;
            this.tabPageManagerConfig.Text = "Options";
            this.tabPageManagerConfig.UseVisualStyleBackColor = true;
            // 
            // groupBoxManagerOptions
            // 
            this.groupBoxManagerOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxManagerOptions.Controls.Add(this.checkBoxSingleProfile);
            this.groupBoxManagerOptions.Controls.Add(this.checkBoxKeepManagerOpen);
            this.groupBoxManagerOptions.Controls.Add(this.buttonCheckGameHealth);
            this.groupBoxManagerOptions.Controls.Add(this.buttonInstallURLHandler);
            this.groupBoxManagerOptions.Location = new System.Drawing.Point(6, 6);
            this.groupBoxManagerOptions.Name = "groupBoxManagerOptions";
            this.groupBoxManagerOptions.Size = new System.Drawing.Size(464, 103);
            this.groupBoxManagerOptions.TabIndex = 0;
            this.groupBoxManagerOptions.TabStop = false;
            this.groupBoxManagerOptions.Text = "Manager Settings";
            // 
            // checkBoxSingleProfile
            // 
            this.checkBoxSingleProfile.AutoSize = true;
            this.checkBoxSingleProfile.Location = new System.Drawing.Point(9, 44);
            this.checkBoxSingleProfile.Name = "checkBoxSingleProfile";
            this.checkBoxSingleProfile.Size = new System.Drawing.Size(117, 17);
            this.checkBoxSingleProfile.TabIndex = 1;
            this.checkBoxSingleProfile.Text = "Single Profile Mode";
            this.toolTip.SetToolTip(this.checkBoxSingleProfile, resources.GetString("checkBoxSingleProfile.ToolTip"));
            this.checkBoxSingleProfile.UseVisualStyleBackColor = true;
            // 
            // buttonCheckGameHealth
            // 
            this.buttonCheckGameHealth.AutoSize = true;
            this.buttonCheckGameHealth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCheckGameHealth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCheckGameHealth.Location = new System.Drawing.Point(131, 68);
            this.buttonCheckGameHealth.Name = "buttonCheckGameHealth";
            this.buttonCheckGameHealth.Size = new System.Drawing.Size(126, 22);
            this.buttonCheckGameHealth.TabIndex = 3;
            this.buttonCheckGameHealth.Text = "Check Game Health...";
            this.buttonCheckGameHealth.UseVisualStyleBackColor = true;
            this.buttonCheckGameHealth.Visible = false;
            // 
            // groupBoxUpdates
            // 
            this.groupBoxUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxUpdates.Controls.Add(this.buttonSwitchToSAManager);
            this.groupBoxUpdates.Controls.Add(this.checkBoxCheckLoaderUpdatesStartup);
            this.groupBoxUpdates.Controls.Add(this.buttonCheckForUpdatesNow);
            this.groupBoxUpdates.Controls.Add(this.labelUpdateFrequency);
            this.groupBoxUpdates.Controls.Add(this.checkBoxCheckUpdateModsStartup);
            this.groupBoxUpdates.Controls.Add(this.numericUpDownUpdateFrequency);
            this.groupBoxUpdates.Controls.Add(this.comboBoxUpdateUnit);
            this.groupBoxUpdates.Controls.Add(this.checkBoxCheckManagerUpdateStartup);
            this.groupBoxUpdates.Location = new System.Drawing.Point(6, 115);
            this.groupBoxUpdates.Name = "groupBoxUpdates";
            this.groupBoxUpdates.Size = new System.Drawing.Size(461, 180);
            this.groupBoxUpdates.TabIndex = 1;
            this.groupBoxUpdates.TabStop = false;
            this.groupBoxUpdates.Text = "Updates";
            // 
            // buttonSwitchToSAManager
            // 
            this.buttonSwitchToSAManager.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSwitchToSAManager.Location = new System.Drawing.Point(237, 43);
            this.buttonSwitchToSAManager.Name = "buttonSwitchToSAManager";
            this.buttonSwitchToSAManager.Size = new System.Drawing.Size(121, 23);
            this.buttonSwitchToSAManager.TabIndex = 3;
            this.buttonSwitchToSAManager.Text = "Switch to SA Manager";
            this.toolTip.SetToolTip(this.buttonSwitchToSAManager, "Replace Mod Manager Classic with the modern SA Mod Manager.");
            this.buttonSwitchToSAManager.UseVisualStyleBackColor = true;
            this.buttonSwitchToSAManager.Visible = false;
            // 
            // checkBoxCheckLoaderUpdatesStartup
            // 
            this.checkBoxCheckLoaderUpdatesStartup.AutoSize = true;
            this.checkBoxCheckLoaderUpdatesStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCheckLoaderUpdatesStartup.Location = new System.Drawing.Point(6, 43);
            this.checkBoxCheckLoaderUpdatesStartup.Name = "checkBoxCheckLoaderUpdatesStartup";
            this.checkBoxCheckLoaderUpdatesStartup.Size = new System.Drawing.Size(209, 18);
            this.checkBoxCheckLoaderUpdatesStartup.TabIndex = 1;
            this.checkBoxCheckLoaderUpdatesStartup.Text = "Check for Loader Updates on Startup";
            this.toolTip.SetToolTip(this.checkBoxCheckLoaderUpdatesStartup, "Check for Mod Loader updates every time the Manager starts up.");
            this.checkBoxCheckLoaderUpdatesStartup.UseVisualStyleBackColor = true;
            // 
            // buttonCheckForUpdatesNow
            // 
            this.buttonCheckForUpdatesNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCheckForUpdatesNow.Location = new System.Drawing.Point(201, 85);
            this.buttonCheckForUpdatesNow.Name = "buttonCheckForUpdatesNow";
            this.buttonCheckForUpdatesNow.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckForUpdatesNow.TabIndex = 6;
            this.buttonCheckForUpdatesNow.Text = "Check Now";
            this.buttonCheckForUpdatesNow.UseVisualStyleBackColor = true;
            this.buttonCheckForUpdatesNow.Click += new System.EventHandler(this.buttonCheckForUpdates_Click);
            // 
            // labelUpdateFrequency
            // 
            this.labelUpdateFrequency.AutoSize = true;
            this.labelUpdateFrequency.Location = new System.Drawing.Point(6, 71);
            this.labelUpdateFrequency.Name = "labelUpdateFrequency";
            this.labelUpdateFrequency.Size = new System.Drawing.Size(132, 13);
            this.labelUpdateFrequency.TabIndex = 2;
            this.labelUpdateFrequency.Text = "Update Check Frequency:";
            // 
            // checkBoxCheckUpdateModsStartup
            // 
            this.checkBoxCheckUpdateModsStartup.AutoSize = true;
            this.checkBoxCheckUpdateModsStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCheckUpdateModsStartup.Location = new System.Drawing.Point(6, 19);
            this.checkBoxCheckUpdateModsStartup.Name = "checkBoxCheckUpdateModsStartup";
            this.checkBoxCheckUpdateModsStartup.Size = new System.Drawing.Size(197, 18);
            this.checkBoxCheckUpdateModsStartup.TabIndex = 0;
            this.checkBoxCheckUpdateModsStartup.Text = "Check for Mod Updates on Startup";
            this.toolTip.SetToolTip(this.checkBoxCheckUpdateModsStartup, "Check for mod updates every time the Manager starts up.");
            this.checkBoxCheckUpdateModsStartup.UseVisualStyleBackColor = true;
            // 
            // numericUpDownUpdateFrequency
            // 
            this.numericUpDownUpdateFrequency.Location = new System.Drawing.Point(133, 88);
            this.numericUpDownUpdateFrequency.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownUpdateFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownUpdateFrequency.Name = "numericUpDownUpdateFrequency";
            this.numericUpDownUpdateFrequency.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownUpdateFrequency.TabIndex = 5;
            this.toolTip.SetToolTip(this.numericUpDownUpdateFrequency, "Set the interval for automatic update checks.");
            this.numericUpDownUpdateFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxUpdateUnit
            // 
            this.comboBoxUpdateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUpdateUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxUpdateUnit.FormattingEnabled = true;
            this.comboBoxUpdateUnit.Items.AddRange(new object[] {
            "Always",
            "Days",
            "Hours",
            "Weeks"});
            this.comboBoxUpdateUnit.Location = new System.Drawing.Point(6, 87);
            this.comboBoxUpdateUnit.Name = "comboBoxUpdateUnit";
            this.comboBoxUpdateUnit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUpdateUnit.TabIndex = 4;
            this.toolTip.SetToolTip(this.comboBoxUpdateUnit, "Set the time unit for automatic update checks.");
            this.comboBoxUpdateUnit.SelectedIndexChanged += new System.EventHandler(this.comboUpdateFrequency_SelectedIndexChanged);
            // 
            // checkBoxCheckManagerUpdateStartup
            // 
            this.checkBoxCheckManagerUpdateStartup.AutoSize = true;
            this.checkBoxCheckManagerUpdateStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxCheckManagerUpdateStartup.Location = new System.Drawing.Point(237, 19);
            this.checkBoxCheckManagerUpdateStartup.Name = "checkBoxCheckManagerUpdateStartup";
            this.checkBoxCheckManagerUpdateStartup.Size = new System.Drawing.Size(218, 18);
            this.checkBoxCheckManagerUpdateStartup.TabIndex = 2;
            this.checkBoxCheckManagerUpdateStartup.Text = "Check for Manager Updates on Startup";
            this.toolTip.SetToolTip(this.checkBoxCheckManagerUpdateStartup, "Check for Mod Manager updates every time it starts up.");
            this.checkBoxCheckManagerUpdateStartup.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripMod
            // 
            this.contextMenuStripMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenuStripMod.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.verifyToolStripMenuItem,
            this.toolStripMenuItemSeparator1,
            this.checkForUpdatesToolStripMenuItem,
            this.forceUpdateToolStripMenuItem,
            this.toolStripMenuItem2Separator2,
            this.disableUpdatesToolStripMenuItem,
            this.uninstallToolStripMenuItem,
            this.toolStripMenuItemSeparator3,
            this.generateManifestToolStripMenuItem});
            this.contextMenuStripMod.Name = "modContextMenu";
            this.contextMenuStripMod.ShowCheckMargin = true;
            this.contextMenuStripMod.ShowImageMargin = false;
            this.contextMenuStripMod.Size = new System.Drawing.Size(172, 198);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openFolderToolStripMenuItem.Text = "Open Mod Folder";
            this.openFolderToolStripMenuItem.ToolTipText = "Open the location of the mod.";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.configureToolStripMenuItem.Text = "Configure...";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // verifyToolStripMenuItem
            // 
            this.verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
            this.verifyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.verifyToolStripMenuItem.Text = "Verify Integrity";
            this.verifyToolStripMenuItem.ToolTipText = "Check if the mod\'s files are intact.";
            this.verifyToolStripMenuItem.Click += new System.EventHandler(this.verifyToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSeparator1
            // 
            this.toolStripMenuItemSeparator1.Name = "toolStripMenuItemSeparator1";
            this.toolStripMenuItemSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.ToolTipText = "Check if there are any updates for the selected mod.";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // forceUpdateToolStripMenuItem
            // 
            this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.forceUpdateToolStripMenuItem.Text = "Force Update";
            this.forceUpdateToolStripMenuItem.ToolTipText = "Force download the latest version of the mod.";
            this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2Separator2
            // 
            this.toolStripMenuItem2Separator2.Name = "toolStripMenuItem2Separator2";
            this.toolStripMenuItem2Separator2.Size = new System.Drawing.Size(168, 6);
            // 
            // disableUpdatesToolStripMenuItem
            // 
            this.disableUpdatesToolStripMenuItem.Name = "disableUpdatesToolStripMenuItem";
            this.disableUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.disableUpdatesToolStripMenuItem.Text = "Disable Updates";
            this.disableUpdatesToolStripMenuItem.ToolTipText = "Check this to prevent the mod from receiving any updates.";
            this.disableUpdatesToolStripMenuItem.Click += new System.EventHandler(this.disableUpdatesToolStripMenuItem_Click);
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.ToolTipText = "Remove this mod.";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSeparator3
            // 
            this.toolStripMenuItemSeparator3.Name = "toolStripMenuItemSeparator3";
            this.toolStripMenuItemSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // generateManifestToolStripMenuItem
            // 
            this.generateManifestToolStripMenuItem.Name = "generateManifestToolStripMenuItem";
            this.generateManifestToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.generateManifestToolStripMenuItem.Text = "Generate Manifest";
            this.generateManifestToolStripMenuItem.ToolTipText = "Create a mod manifest (for developers).";
            this.generateManifestToolStripMenuItem.Click += new System.EventHandler(this.generateManifestToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // contextMenuStripAddMod
            // 
            this.contextMenuStripAddMod.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripAddMod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModArchivetoolStripMenuItem,
            this.fromURLToolStripMenuItem,
            this.toolStripSeparator2,
            this.newModToolStripMenuItem});
            this.contextMenuStripAddMod.Name = "contextMenuStripAddMod";
            this.contextMenuStripAddMod.ShowImageMargin = false;
            this.contextMenuStripAddMod.Size = new System.Drawing.Size(153, 76);
            this.contextMenuStripAddMod.Text = "From Archive...";
            // 
            // addModArchivetoolStripMenuItem
            // 
            this.addModArchivetoolStripMenuItem.Enabled = false;
            this.addModArchivetoolStripMenuItem.Name = "addModArchivetoolStripMenuItem";
            this.addModArchivetoolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addModArchivetoolStripMenuItem.Text = "Add from Archive...";
            // 
            // fromURLToolStripMenuItem
            // 
            this.fromURLToolStripMenuItem.Name = "fromURLToolStripMenuItem";
            this.fromURLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fromURLToolStripMenuItem.Text = "Add from URL...";
            this.fromURLToolStripMenuItem.ToolTipText = "Install one or more mods using links to compatible resources";
            this.fromURLToolStripMenuItem.Click += new System.EventHandler(this.fromURLToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // newModToolStripMenuItem
            // 
            this.newModToolStripMenuItem.Name = "newModToolStripMenuItem";
            this.newModToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newModToolStripMenuItem.Text = "New Mod...";
            this.newModToolStripMenuItem.ToolTipText = "Create a new mod";
            this.newModToolStripMenuItem.Click += new System.EventHandler(this.newModToolStripMenuItem_Click);
            // 
            // statusStripManager
            // 
            this.statusStripManager.AutoSize = false;
            this.statusStripManager.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStripManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelGameFolder});
            this.statusStripManager.Location = new System.Drawing.Point(0, 478);
            this.statusStripManager.Name = "statusStripManager";
            this.statusStripManager.Size = new System.Drawing.Size(484, 22);
            this.statusStripManager.SizingGrip = false;
            this.statusStripManager.TabIndex = 12;
            this.statusStripManager.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(138, 17);
            this.toolStripStatusLabel.Text = "Mod Manager initialized.";
            // 
            // toolStripStatusLabelGameFolder
            // 
            this.toolStripStatusLabelGameFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelGameFolder.Name = "toolStripStatusLabelGameFolder";
            this.toolStripStatusLabelGameFolder.Size = new System.Drawing.Size(331, 17);
            this.toolStripStatusLabelGameFolder.Spring = true;
            this.toolStripStatusLabelGameFolder.Text = "Game location will be displayed here.";
            this.toolStripStatusLabelGameFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabelGameFolder.Click += new System.EventHandler(this.toolStripStatusLabelGameFolder_Click);
            // 
            // contextMenuStripProfile
            // 
            this.contextMenuStripProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDeleteProfile});
            this.contextMenuStripProfile.Name = "contextMenuStripProfile";
            this.contextMenuStripProfile.ShowImageMargin = false;
            this.contextMenuStripProfile.Size = new System.Drawing.Size(120, 26);
            // 
            // toolStripMenuItemDeleteProfile
            // 
            this.toolStripMenuItemDeleteProfile.Name = "toolStripMenuItemDeleteProfile";
            this.toolStripMenuItemDeleteProfile.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItemDeleteProfile.Text = "Delete Profile";
            this.toolStripMenuItemDeleteProfile.Click += new System.EventHandler(this.toolStripMenuItemDeleteProfile_Click);
            // 
            // contextMenuStripResetGameSettings
            // 
            this.contextMenuStripResetGameSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemResetOptimal,
            this.toolStripMenuItemResetSafe});
            this.contextMenuStripResetGameSettings.Name = "contextMenuStripResetGameSettings";
            this.contextMenuStripResetGameSettings.Size = new System.Drawing.Size(208, 48);
            // 
            // toolStripMenuItemResetOptimal
            // 
            this.toolStripMenuItemResetOptimal.Name = "toolStripMenuItemResetOptimal";
            this.toolStripMenuItemResetOptimal.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemResetOptimal.Text = "Reset to Optimal Settings";
            this.toolStripMenuItemResetOptimal.ToolTipText = "Apply the settings for best visuals on current hardware.";
            this.toolStripMenuItemResetOptimal.Click += new System.EventHandler(this.toolStripMenuItemResetOptimal_Click);
            // 
            // toolStripMenuItemResetSafe
            // 
            this.toolStripMenuItemResetSafe.Name = "toolStripMenuItemResetSafe";
            this.toolStripMenuItemResetSafe.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemResetSafe.Text = "Reset to Safe Settings";
            this.toolStripMenuItemResetSafe.ToolTipText = "If the game fails to start, try using this option.";
            this.toolStripMenuItemResetSafe.Click += new System.EventHandler(this.toolStripMenuItemResetSafe_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 503);
            this.Controls.Add(this.statusStripManager);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonInstallLoader);
            this.Controls.Add(this.buttonSaveAndPlay);
            this.Controls.Add(this.buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 483);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SADX Mod Manager Classic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            groupBoxMiscOptions.ResumeLayout(false);
            groupBoxMiscOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVerticalResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHorizontalResolution)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMods.ResumeLayout(false);
            this.tabPageMods.PerformLayout();
            this.tabPageCodes.ResumeLayout(false);
            this.tabPageGameConfig.ResumeLayout(false);
            this.tabControlGameConfig.ResumeLayout(false);
            this.tabPageGraphics.ResumeLayout(false);
            this.groupBoxGraphicsOther.ResumeLayout(false);
            this.groupBoxGraphicsOther.PerformLayout();
            this.groupBoxVisuals.ResumeLayout(false);
            this.groupBoxVisuals.PerformLayout();
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowWidth)).EndInit();
            this.tabPageInput.ResumeLayout(false);
            this.groupBoxControllerDInput.ResumeLayout(false);
            this.groupBoxControllerDInput.PerformLayout();
            this.groupBoxInputMode.ResumeLayout(false);
            this.groupBoxInputMode.PerformLayout();
            this.groupBoxMouseMode.ResumeLayout(false);
            this.groupBoxMouseMode.PerformLayout();
            this.tabPageController.ResumeLayout(false);
            this.groupBoxControlsSDL.ResumeLayout(false);
            this.groupBoxControlsSDL.PerformLayout();
            this.groupBoxRumble.ResumeLayout(false);
            this.groupBoxRumble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRumbleMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRumbleMinTime)).EndInit();
            this.groupBoxDeadzones.ResumeLayout(false);
            this.groupBoxDeadzones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTriggersDeadzone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRightStickDeadzone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeftStickDeadzone)).EndInit();
            this.tabPageSound.ResumeLayout(false);
            this.groupBoxSoundVolume.ResumeLayout(false);
            this.groupBoxSoundVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSEVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVoiceVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVol)).EndInit();
            this.groupBoxSound.ResumeLayout(false);
            this.groupBoxSound.PerformLayout();
            this.tabPagePatches.ResumeLayout(false);
            this.tabPageGameOptions.ResumeLayout(false);
            this.tabPageDebug.ResumeLayout(false);
            this.groupBoxDebugMessages.ResumeLayout(false);
            this.groupBoxDebugMessages.PerformLayout();
            this.groupBoxTestSpawn.ResumeLayout(false);
            this.groupBoxTestSpawn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnAct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestSpawnX)).EndInit();
            this.tabPageManagerConfig.ResumeLayout(false);
            this.groupBoxManagerOptions.ResumeLayout(false);
            this.groupBoxManagerOptions.PerformLayout();
            this.groupBoxUpdates.ResumeLayout(false);
            this.groupBoxUpdates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpdateFrequency)).EndInit();
            this.contextMenuStripMod.ResumeLayout(false);
            this.contextMenuStripAddMod.ResumeLayout(false);
            this.statusStripManager.ResumeLayout(false);
            this.statusStripManager.PerformLayout();
            this.contextMenuStripProfile.ResumeLayout(false);
            this.contextMenuStripResetGameSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMods;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderAuthor;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSaveAndPlay;
		private System.Windows.Forms.Button buttonInstallLoader;
        private System.Windows.Forms.NumericUpDown numericUpDownHorizontalResolution;
        private System.Windows.Forms.NumericUpDown numericUpDownVerticalResolution;
        private System.Windows.Forms.Label labelModDescription;
		private System.Windows.Forms.Button buttonRefreshModList;
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageMods;
		private System.Windows.Forms.TabPage tabPageCodes;
		private System.Windows.Forms.Button buttonModAdd;
		private System.Windows.Forms.CheckBox checkBoxForceAspectRatio;
		private System.Windows.Forms.ComboBox comboBoxScreenNumber;
		private System.Windows.Forms.ColumnHeader columnHeaderVersion;
		private System.Windows.Forms.TabPage tabPageGraphics;
		private System.Windows.Forms.GroupBox groupBoxDisplay;
		private System.Windows.Forms.CheckBox checkBoxForceMipmapping;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox checkBoxForceTextureFilter;
		private System.Windows.Forms.NumericUpDown numericUpDownWindowWidth;
		private System.Windows.Forms.NumericUpDown numericUpDownWindowHeight;
		private System.Windows.Forms.CheckBox checkBoxWindowMaintainAspect;
		private System.Windows.Forms.Button buttonModDown;
		private System.Windows.Forms.Button buttonModUp;
		private System.Windows.Forms.CheckBox checkBoxVsync;
		private System.Windows.Forms.CheckBox checkBoxScaleHud;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripMod;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSeparator1;
		private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItemSeparator3;
		private System.Windows.Forms.ToolStripMenuItem generateManifestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBoxUpdates;
		private System.Windows.Forms.Label labelUpdateFrequency;
		private System.Windows.Forms.CheckBox checkBoxCheckUpdateModsStartup;
		private System.Windows.Forms.NumericUpDown numericUpDownUpdateFrequency;
		private System.Windows.Forms.ComboBox comboBoxUpdateUnit;
		private System.Windows.Forms.CheckBox checkBoxCheckManagerUpdateStartup;
		private System.Windows.Forms.GroupBox groupBoxVisuals;
		private System.Windows.Forms.Button buttonCheckForUpdatesNow;
		private System.Windows.Forms.ToolStripMenuItem verifyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem forceUpdateToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBoxWindowResizable;
		private System.Windows.Forms.ComboBox comboBoxResolutionPreset;
		private System.Windows.Forms.Label labeFmvFillMode;
		private System.Windows.Forms.Label labelBgFillMode;
		private System.Windows.Forms.ComboBox comboBoxFmvFill;
		private System.Windows.Forms.ComboBox comboBoxBackgroundFill;
		private System.Windows.Forms.Button buttonInstallURLHandler;
		private System.Windows.Forms.Button buttonModBottom;
		private System.Windows.Forms.Button buttonModTop;
		private System.Windows.Forms.Button buttonModConfigure;
		private System.Windows.Forms.ComboBox comboBoxFogEmulation;
		private System.Windows.Forms.ComboBox comboBoxClipLevel;
		private System.Windows.Forms.Label labelFogEmulation;
		private System.Windows.Forms.Label labelDetail;
		private System.Windows.Forms.Label labelFramerate;
		private System.Windows.Forms.ComboBox comboBoxFramerate;
		private System.Windows.Forms.TabPage tabPageSound;
		private System.Windows.Forms.GroupBox groupBoxSoundVolume;
		private System.Windows.Forms.Label labelMusicVolume;
		private System.Windows.Forms.Label labelVoiceVolume;
		private System.Windows.Forms.GroupBox groupBoxSound;
		private System.Windows.Forms.CheckBox checkBoxEnableMusic;
		private System.Windows.Forms.CheckBox checkBoxEnableSound;
		private System.Windows.Forms.CheckBox checkBoxEnable3DSound;
        private System.Windows.Forms.TrackBar trackBarVoiceVol;
        private System.Windows.Forms.TrackBar trackBarMusicVol;
        private System.Windows.Forms.Label labelVoiceVol;
        private System.Windows.Forms.Label labelMusicVol;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.GroupBox groupBoxDebugMessages;
        private System.Windows.Forms.CheckBox checkBoxEnableDebugConsole;
        private System.Windows.Forms.CheckBox checkBoxEnableDebugScreen;
        private System.Windows.Forms.CheckBox checkBoxEnableDebugFile;
        private System.Windows.Forms.GroupBox groupBoxTestSpawn;
        private System.Windows.Forms.CheckBox checkBoxTestSpawnPosition;
        private System.Windows.Forms.Button buttonTestSpawnPlay;
        private System.Windows.Forms.ComboBox comboBoxTestSpawnEvent;
        private System.Windows.Forms.CheckBox checkBoxTestSpawnEvent;
        private System.Windows.Forms.CheckBox checkBoxTestSpawnCharacter;
        private System.Windows.Forms.CheckBox checkBoxTestSpawnLevel;
        private System.Windows.Forms.ComboBox comboBoxTestSpawnCharacter;
        private System.Windows.Forms.NumericUpDown numericUpDownTestSpawnAngle;
        private System.Windows.Forms.Label labelTestSpawnAngle;
        private System.Windows.Forms.Label labelTestSpawnY;
        private System.Windows.Forms.CheckBox checkBoxTestSpawnSave;
        private System.Windows.Forms.Label labelTestSpawnX;
        private System.Windows.Forms.Label labelTestSpawnAct;
        private System.Windows.Forms.Label labelTestSpawnZ;
        private System.Windows.Forms.NumericUpDown numericUpDownTestSpawnAct;
        private System.Windows.Forms.NumericUpDown numericUpDownTestSpawnZ;
        private System.Windows.Forms.NumericUpDown numericUpDownTestSpawnY;
        private System.Windows.Forms.ComboBox comboBoxTestSpawnLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownTestSpawnX;
        private System.Windows.Forms.CheckBox checkBoxTestSpawnAngleHex;
        private System.Windows.Forms.CheckBox checkBoxEnableD3D9;
        private System.Windows.Forms.Label labelTestSpawnTime;
        private System.Windows.Forms.ComboBox comboBoxTestSpawnTime;
		private System.Windows.Forms.Label labelTestSpawnWarning;
		private System.Windows.Forms.ComboBox textBoxProfileName;
		private System.Windows.Forms.Button buttonSaveProfile;
		private System.Windows.Forms.Button buttonLoadProfile;
		private System.Windows.Forms.GroupBox groupBoxMouseMode;
		private System.Windows.Forms.Label labelMouseButtonAssignment;
		private System.Windows.Forms.ComboBox comboBoxMouseButtonAssignment;
		private System.Windows.Forms.RadioButton radioButtonMouseDragAccelerate;
		private System.Windows.Forms.RadioButton radioButtonMouseHold;
		private System.Windows.Forms.ComboBox comboBoxMouseAction;
		private System.Windows.Forms.Label labelMouseAction;
		private System.Windows.Forms.CheckBox checkBoxEnableDebugCrashHandler;
		private System.Windows.Forms.ColumnHeader columnHeaderCategory;
		private System.Windows.Forms.ComboBox comboBoxTestSpawnGameMode;
		private System.Windows.Forms.CheckBox checkBoxTestSpawnGameMode;
		private System.Windows.Forms.Label labelSEVol;
		private System.Windows.Forms.TrackBar trackBarSEVol;
		private System.Windows.Forms.Label labelSEVolume;
		private System.Windows.Forms.CheckBox checkBoxUseBassSE;
		private System.Windows.Forms.TabPage tabPageGameConfig;
		private System.Windows.Forms.TabControl tabControlGameConfig;
		private System.Windows.Forms.TabPage tabPageManagerConfig;
		private System.Windows.Forms.TabPage tabPagePatches;
		private System.Windows.Forms.TabPage tabPageInput;
		private System.Windows.Forms.GroupBox groupBoxInputMode;
		private System.Windows.Forms.RadioButton radioButtonSDL;
		private System.Windows.Forms.RadioButton radioButtonDInput;
		private System.Windows.Forms.Label labelCustomWindowSize;
		private System.Windows.Forms.ComboBox comboBoxScreenMode;
		private System.Windows.Forms.Label labelScreenMode;
		private System.Windows.Forms.CheckBox checkBoxShowMouse;
		private System.Windows.Forms.CheckBox checkBoxBorderImage;
		private System.Windows.Forms.GroupBox groupBoxGraphicsOther;
		private System.Windows.Forms.ComboBox comboBoxTestSpawnSave;
		private System.Windows.Forms.Label labelCodeDescription;
		private System.Windows.Forms.ListView listViewCodes;
		private System.Windows.Forms.ColumnHeader columnHeaderCodeName;
		private System.Windows.Forms.ColumnHeader columnHeaderCodeCategory;
		private System.Windows.Forms.ColumnHeader columnHeaderCodeAuthor;
		private System.Windows.Forms.Button buttonCheckModUpdates;
		private System.Windows.Forms.Button buttonSelectAllMods;
		private System.Windows.Forms.TextBox textBoxSearchMod;
		private System.Windows.Forms.CheckBox checkBoxCheckLoaderUpdatesStartup;
		private System.Windows.Forms.Label labelModProfile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem disableUpdatesToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBoxSearchMod;
		private System.Windows.Forms.Label labelPatchDescription;
		private System.Windows.Forms.ListView listViewPatches;
		private System.Windows.Forms.ColumnHeader columnHeaderPatchName;
		private System.Windows.Forms.ColumnHeader columnHeaderPatchAuthor;
		private System.Windows.Forms.ColumnHeader columnHeaderPatchCategory;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripAddMod;
		private System.Windows.Forms.ToolStripMenuItem addModArchivetoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fromURLToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem newModToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStripManager;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.Label labelAntiAliasing;
		private System.Windows.Forms.ComboBox comboBoxAntialiasing;
		private System.Windows.Forms.ComboBox comboBoxAnisotropic;
		private System.Windows.Forms.Label labelAnisotropic;
		private System.Windows.Forms.RadioButton radioButtonMouseDisable;
		private System.Windows.Forms.TabPage tabPageController;
		private System.Windows.Forms.GroupBox groupBoxControlsSDL;
		private System.Windows.Forms.ListView listViewControlBindings;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.GroupBox groupBoxDeadzones;
		private System.Windows.Forms.Label labelTriggersDeadzone;
		private System.Windows.Forms.Label labelRightStickDeadzone;
		private System.Windows.Forms.Label labelLeftStickDeadzone;
		private System.Windows.Forms.Label labelKeyboardPlayer;
		private System.Windows.Forms.ComboBox comboBoxKeyboardPlayer;
		private System.Windows.Forms.GroupBox groupBoxRumble;
		private System.Windows.Forms.NumericUpDown numericUpDownRumbleMinTime;
		private System.Windows.Forms.Label labelRumpleMultiplier;
		private System.Windows.Forms.Label labelMinRumbleTime;
		private System.Windows.Forms.CheckBox checkBoxMegaRumble;
		private System.Windows.Forms.CheckBox checkBoxRadialMotionRight;
		private System.Windows.Forms.CheckBox checkBoxRadialMotionLeft;
		private System.Windows.Forms.NumericUpDown numericUpDownTriggersDeadzone;
		private System.Windows.Forms.NumericUpDown numericUpDownRightStickDeadzone;
		private System.Windows.Forms.NumericUpDown numericUpDownLeftStickDeadzone;
		private System.Windows.Forms.NumericUpDown numericUpDownRumbleMultiplier;
		private System.Windows.Forms.Button buttonBindingReset;
		private System.Windows.Forms.Button buttonBindingClear;
		private System.Windows.Forms.Button buttonBindingSet;
		private System.Windows.Forms.Label labelSdlDevice;
		private System.Windows.Forms.ComboBox comboBoxSdlDevice;
		private System.Windows.Forms.GroupBox groupBoxControllerDInput;
		private System.Windows.Forms.TextBox comboBoxControllerName;
		private System.Windows.Forms.ComboBox comboBoxControllerProfile;
		private System.Windows.Forms.Button buttonControllerProfileAdd;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDInput;
		private System.Windows.Forms.Button buttonControllerProfileRemove;
		private System.Windows.Forms.CheckBox checkBoxUseBassMusic;
		private System.Windows.Forms.CheckBox checkBoxKeepManagerOpen;
		private System.Windows.Forms.Button buttonSwitchToSAManager;
		private System.Windows.Forms.Button buttonCheckGameHealth;
		private System.Windows.Forms.GroupBox groupBoxManagerOptions;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripProfile;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteProfile;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGameFolder;
		private System.Windows.Forms.TabPage tabPageGameOptions;
		private System.Windows.Forms.ComboBox comboBoxTextLanguage;
		private System.Windows.Forms.ComboBox comboBoxVoiceLanguage;
		private System.Windows.Forms.Label labelGameTextLang;
		private System.Windows.Forms.Label labelGameVoiceLang;
		private System.Windows.Forms.CheckBox checkBoxPauseWhenInactive;
		private System.Windows.Forms.CheckBox checkBoxTestSpawnAngleDeg;
		private System.Windows.Forms.CheckBox checkBoxSingleProfile;
		private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2Separator2;
		private System.Windows.Forms.Button buttonResetGameSettings;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripResetGameSettings;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResetOptimal;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResetSafe;
	}
}