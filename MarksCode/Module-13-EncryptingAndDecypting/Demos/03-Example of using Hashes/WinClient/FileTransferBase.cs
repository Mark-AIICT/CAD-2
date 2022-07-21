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
	/// Contains common functionality for the upload and download classes
	/// This class should really be marked abstract but VS doesn't like that because it can't draw it as a component then :(
	/// </summary>
	public class FileTransferBase : BackgroundWorker
	{
        protected MTOM_WebService.MTOM ws;		// the web service object
		public bool AutoSetChunkSize = true;	// take a sample of 5 small chunks and then change the chunk size to suit the bandwidth capacity.  bigger capacity = bigger chunks = more efficient.
		public int ChunkSize = 16 * 1024;		// 16k by default
		public int MaxRetries = 50;				// max number of corrupted chunks to allow before giving up
		protected int NumRetries = 0;	
		public int AverageSample = 5;			// number of chunks to sample the average transfer time for, to use with AutoSetChunkSize
		public bool IncludeHashVerification = true;	// checks the local file hash against the uploaded file hash to verify that the files are identical
		public int PreferredTransferDuration = 1500;	// miliseconds, the timespan the class will attempt to achieve for each chunk
		protected string LocalFileName;			
		protected DateTime StartTime;
		protected Thread HashThread;
		public string LocalFileHash;			// the user can access the local file hash after the upload is complete and the hash has been calculated
		public string RemoteFileHash;			// as above
		public string LocalFilePath;			// this variable must be set prior to starting an Upload.  
        public FileTransferBase()
		{
			base.WorkerReportsProgress = true;
			base.WorkerSupportsCancellation = true;			
		}
        		public MTOM_WebService.MTOM WebService
		{
			get
			{
				if(this.ws == null)
                    ws = new UploadWinClient.MTOM_WebService.MTOM();
				return ws;
			}
		}
		protected override void Dispose(bool disposing)
		{
			if(this.HashThread != null && this.HashThread.IsAlive)
				this.HashThread.Abort();
            base.Dispose(disposing);
		}
		protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
		{
			if(this.HashThread != null && this.HashThread.IsAlive)
				this.HashThread.Abort();
			
			base.OnRunWorkerCompleted(e);
		}
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			// make sure we can connect to the web service.  if this step is not done here, it will retry 50 times because of the retry code...
			this.WebService.Ping();
			base.OnDoWork(e);
		}
		/// <summary>
		/// Returns a description of a number of bytes, in appropriate units.
		/// e.g. 
		///		passing in 1024 will return a string "1 Kb"
		///		passing in 1230000 will return "1.23 Mb"
		/// Megabytes and Gigabytes are formatted to 2 decimal places.
		/// Kilobytes are rounded to whole numbers.
		/// If the rounding results in 0 Kb, "1 Kb" is returned, because Windows behaves like this also.
		/// </summary>
		public static string GetFileSize(long numBytes)
		{
			string fileSize = "";
			if(numBytes > 1073741824)
				fileSize = String.Format("{0:0.00} Gb", (double)numBytes / 1073741824);
			else if(numBytes > 1048576)
				fileSize = String.Format("{0:0.00} Mb", (double)numBytes / 1048576);
			else
				fileSize = String.Format("{0:0} Kb", (double)numBytes / 1024);

			if(fileSize == "0 Kb")
				fileSize = "1 Kb";	// min.							
			return fileSize;
		}
		/// <summary>
		/// This method is intended to be run on a background thread. 
		/// </summary>
		protected void CheckLocalFileHash()
		{
			SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
			byte[] hash;
			using(FileStream fs = new FileStream(this.LocalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096))
				hash = sha1.ComputeHash(fs);
			this.LocalFileHash = BitConverter.ToString(hash);
		}
	}
}