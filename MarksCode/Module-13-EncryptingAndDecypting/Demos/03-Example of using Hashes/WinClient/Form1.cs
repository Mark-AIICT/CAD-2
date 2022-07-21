using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UploadWinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// the first tab is for uploading files, the second one is for downloading.
        /// when the user switches to the download tab, the list of files should be updated.
        /// </summary>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && this.lstFiles.Items.Count == 0)
                workerGetFileList.RunWorkerAsync();
        }

        #region upload UI code
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            this.txtFilePath.Text = this.openFileDialog1.FileName;
            if (File.Exists(this.openFileDialog1.FileName))
            {
                long FileSize = new FileInfo(this.openFileDialog1.FileName).Length;
                this.lblFileSizeUpload.Text = "File size " + FileTransferBase.GetFileSize(FileSize);
            }
        }

        /// <summary>
        /// The same button is used to start the upload, and cancel it. (the text changes as needed)
        /// </summary>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            switch (this.btnStartStop.Text)
            {
                case "Start Upload":
					if(this.fileTransferUpload1.IsBusy)
					{
						Thread.Sleep(1000);	// give it a chance to cancel if it is cancelling
						if(this.fileTransferUpload1.IsBusy)
							MessageBox.Show("Upload worker thread is still busy, please wait", "Busy");
						return;
					}
					this.statusText.Text = "Initialising upload...";
					this.lblUploadHash.Text = "";
					this.toolStripProgressBar1.Visible = true;
					this.toolStripProgressBar1.Value = 0;

					// set up the chunking options
					if(this.chkUploadAutoChunksize.Checked)
						this.fileTransferUpload1.AutoSetChunkSize = true;
					else
					{
						this.fileTransferUpload1.AutoSetChunkSize = false;
						this.fileTransferUpload1.ChunkSize = (int)this.chunkSizeUpload.Value * 1024;	// kb
					}
					// set the filepath and start the uploader
					this.fileTransferUpload1.LocalFilePath = this.txtFilePath.Text;
					this.fileTransferUpload1.RunWorkerAsync();     // start the background worker
                    this.btnStartStop.Text = "Cancel";                   
					break;
                case "Cancel":
                    this.toolStripProgressBar1.Visible = false;
					this.fileTransferUpload1.CancelAsync();        // request a cancel on the background worker
                    this.btnStartStop.Text = "Start Upload";
                    break;
            }
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            // don't enable the Start button if there is no file 
            this.btnStartStop.Enabled = (this.txtFilePath.Text != "");

            // clear the text in the label containing the file hash
            this.lblUploadHash.Text = "";
        }

		private void chkUploadAutoChunksize_CheckedChanged(object sender, EventArgs e)
		{
			this.chunkSizeUpload.Enabled = !this.chkUploadAutoChunksize.Checked;
		}

        #endregion
       
        #region download UI code
        private void btnRefreshFiles_Click(object sender, EventArgs e)
        {
            try
            {
                // refresh the list of files from the Upload folder on the server. 
                this.workerGetFileList.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// The same button is used to start the download, and cancel it. (the text changes as needed)
        /// Note: the upload and download operations have separate background workers. 
        /// </summary>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            switch (this.btnDownload.Text)
            {
                case "Download Selected File":
					if(this.lstFiles.SelectedIndex == -1)
                        return; // can't download unless a file is selected

					if(this.fileTransferDownload1.IsBusy)
					{
						Thread.Sleep(1000);	// give it a chance to cancel if it is cancelling
						if(this.fileTransferDownload1.IsBusy)
							MessageBox.Show("Download worker thread is still busy, please wait", "Busy");
						return;
					}
					this.lblDownloadHash.Text = "";
					this.statusText.Text = "Initialising download...";
					this.toolStripProgressBar1.Visible = true;
					this.toolStripProgressBar1.Value = 0;

					// set up the chunking options
					if(this.chkDownloadAutoChunkSize.Checked)
						this.fileTransferDownload1.AutoSetChunkSize = true;
					else
					{
						this.fileTransferDownload1.AutoSetChunkSize = false;
						this.fileTransferDownload1.ChunkSize = (int)this.chunkSizeDownload.Value * 1024;	// kb
					}
					// set the remote file name and start the background worker
					this.fileTransferDownload1.RemoteFileName = this.lstFiles.SelectedValue.ToString();
					this.fileTransferDownload1.LocalSaveFolder = Application.StartupPath;
					this.fileTransferDownload1.RunWorkerAsync();    
                    this.btnDownload.Text = "Cancel";
                    this.lblDownloadHash.Text = "";
                    break;
                case "Cancel":
                    this.toolStripProgressBar1.Visible = false;
					this.fileTransferDownload1.CancelAsync();      // request a cancel on the background worker
                    this.btnDownload.Text = "Download Selected File";
					break;
            }
        }

		private void chkDownloadAutoChunkSize_CheckedChanged(object sender, EventArgs e)
		{
			this.chunkSizeDownload.Enabled = !this.chkDownloadAutoChunkSize.Checked;
		}

		#endregion

		#region Get Server File List code
		/// <summary>
        /// This method fetches a string[] of filenames from the Upload folder on the server.
        /// </summary>
        private void workerGetFileList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error retrieving file list");
                return;
            }
            // copy the list of filenames into the listbox
            this.lstFiles.DataSource = e.Result as string[];
        }

        private void workerGetFileList_DoWork(object sender, DoWorkEventArgs e)
        {
			// fetch the list of filenames from the web service
            string[] files = this.fileTransferDownload1.WebService.GetFilesList();

			// set the result with the return value (available to workerGetFileList_RunWorkerCompleted method as e.Result)
            e.Result = files;
        }
        #endregion

		#region ProgressChanged and WorkerCompleted event handlers


		/// <summary>
		/// Shared by upload and download code
		/// </summary>
		private void fileTransfer_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// update the progress bar and status bar text
			this.toolStripProgressBar1.Value = e.ProgressPercentage;
			this.statusText.Text = e.UserState.ToString();  // summary text is sent in the UserState parameter
		}

		private void fileTransferDownload1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Error != null)
			{
				this.statusText.Text = "Download failed";
				MessageBox.Show(e.Error.Message, "Download Error");
			}
			else if(e.Cancelled)
				this.statusText.Text = "Download cancelled";
			else
			{
				this.statusText.Text = "Download complete";
				if(this.chkHashDownload.Checked)
					this.lblDownloadHash.Text = e.Result.ToString();
			}
			// reset the state of the download button and status bar text
			this.btnDownload.Text = "Download Selected File";
			this.toolStripProgressBar1.Visible = false;
		}


		private void fileTransferUpload1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Error != null)
			{
				this.statusText.Text = "Upload failed";
				MessageBox.Show(e.Error.Message, "Upload Error");
			}
			else if(e.Cancelled)
				this.statusText.Text = "Upload cancelled";
			else
			{
				this.statusText.Text = "Upload complete";
				if(this.chkHashUpload.Checked)
					this.lblUploadHash.Text = e.Result.ToString();
			}
			// reset the button and progress bar
			this.btnStartStop.Text = "Start Upload";
			this.toolStripProgressBar1.Visible = false;
		}
		#endregion

		private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.lblDownloadFileSize.Text = String.Format("File size: {0}", FileTransferBase.GetFileSize(this.fileTransferDownload1.WebService.GetFileSize(this.lstFiles.SelectedValue.ToString())));
		}
	}
}