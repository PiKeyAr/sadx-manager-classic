using System;

namespace SADXModManager.Forms
{
	partial class NewModDialog
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
            this.labelModName = new System.Windows.Forms.Label();
            this.labelModDescription = new System.Windows.Forms.Label();
            this.labelModAuthor = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxModName = new System.Windows.Forms.TextBox();
            this.textBoxModAuthor = new System.Windows.Forms.TextBox();
            this.checkBoxOpenModFolder = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxModCategory = new System.Windows.Forms.ComboBox();
            this.textBoxModDescription = new System.Windows.Forms.TextBox();
            this.textBoxModVersion = new System.Windows.Forms.TextBox();
            this.label4ModVersion = new System.Windows.Forms.Label();
            this.tabControlNewModProperties = new System.Windows.Forms.TabControl();
            this.tabPageNewModProperties = new System.Windows.Forms.TabPage();
            this.labelModCategory = new System.Windows.Forms.Label();
            this.tabPageNewModUpdates = new System.Windows.Forms.TabPage();
            this.groupBoxSelfHosted = new System.Windows.Forms.GroupBox();
            this.labelModSelfHostUrl = new System.Windows.Forms.Label();
            this.textBoxSelfHostUrl = new System.Windows.Forms.TextBox();
            this.groupBoxGitHub = new System.Windows.Forms.GroupBox();
            this.labelModGitAsset = new System.Windows.Forms.Label();
            this.labelModRepo = new System.Windows.Forms.Label();
            this.textBoxGitHubAttachment = new System.Windows.Forms.TextBox();
            this.textBoxGitHubRepo = new System.Windows.Forms.TextBox();
            this.groupBoxGameBanana = new System.Windows.Forms.GroupBox();
            this.labelModGameBananaType = new System.Windows.Forms.Label();
            this.labelModGameBananaId = new System.Windows.Forms.Label();
            this.comboBoxGameBananaType = new System.Windows.Forms.ComboBox();
            this.tabPageNewModAdvanced = new System.Windows.Forms.TabPage();
            this.labelSourceUrl = new System.Windows.Forms.Label();
            this.labelHomepageUrl = new System.Windows.Forms.Label();
            this.labelIncludeFolders = new System.Windows.Forms.Label();
            this.labelSaveRedirect = new System.Windows.Forms.Label();
            this.checkBoxRedirectChaoSave = new System.Windows.Forms.CheckBox();
            this.checkBoxRedirectMainSave = new System.Windows.Forms.CheckBox();
            this.radioButtonModUpdatesGitHub = new System.Windows.Forms.RadioButton();
            this.radioButtonModUpdatesSelf = new System.Windows.Forms.RadioButton();
            this.radioButtonModUpdatesGameBanana = new System.Windows.Forms.RadioButton();
            this.labelModUpdateHost = new System.Windows.Forms.Label();
            this.radioButtonModUpdatesNone = new System.Windows.Forms.RadioButton();
            this.buttonGenerateModId = new System.Windows.Forms.Button();
            this.labelModId = new System.Windows.Forms.Label();
            this.textBoxModID = new System.Windows.Forms.TextBox();
            this.labelModSelfHostChangelog = new System.Windows.Forms.Label();
            this.textBoxSelfHostChangelogUrl = new System.Windows.Forms.TextBox();
            this.textBoxIncludeFolders = new System.Windows.Forms.TextBox();
            this.textBoxHomepageUrl = new System.Windows.Forms.TextBox();
            this.textBoxSourceUrl = new System.Windows.Forms.TextBox();
            this.textBoxModDll = new System.Windows.Forms.TextBox();
            this.labelModDll = new System.Windows.Forms.Label();
            this.labelCustomExe = new System.Windows.Forms.Label();
            this.textBoxModExeFile = new System.Windows.Forms.TextBox();
            this.listViewModDependencies = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.columnHeaderDepName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDepId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDepLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDepFolder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownGameBananaID = new System.Windows.Forms.NumericUpDown();
            this.tabControlNewModProperties.SuspendLayout();
            this.tabPageNewModProperties.SuspendLayout();
            this.tabPageNewModUpdates.SuspendLayout();
            this.groupBoxSelfHosted.SuspendLayout();
            this.groupBoxGitHub.SuspendLayout();
            this.groupBoxGameBanana.SuspendLayout();
            this.tabPageNewModAdvanced.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGameBananaID)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModName
            // 
            this.labelModName.AutoSize = true;
            this.labelModName.Location = new System.Drawing.Point(22, 9);
            this.labelModName.Name = "labelModName";
            this.labelModName.Size = new System.Drawing.Size(62, 13);
            this.labelModName.TabIndex = 0;
            this.labelModName.Text = "Mod Name:";
            // 
            // labelModDescription
            // 
            this.labelModDescription.AutoSize = true;
            this.labelModDescription.Location = new System.Drawing.Point(21, 166);
            this.labelModDescription.Name = "labelModDescription";
            this.labelModDescription.Size = new System.Drawing.Size(63, 13);
            this.labelModDescription.TabIndex = 6;
            this.labelModDescription.Text = "Description:";
            // 
            // labelModAuthor
            // 
            this.labelModAuthor.AutoSize = true;
            this.labelModAuthor.Location = new System.Drawing.Point(38, 37);
            this.labelModAuthor.Name = "labelModAuthor";
            this.labelModAuthor.Size = new System.Drawing.Size(46, 13);
            this.labelModAuthor.TabIndex = 2;
            this.labelModAuthor.Text = "Authors:";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOK.Location = new System.Drawing.Point(216, 387);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(297, 387);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxModName
            // 
            this.textBoxModName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModName.Location = new System.Drawing.Point(90, 6);
            this.textBoxModName.Name = "textBoxModName";
            this.textBoxModName.Size = new System.Drawing.Size(256, 20);
            this.textBoxModName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxModName, "This name will be displayed on the mod list.");
            // 
            // textBoxModAuthor
            // 
            this.textBoxModAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModAuthor.Location = new System.Drawing.Point(90, 34);
            this.textBoxModAuthor.Name = "textBoxModAuthor";
            this.textBoxModAuthor.Size = new System.Drawing.Size(256, 20);
            this.textBoxModAuthor.TabIndex = 1;
            // 
            // checkBoxOpenModFolder
            // 
            this.checkBoxOpenModFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxOpenModFolder.AutoSize = true;
            this.checkBoxOpenModFolder.Checked = true;
            this.checkBoxOpenModFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOpenModFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxOpenModFolder.Location = new System.Drawing.Point(16, 387);
            this.checkBoxOpenModFolder.Name = "checkBoxOpenModFolder";
            this.checkBoxOpenModFolder.Size = new System.Drawing.Size(114, 18);
            this.checkBoxOpenModFolder.TabIndex = 1;
            this.checkBoxOpenModFolder.Text = "Open Mod Folder";
            this.toolTip1.SetToolTip(this.checkBoxOpenModFolder, "Open the newly created mod\'s folder upon completion.");
            this.checkBoxOpenModFolder.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // comboBoxModCategory
            // 
            this.comboBoxModCategory.FormattingEnabled = true;
            this.comboBoxModCategory.Items.AddRange(new object[] {
            "Animations",
            "Chao",
            "Custom Level",
            "Cutscene",
            "Game Overhaul",
            "Gameplay",
            "Misc",
            "Music",
            "Patch",
            "Skin",
            "Sound",
            "Textures",
            "UI"});
            this.comboBoxModCategory.Location = new System.Drawing.Point(90, 86);
            this.comboBoxModCategory.Name = "comboBoxModCategory";
            this.comboBoxModCategory.Size = new System.Drawing.Size(256, 21);
            this.comboBoxModCategory.Sorted = true;
            this.comboBoxModCategory.TabIndex = 3;
            this.comboBoxModCategory.Text = "--Select a category--";
            this.toolTip1.SetToolTip(this.comboBoxModCategory, "Select or enter the category of your mod (optional).");
            // 
            // textBoxModDescription
            // 
            this.textBoxModDescription.AcceptsReturn = true;
            this.textBoxModDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModDescription.Location = new System.Drawing.Point(90, 165);
            this.textBoxModDescription.Multiline = true;
            this.textBoxModDescription.Name = "textBoxModDescription";
            this.textBoxModDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxModDescription.Size = new System.Drawing.Size(256, 172);
            this.textBoxModDescription.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBoxModDescription, "This description will show up in the Mod Manager.");
            // 
            // textBoxModVersion
            // 
            this.textBoxModVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModVersion.Location = new System.Drawing.Point(90, 60);
            this.textBoxModVersion.Name = "textBoxModVersion";
            this.textBoxModVersion.Size = new System.Drawing.Size(256, 20);
            this.textBoxModVersion.TabIndex = 2;
            this.textBoxModVersion.Text = "0.1";
            // 
            // label4ModVersion
            // 
            this.label4ModVersion.AutoSize = true;
            this.label4ModVersion.Location = new System.Drawing.Point(39, 63);
            this.label4ModVersion.Name = "label4ModVersion";
            this.label4ModVersion.Size = new System.Drawing.Size(45, 13);
            this.label4ModVersion.TabIndex = 4;
            this.label4ModVersion.Text = "Version:";
            // 
            // tabControlNewModProperties
            // 
            this.tabControlNewModProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlNewModProperties.Controls.Add(this.tabPageNewModProperties);
            this.tabControlNewModProperties.Controls.Add(this.tabPageNewModUpdates);
            this.tabControlNewModProperties.Controls.Add(this.tabPageNewModAdvanced);
            this.tabControlNewModProperties.Location = new System.Drawing.Point(12, 12);
            this.tabControlNewModProperties.Name = "tabControlNewModProperties";
            this.tabControlNewModProperties.SelectedIndex = 0;
            this.tabControlNewModProperties.Size = new System.Drawing.Size(360, 369);
            this.tabControlNewModProperties.TabIndex = 0;
            // 
            // tabPageNewModProperties
            // 
            this.tabPageNewModProperties.Controls.Add(this.textBoxModDll);
            this.tabPageNewModProperties.Controls.Add(this.labelModDll);
            this.tabPageNewModProperties.Controls.Add(this.buttonGenerateModId);
            this.tabPageNewModProperties.Controls.Add(this.labelModId);
            this.tabPageNewModProperties.Controls.Add(this.textBoxModID);
            this.tabPageNewModProperties.Controls.Add(this.comboBoxModCategory);
            this.tabPageNewModProperties.Controls.Add(this.labelModCategory);
            this.tabPageNewModProperties.Controls.Add(this.labelModName);
            this.tabPageNewModProperties.Controls.Add(this.labelModDescription);
            this.tabPageNewModProperties.Controls.Add(this.labelModAuthor);
            this.tabPageNewModProperties.Controls.Add(this.textBoxModName);
            this.tabPageNewModProperties.Controls.Add(this.label4ModVersion);
            this.tabPageNewModProperties.Controls.Add(this.textBoxModAuthor);
            this.tabPageNewModProperties.Controls.Add(this.textBoxModVersion);
            this.tabPageNewModProperties.Controls.Add(this.textBoxModDescription);
            this.tabPageNewModProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewModProperties.Name = "tabPageNewModProperties";
            this.tabPageNewModProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewModProperties.Size = new System.Drawing.Size(352, 343);
            this.tabPageNewModProperties.TabIndex = 0;
            this.tabPageNewModProperties.Text = "Properties";
            this.tabPageNewModProperties.UseVisualStyleBackColor = true;
            // 
            // labelModCategory
            // 
            this.labelModCategory.AutoSize = true;
            this.labelModCategory.Location = new System.Drawing.Point(32, 89);
            this.labelModCategory.Name = "labelModCategory";
            this.labelModCategory.Size = new System.Drawing.Size(52, 13);
            this.labelModCategory.TabIndex = 11;
            this.labelModCategory.Text = "Category:";
            // 
            // tabPageNewModUpdates
            // 
            this.tabPageNewModUpdates.Controls.Add(this.radioButtonModUpdatesNone);
            this.tabPageNewModUpdates.Controls.Add(this.labelModUpdateHost);
            this.tabPageNewModUpdates.Controls.Add(this.radioButtonModUpdatesGameBanana);
            this.tabPageNewModUpdates.Controls.Add(this.radioButtonModUpdatesSelf);
            this.tabPageNewModUpdates.Controls.Add(this.radioButtonModUpdatesGitHub);
            this.tabPageNewModUpdates.Controls.Add(this.groupBoxGameBanana);
            this.tabPageNewModUpdates.Controls.Add(this.groupBoxSelfHosted);
            this.tabPageNewModUpdates.Controls.Add(this.groupBoxGitHub);
            this.tabPageNewModUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewModUpdates.Name = "tabPageNewModUpdates";
            this.tabPageNewModUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewModUpdates.Size = new System.Drawing.Size(352, 343);
            this.tabPageNewModUpdates.TabIndex = 1;
            this.tabPageNewModUpdates.Text = "Updates";
            this.tabPageNewModUpdates.UseVisualStyleBackColor = true;
            // 
            // groupBoxSelfHosted
            // 
            this.groupBoxSelfHosted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSelfHosted.Controls.Add(this.textBoxSelfHostChangelogUrl);
            this.groupBoxSelfHosted.Controls.Add(this.labelModSelfHostChangelog);
            this.groupBoxSelfHosted.Controls.Add(this.labelModSelfHostUrl);
            this.groupBoxSelfHosted.Controls.Add(this.textBoxSelfHostUrl);
            this.groupBoxSelfHosted.Location = new System.Drawing.Point(6, 111);
            this.groupBoxSelfHosted.Name = "groupBoxSelfHosted";
            this.groupBoxSelfHosted.Size = new System.Drawing.Size(343, 78);
            this.groupBoxSelfHosted.TabIndex = 5;
            this.groupBoxSelfHosted.TabStop = false;
            this.groupBoxSelfHosted.Text = "Self-Hosted Directory";
            // 
            // labelModSelfHostUrl
            // 
            this.labelModSelfHostUrl.AutoSize = true;
            this.labelModSelfHostUrl.Location = new System.Drawing.Point(20, 22);
            this.labelModSelfHostUrl.Name = "labelModSelfHostUrl";
            this.labelModSelfHostUrl.Size = new System.Drawing.Size(77, 13);
            this.labelModSelfHostUrl.TabIndex = 1;
            this.labelModSelfHostUrl.Text = "Directory URL:";
            // 
            // textBoxSelfHostUrl
            // 
            this.textBoxSelfHostUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelfHostUrl.Location = new System.Drawing.Point(103, 19);
            this.textBoxSelfHostUrl.Name = "textBoxSelfHostUrl";
            this.textBoxSelfHostUrl.Size = new System.Drawing.Size(234, 20);
            this.textBoxSelfHostUrl.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxSelfHostUrl, "Enter the direct URL to a remote folder containing mod.ini.");
            // 
            // groupBoxGitHub
            // 
            this.groupBoxGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGitHub.Controls.Add(this.labelModGitAsset);
            this.groupBoxGitHub.Controls.Add(this.labelModRepo);
            this.groupBoxGitHub.Controls.Add(this.textBoxGitHubAttachment);
            this.groupBoxGitHub.Controls.Add(this.textBoxGitHubRepo);
            this.groupBoxGitHub.Location = new System.Drawing.Point(6, 33);
            this.groupBoxGitHub.Name = "groupBoxGitHub";
            this.groupBoxGitHub.Size = new System.Drawing.Size(343, 71);
            this.groupBoxGitHub.TabIndex = 4;
            this.groupBoxGitHub.TabStop = false;
            this.groupBoxGitHub.Text = "GitHub";
            // 
            // labelModGitAsset
            // 
            this.labelModGitAsset.AutoSize = true;
            this.labelModGitAsset.Location = new System.Drawing.Point(33, 48);
            this.labelModGitAsset.Name = "labelModGitAsset";
            this.labelModGitAsset.Size = new System.Drawing.Size(64, 13);
            this.labelModGitAsset.TabIndex = 3;
            this.labelModGitAsset.Text = "Attachment:";
            // 
            // labelModRepo
            // 
            this.labelModRepo.AutoSize = true;
            this.labelModRepo.Location = new System.Drawing.Point(6, 22);
            this.labelModRepo.Name = "labelModRepo";
            this.labelModRepo.Size = new System.Drawing.Size(91, 13);
            this.labelModRepo.TabIndex = 2;
            this.labelModRepo.Text = "Repo (user/repo):";
            // 
            // textBoxGitHubAttachment
            // 
            this.textBoxGitHubAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGitHubAttachment.Location = new System.Drawing.Point(103, 45);
            this.textBoxGitHubAttachment.Name = "textBoxGitHubAttachment";
            this.textBoxGitHubAttachment.Size = new System.Drawing.Size(234, 20);
            this.textBoxGitHubAttachment.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxGitHubAttachment, "Enter the GitHub asset name. This file will be retrieved from GitHub releases. Ex" +
        "ample: mymod.7z");
            // 
            // textBoxGitHubRepo
            // 
            this.textBoxGitHubRepo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGitHubRepo.Location = new System.Drawing.Point(103, 19);
            this.textBoxGitHubRepo.Name = "textBoxGitHubRepo";
            this.textBoxGitHubRepo.Size = new System.Drawing.Size(234, 20);
            this.textBoxGitHubRepo.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxGitHubRepo, "Enter the author and repository name. Example: x-hax/mymod");
            // 
            // groupBoxGameBanana
            // 
            this.groupBoxGameBanana.Controls.Add(this.numericUpDownGameBananaID);
            this.groupBoxGameBanana.Controls.Add(this.comboBoxGameBananaType);
            this.groupBoxGameBanana.Controls.Add(this.labelModGameBananaId);
            this.groupBoxGameBanana.Controls.Add(this.labelModGameBananaType);
            this.groupBoxGameBanana.Location = new System.Drawing.Point(6, 195);
            this.groupBoxGameBanana.Name = "groupBoxGameBanana";
            this.groupBoxGameBanana.Size = new System.Drawing.Size(343, 75);
            this.groupBoxGameBanana.TabIndex = 6;
            this.groupBoxGameBanana.TabStop = false;
            this.groupBoxGameBanana.Text = "GameBanana";
            // 
            // labelModGameBananaType
            // 
            this.labelModGameBananaType.AutoSize = true;
            this.labelModGameBananaType.Location = new System.Drawing.Point(39, 19);
            this.labelModGameBananaType.Name = "labelModGameBananaType";
            this.labelModGameBananaType.Size = new System.Drawing.Size(57, 13);
            this.labelModGameBananaType.TabIndex = 0;
            this.labelModGameBananaType.Text = "Item Type:";
            // 
            // labelModGameBananaId
            // 
            this.labelModGameBananaId.AutoSize = true;
            this.labelModGameBananaId.Location = new System.Drawing.Point(52, 45);
            this.labelModGameBananaId.Name = "labelModGameBananaId";
            this.labelModGameBananaId.Size = new System.Drawing.Size(44, 13);
            this.labelModGameBananaId.TabIndex = 1;
            this.labelModGameBananaId.Text = "Item ID:";
            // 
            // comboBoxGameBananaType
            // 
            this.comboBoxGameBananaType.FormattingEnabled = true;
            this.comboBoxGameBananaType.Items.AddRange(new object[] {
            "Mod",
            "Gamefile"});
            this.comboBoxGameBananaType.Location = new System.Drawing.Point(102, 16);
            this.comboBoxGameBananaType.Name = "comboBoxGameBananaType";
            this.comboBoxGameBananaType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGameBananaType.TabIndex = 0;
            this.comboBoxGameBananaType.Text = "Mod";
            this.toolTip1.SetToolTip(this.comboBoxGameBananaType, "Enter the GameBanana item type. \'Mod\' is the most common item type.");
            // 
            // tabPageNewModAdvanced
            // 
            this.tabPageNewModAdvanced.Controls.Add(this.groupBox1);
            this.tabPageNewModAdvanced.Controls.Add(this.textBoxModExeFile);
            this.tabPageNewModAdvanced.Controls.Add(this.labelCustomExe);
            this.tabPageNewModAdvanced.Controls.Add(this.textBoxSourceUrl);
            this.tabPageNewModAdvanced.Controls.Add(this.textBoxHomepageUrl);
            this.tabPageNewModAdvanced.Controls.Add(this.textBoxIncludeFolders);
            this.tabPageNewModAdvanced.Controls.Add(this.labelSaveRedirect);
            this.tabPageNewModAdvanced.Controls.Add(this.checkBoxRedirectChaoSave);
            this.tabPageNewModAdvanced.Controls.Add(this.checkBoxRedirectMainSave);
            this.tabPageNewModAdvanced.Controls.Add(this.labelSourceUrl);
            this.tabPageNewModAdvanced.Controls.Add(this.labelHomepageUrl);
            this.tabPageNewModAdvanced.Controls.Add(this.labelIncludeFolders);
            this.tabPageNewModAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewModAdvanced.Name = "tabPageNewModAdvanced";
            this.tabPageNewModAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewModAdvanced.Size = new System.Drawing.Size(352, 343);
            this.tabPageNewModAdvanced.TabIndex = 2;
            this.tabPageNewModAdvanced.Text = "Advanced";
            this.tabPageNewModAdvanced.UseVisualStyleBackColor = true;
            // 
            // labelSourceUrl
            // 
            this.labelSourceUrl.AutoSize = true;
            this.labelSourceUrl.Location = new System.Drawing.Point(5, 61);
            this.labelSourceUrl.Name = "labelSourceUrl";
            this.labelSourceUrl.Size = new System.Drawing.Size(97, 13);
            this.labelSourceUrl.TabIndex = 22;
            this.labelSourceUrl.Text = "Source Code URL:";
            // 
            // labelHomepageUrl
            // 
            this.labelHomepageUrl.AutoSize = true;
            this.labelHomepageUrl.Location = new System.Drawing.Point(15, 35);
            this.labelHomepageUrl.Name = "labelHomepageUrl";
            this.labelHomepageUrl.Size = new System.Drawing.Size(87, 13);
            this.labelHomepageUrl.TabIndex = 21;
            this.labelHomepageUrl.Text = "Homepage URL:";
            // 
            // labelIncludeFolders
            // 
            this.labelIncludeFolders.AutoSize = true;
            this.labelIncludeFolders.Location = new System.Drawing.Point(20, 9);
            this.labelIncludeFolders.Name = "labelIncludeFolders";
            this.labelIncludeFolders.Size = new System.Drawing.Size(82, 13);
            this.labelIncludeFolders.TabIndex = 20;
            this.labelIncludeFolders.Text = "Include Folders:";
            // 
            // labelSaveRedirect
            // 
            this.labelSaveRedirect.AutoSize = true;
            this.labelSaveRedirect.Location = new System.Drawing.Point(24, 113);
            this.labelSaveRedirect.Name = "labelSaveRedirect";
            this.labelSaveRedirect.Size = new System.Drawing.Size(78, 13);
            this.labelSaveRedirect.TabIndex = 28;
            this.labelSaveRedirect.Text = "Save Redirect:";
            // 
            // checkBoxRedirectChaoSave
            // 
            this.checkBoxRedirectChaoSave.AutoSize = true;
            this.checkBoxRedirectChaoSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxRedirectChaoSave.Location = new System.Drawing.Point(108, 135);
            this.checkBoxRedirectChaoSave.Name = "checkBoxRedirectChaoSave";
            this.checkBoxRedirectChaoSave.Size = new System.Drawing.Size(85, 18);
            this.checkBoxRedirectChaoSave.TabIndex = 5;
            this.checkBoxRedirectChaoSave.Text = "Chao Save";
            this.toolTip1.SetToolTip(this.checkBoxRedirectChaoSave, "Check to make the mod use a separate Chao Garden save file.");
            this.checkBoxRedirectChaoSave.UseVisualStyleBackColor = true;
            // 
            // checkBoxRedirectMainSave
            // 
            this.checkBoxRedirectMainSave.AutoSize = true;
            this.checkBoxRedirectMainSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxRedirectMainSave.Location = new System.Drawing.Point(108, 111);
            this.checkBoxRedirectMainSave.Name = "checkBoxRedirectMainSave";
            this.checkBoxRedirectMainSave.Size = new System.Drawing.Size(83, 18);
            this.checkBoxRedirectMainSave.TabIndex = 4;
            this.checkBoxRedirectMainSave.Text = "Main Save";
            this.toolTip1.SetToolTip(this.checkBoxRedirectMainSave, "Check to make the mod use a separate save file.");
            this.checkBoxRedirectMainSave.UseVisualStyleBackColor = true;
            // 
            // radioButtonModUpdatesGitHub
            // 
            this.radioButtonModUpdatesGitHub.AutoSize = true;
            this.radioButtonModUpdatesGitHub.Location = new System.Drawing.Point(190, 10);
            this.radioButtonModUpdatesGitHub.Name = "radioButtonModUpdatesGitHub";
            this.radioButtonModUpdatesGitHub.Size = new System.Drawing.Size(58, 17);
            this.radioButtonModUpdatesGitHub.TabIndex = 2;
            this.radioButtonModUpdatesGitHub.Text = "GitHub";
            this.toolTip1.SetToolTip(this.radioButtonModUpdatesGitHub, "Select if the mod will be using a GitHub repository for updates.");
            this.radioButtonModUpdatesGitHub.UseVisualStyleBackColor = true;
            // 
            // radioButtonModUpdatesSelf
            // 
            this.radioButtonModUpdatesSelf.AutoSize = true;
            this.radioButtonModUpdatesSelf.Location = new System.Drawing.Point(104, 10);
            this.radioButtonModUpdatesSelf.Name = "radioButtonModUpdatesSelf";
            this.radioButtonModUpdatesSelf.Size = new System.Drawing.Size(80, 17);
            this.radioButtonModUpdatesSelf.TabIndex = 1;
            this.radioButtonModUpdatesSelf.Text = "Self-Hosted";
            this.toolTip1.SetToolTip(this.radioButtonModUpdatesSelf, "Select if the mod will be using a direct link to a folder for updates.");
            this.radioButtonModUpdatesSelf.UseVisualStyleBackColor = true;
            // 
            // radioButtonModUpdatesGameBanana
            // 
            this.radioButtonModUpdatesGameBanana.AutoSize = true;
            this.radioButtonModUpdatesGameBanana.Location = new System.Drawing.Point(254, 10);
            this.radioButtonModUpdatesGameBanana.Name = "radioButtonModUpdatesGameBanana";
            this.radioButtonModUpdatesGameBanana.Size = new System.Drawing.Size(90, 17);
            this.radioButtonModUpdatesGameBanana.TabIndex = 3;
            this.radioButtonModUpdatesGameBanana.Text = "GameBanana";
            this.toolTip1.SetToolTip(this.radioButtonModUpdatesGameBanana, "Select if the mod will be using GameBanana for updates.");
            this.radioButtonModUpdatesGameBanana.UseVisualStyleBackColor = true;
            // 
            // labelModUpdateHost
            // 
            this.labelModUpdateHost.AutoSize = true;
            this.labelModUpdateHost.Location = new System.Drawing.Point(9, 12);
            this.labelModUpdateHost.Name = "labelModUpdateHost";
            this.labelModUpdateHost.Size = new System.Drawing.Size(32, 13);
            this.labelModUpdateHost.TabIndex = 6;
            this.labelModUpdateHost.Text = "Host:";
            // 
            // radioButtonModUpdatesNone
            // 
            this.radioButtonModUpdatesNone.AutoSize = true;
            this.radioButtonModUpdatesNone.Checked = true;
            this.radioButtonModUpdatesNone.Location = new System.Drawing.Point(47, 10);
            this.radioButtonModUpdatesNone.Name = "radioButtonModUpdatesNone";
            this.radioButtonModUpdatesNone.Size = new System.Drawing.Size(51, 17);
            this.radioButtonModUpdatesNone.TabIndex = 0;
            this.radioButtonModUpdatesNone.TabStop = true;
            this.radioButtonModUpdatesNone.Text = "None";
            this.toolTip1.SetToolTip(this.radioButtonModUpdatesNone, "Select if the mod does not provide automatic updates.");
            this.radioButtonModUpdatesNone.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateModId
            // 
            this.buttonGenerateModId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateModId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGenerateModId.Location = new System.Drawing.Point(281, 111);
            this.buttonGenerateModId.Name = "buttonGenerateModId";
            this.buttonGenerateModId.Size = new System.Drawing.Size(65, 23);
            this.buttonGenerateModId.TabIndex = 5;
            this.buttonGenerateModId.Text = "Generate";
            this.toolTip1.SetToolTip(this.buttonGenerateModId, "Generates a new Mod ID. If Mod Name and Author are supplied, it\'ll generate a mod" +
        " ID based on those. Otherwise, it generates it based on the current time hash.");
            this.buttonGenerateModId.UseVisualStyleBackColor = true;
            this.buttonGenerateModId.Click += new System.EventHandler(this.buttonGenerateModId_Click);
            // 
            // labelModId
            // 
            this.labelModId.AutoSize = true;
            this.labelModId.Location = new System.Drawing.Point(39, 116);
            this.labelModId.Name = "labelModId";
            this.labelModId.Size = new System.Drawing.Size(45, 13);
            this.labelModId.TabIndex = 26;
            this.labelModId.Text = "Mod ID:";
            // 
            // textBoxModID
            // 
            this.textBoxModID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModID.Location = new System.Drawing.Point(90, 113);
            this.textBoxModID.Name = "textBoxModID";
            this.textBoxModID.Size = new System.Drawing.Size(185, 20);
            this.textBoxModID.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxModID, "Enter the mod\'s unique ID that can be used to interact with other mods (optional)" +
        ".");
            // 
            // labelModSelfHostChangelog
            // 
            this.labelModSelfHostChangelog.AutoSize = true;
            this.labelModSelfHostChangelog.Location = new System.Drawing.Point(11, 46);
            this.labelModSelfHostChangelog.Name = "labelModSelfHostChangelog";
            this.labelModSelfHostChangelog.Size = new System.Drawing.Size(86, 13);
            this.labelModSelfHostChangelog.TabIndex = 2;
            this.labelModSelfHostChangelog.Text = "Changelog URL:";
            // 
            // textBoxSelfHostChangelogUrl
            // 
            this.textBoxSelfHostChangelogUrl.Location = new System.Drawing.Point(103, 45);
            this.textBoxSelfHostChangelogUrl.Name = "textBoxSelfHostChangelogUrl";
            this.textBoxSelfHostChangelogUrl.Size = new System.Drawing.Size(231, 20);
            this.textBoxSelfHostChangelogUrl.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxSelfHostChangelogUrl, "Enter the direct URL to the text file containing the changelog (optional).");
            // 
            // textBoxIncludeFolders
            // 
            this.textBoxIncludeFolders.Location = new System.Drawing.Point(108, 6);
            this.textBoxIncludeFolders.Name = "textBoxIncludeFolders";
            this.textBoxIncludeFolders.Size = new System.Drawing.Size(237, 20);
            this.textBoxIncludeFolders.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxIncludeFolders, "Enter a comma-separated list of folders for codeless mod configuration.");
            // 
            // textBoxHomepageUrl
            // 
            this.textBoxHomepageUrl.Location = new System.Drawing.Point(108, 32);
            this.textBoxHomepageUrl.Name = "textBoxHomepageUrl";
            this.textBoxHomepageUrl.Size = new System.Drawing.Size(237, 20);
            this.textBoxHomepageUrl.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxHomepageUrl, "Enter the URL to the author or the mod\'s homepage.");
            // 
            // textBoxSourceUrl
            // 
            this.textBoxSourceUrl.Location = new System.Drawing.Point(108, 58);
            this.textBoxSourceUrl.Name = "textBoxSourceUrl";
            this.textBoxSourceUrl.Size = new System.Drawing.Size(237, 20);
            this.textBoxSourceUrl.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxSourceUrl, "Enter the URL of the mod\'s source code.");
            // 
            // textBoxModDll
            // 
            this.textBoxModDll.Location = new System.Drawing.Point(90, 139);
            this.textBoxModDll.Name = "textBoxModDll";
            this.textBoxModDll.Size = new System.Drawing.Size(185, 20);
            this.textBoxModDll.TabIndex = 6;
            this.toolTip1.SetToolTip(this.textBoxModDll, "Enter the name of the DLL file (with extension) loaded by the mod (optional).");
            // 
            // labelModDll
            // 
            this.labelModDll.AutoSize = true;
            this.labelModDll.Location = new System.Drawing.Point(35, 142);
            this.labelModDll.Name = "labelModDll";
            this.labelModDll.Size = new System.Drawing.Size(49, 13);
            this.labelModDll.TabIndex = 30;
            this.labelModDll.Text = "DLL File:";
            // 
            // labelCustomExe
            // 
            this.labelCustomExe.AutoSize = true;
            this.labelCustomExe.Location = new System.Drawing.Point(14, 88);
            this.labelCustomExe.Name = "labelCustomExe";
            this.labelCustomExe.Size = new System.Drawing.Size(88, 13);
            this.labelCustomExe.TabIndex = 33;
            this.labelCustomExe.Text = "Custom EXE File:";
            // 
            // textBoxModExeFile
            // 
            this.textBoxModExeFile.Location = new System.Drawing.Point(108, 85);
            this.textBoxModExeFile.Name = "textBoxModExeFile";
            this.textBoxModExeFile.Size = new System.Drawing.Size(237, 20);
            this.textBoxModExeFile.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxModExeFile, "Enter the name of a custom sonic.exe included with the mod. This option is meant " +
        "for legacy mods and is not recommended for regular use.");
            // 
            // listViewModDependencies
            // 
            this.listViewModDependencies.CheckBoxes = true;
            this.listViewModDependencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDepId,
            this.columnHeaderDepName,
            this.columnHeaderDepFolder,
            this.columnHeaderDepLink});
            this.listViewModDependencies.FullRowSelect = true;
            this.listViewModDependencies.HideSelection = false;
            this.listViewModDependencies.Location = new System.Drawing.Point(6, 19);
            this.listViewModDependencies.Name = "listViewModDependencies";
            this.listViewModDependencies.ShowGroups = false;
            this.listViewModDependencies.Size = new System.Drawing.Size(325, 124);
            this.listViewModDependencies.TabIndex = 0;
            this.listViewModDependencies.UseCompatibleStateImageBehavior = false;
            this.listViewModDependencies.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(256, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // columnHeaderDepName
            // 
            this.columnHeaderDepName.Text = "Name";
            // 
            // columnHeaderDepId
            // 
            this.columnHeaderDepId.Text = "Mod ID";
            // 
            // columnHeaderDepLink
            // 
            this.columnHeaderDepLink.Text = "URL";
            // 
            // columnHeaderDepFolder
            // 
            this.columnHeaderDepFolder.Text = "Folder";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewModDependencies);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(8, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 178);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dependencies";
            this.groupBox1.Visible = false;
            // 
            // numericUpDownGameBananaID
            // 
            this.numericUpDownGameBananaID.Location = new System.Drawing.Point(103, 44);
            this.numericUpDownGameBananaID.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericUpDownGameBananaID.Name = "numericUpDownGameBananaID";
            this.numericUpDownGameBananaID.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownGameBananaID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.numericUpDownGameBananaID, "Enter the numeric ID of the GameBanana upload.");
            // 
            // NewModDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 422);
            this.Controls.Add(this.tabControlNewModProperties);
            this.Controls.Add(this.checkBoxOpenModFolder);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewModDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Mod";
            this.tabControlNewModProperties.ResumeLayout(false);
            this.tabPageNewModProperties.ResumeLayout(false);
            this.tabPageNewModProperties.PerformLayout();
            this.tabPageNewModUpdates.ResumeLayout(false);
            this.tabPageNewModUpdates.PerformLayout();
            this.groupBoxSelfHosted.ResumeLayout(false);
            this.groupBoxSelfHosted.PerformLayout();
            this.groupBoxGitHub.ResumeLayout(false);
            this.groupBoxGitHub.PerformLayout();
            this.groupBoxGameBanana.ResumeLayout(false);
            this.groupBoxGameBanana.PerformLayout();
            this.tabPageNewModAdvanced.ResumeLayout(false);
            this.tabPageNewModAdvanced.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGameBananaID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelModName;
		private System.Windows.Forms.Label labelModDescription;
		private System.Windows.Forms.Label labelModAuthor;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxModName;
		private System.Windows.Forms.TextBox textBoxModAuthor;
		private System.Windows.Forms.CheckBox checkBoxOpenModFolder;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox textBoxModDescription;
        private System.Windows.Forms.TextBox textBoxModVersion;
        private System.Windows.Forms.Label label4ModVersion;
		private System.Windows.Forms.TabControl tabControlNewModProperties;
		private System.Windows.Forms.TabPage tabPageNewModProperties;
		private System.Windows.Forms.TabPage tabPageNewModUpdates;
		private System.Windows.Forms.GroupBox groupBoxSelfHosted;
		private System.Windows.Forms.Label labelModSelfHostUrl;
		private System.Windows.Forms.TextBox textBoxSelfHostUrl;
		private System.Windows.Forms.GroupBox groupBoxGitHub;
		private System.Windows.Forms.Label labelModGitAsset;
		private System.Windows.Forms.Label labelModRepo;
		private System.Windows.Forms.TextBox textBoxGitHubAttachment;
		private System.Windows.Forms.TextBox textBoxGitHubRepo;
		private System.Windows.Forms.Label labelModCategory;
		private System.Windows.Forms.ComboBox comboBoxModCategory;
		private System.Windows.Forms.GroupBox groupBoxGameBanana;
		private System.Windows.Forms.ComboBox comboBoxGameBananaType;
		private System.Windows.Forms.Label labelModGameBananaId;
		private System.Windows.Forms.Label labelModGameBananaType;
		private System.Windows.Forms.TabPage tabPageNewModAdvanced;
		private System.Windows.Forms.RadioButton radioButtonModUpdatesNone;
		private System.Windows.Forms.Label labelModUpdateHost;
		private System.Windows.Forms.RadioButton radioButtonModUpdatesGameBanana;
		private System.Windows.Forms.RadioButton radioButtonModUpdatesSelf;
		private System.Windows.Forms.RadioButton radioButtonModUpdatesGitHub;
		private System.Windows.Forms.Label labelSaveRedirect;
		private System.Windows.Forms.CheckBox checkBoxRedirectChaoSave;
		private System.Windows.Forms.CheckBox checkBoxRedirectMainSave;
		private System.Windows.Forms.Label labelSourceUrl;
		private System.Windows.Forms.Label labelHomepageUrl;
		private System.Windows.Forms.Label labelIncludeFolders;
		private System.Windows.Forms.Button buttonGenerateModId;
		private System.Windows.Forms.Label labelModId;
		private System.Windows.Forms.TextBox textBoxModID;
		private System.Windows.Forms.TextBox textBoxSelfHostChangelogUrl;
		private System.Windows.Forms.Label labelModSelfHostChangelog;
		private System.Windows.Forms.TextBox textBoxModDll;
		private System.Windows.Forms.Label labelModDll;
		private System.Windows.Forms.TextBox textBoxSourceUrl;
		private System.Windows.Forms.TextBox textBoxHomepageUrl;
		private System.Windows.Forms.TextBox textBoxIncludeFolders;
		private System.Windows.Forms.TextBox textBoxModExeFile;
		private System.Windows.Forms.Label labelCustomExe;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listViewModDependencies;
		private System.Windows.Forms.ColumnHeader columnHeaderDepName;
		private System.Windows.Forms.ColumnHeader columnHeaderDepId;
		private System.Windows.Forms.ColumnHeader columnHeaderDepLink;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ColumnHeader columnHeaderDepFolder;
		private System.Windows.Forms.NumericUpDown numericUpDownGameBananaID;
	}
}