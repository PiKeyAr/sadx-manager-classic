namespace SADXModManager.Forms
{
	partial class SaveProfileDialog
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
            this.buttonSaveProfile = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.labelTypeName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSaveProfile
            // 
            this.buttonSaveProfile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSaveProfile.Enabled = false;
            this.buttonSaveProfile.Location = new System.Drawing.Point(12, 51);
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveProfile.TabIndex = 1;
            this.buttonSaveProfile.Text = "Save";
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(117, 51);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Location = new System.Drawing.Point(12, 25);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(180, 20);
            this.textBoxProfileName.TabIndex = 0;
            this.textBoxProfileName.TextChanged += new System.EventHandler(this.textBoxProfileName_TextChanged);
            this.textBoxProfileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProfileName_KeyDown);
            // 
            // labelTypeName
            // 
            this.labelTypeName.AutoSize = true;
            this.labelTypeName.Location = new System.Drawing.Point(12, 9);
            this.labelTypeName.Name = "labelTypeName";
            this.labelTypeName.Size = new System.Drawing.Size(180, 13);
            this.labelTypeName.TabIndex = 3;
            this.labelTypeName.Text = "Type the name of the profile to save:";
            // 
            // SaveProfileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(204, 83);
            this.Controls.Add(this.labelTypeName);
            this.Controls.Add(this.textBoxProfileName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveProfileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Profile";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaveProfileDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSaveProfile;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxProfileName;
		private System.Windows.Forms.Label labelTypeName;
	}
}