namespace UploadWinClient
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chunkSizeUpload = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblFileSizeUpload = new System.Windows.Forms.Label();
            this.chkHashUpload = new System.Windows.Forms.CheckBox();
            this.lblUploadHash = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkUploadAutoChunksize = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkDownloadAutoChunkSize = new System.Windows.Forms.CheckBox();
            this.lblDownloadFileSize = new System.Windows.Forms.Label();
            this.chunkSizeDownload = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshFiles = new System.Windows.Forms.Button();
            this.lblDownloadHash = new System.Windows.Forms.Label();
            this.chkHashDownload = new System.Windows.Forms.CheckBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.workerGetFileList = new System.ComponentModel.BackgroundWorker();
            this.fileTransferDownload1 = new UploadWinClient.FileTransferDownload();
            this.fileTransferUpload1 = new UploadWinClient.FileTransferUpload();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSizeUpload)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSizeDownload)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 256);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // statusText
            // 
            this.statusText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusText.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(38, 17);
            this.statusText.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Visible = false;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(83, 9);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(579, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File to upload";
            // 
            // chunkSizeUpload
            // 
            this.chunkSizeUpload.Enabled = false;
            this.chunkSizeUpload.Location = new System.Drawing.Point(83, 45);
            this.chunkSizeUpload.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.chunkSizeUpload.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.chunkSizeUpload.Name = "chunkSizeUpload";
            this.chunkSizeUpload.Size = new System.Drawing.Size(70, 20);
            this.chunkSizeUpload.TabIndex = 4;
            this.chunkSizeUpload.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chunk Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kb";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Enabled = false;
            this.btnStartStop.Location = new System.Drawing.Point(284, 101);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(140, 23);
            this.btnStartStop.TabIndex = 7;
            this.btnStartStop.Text = "Start Upload";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblFileSizeUpload
            // 
            this.lblFileSizeUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileSizeUpload.AutoSize = true;
            this.lblFileSizeUpload.Location = new System.Drawing.Point(524, 45);
            this.lblFileSizeUpload.Name = "lblFileSizeUpload";
            this.lblFileSizeUpload.Size = new System.Drawing.Size(43, 13);
            this.lblFileSizeUpload.TabIndex = 8;
            this.lblFileSizeUpload.Text = "            ";
            this.lblFileSizeUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkHashUpload
            // 
            this.chkHashUpload.AutoSize = true;
            this.chkHashUpload.Checked = true;
            this.chkHashUpload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHashUpload.Location = new System.Drawing.Point(13, 79);
            this.chkHashUpload.Name = "chkHashUpload";
            this.chkHashUpload.Size = new System.Drawing.Size(179, 17);
            this.chkHashUpload.TabIndex = 9;
            this.chkHashUpload.Text = "Verify file upload with MD5 Hash";
            this.chkHashUpload.UseVisualStyleBackColor = true;
            // 
            // lblUploadHash
            // 
            this.lblUploadHash.AutoSize = true;
            this.lblUploadHash.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadHash.Location = new System.Drawing.Point(10, 129);
            this.lblUploadHash.Name = "lblUploadHash";
            this.lblUploadHash.Size = new System.Drawing.Size(70, 14);
            this.lblUploadHash.TabIndex = 10;
            this.lblUploadHash.Text = "         ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(828, 256);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkUploadAutoChunksize);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Controls.Add(this.btnStartStop);
            this.tabPage1.Controls.Add(this.lblUploadHash);
            this.tabPage1.Controls.Add(this.txtFilePath);
            this.tabPage1.Controls.Add(this.chkHashUpload);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblFileSizeUpload);
            this.tabPage1.Controls.Add(this.chunkSizeUpload);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(820, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upload";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkUploadAutoChunksize
            // 
            this.chkUploadAutoChunksize.AutoSize = true;
            this.chkUploadAutoChunksize.Checked = true;
            this.chkUploadAutoChunksize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUploadAutoChunksize.Location = new System.Drawing.Point(220, 48);
            this.chkUploadAutoChunksize.Name = "chkUploadAutoChunksize";
            this.chkUploadAutoChunksize.Size = new System.Drawing.Size(65, 17);
            this.chkUploadAutoChunksize.TabIndex = 13;
            this.chkUploadAutoChunksize.Text = "Auto set";
            this.chkUploadAutoChunksize.UseVisualStyleBackColor = true;
            this.chkUploadAutoChunksize.CheckedChanged += new System.EventHandler(this.chkUploadAutoChunksize_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(682, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkDownloadAutoChunkSize);
            this.tabPage2.Controls.Add(this.lblDownloadFileSize);
            this.tabPage2.Controls.Add(this.chunkSizeDownload);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnRefreshFiles);
            this.tabPage2.Controls.Add(this.lblDownloadHash);
            this.tabPage2.Controls.Add(this.chkHashDownload);
            this.tabPage2.Controls.Add(this.btnDownload);
            this.tabPage2.Controls.Add(this.lstFiles);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(820, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Download";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkDownloadAutoChunkSize
            // 
            this.chkDownloadAutoChunkSize.AutoSize = true;
            this.chkDownloadAutoChunkSize.Checked = true;
            this.chkDownloadAutoChunkSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDownloadAutoChunkSize.Location = new System.Drawing.Point(343, 12);
            this.chkDownloadAutoChunkSize.Name = "chkDownloadAutoChunkSize";
            this.chkDownloadAutoChunkSize.Size = new System.Drawing.Size(65, 17);
            this.chkDownloadAutoChunkSize.TabIndex = 14;
            this.chkDownloadAutoChunkSize.Text = "Auto set";
            this.chkDownloadAutoChunkSize.UseVisualStyleBackColor = true;
            this.chkDownloadAutoChunkSize.CheckedChanged += new System.EventHandler(this.chkDownloadAutoChunkSize_CheckedChanged);
            // 
            // lblDownloadFileSize
            // 
            this.lblDownloadFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDownloadFileSize.AutoSize = true;
            this.lblDownloadFileSize.Location = new System.Drawing.Point(604, 32);
            this.lblDownloadFileSize.Name = "lblDownloadFileSize";
            this.lblDownloadFileSize.Size = new System.Drawing.Size(46, 13);
            this.lblDownloadFileSize.TabIndex = 12;
            this.lblDownloadFileSize.Text = "             ";
            this.lblDownloadFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chunkSizeDownload
            // 
            this.chunkSizeDownload.Enabled = false;
            this.chunkSizeDownload.Location = new System.Drawing.Point(343, 30);
            this.chunkSizeDownload.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.chunkSizeDownload.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.chunkSizeDownload.Name = "chunkSizeDownload";
            this.chunkSizeDownload.Size = new System.Drawing.Size(70, 20);
            this.chunkSizeDownload.TabIndex = 9;
            this.chunkSizeDownload.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Chunk Size:";
            // 
            // btnRefreshFiles
            // 
            this.btnRefreshFiles.Location = new System.Drawing.Point(8, 6);
            this.btnRefreshFiles.Name = "btnRefreshFiles";
            this.btnRefreshFiles.Size = new System.Drawing.Size(143, 23);
            this.btnRefreshFiles.TabIndex = 5;
            this.btnRefreshFiles.Text = "Refresh Server File List";
            this.btnRefreshFiles.UseVisualStyleBackColor = true;
            this.btnRefreshFiles.Click += new System.EventHandler(this.btnRefreshFiles_Click);
            // 
            // lblDownloadHash
            // 
            this.lblDownloadHash.AutoSize = true;
            this.lblDownloadHash.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadHash.Location = new System.Drawing.Point(270, 126);
            this.lblDownloadHash.Name = "lblDownloadHash";
            this.lblDownloadHash.Size = new System.Drawing.Size(91, 14);
            this.lblDownloadHash.TabIndex = 4;
            this.lblDownloadHash.Text = "            ";
            // 
            // chkHashDownload
            // 
            this.chkHashDownload.AutoSize = true;
            this.chkHashDownload.Checked = true;
            this.chkHashDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHashDownload.Location = new System.Drawing.Point(273, 61);
            this.chkHashDownload.Name = "chkHashDownload";
            this.chkHashDownload.Size = new System.Drawing.Size(193, 17);
            this.chkHashDownload.TabIndex = 3;
            this.chkHashDownload.Text = "Verify file download with MD5 Hash";
            this.chkHashDownload.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(273, 88);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(157, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download Selected File";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(8, 32);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(243, 186);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // workerGetFileList
            // 
            this.workerGetFileList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerGetFileList_DoWork);
            this.workerGetFileList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerGetFileList_RunWorkerCompleted);
            // 
            // fileTransferDownload1
            // 
            this.fileTransferDownload1.WorkerReportsProgress = true;
            this.fileTransferDownload1.WorkerSupportsCancellation = true;
            this.fileTransferDownload1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileTransferDownload1_RunWorkerCompleted);
            this.fileTransferDownload1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileTransfer_ProgressChanged);
            // 
            // fileTransferUpload1
            // 
            this.fileTransferUpload1.WorkerReportsProgress = true;
            this.fileTransferUpload1.WorkerSupportsCancellation = true;
            this.fileTransferUpload1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileTransferUpload1_RunWorkerCompleted);
            this.fileTransferUpload1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileTransfer_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 278);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "MTOM Chunked File Transfer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSizeUpload)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chunkSizeDownload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown chunkSizeUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblFileSizeUpload;
        private System.Windows.Forms.CheckBox chkHashUpload;
        private System.Windows.Forms.Label lblUploadHash;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblDownloadHash;
        private System.Windows.Forms.CheckBox chkHashDownload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ListBox lstFiles;
        private System.ComponentModel.BackgroundWorker workerGetFileList;
		private System.Windows.Forms.Button btnRefreshFiles;
        private System.Windows.Forms.Label lblDownloadFileSize;
        private System.Windows.Forms.NumericUpDown chunkSizeDownload;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox chkUploadAutoChunksize;
		private System.Windows.Forms.CheckBox chkDownloadAutoChunkSize;
		private FileTransferDownload fileTransferDownload1;
		private FileTransferUpload fileTransferUpload1;
    }
}

