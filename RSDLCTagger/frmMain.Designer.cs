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
            this.themeContainerMain = new Ambiance.Ambiance_ThemeContainer();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusLblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblMiddle = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLblTagged = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSelectAllNone = new Ambiance.Ambiance_Button_1();
            this.lblWorkingFolderPath = new Ambiance.Ambiance_Label();
            this.tbWorkingFolderPath = new Ambiance.Ambiance_TextBox();
            this.btnProcessSelected = new Ambiance.Ambiance_Button_1();
            this.btnRunRS = new Ambiance.Ambiance_Button_2();
            this.checkDeleteExtractedOnDone = new Ambiance.Ambiance_CheckBox();
            this.dgvSongs = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTagged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRSPath = new Ambiance.Ambiance_Label();
            this.tbRSPath = new Ambiance.Ambiance_TextBox();
            this.ambiance_ControlBox1 = new Ambiance.Ambiance_ControlBox();
            this.btnLoadSongs = new Ambiance.Ambiance_Button_1();
            this.themeContainerMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).BeginInit();
            this.SuspendLayout();
            // 
            // themeContainerMain
            // 
            this.themeContainerMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.themeContainerMain.Controls.Add(this.btnLoadSongs);
            this.themeContainerMain.Controls.Add(this.statusStripMain);
            this.themeContainerMain.Controls.Add(this.btnSelectAllNone);
            this.themeContainerMain.Controls.Add(this.lblWorkingFolderPath);
            this.themeContainerMain.Controls.Add(this.tbWorkingFolderPath);
            this.themeContainerMain.Controls.Add(this.btnProcessSelected);
            this.themeContainerMain.Controls.Add(this.btnRunRS);
            this.themeContainerMain.Controls.Add(this.checkDeleteExtractedOnDone);
            this.themeContainerMain.Controls.Add(this.dgvSongs);
            this.themeContainerMain.Controls.Add(this.lblRSPath);
            this.themeContainerMain.Controls.Add(this.tbRSPath);
            this.themeContainerMain.Controls.Add(this.ambiance_ControlBox1);
            this.themeContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.themeContainerMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.themeContainerMain.Location = new System.Drawing.Point(0, 0);
            this.themeContainerMain.Name = "themeContainerMain";
            this.themeContainerMain.Padding = new System.Windows.Forms.Padding(20, 56, 20, 16);
            this.themeContainerMain.RoundCorners = true;
            this.themeContainerMain.Sizable = true;
            this.themeContainerMain.Size = new System.Drawing.Size(655, 496);
            this.themeContainerMain.SmartBounds = true;
            this.themeContainerMain.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.themeContainerMain.TabIndex = 0;
            this.themeContainerMain.Text = "#RS DLC Tagger";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblMain,
            this.statusLblMiddle,
            this.statusLblTagged});
            this.statusStripMain.Location = new System.Drawing.Point(20, 458);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(615, 22);
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
            this.statusLblMiddle.Size = new System.Drawing.Size(371, 17);
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
            this.btnSelectAllNone.Location = new System.Drawing.Point(37, 115);
            this.btnSelectAllNone.Name = "btnSelectAllNone";
            this.btnSelectAllNone.Size = new System.Drawing.Size(155, 30);
            this.btnSelectAllNone.TabIndex = 9;
            this.btnSelectAllNone.Text = "Select all/none";
            this.btnSelectAllNone.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSelectAllNone.Click += new System.EventHandler(this.btnSelectAllNone_Click);
            // 
            // lblWorkingFolderPath
            // 
            this.lblWorkingFolderPath.AutoSize = true;
            this.lblWorkingFolderPath.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkingFolderPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWorkingFolderPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblWorkingFolderPath.Location = new System.Drawing.Point(280, 63);
            this.lblWorkingFolderPath.Name = "lblWorkingFolderPath";
            this.lblWorkingFolderPath.Size = new System.Drawing.Size(146, 20);
            this.lblWorkingFolderPath.TabIndex = 8;
            this.lblWorkingFolderPath.Text = "Working folder path:";
            // 
            // tbWorkingFolderPath
            // 
            this.tbWorkingFolderPath.BackColor = System.Drawing.Color.Transparent;
            this.tbWorkingFolderPath.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbWorkingFolderPath.ForeColor = System.Drawing.Color.DimGray;
            this.tbWorkingFolderPath.Location = new System.Drawing.Point(430, 59);
            this.tbWorkingFolderPath.MaxLength = 32767;
            this.tbWorkingFolderPath.Multiline = false;
            this.tbWorkingFolderPath.Name = "tbWorkingFolderPath";
            this.tbWorkingFolderPath.ReadOnly = false;
            this.tbWorkingFolderPath.Size = new System.Drawing.Size(176, 28);
            this.tbWorkingFolderPath.TabIndex = 7;
            this.tbWorkingFolderPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbWorkingFolderPath.UseSystemPasswordChar = false;
            // 
            // btnProcessSelected
            // 
            this.btnProcessSelected.BackColor = System.Drawing.Color.Transparent;
            this.btnProcessSelected.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnProcessSelected.Image = null;
            this.btnProcessSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessSelected.Location = new System.Drawing.Point(239, 412);
            this.btnProcessSelected.Name = "btnProcessSelected";
            this.btnProcessSelected.Size = new System.Drawing.Size(177, 30);
            this.btnProcessSelected.TabIndex = 6;
            this.btnProcessSelected.Text = "Process selected";
            this.btnProcessSelected.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnProcessSelected.Click += new System.EventHandler(this.btnProcessSelected_Click);
            // 
            // btnRunRS
            // 
            this.btnRunRS.BackColor = System.Drawing.Color.Transparent;
            this.btnRunRS.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRunRS.Image = null;
            this.btnRunRS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunRS.Location = new System.Drawing.Point(238, 113);
            this.btnRunRS.Name = "btnRunRS";
            this.btnRunRS.Size = new System.Drawing.Size(177, 30);
            this.btnRunRS.TabIndex = 5;
            this.btnRunRS.Text = "Run RS";
            this.btnRunRS.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRunRS.Click += new System.EventHandler(this.btnRunRS_Click);
            // 
            // checkDeleteExtractedOnDone
            // 
            this.checkDeleteExtractedOnDone.BackColor = System.Drawing.Color.Transparent;
            this.checkDeleteExtractedOnDone.Checked = false;
            this.checkDeleteExtractedOnDone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkDeleteExtractedOnDone.Location = new System.Drawing.Point(225, 92);
            this.checkDeleteExtractedOnDone.Name = "checkDeleteExtractedOnDone";
            this.checkDeleteExtractedOnDone.Size = new System.Drawing.Size(241, 15);
            this.checkDeleteExtractedOnDone.TabIndex = 4;
            this.checkDeleteExtractedOnDone.Text = "Delete extracted when done";
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
            this.dgvSongs.Location = new System.Drawing.Point(27, 151);
            this.dgvSongs.Name = "dgvSongs";
            this.dgvSongs.RowHeadersVisible = false;
            this.dgvSongs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSongs.Size = new System.Drawing.Size(584, 241);
            this.dgvSongs.TabIndex = 3;
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
            this.colPath.HeaderText = "Path";
            this.colPath.Name = "colPath";
            this.colPath.Width = 380;
            // 
            // lblRSPath
            // 
            this.lblRSPath.AutoSize = true;
            this.lblRSPath.BackColor = System.Drawing.Color.Transparent;
            this.lblRSPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRSPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lblRSPath.Location = new System.Drawing.Point(22, 62);
            this.lblRSPath.Name = "lblRSPath";
            this.lblRSPath.Size = new System.Drawing.Size(63, 20);
            this.lblRSPath.TabIndex = 2;
            this.lblRSPath.Text = "RS path:";
            // 
            // tbRSPath
            // 
            this.tbRSPath.BackColor = System.Drawing.Color.Transparent;
            this.tbRSPath.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbRSPath.ForeColor = System.Drawing.Color.DimGray;
            this.tbRSPath.Location = new System.Drawing.Point(91, 59);
            this.tbRSPath.MaxLength = 32767;
            this.tbRSPath.Multiline = false;
            this.tbRSPath.Name = "tbRSPath";
            this.tbRSPath.ReadOnly = false;
            this.tbRSPath.Size = new System.Drawing.Size(176, 28);
            this.tbRSPath.TabIndex = 1;
            this.tbRSPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbRSPath.UseSystemPasswordChar = false;
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
            // btnLoadSongs
            // 
            this.btnLoadSongs.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadSongs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLoadSongs.Image = null;
            this.btnLoadSongs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadSongs.Location = new System.Drawing.Point(430, 113);
            this.btnLoadSongs.Name = "btnLoadSongs";
            this.btnLoadSongs.Size = new System.Drawing.Size(155, 30);
            this.btnLoadSongs.TabIndex = 11;
            this.btnLoadSongs.Text = "Load songs";
            this.btnLoadSongs.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnLoadSongs.Click += new System.EventHandler(this.btnLoadSongs_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 496);
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
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ambiance.Ambiance_ThemeContainer themeContainerMain;
        private System.Windows.Forms.DataGridView dgvSongs;
        private Ambiance.Ambiance_Label lblRSPath;
        private Ambiance.Ambiance_TextBox tbRSPath;
        private Ambiance.Ambiance_ControlBox ambiance_ControlBox1;
        private Ambiance.Ambiance_CheckBox checkDeleteExtractedOnDone;
        private Ambiance.Ambiance_Button_2 btnRunRS;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTagged;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private Ambiance.Ambiance_Button_1 btnProcessSelected;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private Ambiance.Ambiance_Label lblWorkingFolderPath;
        private Ambiance.Ambiance_TextBox tbWorkingFolderPath;
        private Ambiance.Ambiance_Button_1 btnSelectAllNone;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLblMain;
        private System.Windows.Forms.ToolStripStatusLabel statusLblMiddle;
        private System.Windows.Forms.ToolStripStatusLabel statusLblTagged;
        private Ambiance.Ambiance_Button_1 btnLoadSongs;
    }
}

