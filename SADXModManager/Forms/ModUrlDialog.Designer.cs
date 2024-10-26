namespace SADXModManager.Forms
{
	partial class ModUrlDialog
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
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.textBoxPasteUrls = new System.Windows.Forms.TextBox();
            this.labelPasteUrls = new System.Windows.Forms.Label();
            this.buttonParse = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelParseStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPasteUrls
            // 
            this.textBoxPasteUrls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPasteUrls.Location = new System.Drawing.Point(12, 77);
            this.textBoxPasteUrls.Multiline = true;
            this.textBoxPasteUrls.Name = "textBoxPasteUrls";
            this.textBoxPasteUrls.Size = new System.Drawing.Size(352, 238);
            this.textBoxPasteUrls.TabIndex = 0;
            this.textBoxPasteUrls.TextChanged += new System.EventHandler(this.textBoxPasteUrls_TextChanged);
            // 
            // labelPasteUrls
            // 
            this.labelPasteUrls.AutoSize = true;
            this.labelPasteUrls.Location = new System.Drawing.Point(12, 9);
            this.labelPasteUrls.Name = "labelPasteUrls";
            this.labelPasteUrls.Size = new System.Drawing.Size(261, 65);
            this.labelPasteUrls.TabIndex = 1;
            this.labelPasteUrls.Text = "Paste the URLs in the text box below and click Parse.\r\nSuitable URLS:\r\n- Links to" +
    " mod GitHub repos\r\n- Links to mods on GameBanana\r\n- 1-click install links that b" +
    "egin with \"sadxmm\"";
            // 
            // buttonParse
            // 
            this.buttonParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParse.Location = new System.Drawing.Point(289, 324);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(75, 23);
            this.buttonParse.TabIndex = 2;
            this.buttonParse.Text = "Parse...";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
			this.buttonParse.Enabled = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(208, 324);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelParseStatus
            // 
            this.labelParseStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelParseStatus.AutoSize = true;
            this.labelParseStatus.Location = new System.Drawing.Point(12, 329);
            this.labelParseStatus.Name = "labelParseStatus";
            this.labelParseStatus.Size = new System.Drawing.Size(93, 13);
            this.labelParseStatus.TabIndex = 4;
            this.labelParseStatus.Text = "No links detected.";
            // 
            // ModUrlDialog
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 359);
            this.Controls.Add(this.labelParseStatus);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.labelPasteUrls);
            this.Controls.Add(this.textBoxPasteUrls);
			this.MinimizeBox = false;
			this.ShowIcon = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ModUrlDialog";
            this.Text = "Add Mods from URLs";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxPasteUrls;
		private System.Windows.Forms.Label labelPasteUrls;
		private System.Windows.Forms.Button buttonParse;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelParseStatus;
	}
}