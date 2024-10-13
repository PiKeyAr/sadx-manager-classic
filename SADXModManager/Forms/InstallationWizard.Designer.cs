namespace SADXModManager.Forms
{
	partial class InstallationWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallationWizard));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelGameFolder = new System.Windows.Forms.Label();
            this.textBoxGameFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelManagerData = new System.Windows.Forms.Label();
            this.radioButtonAppData = new System.Windows.Forms.RadioButton();
            this.radioButtonGameFolder = new System.Windows.Forms.RadioButton();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBoxManagerIcon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxDirectX = new System.Windows.Forms.CheckBox();
            this.checkBoxVCC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManagerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Location = new System.Drawing.Point(50, 19);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(434, 13);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to the SADX Mod Manager! Let\'s get started by locating your SADX game fol" +
    "der.";
            // 
            // labelGameFolder
            // 
            this.labelGameFolder.AutoSize = true;
            this.labelGameFolder.Location = new System.Drawing.Point(21, 50);
            this.labelGameFolder.Name = "labelGameFolder";
            this.labelGameFolder.Size = new System.Drawing.Size(70, 13);
            this.labelGameFolder.TabIndex = 1;
            this.labelGameFolder.Text = "Game Folder:";
            // 
            // textBoxGameFolder
            // 
            this.textBoxGameFolder.Location = new System.Drawing.Point(97, 47);
            this.textBoxGameFolder.Name = "textBoxGameFolder";
            this.textBoxGameFolder.Size = new System.Drawing.Size(311, 20);
            this.textBoxGameFolder.TabIndex = 0;
            this.textBoxGameFolder.TextChanged += new System.EventHandler(this.textBoxGameFolder_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(414, 45);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelManagerData
            // 
            this.labelManagerData.AutoSize = true;
            this.labelManagerData.Location = new System.Drawing.Point(13, 79);
            this.labelManagerData.Name = "labelManagerData";
            this.labelManagerData.Size = new System.Drawing.Size(78, 13);
            this.labelManagerData.TabIndex = 4;
            this.labelManagerData.Text = "Manager Data:";
            // 
            // radioButtonAppData
            // 
            this.radioButtonAppData.AutoSize = true;
            this.radioButtonAppData.Location = new System.Drawing.Point(97, 77);
            this.radioButtonAppData.Name = "radioButtonAppData";
            this.radioButtonAppData.Size = new System.Drawing.Size(135, 17);
            this.radioButtonAppData.TabIndex = 2;
            this.radioButtonAppData.Text = "Application Data Folder";
            this.toolTip1.SetToolTip(this.radioButtonAppData, "In this mode settings and mod lists will be saved in the AppData folder.\r\nThe Mod" +
        " Manager can be placed anywhere, and settings and mod lists will be global to th" +
        "is computer.");
            this.radioButtonAppData.UseVisualStyleBackColor = true;
            // 
            // radioButtonGameFolder
            // 
            this.radioButtonGameFolder.AutoSize = true;
            this.radioButtonGameFolder.Checked = true;
            this.radioButtonGameFolder.Location = new System.Drawing.Point(238, 77);
            this.radioButtonGameFolder.Name = "radioButtonGameFolder";
            this.radioButtonGameFolder.Size = new System.Drawing.Size(163, 17);
            this.radioButtonGameFolder.TabIndex = 3;
            this.radioButtonGameFolder.TabStop = true;
            this.radioButtonGameFolder.Text = "Game Folder (Portable Mode)";
            this.toolTip1.SetToolTip(this.radioButtonGameFolder, resources.GetString("radioButtonGameFolder.ToolTip"));
            this.radioButtonGameFolder.UseVisualStyleBackColor = true;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(333, 97);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 4;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(414, 97);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // pictureBoxManagerIcon
            // 
            this.pictureBoxManagerIcon.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxManagerIcon.Name = "pictureBoxManagerIcon";
            this.pictureBoxManagerIcon.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxManagerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxManagerIcon.TabIndex = 9;
            this.pictureBoxManagerIcon.TabStop = false;
            this.pictureBoxManagerIcon.Click += new System.EventHandler(this.pictureBoxManagerIcon_Click);
            // 
            // checkBoxDirectX
            // 
            this.checkBoxDirectX.AutoSize = true;
            this.checkBoxDirectX.Checked = true;
            this.checkBoxDirectX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDirectX.Location = new System.Drawing.Point(16, 103);
            this.checkBoxDirectX.Name = "checkBoxDirectX";
            this.checkBoxDirectX.Size = new System.Drawing.Size(115, 17);
            this.checkBoxDirectX.TabIndex = 10;
            this.checkBoxDirectX.Text = "Install DirectX 9.0c";
            this.checkBoxDirectX.UseVisualStyleBackColor = true;
            // 
            // checkBoxVCC
            // 
            this.checkBoxVCC.AutoSize = true;
            this.checkBoxVCC.Checked = true;
            this.checkBoxVCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVCC.Location = new System.Drawing.Point(137, 103);
            this.checkBoxVCC.Name = "checkBoxVCC";
            this.checkBoxVCC.Size = new System.Drawing.Size(156, 17);
            this.checkBoxVCC.TabIndex = 11;
            this.checkBoxVCC.Text = "Update Visual C++ runtimes";
            this.checkBoxVCC.UseVisualStyleBackColor = true;
            // 
            // InstallationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 132);
            this.Controls.Add(this.checkBoxVCC);
            this.Controls.Add(this.checkBoxDirectX);
            this.Controls.Add(this.pictureBoxManagerIcon);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.radioButtonGameFolder);
            this.Controls.Add(this.radioButtonAppData);
            this.Controls.Add(this.labelManagerData);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxGameFolder);
            this.Controls.Add(this.labelGameFolder);
            this.Controls.Add(this.labelWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallationWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome Screen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManagerIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelWelcome;
		private System.Windows.Forms.Label labelGameFolder;
		private System.Windows.Forms.TextBox textBoxGameFolder;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Label labelManagerData;
		private System.Windows.Forms.RadioButton radioButtonAppData;
		private System.Windows.Forms.RadioButton radioButtonGameFolder;
		private System.Windows.Forms.Button buttonInstall;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.PictureBox pictureBoxManagerIcon;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox checkBoxDirectX;
		private System.Windows.Forms.CheckBox checkBoxVCC;
	}
}