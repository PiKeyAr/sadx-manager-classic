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
            this.components = new System.ComponentModel.Container();
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
            this.tabPageUpdateChanges = new System.Windows.Forms.TabPage();
            this.textBoxChangelog = new System.Windows.Forms.RichTextBox();
            this.tabPageUpdateFiles = new System.Windows.Forms.TabPage();
            this.listViewUpdateFiles = new System.Windows.Forms.ListView();
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageUpdateDetails = new System.Windows.Forms.TabPage();
            this.groupReleaseDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelRelease = new System.Windows.Forms.TableLayoutPanel();
            this.labelReleasePublishedDate = new System.Windows.Forms.Label();
            this.labelReleasePublishedValue = new System.Windows.Forms.Label();
            this.labelReleaseTag = new System.Windows.Forms.Label();
            this.labelReleasePage = new System.Windows.Forms.Label();
            this.labelReleaseName = new System.Windows.Forms.Label();
            this.labelReleaseNameValue = new System.Windows.Forms.Label();
            this.labelReleasePageValue = new System.Windows.Forms.LinkLabel();
            this.labelReleaseTagValue = new System.Windows.Forms.Label();
            this.groupBoxDownloadDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelDownload = new System.Windows.Forms.TableLayoutPanel();
            this.labelDownloadPublishDate = new System.Windows.Forms.Label();
            this.labelDownloadFiles = new System.Windows.Forms.Label();
            this.labelDownloadSize = new System.Windows.Forms.Label();
            this.labelDownloadPublishedValue = new System.Windows.Forms.Label();
            this.labelDownloadSizeValue = new System.Windows.Forms.Label();
            this.labelDownloadFileCountValue = new System.Windows.Forms.Label();
            this.tabControlUpdateDetails.SuspendLayout();
            this.tabPageUpdateChanges.SuspendLayout();
            this.tabPageUpdateFiles.SuspendLayout();
            this.tabPageUpdateDetails.SuspendLayout();
            this.groupReleaseDetails.SuspendLayout();
            this.tableLayoutPanelRelease.SuspendLayout();
            this.groupBoxDownloadDetails.SuspendLayout();
            this.tableLayoutPanelDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarItem
            // 
            this.progressBarItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarItem.Location = new System.Drawing.Point(12, 281);
            this.progressBarItem.Name = "progressBarItem";
            this.progressBarItem.Size = new System.Drawing.Size(638, 23);
            this.progressBarItem.TabIndex = 0;
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTotal.Location = new System.Drawing.Point(12, 323);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(638, 23);
            this.progressBarTotal.TabIndex = 1;
            // 
            // labelUpdatesAvailable
            // 
            this.labelUpdatesAvailable.AutoSize = true;
            this.labelUpdatesAvailable.Location = new System.Drawing.Point(9, 13);
            this.labelUpdatesAvailable.Name = "labelUpdatesAvailable";
            this.labelUpdatesAvailable.Size = new System.Drawing.Size(177, 13);
            this.labelUpdatesAvailable.TabIndex = 2;
            this.labelUpdatesAvailable.Text = "The following updates are available:";
            // 
            // labelItemProgress
            // 
            this.labelItemProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelItemProgress.AutoSize = true;
            this.labelItemProgress.Location = new System.Drawing.Point(9, 265);
            this.labelItemProgress.Name = "labelItemProgress";
            this.labelItemProgress.Size = new System.Drawing.Size(176, 13);
            this.labelItemProgress.TabIndex = 4;
            this.labelItemProgress.Text = "Item progress will be displayed here.";
            // 
            // labelTotalProgress
            // 
            this.labelTotalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTotalProgress.AutoSize = true;
            this.labelTotalProgress.Location = new System.Drawing.Point(9, 307);
            this.labelTotalProgress.Name = "labelTotalProgress";
            this.labelTotalProgress.Size = new System.Drawing.Size(180, 13);
            this.labelTotalProgress.TabIndex = 5;
            this.labelTotalProgress.Text = "Total progress will be displayed here.";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(575, 355);
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
            this.buttonUpdateSelected.Location = new System.Drawing.Point(465, 355);
            this.buttonUpdateSelected.Name = "buttonUpdateSelected";
            this.buttonUpdateSelected.Size = new System.Drawing.Size(104, 23);
            this.buttonUpdateSelected.TabIndex = 8;
            this.buttonUpdateSelected.Text = "Update Selected";
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
            this.listViewUpdates.Size = new System.Drawing.Size(259, 233);
            this.listViewUpdates.TabIndex = 10;
            this.listViewUpdates.UseCompatibleStateImageBehavior = false;
            this.listViewUpdates.View = System.Windows.Forms.View.Details;
            this.listViewUpdates.SelectedIndexChanged += new System.EventHandler(this.listViewUpdates_SelectedIndexChanged);
			this.listViewUpdates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewUpdates_ItemCheck);
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
            this.tabControlUpdateDetails.Controls.Add(this.tabPageUpdateChanges);
            this.tabControlUpdateDetails.Controls.Add(this.tabPageUpdateFiles);
            this.tabControlUpdateDetails.Controls.Add(this.tabPageUpdateDetails);
            this.tabControlUpdateDetails.Location = new System.Drawing.Point(277, 29);
            this.tabControlUpdateDetails.Name = "tabControlUpdateDetails";
            this.tabControlUpdateDetails.SelectedIndex = 0;
            this.tabControlUpdateDetails.Size = new System.Drawing.Size(378, 233);
            this.tabControlUpdateDetails.TabIndex = 11;
            // 
            // tabPageUpdateChanges
            // 
            this.tabPageUpdateChanges.Controls.Add(this.textBoxChangelog);
            this.tabPageUpdateChanges.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateChanges.Name = "tabPageUpdateChanges";
            this.tabPageUpdateChanges.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdateChanges.Size = new System.Drawing.Size(370, 207);
            this.tabPageUpdateChanges.TabIndex = 0;
            this.tabPageUpdateChanges.Text = "Changes";
            this.tabPageUpdateChanges.UseVisualStyleBackColor = true;
            // 
            // textBoxChangelog
            // 
            this.textBoxChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChangelog.Location = new System.Drawing.Point(3, 3);
            this.textBoxChangelog.Name = "textBoxChangelog";
            this.textBoxChangelog.ReadOnly = true;
            this.textBoxChangelog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBoxChangelog.Size = new System.Drawing.Size(364, 201);
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
            this.tabPageUpdateFiles.Size = new System.Drawing.Size(370, 207);
            this.tabPageUpdateFiles.TabIndex = 1;
            this.tabPageUpdateFiles.Text = "Files";
            this.tabPageUpdateFiles.UseVisualStyleBackColor = true;
            // 
            // listViewUpdateFiles
            // 
            this.listViewUpdateFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnStatus,
            this.columnFile});
            this.listViewUpdateFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUpdateFiles.FullRowSelect = true;
            this.listViewUpdateFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUpdateFiles.HideSelection = false;
            this.listViewUpdateFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewUpdateFiles.MultiSelect = false;
            this.listViewUpdateFiles.Name = "listViewUpdateFiles";
            this.listViewUpdateFiles.Size = new System.Drawing.Size(364, 201);
            this.listViewUpdateFiles.TabIndex = 1;
            this.listViewUpdateFiles.UseCompatibleStateImageBehavior = false;
            this.listViewUpdateFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 114;
            // 
            // columnFile
            // 
            this.columnFile.Text = "File";
            this.columnFile.Width = 237;
            // 
            // tabPageUpdateDetails
            // 
            this.tabPageUpdateDetails.Controls.Add(this.groupReleaseDetails);
            this.tabPageUpdateDetails.Controls.Add(this.groupBoxDownloadDetails);
            this.tabPageUpdateDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdateDetails.Name = "tabPageUpdateDetails";
            this.tabPageUpdateDetails.Size = new System.Drawing.Size(370, 207);
            this.tabPageUpdateDetails.TabIndex = 2;
            this.tabPageUpdateDetails.Text = "Details";
            this.tabPageUpdateDetails.UseVisualStyleBackColor = true;
            // 
            // groupReleaseDetails
            // 
            this.groupReleaseDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupReleaseDetails.Controls.Add(this.tableLayoutPanelRelease);
            this.groupReleaseDetails.Location = new System.Drawing.Point(3, 73);
            this.groupReleaseDetails.Name = "groupReleaseDetails";
            this.groupReleaseDetails.Size = new System.Drawing.Size(364, 74);
            this.groupReleaseDetails.TabIndex = 3;
            this.groupReleaseDetails.TabStop = false;
            this.groupReleaseDetails.Text = "Release Details";
            // 
            // tableLayoutPanelRelease
            // 
            this.tableLayoutPanelRelease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRelease.ColumnCount = 2;
            this.tableLayoutPanelRelease.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRelease.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleasePublishedDate, 0, 0);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleasePublishedValue, 1, 0);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleaseTag, 0, 3);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleasePage, 0, 1);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleaseName, 0, 2);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleaseNameValue, 1, 2);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleasePageValue, 1, 1);
            this.tableLayoutPanelRelease.Controls.Add(this.labelReleaseTagValue, 1, 3);
            this.tableLayoutPanelRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRelease.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelRelease.Name = "tableLayoutPanelRelease";
            this.tableLayoutPanelRelease.RowCount = 4;
            this.tableLayoutPanelRelease.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRelease.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRelease.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRelease.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRelease.Size = new System.Drawing.Size(358, 55);
            this.tableLayoutPanelRelease.TabIndex = 4;
            // 
            // labelReleasePublishedDate
            // 
            this.labelReleasePublishedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReleasePublishedDate.AutoSize = true;
            this.labelReleasePublishedDate.Location = new System.Drawing.Point(3, 0);
            this.labelReleasePublishedDate.Name = "labelReleasePublishedDate";
            this.labelReleasePublishedDate.Size = new System.Drawing.Size(56, 13);
            this.labelReleasePublishedDate.TabIndex = 7;
            this.labelReleasePublishedDate.Text = "Published:";
            // 
            // labelReleasePublishedValue
            // 
            this.labelReleasePublishedValue.AutoSize = true;
            this.labelReleasePublishedValue.Location = new System.Drawing.Point(65, 0);
            this.labelReleasePublishedValue.Name = "labelReleasePublishedValue";
            this.labelReleasePublishedValue.Size = new System.Drawing.Size(114, 13);
            this.labelReleasePublishedValue.TabIndex = 8;
            this.labelReleasePublishedValue.Text = "labelReleasePublished";
            // 
            // labelReleaseTag
            // 
            this.labelReleaseTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReleaseTag.AutoSize = true;
            this.labelReleaseTag.Location = new System.Drawing.Point(30, 39);
            this.labelReleaseTag.Name = "labelReleaseTag";
            this.labelReleaseTag.Size = new System.Drawing.Size(29, 13);
            this.labelReleaseTag.TabIndex = 1;
            this.labelReleaseTag.Text = "Tag:";
            // 
            // labelReleasePage
            // 
            this.labelReleasePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReleasePage.AutoSize = true;
            this.labelReleasePage.Location = new System.Drawing.Point(24, 13);
            this.labelReleasePage.Name = "labelReleasePage";
            this.labelReleasePage.Size = new System.Drawing.Size(35, 13);
            this.labelReleasePage.TabIndex = 5;
            this.labelReleasePage.Text = "Page:";
            // 
            // labelReleaseName
            // 
            this.labelReleaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReleaseName.AutoSize = true;
            this.labelReleaseName.Location = new System.Drawing.Point(21, 26);
            this.labelReleaseName.Name = "labelReleaseName";
            this.labelReleaseName.Size = new System.Drawing.Size(38, 13);
            this.labelReleaseName.TabIndex = 0;
            this.labelReleaseName.Text = "Name:";
            // 
            // labelReleaseNameValue
            // 
            this.labelReleaseNameValue.AutoSize = true;
            this.labelReleaseNameValue.Location = new System.Drawing.Point(65, 26);
            this.labelReleaseNameValue.Name = "labelReleaseNameValue";
            this.labelReleaseNameValue.Size = new System.Drawing.Size(96, 13);
            this.labelReleaseNameValue.TabIndex = 3;
            this.labelReleaseNameValue.Text = "labelReleaseName";
            // 
            // labelReleasePageValue
            // 
            this.labelReleasePageValue.AutoSize = true;
            this.labelReleasePageValue.Location = new System.Drawing.Point(65, 13);
            this.labelReleasePageValue.Name = "labelReleasePageValue";
            this.labelReleasePageValue.Size = new System.Drawing.Size(62, 13);
            this.labelReleasePageValue.TabIndex = 6;
            this.labelReleasePageValue.TabStop = true;
            this.labelReleasePageValue.Text = "linkRelease";
            this.labelReleasePageValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelReleasePageValue_LinkClicked);
            // 
            // labelReleaseTagValue
            // 
            this.labelReleaseTagValue.AutoSize = true;
            this.labelReleaseTagValue.Location = new System.Drawing.Point(65, 39);
            this.labelReleaseTagValue.Name = "labelReleaseTagValue";
            this.labelReleaseTagValue.Size = new System.Drawing.Size(87, 13);
            this.labelReleaseTagValue.TabIndex = 4;
            this.labelReleaseTagValue.Text = "labelReleaseTag";
            // 
            // groupBoxDownloadDetails
            // 
            this.groupBoxDownloadDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDownloadDetails.Controls.Add(this.tableLayoutPanelDownload);
            this.groupBoxDownloadDetails.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDownloadDetails.Name = "groupBoxDownloadDetails";
            this.groupBoxDownloadDetails.Size = new System.Drawing.Size(364, 64);
            this.groupBoxDownloadDetails.TabIndex = 2;
            this.groupBoxDownloadDetails.TabStop = false;
            this.groupBoxDownloadDetails.Text = "Download Details";
            // 
            // tableLayoutPanelDownload
            // 
            this.tableLayoutPanelDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDownload.ColumnCount = 2;
            this.tableLayoutPanelDownload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDownload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadPublishDate, 0, 0);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadFiles, 0, 2);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadSize, 0, 1);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadPublishedValue, 1, 0);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadSizeValue, 1, 1);
            this.tableLayoutPanelDownload.Controls.Add(this.labelDownloadFileCountValue, 1, 2);
            this.tableLayoutPanelDownload.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelDownload.Name = "tableLayoutPanelDownload";
            this.tableLayoutPanelDownload.RowCount = 3;
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDownload.Size = new System.Drawing.Size(355, 39);
            this.tableLayoutPanelDownload.TabIndex = 3;
            // 
            // labelDownloadPublishDate
            // 
            this.labelDownloadPublishDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDownloadPublishDate.AutoSize = true;
            this.labelDownloadPublishDate.Location = new System.Drawing.Point(3, 0);
            this.labelDownloadPublishDate.Name = "labelDownloadPublishDate";
            this.labelDownloadPublishDate.Size = new System.Drawing.Size(56, 13);
            this.labelDownloadPublishDate.TabIndex = 0;
            this.labelDownloadPublishDate.Text = "Published:";
            // 
            // labelDownloadFiles
            // 
            this.labelDownloadFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDownloadFiles.AutoSize = true;
            this.labelDownloadFiles.Location = new System.Drawing.Point(28, 26);
            this.labelDownloadFiles.Name = "labelDownloadFiles";
            this.labelDownloadFiles.Size = new System.Drawing.Size(31, 13);
            this.labelDownloadFiles.TabIndex = 2;
            this.labelDownloadFiles.Text = "Files:";
            // 
            // labelDownloadSize
            // 
            this.labelDownloadSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDownloadSize.AutoSize = true;
            this.labelDownloadSize.Location = new System.Drawing.Point(29, 13);
            this.labelDownloadSize.Name = "labelDownloadSize";
            this.labelDownloadSize.Size = new System.Drawing.Size(30, 13);
            this.labelDownloadSize.TabIndex = 1;
            this.labelDownloadSize.Text = "Size:";
            // 
            // labelDownloadPublishedValue
            // 
            this.labelDownloadPublishedValue.AutoSize = true;
            this.labelDownloadPublishedValue.Location = new System.Drawing.Point(65, 0);
            this.labelDownloadPublishedValue.Name = "labelDownloadPublishedValue";
            this.labelDownloadPublishedValue.Size = new System.Drawing.Size(123, 13);
            this.labelDownloadPublishedValue.TabIndex = 3;
            this.labelDownloadPublishedValue.Text = "labelDownloadPublished";
            // 
            // labelDownloadSizeValue
            // 
            this.labelDownloadSizeValue.AutoSize = true;
            this.labelDownloadSizeValue.Location = new System.Drawing.Point(65, 13);
            this.labelDownloadSizeValue.Name = "labelDownloadSizeValue";
            this.labelDownloadSizeValue.Size = new System.Drawing.Size(49, 13);
            this.labelDownloadSizeValue.TabIndex = 4;
            this.labelDownloadSizeValue.Text = "labelSize";
            // 
            // labelDownloadFileCountValue
            // 
            this.labelDownloadFileCountValue.AutoSize = true;
            this.labelDownloadFileCountValue.Location = new System.Drawing.Point(65, 26);
            this.labelDownloadFileCountValue.Name = "labelDownloadFileCountValue";
            this.labelDownloadFileCountValue.Size = new System.Drawing.Size(73, 13);
            this.labelDownloadFileCountValue.TabIndex = 5;
            this.labelDownloadFileCountValue.Text = "labelFileCount";
            // 
            // UpdatesAvailableDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(662, 388);
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
            this.tabPageUpdateChanges.ResumeLayout(false);
            this.tabPageUpdateFiles.ResumeLayout(false);
            this.tabPageUpdateDetails.ResumeLayout(false);
            this.groupReleaseDetails.ResumeLayout(false);
            this.tableLayoutPanelRelease.ResumeLayout(false);
            this.tableLayoutPanelRelease.PerformLayout();
            this.groupBoxDownloadDetails.ResumeLayout(false);
            this.tableLayoutPanelDownload.ResumeLayout(false);
            this.tableLayoutPanelDownload.PerformLayout();
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
		private System.Windows.Forms.TabPage tabPageUpdateChanges;
		private System.Windows.Forms.TabPage tabPageUpdateFiles;
		private System.Windows.Forms.TabPage tabPageUpdateDetails;
		private System.Windows.Forms.ListView listViewUpdateFiles;
		private System.Windows.Forms.ColumnHeader columnStatus;
		private System.Windows.Forms.ColumnHeader columnFile;
		private System.Windows.Forms.GroupBox groupReleaseDetails;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRelease;
		private System.Windows.Forms.Label labelReleasePublishedDate;
		private System.Windows.Forms.Label labelReleasePublishedValue;
		private System.Windows.Forms.Label labelReleaseTag;
		private System.Windows.Forms.Label labelReleasePage;
		private System.Windows.Forms.Label labelReleaseName;
		private System.Windows.Forms.Label labelReleaseNameValue;
		private System.Windows.Forms.LinkLabel labelReleasePageValue;
		private System.Windows.Forms.Label labelReleaseTagValue;
		private System.Windows.Forms.GroupBox groupBoxDownloadDetails;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDownload;
		private System.Windows.Forms.Label labelDownloadPublishDate;
		private System.Windows.Forms.Label labelDownloadFiles;
		private System.Windows.Forms.Label labelDownloadSize;
		private System.Windows.Forms.Label labelDownloadPublishedValue;
		private System.Windows.Forms.Label labelDownloadSizeValue;
		private System.Windows.Forms.Label labelDownloadFileCountValue;
		private System.Windows.Forms.RichTextBox textBoxChangelog;
	}
}