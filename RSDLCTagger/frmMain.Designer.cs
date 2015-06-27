namespace RSDLCTagger
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.sfdPreview = new System.Windows.Forms.SaveFileDialog();
            this.themeContainerMain = new Ambiance.Ambiance_ThemeContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSavePreview = new Ambiance.Ambiance_Button_1();
            this.lblTagPacks = new Ambiance.Ambiance_Label();
            this.comboTagPacks = new Ambiance.Ambiance_ComboBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkAddTagsToFileName = new Ambiance.Ambiance_CheckBox();
            this.lblWorkingFolderPath = new Ambiance.Ambiance_Label();
            this.tbWorkingFolderPath = new Ambiance.Ambiance_TextBox();
            this.checkDeleteExtractedOnDone = new Ambiance.Ambiance_CheckBox();
            this.lblRSPath = new Ambiance.Ambiance_Label();
            this.tbRSPath = new Ambiance.Ambiance_TextBox();
            this.btnShowPreview = new Ambiance.Ambiance_Button_1();
            this.btnRemoveTags = new Ambiance.Ambiance_Button_1();
            this.lblSearch = new Ambiance.Ambiance_Label();
            this.tbSearch = new Ambiance.Ambiance_TextBox();
            this.btnLoadSongs = new Ambiance.Ambiance_Button_1();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusLblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblMiddle = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblTagged = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSelectAllNone = new Ambiance.Ambiance_Button_1();
            this.btnProcessSelected = new Ambiance.Ambiance_Button_1();
            this.btnRunRS = new Ambiance.Ambiance_Button_2();
            this.dgvSongs = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTagged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ambiance_ControlBox1 = new Ambiance.Ambiance_ControlBox();
            this.themeContainerMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).BeginInit();
            this.SuspendLayout();
            // 
            // sfdPreview
            // 
            this.sfdPreview.Filter = "Png Image|*.png";
            this.sfdPreview.Title = "Save preview";
            // 
            // themeContainerMain
            // 
            this.themeContainerMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.themeContainerMain.Controls.Add(this.groupBox2);
            this.themeContainerMain.Controls.Add(this.groupBox1);
            this.themeContainerMain.Controls.Add(this.btnShowPreview);
            this.themeContainerMain.Controls.Add(this.btnRemoveTags);
            this.themeContainerMain.Controls.Add(this.lblSearch);
            this.themeContainerMain.Controls.Add(this.tbSearch);
            this.themeContainerMain.Controls.Add(this.btnLoadSongs);
            this.themeContainerMain.Controls.Add(this.statusStripMain);
            this.themeContainerMain.Controls.Add(this.btnSelectAllNone);
            this.themeContainerMain.Controls.Add(this.btnProcessSelected);
            this.themeContainerMain.Controls.Add(this.btnRunRS);
            this.themeContainerMain.Controls.Add(this.dgvSongs);
            this.themeContainerMain.Controls.Add(this.ambiance_ControlBox1);
            this.themeContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themeContainerMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.themeContainerMain.Location = new System.Drawing.Point(0, 0);
            this.themeContainerMain.Name = "themeContainerMain";
            this.themeContainerMain.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.themeContainerMain.RoundCorners = true;
            this.themeContainerMain.Sizable = true;
            this.themeContainerMain.Size = new System.Drawing.Size(695, 719);
            this.themeContainerMain.SmartBounds = true;
            this.themeContainerMain.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.themeContainerMain.TabIndex = 0;
            this.themeContainerMain.Text = "#RS DLC Tagger";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSavePreview);
            this.groupBox2.Controls.Add(this.lblTagPacks);
            this.groupBox2.Controls.Add(this.comboTagPacks);
            this.groupBox2.Controls.Add(this.pictureBoxPreview);
            this.groupBox2.Location = new System.Drawing.Point(62, 493);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 155);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag packs";
            // 
            // btnSavePreview
            // 
            this.btnSavePreview.BackColor = System.Drawing.Color.Transparent;
            this.btnSavePreview.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSavePreview.Image = null;
            this.btnSavePreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePreview.Location = new System.Drawing.Point(80, 95);
            this.btnSavePreview.Name = "btnSavePreview";
            this.btnSavePreview.Size = new System.Drawing.Size(177, 30);
            this.btnSavePreview.TabIndex = 23;
            this.btnSavePreview.Text = "Save preview";
            this.btnSavePreview.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSavePreview.Click += new System.EventHandler(this.btnSavePreview_Click);
            // 
            // lblTagPacks
            // 
            this.lblTagPacks.AutoSize = true;
            this.lblTagPacks.BackColor = System.Drawing.Color.Transparent;
            this.lblTagPacks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTagPacks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblTagPacks.Location = new System.Drawing.Point(135, 40);
            this.lblTagPacks.Name = "lblTagPacks";
            this.lblTagPacks.Size = new System.Drawing.Size(75, 20);
            this.lblTagPacks.TabIndex = 22;
            this.lblTagPacks.Text = "Tag packs";
            // 
            // comboTagPacks
            // 
            this.comboTagPacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.comboTagPacks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboTagPacks.DropDownHeight = 100;
            this.comboTagPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTagPacks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboTagPacks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.comboTagPacks.FormattingEnabled = true;
            this.comboTagPacks.HoverSelectionColor = System.Drawing.Color.Empty;
            this.comboTagPacks.IntegralHeight = false;
            this.comboTagPacks.ItemHeight = 20;
            this.comboTagPacks.Items.AddRange(new object[] {
            "Frack-default pack",
            "Motive #1 pack ",
            "Motive #2 pack",
            "Motive #3 pack"});
            this.comboTagPacks.Location = new System.Drawing.Point(57, 63);
            this.comboTagPacks.Name = "comboTagPacks";
            this.comboTagPacks.Size = new System.Drawing.Size(237, 26);
            this.comboTagPacks.StartIndex = 1;
            this.comboTagPacks.TabIndex = 21;
            this.comboTagPacks.SelectedIndexChanged += new System.EventHandler(this.comboTagPacks_SelectedIndexChanged);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(370, 17);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxPreview.TabIndex = 20;
            this.pictureBoxPreview.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkAddTagsToFileName);
            this.groupBox1.Controls.Add(this.lblWorkingFolderPath);
            this.groupBox1.Controls.Add(this.tbWorkingFolderPath);
            this.groupBox1.Controls.Add(this.checkDeleteExtractedOnDone);
            this.groupBox1.Controls.Add(this.lblRSPath);
            this.groupBox1.Controls.Add(this.tbRSPath);
            this.groupBox1.Location = new System.Drawing.Point(20, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 80);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkAddTagsToFileName
            // 
            this.checkAddTagsToFileName.BackColor = System.Drawing.Color.Transparent;
            this.checkAddTagsToFileName.Checked = false;
            this.checkAddTagsToFileName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkAddTagsToFileName.Location = new System.Drawing.Point(422, 59);
            this.checkAddTagsToFileName.Name = "checkAddTagsToFileName";
            this.checkAddTagsToFileName.Size = new System.Drawing.Size(171, 15);
            this.checkAddTagsToFileName.TabIndex = 21;
            this.checkAddTagsToFileName.Text = "Add tags to file name";
            // 
            // lblWorkingFolderPath
            // 
            this.lblWorkingFolderPath.AutoSize = true;
            this.lblWorkingFolderPath.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkingFolderPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWorkingFolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblWorkingFolderPath.Location = new System.Drawing.Point(281, 23);
            this.lblWorkingFolderPath.Name = "lblWorkingFolderPath";
            this.lblWorkingFolderPath.Size = new System.Drawing.Size(146, 20);
            this.lblWorkingFolderPath.TabIndex = 20;
            this.lblWorkingFolderPath.Text = "Working folder path:";
            // 
            // tbWorkingFolderPath
            // 
            this.tbWorkingFolderPath.BackColor = System.Drawing.Color.Transparent;
            this.tbWorkingFolderPath.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbWorkingFolderPath.ForeColor = System.Drawing.Color.DimGray;
            this.tbWorkingFolderPath.Location = new System.Drawing.Point(429, 19);
            this.tbWorkingFolderPath.MaxLength = 32767;
            this.tbWorkingFolderPath.Multiline = false;
            this.tbWorkingFolderPath.Name = "tbWorkingFolderPath";
            this.tbWorkingFolderPath.ReadOnly = false;
            this.tbWorkingFolderPath.Size = new System.Drawing.Size(176, 28);
            this.tbWorkingFolderPath.TabIndex = 19;
            this.tbWorkingFolderPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbWorkingFolderPath.UseSystemPasswordChar = false;
            // 
            // checkDeleteExtractedOnDone
            // 
            this.checkDeleteExtractedOnDone.BackColor = System.Drawing.Color.Transparent;
            this.checkDeleteExtractedOnDone.Checked = false;
            this.checkDeleteExtractedOnDone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkDeleteExtractedOnDone.Location = new System.Drawing.Point(95, 59);
            this.checkDeleteExtractedOnDone.Name = "checkDeleteExtractedOnDone";
            this.checkDeleteExtractedOnDone.Size = new System.Drawing.Size(241, 15);
            this.checkDeleteExtractedOnDone.TabIndex = 18;
            this.checkDeleteExtractedOnDone.Text = "Delete extracted when done";
            // 
            // lblRSPath
            // 
            this.lblRSPath.AutoSize = true;
            this.lblRSPath.BackColor = System.Drawing.Color.Transparent;
            this.lblRSPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRSPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblRSPath.Location = new System.Drawing.Point(21, 23);
            this.lblRSPath.Name = "lblRSPath";
            this.lblRSPath.Size = new System.Drawing.Size(63, 20);
            this.lblRSPath.TabIndex = 17;
            this.lblRSPath.Text = "RS path:";
            // 
            // tbRSPath
            // 
            this.tbRSPath.BackColor = System.Drawing.Color.Transparent;
            this.tbRSPath.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbRSPath.ForeColor = System.Drawing.Color.DimGray;
            this.tbRSPath.Location = new System.Drawing.Point(87, 21);
            this.tbRSPath.MaxLength = 32767;
            this.tbRSPath.Multiline = false;
            this.tbRSPath.Name = "tbRSPath";
            this.tbRSPath.ReadOnly = false;
            this.tbRSPath.Size = new System.Drawing.Size(176, 28);
            this.tbRSPath.TabIndex = 16;
            this.tbRSPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbRSPath.UseSystemPasswordChar = false;
            // 
            // btnShowPreview
            // 
            this.btnShowPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPreview.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShowPreview.Image = null;
            this.btnShowPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowPreview.Location = new System.Drawing.Point(440, 446);
            this.btnShowPreview.Name = "btnShowPreview";
            this.btnShowPreview.Size = new System.Drawing.Size(177, 30);
            this.btnShowPreview.TabIndex = 17;
            this.btnShowPreview.Text = "Preview selected";
            this.btnShowPreview.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnShowPreview.Click += new System.EventHandler(this.btnShowPreview_Click);
            // 
            // btnRemoveTags
            // 
            this.btnRemoveTags.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveTags.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRemoveTags.Image = null;
            this.btnRemoveTags.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveTags.Location = new System.Drawing.Point(253, 446);
            this.btnRemoveTags.Name = "btnRemoveTags";
            this.btnRemoveTags.Size = new System.Drawing.Size(177, 30);
            this.btnRemoveTags.TabIndex = 14;
            this.btnRemoveTags.Text = "Remove tags";
            this.btnRemoveTags.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRemoveTags.Click += new System.EventHandler(this.btnRemoveTags_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblSearch.Location = new System.Drawing.Point(216, 179);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(56, 20);
            this.lblSearch.TabIndex = 13;
            this.lblSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.Transparent;
            this.tbSearch.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbSearch.ForeColor = System.Drawing.Color.DimGray;
            this.tbSearch.Location = new System.Drawing.Point(272, 175);
            this.tbSearch.MaxLength = 32767;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.ReadOnly = false;
            this.tbSearch.Size = new System.Drawing.Size(177, 28);
            this.tbSearch.TabIndex = 12;
            this.tbSearch.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbSearch.UseSystemPasswordChar = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // btnLoadSongs
            // 
            this.btnLoadSongs.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadSongs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLoadSongs.Image = null;
            this.btnLoadSongs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadSongs.Location = new System.Drawing.Point(477, 175);
            this.btnLoadSongs.Name = "btnLoadSongs";
            this.btnLoadSongs.Size = new System.Drawing.Size(155, 30);
            this.btnLoadSongs.TabIndex = 11;
            this.btnLoadSongs.Text = "Load songs";
            this.btnLoadSongs.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnLoadSongs.Click += new System.EventHandler(this.btnLoadSongs_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblMain,
            this.statusLblMiddle,
            this.statusLblTagged});
            this.statusStripMain.Location = new System.Drawing.Point(20, 681);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(655, 22);
            this.statusStripMain.TabIndex = 10;
            // 
            // statusLblMain
            // 
            this.statusLblMain.Name = "statusLblMain";
            this.statusLblMain.Size = new System.Drawing.Size(159, 17);
            this.statusLblMain.Text = "#Welcome to RS DLC tagger!";
            // 
            // statusLblMiddle
            // 
            this.statusLblMiddle.Name = "statusLblMiddle";
            this.statusLblMiddle.Size = new System.Drawing.Size(411, 17);
            this.statusLblMiddle.Spring = true;
            // 
            // statusLblTagged
            // 
            this.statusLblTagged.Name = "statusLblTagged";
            this.statusLblTagged.Size = new System.Drawing.Size(70, 17);
            this.statusLblTagged.Text = "Tagged: 0/0";
            // 
            // btnSelectAllNone
            // 
            this.btnSelectAllNone.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectAllNone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSelectAllNone.Image = null;
            this.btnSelectAllNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAllNone.Location = new System.Drawing.Point(55, 175);
            this.btnSelectAllNone.Name = "btnSelectAllNone";
            this.btnSelectAllNone.Size = new System.Drawing.Size(155, 30);
            this.btnSelectAllNone.TabIndex = 9;
            this.btnSelectAllNone.Text = "Select all/none";
            this.btnSelectAllNone.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSelectAllNone.Click += new System.EventHandler(this.btnSelectAllNone_Click);
            // 
            // btnProcessSelected
            // 
            this.btnProcessSelected.BackColor = System.Drawing.Color.Transparent;
            this.btnProcessSelected.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnProcessSelected.Image = null;
            this.btnProcessSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessSelected.Location = new System.Drawing.Point(62, 446);
            this.btnProcessSelected.Name = "btnProcessSelected";
            this.btnProcessSelected.Size = new System.Drawing.Size(177, 30);
            this.btnProcessSelected.TabIndex = 6;
            this.btnProcessSelected.Text = "Tag selected";
            this.btnProcessSelected.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnProcessSelected.Click += new System.EventHandler(this.btnProcessSelected_Click);
            // 
            // btnRunRS
            // 
            this.btnRunRS.BackColor = System.Drawing.Color.Transparent;
            this.btnRunRS.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRunRS.Image = null;
            this.btnRunRS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunRS.Location = new System.Drawing.Point(257, 135);
            this.btnRunRS.Name = "btnRunRS";
            this.btnRunRS.Size = new System.Drawing.Size(177, 30);
            this.btnRunRS.TabIndex = 5;
            this.btnRunRS.Text = "Run RS";
            this.btnRunRS.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRunRS.Click += new System.EventHandler(this.btnRunRS_Click);
            // 
            // dgvSongs
            // 
            this.dgvSongs.AllowUserToAddRows = false;
            this.dgvSongs.AllowUserToDeleteRows = false;
            this.dgvSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colTagged,
            this.colPath});
            this.dgvSongs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvSongs.Location = new System.Drawing.Point(45, 215);
            this.dgvSongs.Name = "dgvSongs";
            this.dgvSongs.RowHeadersVisible = false;
            this.dgvSongs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSongs.Size = new System.Drawing.Size(600, 225);
            this.dgvSongs.TabIndex = 3;
            this.dgvSongs.SelectionChanged += new System.EventHandler(this.dgvSongs_SelectionChanged);
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTagged
            // 
            this.colTagged.HeaderText = "Tagged";
            this.colTagged.Name = "colTagged";
            // 
            // colPath
            // 
            this.colPath.HeaderText = "Short Path";
            this.colPath.Name = "colPath";
            this.colPath.Width = 395;
            // 
            // ambiance_ControlBox1
            // 
            this.ambiance_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_ControlBox1.EnableMaximize = true;
            this.ambiance_ControlBox1.Font = new System.Drawing.Font("Marlett", 7F);
            this.ambiance_ControlBox1.Location = new System.Drawing.Point(5, 13);
            this.ambiance_ControlBox1.Name = "ambiance_ControlBox1";
            this.ambiance_ControlBox1.Size = new System.Drawing.Size(64, 22);
            this.ambiance_ControlBox1.TabIndex = 0;
            this.ambiance_ControlBox1.Text = "ambiance_ControlBox1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 719);
            this.Controls.Add(this.themeContainerMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "frmMain";
            this.Text = "#RS DLC Tagger";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.themeContainerMain.ResumeLayout(false);
            this.themeContainerMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ambiance.Ambiance_ThemeContainer themeContainerMain;
        private System.Windows.Forms.DataGridView dgvSongs;
        private Ambiance.Ambiance_ControlBox ambiance_ControlBox1;
        private Ambiance.Ambiance_Button_2 btnRunRS;
        private Ambiance.Ambiance_Button_1 btnProcessSelected;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private Ambiance.Ambiance_Button_1 btnSelectAllNone;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLblMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLblMiddle;
        private System.Windows.Forms.ToolStripStatusLabel statusLblTagged;
        private Ambiance.Ambiance_Button_1 btnLoadSongs;
        private Ambiance.Ambiance_Label lblSearch;
        private Ambiance.Ambiance_TextBox tbSearch;
        private Ambiance.Ambiance_Button_1 btnRemoveTags;
        private Ambiance.Ambiance_Button_1 btnShowPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ambiance.Ambiance_CheckBox checkAddTagsToFileName;
        private Ambiance.Ambiance_Label lblWorkingFolderPath;
        private Ambiance.Ambiance_TextBox tbWorkingFolderPath;
        private Ambiance.Ambiance_CheckBox checkDeleteExtractedOnDone;
        private Ambiance.Ambiance_Label lblRSPath;
        private Ambiance.Ambiance_TextBox tbRSPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ambiance.Ambiance_Label lblTagPacks;
        private Ambiance.Ambiance_ComboBox comboTagPacks;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private Ambiance.Ambiance_Button_1 btnSavePreview;
        private System.Windows.Forms.SaveFileDialog sfdPreview;
    }
}

