namespace SADXModManager.Forms
{
	partial class UpdatesAvailableDialog
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
            this.progressBarItem = new System.Windows.Forms.ProgressBar();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.labelUpdatesAvailable = new System.Windows.Forms.Label();
            this.labelItemProgress = new System.Windows.Forms.Label();
            this.labelTotalProgress = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdateSelected = new System.Windows.Forms.Button();
            this.listViewUpdates = new System.Windows.Forms.ListView();
            this.columnHeaderUpdateName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUpdateSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlUpdateDetails = new System.Windows.Forms.TabControl();
            this.tabPageUpdateDetails = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDownload = new System.Windows.Forms.TableLayoutPanel();
            this.labelDownloadLink = new System.Windows.Forms.LinkLabel();
            this.labelD8Homepage = new System.Windows.Forms.Label();
            this.labelUpdateVersion = new System.Windows.Forms.Label();
            this.labelUpdateAuthor = new System.Windows.Forms.Label();
            this.labelD7FileCount = new System.Windows.Forms.Label();
            this.labelDownloadFileCount = new System.Windows.Forms.Label();
            this.labelD6DownloadSize = new System.Windows.Forms.Label();
            this.labelDownloadSize = new System.Windows.Forms.Label();
            this.labelD5UploadDate = new System.Windows.Forms.Label();
            this.labelUploadDate = new System.Windows.Forms.Label();
            this.labelD2Author = new System.Windows.Forms.Label();
            this.labelD3Version = new System.Windows.Forms.Label();
            this.labelUpdateName = new System.Windows.Forms.Label();
            this.labelD4ReleaseDate = new System.Windows.Forms.Label();
            this.labelReleaseDate = new System.Windows.Forms.Label();
            this.labelD1Name = new System.Windows.Forms.Label();
            this.labelHomepage = new System.Windows.Forms.LinkLabel();
            this.labelD10ReleaseTag = new System.Windows.Forms.Label();
            this.labelD9ReleaseName = new System.Windows.Forms.Label();
            this.labelReleaseTag = new System.Windows.Forms.Label();
            this.labelD9DownloadLink = new System.Windows.Forms.Label();
            this.labelReleaseName = new System.Windows.Forms.Label();
            this.tabPageUpdateInformation = new System.Windows.Forms.TabPage();
            this.textBoxChangelog = new System.Windows.Forms.RichTextBox();
            this.tabPageUpdateFiles = new System.Windows.Forms.TabPage();
            this.listViewUpdateFiles = new System.Windows.Forms.ListView();
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxUpdateDescription = new System.Windows.Forms.TextBox();
            this.tabControlUpdateDetails.SuspendLayout();
            this.tabPageUpdateDetails.SuspendLayout();
            this.tableLayoutPanelDownload.SuspendLayout();
            this.tabPageUpdateInformation.SuspendLayout();
            this.tabPageUpdateFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarItem
            // 
            this.progressBarItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarItem.Location = new System.Drawing.Point(12, 372);
            this.progressBarItem.Name = "progressBarItem";
            this.progressBarItem.Size = new System.Drawing.Size(638, 23);
            this.progressBarItem.TabIndex = 0;
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTotal.Location = new System.Drawing.Point(12, 414);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(638, 23);
            this.progressBarTotal.TabIndex = 1;
            // 
            // labelUpdatesAvailable
            // 
            this.labelUpdatesAvailable.AutoSize = true;
            this.labelUpdatesAvailable.Location = new System.Drawing.Point(9, 13);
            this.labelUpdatesAvailable.Name = "labelUpdatesAvailable";
            this.labelUpdatesAvailable.Size = new System.Drawing.Size(163, 13);
            this.labelUpdatesAvailable.TabIndex = 2;
            this.labelUpdatesAvailable.Text = "The following items are available:";
            // 
            // labelItemProgress
            // 
            this.labelItemProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelItemProgress.AutoSize = true;
            this.labelItemProgress.Location = new System.Drawing.Point(9, 356);
            this.labelItemProgress.Name = "labelItemProgress";
            this.labelItemProgress.Size = new System.Drawing.Size(176, 13);
            this.labelItemProgress.TabIndex = 4;
            this.labelItemProgress.Text = "Item progress will be displayed here.";
            // 
            // labelTotalProgress
            // 
            this.labelTotalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalProgress.AutoSize = true;
            this.labelTotalProgress.Location = new System.Drawing.Point(9, 398);
            this.labelTotalProgress.Name = "labelTotalProgress";
            this.labelTotalProgress.Size = new System.Drawing.Size(180, 13);
            this.labelTotalProgress.TabIndex = 5;
            this.labelTotalProgress.Text = "Total progress will be displayed here.";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(575, 446);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdateSelected
            // 
            this.buttonUpdateSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateSelected.Location = new System.Drawing.Point(465, 446);
            this.buttonUpdateSelected.Name = "buttonUpdateSelected";
            this.buttonUpdateSelected.Size = new System.Drawing.Size(104, 23);
            this.buttonUpdateSelected.TabIndex = 8;
            this.buttonUpdateSelected.Text = "Install Selected";
            this.buttonUpdateSelected.UseVisualStyleBackColor = true;
            this.buttonUpdateSelected.Click += new System.EventHandler(this.buttonUpdateSelected_Click);
            // 
            // listViewUpdates
            // 
            this.listViewUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewUpdates.CheckBoxes = true;
            this.listViewUpdates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUpdateName,
            this.columnHeaderUpdateSize});
            this.listViewUpdates.FullRowSelect = true;
            this.listViewUpdates.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUpdates.HideSelection = false;
            this.listViewUpdates.LabelWrap = false;
            this.listViewUpdates.Location = new System.Drawing.Point(12, 29);
            this.listViewUpdates.MultiSelect = false;
            this.listViewUpdates.Name = "listViewUpdates";
            this.listViewUpdates.ShowGroups = false;
            this.listViewUpdates.Size = new System.Drawing.Size(259, 324);
            this.listViewUpdates.TabIndex = 10;
            this.listViewUpdates.UseCompatibleStateImageBehavior = false;
            this.listViewUpdates.View = System.Windows.Forms.View.Details;
            this.listViewUpdates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewUpdates_ItemCheck);
            this.listViewUpdates.SelectedIndexChanged += new System.EventHandler(this.listViewUpdates_SelectedIndexChanged);
            // 
            // columnHeaderUpdateName
            // 
            this.columnHeaderUpdateName.Text = "Name";
            this.columnHeaderUpdateName.Width = 98;
            // 
            // columnHeaderUpdateSize
            // 
            this.columnHeaderUpdateSize.Text = "Size";
            // 
            // tabControlUpdateDetails
            // 
            this.tabControlUpdateDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlUpdateDetails.Controls.Add(this.tabPageUpdateDetails);
            this.tabControlUpdateDetails.Controls.Add(this.tabPageUpdateInformation);
            this.tabControlUpdateDetails.Controls.Add(this.tabPageUpdateFiles);
            this.tabControlUpdateDetails.Location = new System.Drawing.Point(277, 29);
            this.tabControlUpdateDetails.Name = "tabControlUpdateDetails";
            this.tabControlUpdateDetails.SelectedIndex = 0;
            this.tabControlUpdateDetails.Size = new System.Drawing.Size(378, 324);
            this.tabControlUpdateDetails.TabIndex = 11;
            // 
            // tabPageUpdateDetails
            // 
            this.tabPageUpdateDetails.Controls.Add(this.tableLayoutPanelDownload);
            this.tabPageUpdateDetails.Controls.Add(this.textBoxUpdateDescription);
            this.tabPageUpdateDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateDetails.Name = "tabPageUpdateDetails";
            this.tabPageUpdateDetails.Size = new System.Drawing.Size(370, 298);
            this.tabPageUpdateDetails.TabIndex = 2;
            this.tabPageUpdateDetails.Text = "Details";
            this.tabPageUpdateDetails.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDownload
            // 
            this.tableLayoutPanelDownload.AutoSize = true;
            this.tableLayoutPanelDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanelDownload.ColumnCount = 2;
            this.tableLayoutPanelDownload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDownload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadLink, 1, 8);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD8Homepage, 0, 7);
            this.tableLayoutPanelDownload.Controls.Add(this.labelUpdateVersion, 1, 2);
            this.tableLayoutPanelDownload.Controls.Add(this.labelUpdateAuthor, 1, 1);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD7FileCount, 0, 6);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadFileCount, 1, 6);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD6DownloadSize, 0, 5);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadSize, 1, 5);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD5UploadDate, 0, 4);
            this.tableLayoutPanelDownload.Controls.Add(this.labelUploadDate, 1, 4);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD2Author, 0, 1);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD3Version, 0, 2);
            this.tableLayoutPanelDownload.Controls.Add(this.labelUpdateName, 1, 0);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD4ReleaseDate, 0, 3);
            this.tableLayoutPanelDownload.Controls.Add(this.labelReleaseDate, 1, 3);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD1Name, 0, 0);
            this.tableLayoutPanelDownload.Controls.Add(this.labelHomepage, 1, 7);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD10ReleaseTag, 0, 10);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD9ReleaseName, 0, 9);
            this.tableLayoutPanelDownload.Controls.Add(this.labelReleaseTag, 1, 10);
            this.tableLayoutPanelDownload.Controls.Add(this.labelD9DownloadLink, 0, 8);
            this.tableLayoutPanelDownload.Controls.Add(this.labelReleaseName, 1, 9);
            this.tableLayoutPanelDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDownload.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDownload.Name = "tableLayoutPanelDownload";
            this.tableLayoutPanelDownload.RowCount = 11;
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDownload.Size = new System.Drawing.Size(370, 213);
            this.tableLayoutPanelDownload.TabIndex = 3;
            // 
            // labelDownloadLink
            // 
            this.labelDownloadLink.AutoSize = true;
            this.labelDownloadLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDownloadLink.Location = new System.Drawing.Point(87, 138);
            this.labelDownloadLink.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelDownloadLink.Name = "labelDownloadLink";
            this.labelDownloadLink.Size = new System.Drawing.Size(283, 13);
            this.labelDownloadLink.TabIndex = 18;
            this.labelDownloadLink.TabStop = true;
            this.labelDownloadLink.Text = "linkRelease";
            this.labelDownloadLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelDownloadLink_LinkClicked);
            // 
            // labelD8Homepage
            // 
            this.labelD8Homepage.AutoSize = true;
            this.labelD8Homepage.Location = new System.Drawing.Point(3, 119);
            this.labelD8Homepage.Name = "labelD8Homepage";
            this.labelD8Homepage.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD8Homepage.Size = new System.Drawing.Size(62, 17);
            this.labelD8Homepage.TabIndex = 17;
            this.labelD8Homepage.Text = "Homepage:";
            // 
            // labelUpdateVersion
            // 
            this.labelUpdateVersion.AutoSize = true;
            this.labelUpdateVersion.Location = new System.Drawing.Point(87, 36);
            this.labelUpdateVersion.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelUpdateVersion.Name = "labelUpdateVersion";
            this.labelUpdateVersion.Size = new System.Drawing.Size(99, 13);
            this.labelUpdateVersion.TabIndex = 14;
            this.labelUpdateVersion.Text = "labelUpdateVersion";
            // 
            // labelUpdateAuthor
            // 
            this.labelUpdateAuthor.AutoSize = true;
            this.labelUpdateAuthor.Location = new System.Drawing.Point(87, 19);
            this.labelUpdateAuthor.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelUpdateAuthor.Name = "labelUpdateAuthor";
            this.labelUpdateAuthor.Size = new System.Drawing.Size(95, 13);
            this.labelUpdateAuthor.TabIndex = 13;
            this.labelUpdateAuthor.Text = "labelUpdateAuthor";
            // 
            // labelD7FileCount
            // 
            this.labelD7FileCount.AutoSize = true;
            this.labelD7FileCount.Location = new System.Drawing.Point(3, 102);
            this.labelD7FileCount.Name = "labelD7FileCount";
            this.labelD7FileCount.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD7FileCount.Size = new System.Drawing.Size(57, 17);
            this.labelD7FileCount.TabIndex = 2;
            this.labelD7FileCount.Text = "File Count:";
            // 
            // labelDownloadFileCount
            // 
            this.labelDownloadFileCount.AutoSize = true;
            this.labelDownloadFileCount.Location = new System.Drawing.Point(87, 104);
            this.labelDownloadFileCount.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelDownloadFileCount.Name = "labelDownloadFileCount";
            this.labelDownloadFileCount.Size = new System.Drawing.Size(73, 13);
            this.labelDownloadFileCount.TabIndex = 5;
            this.labelDownloadFileCount.Text = "labelFileCount";
            // 
            // labelD6DownloadSize
            // 
            this.labelD6DownloadSize.AutoSize = true;
            this.labelD6DownloadSize.Location = new System.Drawing.Point(3, 85);
            this.labelD6DownloadSize.Name = "labelD6DownloadSize";
            this.labelD6DownloadSize.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD6DownloadSize.Size = new System.Drawing.Size(81, 17);
            this.labelD6DownloadSize.TabIndex = 1;
            this.labelD6DownloadSize.Text = "Download Size:";
            // 
            // labelDownloadSize
            // 
            this.labelDownloadSize.AutoSize = true;
            this.labelDownloadSize.Location = new System.Drawing.Point(87, 87);
            this.labelDownloadSize.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelDownloadSize.Name = "labelDownloadSize";
            this.labelDownloadSize.Size = new System.Drawing.Size(49, 13);
            this.labelDownloadSize.TabIndex = 4;
            this.labelDownloadSize.Text = "labelSize";
            // 
            // labelD5UploadDate
            // 
            this.labelD5UploadDate.AutoSize = true;
            this.labelD5UploadDate.Location = new System.Drawing.Point(3, 68);
            this.labelD5UploadDate.Name = "labelD5UploadDate";
            this.labelD5UploadDate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD5UploadDate.Size = new System.Drawing.Size(70, 17);
            this.labelD5UploadDate.TabIndex = 0;
            this.labelD5UploadDate.Text = "Upload Date:";
            // 
            // labelUploadDate
            // 
            this.labelUploadDate.AutoSize = true;
            this.labelUploadDate.Location = new System.Drawing.Point(87, 70);
            this.labelUploadDate.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelUploadDate.Name = "labelUploadDate";
            this.labelUploadDate.Size = new System.Drawing.Size(123, 13);
            this.labelUploadDate.TabIndex = 3;
            this.labelUploadDate.Text = "labelDownloadPublished";
            // 
            // labelD2Author
            // 
            this.labelD2Author.AutoSize = true;
            this.labelD2Author.Location = new System.Drawing.Point(3, 17);
            this.labelD2Author.Name = "labelD2Author";
            this.labelD2Author.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD2Author.Size = new System.Drawing.Size(46, 17);
            this.labelD2Author.TabIndex = 10;
            this.labelD2Author.Text = "Authors:";
            // 
            // labelD3Version
            // 
            this.labelD3Version.AutoSize = true;
            this.labelD3Version.Location = new System.Drawing.Point(3, 34);
            this.labelD3Version.Name = "labelD3Version";
            this.labelD3Version.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD3Version.Size = new System.Drawing.Size(45, 17);
            this.labelD3Version.TabIndex = 11;
            this.labelD3Version.Text = "Version:";
            // 
            // labelUpdateName
            // 
            this.labelUpdateName.AutoSize = true;
            this.labelUpdateName.Location = new System.Drawing.Point(87, 2);
            this.labelUpdateName.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelUpdateName.Name = "labelUpdateName";
            this.labelUpdateName.Size = new System.Drawing.Size(92, 13);
            this.labelUpdateName.TabIndex = 12;
            this.labelUpdateName.Text = "labelUpdateName";
            // 
            // labelD4ReleaseDate
            // 
            this.labelD4ReleaseDate.AutoSize = true;
            this.labelD4ReleaseDate.Location = new System.Drawing.Point(3, 51);
            this.labelD4ReleaseDate.Name = "labelD4ReleaseDate";
            this.labelD4ReleaseDate.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD4ReleaseDate.Size = new System.Drawing.Size(75, 17);
            this.labelD4ReleaseDate.TabIndex = 7;
            this.labelD4ReleaseDate.Text = "Release Date:";
            // 
            // labelReleaseDate
            // 
            this.labelReleaseDate.AutoSize = true;
            this.labelReleaseDate.Location = new System.Drawing.Point(87, 53);
            this.labelReleaseDate.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelReleaseDate.Name = "labelReleaseDate";
            this.labelReleaseDate.Size = new System.Drawing.Size(114, 13);
            this.labelReleaseDate.TabIndex = 8;
            this.labelReleaseDate.Text = "labelReleasePublished";
            // 
            // labelD1Name
            // 
            this.labelD1Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelD1Name.AutoSize = true;
            this.labelD1Name.Location = new System.Drawing.Point(3, 0);
            this.labelD1Name.Name = "labelD1Name";
            this.labelD1Name.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD1Name.Size = new System.Drawing.Size(81, 17);
            this.labelD1Name.TabIndex = 9;
            this.labelD1Name.Text = "Name:";
            // 
            // labelHomepage
            // 
            this.labelHomepage.AutoSize = true;
            this.labelHomepage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHomepage.Location = new System.Drawing.Point(87, 121);
            this.labelHomepage.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelHomepage.Name = "labelHomepage";
            this.labelHomepage.Size = new System.Drawing.Size(283, 13);
            this.labelHomepage.TabIndex = 6;
            this.labelHomepage.TabStop = true;
            this.labelHomepage.Text = "linkHomepage";
            this.labelHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelReleasePageValue_LinkClicked);
            // 
            // labelD10ReleaseTag
            // 
            this.labelD10ReleaseTag.AutoSize = true;
            this.labelD10ReleaseTag.Location = new System.Drawing.Point(3, 170);
            this.labelD10ReleaseTag.Name = "labelD10ReleaseTag";
            this.labelD10ReleaseTag.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD10ReleaseTag.Size = new System.Drawing.Size(71, 17);
            this.labelD10ReleaseTag.TabIndex = 1;
            this.labelD10ReleaseTag.Text = "Release Tag:";
            // 
            // labelD9ReleaseName
            // 
            this.labelD9ReleaseName.AutoSize = true;
            this.labelD9ReleaseName.Location = new System.Drawing.Point(3, 153);
            this.labelD9ReleaseName.Name = "labelD9ReleaseName";
            this.labelD9ReleaseName.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD9ReleaseName.Size = new System.Drawing.Size(80, 17);
            this.labelD9ReleaseName.TabIndex = 0;
            this.labelD9ReleaseName.Text = "Release Name:";
            // 
            // labelReleaseTag
            // 
            this.labelReleaseTag.AutoSize = true;
            this.labelReleaseTag.Location = new System.Drawing.Point(87, 172);
            this.labelReleaseTag.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelReleaseTag.Name = "labelReleaseTag";
            this.labelReleaseTag.Size = new System.Drawing.Size(87, 13);
            this.labelReleaseTag.TabIndex = 4;
            this.labelReleaseTag.Text = "labelReleaseTag";
            // 
            // labelD9DownloadLink
            // 
            this.labelD9DownloadLink.AutoSize = true;
            this.labelD9DownloadLink.Location = new System.Drawing.Point(3, 136);
            this.labelD9DownloadLink.Name = "labelD9DownloadLink";
            this.labelD9DownloadLink.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelD9DownloadLink.Size = new System.Drawing.Size(81, 17);
            this.labelD9DownloadLink.TabIndex = 5;
            this.labelD9DownloadLink.Text = "Download Link:";
            // 
            // labelReleaseName
            // 
            this.labelReleaseName.AutoSize = true;
            this.labelReleaseName.Location = new System.Drawing.Point(87, 155);
            this.labelReleaseName.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.labelReleaseName.Name = "labelReleaseName";
            this.labelReleaseName.Size = new System.Drawing.Size(96, 13);
            this.labelReleaseName.TabIndex = 3;
            this.labelReleaseName.Text = "labelReleaseName";
            // 
            // tabPageUpdateInformation
            // 
            this.tabPageUpdateInformation.Controls.Add(this.textBoxChangelog);
            this.tabPageUpdateInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateInformation.Name = "tabPageUpdateInformation";
            this.tabPageUpdateInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdateInformation.Size = new System.Drawing.Size(370, 298);
            this.tabPageUpdateInformation.TabIndex = 0;
            this.tabPageUpdateInformation.Text = "Information";
            this.tabPageUpdateInformation.UseVisualStyleBackColor = true;
            // 
            // textBoxChangelog
            // 
            this.textBoxChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChangelog.Location = new System.Drawing.Point(3, 3);
            this.textBoxChangelog.Name = "textBoxChangelog";
            this.textBoxChangelog.ReadOnly = true;
            this.textBoxChangelog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBoxChangelog.Size = new System.Drawing.Size(364, 292);
            this.textBoxChangelog.TabIndex = 0;
            this.textBoxChangelog.Text = "";
            this.textBoxChangelog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textBoxChangelog_LinkClicked);
            // 
            // tabPageUpdateFiles
            // 
            this.tabPageUpdateFiles.Controls.Add(this.listViewUpdateFiles);
            this.tabPageUpdateFiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateFiles.Name = "tabPageUpdateFiles";
            this.tabPageUpdateFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdateFiles.Size = new System.Drawing.Size(370, 298);
            this.tabPageUpdateFiles.TabIndex = 1;
            this.tabPageUpdateFiles.Text = "Files";
            this.tabPageUpdateFiles.UseVisualStyleBackColor = true;
            // 
            // listViewUpdateFiles
            // 
            this.listViewUpdateFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnStatus,
            this.columnFile,
            this.columnFileSize});
            this.listViewUpdateFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUpdateFiles.FullRowSelect = true;
            this.listViewUpdateFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUpdateFiles.HideSelection = false;
            this.listViewUpdateFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewUpdateFiles.MultiSelect = false;
            this.listViewUpdateFiles.Name = "listViewUpdateFiles";
            this.listViewUpdateFiles.Size = new System.Drawing.Size(364, 292);
            this.listViewUpdateFiles.TabIndex = 1;
            this.listViewUpdateFiles.UseCompatibleStateImageBehavior = false;
            this.listViewUpdateFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 84;
            // 
            // columnFile
            // 
            this.columnFile.Text = "File";
            this.columnFile.Width = 134;
            // 
            // columnFileSize
            // 
            this.columnFileSize.Text = "Size";
            this.columnFileSize.Width = 116;
            // 
            // textBoxUpdateDescription
            // 
            this.textBoxUpdateDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUpdateDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxUpdateDescription.Location = new System.Drawing.Point(0, 213);
            this.textBoxUpdateDescription.Multiline = true;
            this.textBoxUpdateDescription.Name = "textBoxUpdateDescription";
            this.textBoxUpdateDescription.ReadOnly = true;
            this.textBoxUpdateDescription.Size = new System.Drawing.Size(370, 85);
            this.textBoxUpdateDescription.TabIndex = 19;
            this.textBoxUpdateDescription.Text = "Description: ";
            // 
            // UpdatesAvailableDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(662, 479);
            this.Controls.Add(this.tabControlUpdateDetails);
            this.Controls.Add(this.listViewUpdates);
            this.Controls.Add(this.buttonUpdateSelected);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTotalProgress);
            this.Controls.Add(this.labelItemProgress);
            this.Controls.Add(this.labelUpdatesAvailable);
            this.Controls.Add(this.progressBarTotal);
            this.Controls.Add(this.progressBarItem);
            this.MinimizeBox = false;
            this.Name = "UpdatesAvailableDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Updates Available";
            this.tabControlUpdateDetails.ResumeLayout(false);
            this.tabPageUpdateDetails.ResumeLayout(false);
            this.tabPageUpdateDetails.PerformLayout();
            this.tableLayoutPanelDownload.ResumeLayout(false);
            this.tableLayoutPanelDownload.PerformLayout();
            this.tabPageUpdateInformation.ResumeLayout(false);
            this.tabPageUpdateFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBarItem;
		private System.Windows.Forms.ProgressBar progressBarTotal;
		private System.Windows.Forms.Label labelUpdatesAvailable;
		private System.Windows.Forms.Label labelItemProgress;
		private System.Windows.Forms.Label labelTotalProgress;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonUpdateSelected;
		private System.Windows.Forms.ListView listViewUpdates;
		private System.Windows.Forms.ColumnHeader columnHeaderUpdateName;
		private System.Windows.Forms.ColumnHeader columnHeaderUpdateSize;
		private System.Windows.Forms.TabControl tabControlUpdateDetails;
		private System.Windows.Forms.TabPage tabPageUpdateInformation;
		private System.Windows.Forms.TabPage tabPageUpdateFiles;
		private System.Windows.Forms.TabPage tabPageUpdateDetails;
		private System.Windows.Forms.ListView listViewUpdateFiles;
		private System.Windows.Forms.ColumnHeader columnStatus;
		private System.Windows.Forms.ColumnHeader columnFile;
		private System.Windows.Forms.Label labelD4ReleaseDate;
		private System.Windows.Forms.Label labelReleaseDate;
		private System.Windows.Forms.Label labelD10ReleaseTag;
		private System.Windows.Forms.Label labelD9DownloadLink;
		private System.Windows.Forms.Label labelD9ReleaseName;
		private System.Windows.Forms.Label labelReleaseName;
		private System.Windows.Forms.LinkLabel labelHomepage;
		private System.Windows.Forms.Label labelReleaseTag;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDownload;
		private System.Windows.Forms.Label labelD5UploadDate;
		private System.Windows.Forms.Label labelD7FileCount;
		private System.Windows.Forms.Label labelD6DownloadSize;
		private System.Windows.Forms.Label labelUploadDate;
		private System.Windows.Forms.Label labelDownloadSize;
		private System.Windows.Forms.Label labelDownloadFileCount;
		private System.Windows.Forms.RichTextBox textBoxChangelog;
		private System.Windows.Forms.Label labelUpdateVersion;
		private System.Windows.Forms.Label labelUpdateAuthor;
		private System.Windows.Forms.Label labelD1Name;
		private System.Windows.Forms.Label labelD2Author;
		private System.Windows.Forms.Label labelD3Version;
		private System.Windows.Forms.Label labelUpdateName;
		private System.Windows.Forms.LinkLabel labelDownloadLink;
		private System.Windows.Forms.Label labelD8Homepage;
		private System.Windows.Forms.ColumnHeader columnFileSize;
		private System.Windows.Forms.TextBox textBoxUpdateDescription;
	}
}