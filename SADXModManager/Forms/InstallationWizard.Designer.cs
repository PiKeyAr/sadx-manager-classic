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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelGameFolder = new System.Windows.Forms.Label();
            this.textBoxGameFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
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
            this.textBoxGameFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxGameFolder_KeyDown);
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
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Enabled = false;
            this.buttonInstall.Location = new System.Drawing.Point(333, 76);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 6;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(414, 76);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 7;
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
            this.checkBoxDirectX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDirectX.AutoSize = true;
            this.checkBoxDirectX.Checked = true;
            this.checkBoxDirectX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDirectX.Location = new System.Drawing.Point(12, 82);
            this.checkBoxDirectX.Name = "checkBoxDirectX";
            this.checkBoxDirectX.Size = new System.Drawing.Size(115, 17);
            this.checkBoxDirectX.TabIndex = 4;
            this.checkBoxDirectX.Text = "Install DirectX 9.0c";
            this.toolTip1.SetToolTip(this.checkBoxDirectX, "Install DirectX 9.0c which is required for some mods.");
            this.checkBoxDirectX.UseVisualStyleBackColor = true;
            // 
            // checkBoxVCC
            // 
            this.checkBoxVCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxVCC.AutoSize = true;
            this.checkBoxVCC.Checked = true;
            this.checkBoxVCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVCC.Location = new System.Drawing.Point(133, 82);
            this.checkBoxVCC.Name = "checkBoxVCC";
            this.checkBoxVCC.Size = new System.Drawing.Size(156, 17);
            this.checkBoxVCC.TabIndex = 5;
            this.checkBoxVCC.Text = "Update Visual C++ runtimes";
            this.toolTip1.SetToolTip(this.checkBoxVCC, "Update Visual C++ runtimes which are required by most mods.");
            this.checkBoxVCC.UseVisualStyleBackColor = true;
            // 
            // InstallationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 111);
            this.Controls.Add(this.checkBoxVCC);
            this.Controls.Add(this.checkBoxDirectX);
            this.Controls.Add(this.pictureBoxManagerIcon);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonInstall);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InstallationWizard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxManagerIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelWelcome;
		private System.Windows.Forms.Label labelGameFolder;
		private System.Windows.Forms.TextBox textBoxGameFolder;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonInstall;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.PictureBox pictureBoxManagerIcon;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox checkBoxDirectX;
		private System.Windows.Forms.CheckBox checkBoxVCC;
	}
}