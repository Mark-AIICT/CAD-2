using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UploadWinClient
{
	/// <summary>
	/// A class to download a file from a web server using WSE 3.0 web services, with the MTOM standard.
	/// To use this class, drag/drop an instance onto a windows form, and create event handlers for ProgressChanged
	/// and RunWorkerCompleted.  
	/// Make sure to specify the RemoteFileName and LocalSaveFolder before you call RunWorkerAsync() to begin the download
	/// </summary>
	public class FileTransferDownload : FileTransferBase
	{
		public string RemoteFileName;
		public string LocalSaveFolder;

		/// <summary>
		/// This method starts the download process. It supports cancellation, reporting progress, and exception handling.
		/// </summary>
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			base.OnDoWork(e);

			int numIterations = 0;
			this.StartTime = DateTime.Now;	// used to calculate the time taken to transfer the first 5 chunks

			this.LocalFilePath = this.LocalSaveFolder.TrimEnd('\\') + "\\" + RemoteFileName;
			if(File.Exists(this.LocalFilePath))   // create a new empty file
				File.Create(this.LocalFilePath).Close();

			long FileSize = this.WebService.GetFileSize(this.RemoteFileName);   // the file is on the server and we need to know how big it is before we start downloading, in order to give accurate feedback to the user.
			string FileSizeDescription = GetFileSize(FileSize);   // e.g. "2.4 Gb" instead of 24000000000000000 bytes etc.
			long ReceivedBytes = 0; // this variable is used to allow the code to know when to stop requesting chunks

			// open a file stream for the file we will write to in the start-up folder
			using(FileStream fs = new FileStream(LocalFilePath, FileMode.Append, FileAccess.Write))
			{
				// download the chunks from the web service one by one, until all the bytes have been read, meaning the entire file has been downloaded.
				while(ReceivedBytes < FileSize && !this.CancellationPending)
				{
					if(this.AutoSetChunkSize && numIterations == AverageSample)		// take an average of the first 5 transfers
					{
						long timeForInitialChunks = (long)DateTime.Now.Subtract(StartTime).TotalMilliseconds;
						long averageChunkTime = Math.Max(1, timeForInitialChunks / AverageSample);	// average of 5 chunks, in ms
						this.ChunkSize = (int)Math.Min(4000000, this.ChunkSize * PreferredTransferDuration / averageChunkTime);	// set the chunk size so that it takes 2 seconds per chunk (estimate), but not greater than 4mb
					}

					try
					{
						// although the DownloadChunk returns a byte[], it is actually sent using MTOM because of the configuration settings. 
						byte[] Buffer = this.WebService.DownloadChunk(this.RemoteFileName, ReceivedBytes, ChunkSize);
						fs.Write(Buffer, 0, Buffer.Length);
						ReceivedBytes += Buffer.Length;
					}
					catch(Exception ex)
					{
						Debug.WriteLine("Exception: " + ex.ToString());
						if(NumRetries++ < MaxRetries)
						{
							// swallow the exception and try again
						}
						else
						{
							fs.Close();
							throw new Exception(String.Format("Error occurred during upload {0}, too many retries.", ex.Message));
						}
					}
					// update the user interface by reporting progress.
					string SummaryText = String.Format("Transferred {0} / {1}", GetFileSize(ReceivedBytes), FileSizeDescription);
					this.ReportProgress((int)(((decimal)ReceivedBytes / (decimal)FileSize) * 100), SummaryText);
					numIterations++;
				}
			}


			// the user may select to have the local file hash-verified against the server file
			if(this.IncludeHashVerification)
			{
				this.ReportProgress(99, "Checking file hash...");

				// start calculating the local hash
				this.HashThread = new Thread(new ThreadStart(this.CheckLocalFileHash));
				this.HashThread.Start();

				// request the server hash
				this.RemoteFileHash = this.WebService.CheckFileHash(this.RemoteFileName);

				// wait for the local hash to complete
				this.HashThread.Join();

				if(this.LocalFileHash == RemoteFileHash)
					e.Result = String.Format("Hashes match exactly\nLocal hash:  {0}\nServer hash: {1}", LocalFileHash, RemoteFileHash);
				else    // could throw an exception here if you want.  different hashes = corrupt download!
					e.Result = String.Format("Hashes are different!\nLocal hash:  {0}\nServer hash: {1}", LocalFileHash, RemoteFileHash);
			}
		}
	}
}
