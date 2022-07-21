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
	/// A class to upload a file to a web server using WSE 3.0 web services, with the MTOM standard.
	/// To use this class, drag/drop an instance onto a windows form, and create event handlers for ProgressChanged
	/// and RunWorkerCompleted.  
	/// Make sure to specify the LocalFilePath before you call RunWorkerAsync() to begin the upload
	/// </summary>
	public class FileTransferUpload : FileTransferBase
	{

		/// <summary>
		/// This method starts the uplaod process. It supports cancellation, reporting progress, and exception handling.
		/// </summary>
		protected override void OnDoWork(DoWorkEventArgs e)
		{
			base.OnDoWork(e);
			
			int numIterations = 0;
			this.LocalFileName = Path.GetFileName(this.LocalFilePath);
			if(this.AutoSetChunkSize)
				this.ChunkSize = 16 * 1024;
			
			if(!File.Exists(LocalFilePath))
				throw new Exception(String.Format("Could not find file {0}", LocalFilePath));

			long FileSize = new FileInfo(LocalFilePath).Length;
			string FileSizeDescription = GetFileSize(FileSize); // e.g. "2.4 Gb" instead of 240000000000000 bytes etc...
			long SentBytes = 0;   // this variable is used to inform the user interface of the upload progress
			byte[] Buffer = new byte[ChunkSize];    // this buffer stores each chunk, for sending to the web service via MTOM

			using(FileStream fs = new FileStream(this.LocalFilePath, FileMode.Open, FileAccess.Read))
			{
				int BytesRead = fs.Read(Buffer, 0, ChunkSize);	// read the first chunk in the buffer

				// send the chunks to the web service one by one, until FileStream.Read() returns 0, meaning the entire file has been read.
				while(BytesRead > 0 && !this.CancellationPending)
				{
					try
					{
						// send this chunk to the server.  it is sent as a byte[] parameter, but the client and server have been configured to encode byte[] using MTOM. 
						this.WebService.AppendChunk(this.LocalFileName, Buffer, SentBytes, BytesRead);

						if(numIterations == 1)	// don't include the first chunk in the average because it may involve an initial delay in connecting to the web service
							this.StartTime = DateTime.Now;	// used to calculate the time taken to transfer the first 5 chunks

						if(this.AutoSetChunkSize && numIterations == AverageSample+1)		// take an average of the first 5 transfers
						{
							long timeForInitialChunks = (long)DateTime.Now.Subtract(StartTime).TotalMilliseconds;
							long averageChunkTime = Math.Max(1, timeForInitialChunks / AverageSample);	// average of 5 chunks, in ms
							this.ChunkSize = (int)Math.Min(4000000, this.ChunkSize * PreferredTransferDuration / averageChunkTime);	// set the chunk size so that it takes 2 seconds per chunk (estimate), but not greater than 4mb
							Buffer = new byte[ChunkSize];    // reset the size of the buffer for the new chunksize
						}

						// sentBytes is only updated AFTER a successful send of the bytes. so it would be possible to build in 'retry' code, to resume the upload from the current SentBytes position if AppendChunk fails.
						SentBytes += BytesRead;

						// update the user interface
						string SummaryText = String.Format("Transferred {0} / {1}", GetFileSize(SentBytes), FileSizeDescription);
						this.ReportProgress((int)(((decimal)SentBytes / (decimal)FileSize) * 100), SummaryText);
					}
					catch(Exception ex)
					{
						Debug.WriteLine("Exception: " + ex.ToString());
						if(NumRetries++ < MaxRetries)
						{
							// rewind the filestream and keep trying
							fs.Position -= BytesRead;
						}
						else
						{
							fs.Close();
							throw new Exception(String.Format("Error occurred during upload, too many retries. \n{0}", ex.ToString()));
						}
					}
					BytesRead = fs.Read(Buffer, 0, ChunkSize);	// read the next chunk (if it exists) into the buffer.  the while loop will terminate if there is nothing left to read
					numIterations++;
				}
			}
			if(this.IncludeHashVerification)
			{
				this.ReportProgress(99, "Checking file hash...");

				// start calculating the local hash
				this.HashThread = new Thread(new ThreadStart(this.CheckLocalFileHash));
				this.HashThread.Start();

				// request the server hash
				this.RemoteFileHash = this.WebService.CheckFileHash(this.LocalFileName);

				// wait for the local hash to complete
				this.HashThread.Join();

				if(this.LocalFileHash == this.RemoteFileHash)
					e.Result = String.Format("Hashes match exactly\nLocal hash:  {0}\nServer hash: {1}", LocalFileHash, RemoteFileHash);
				else    // could throw an exception here if you want.  different hashes indicates a corrupt upload
					e.Result = String.Format("Hashes are different!\nLocal hash:  {0}\nServer hash: {1}", LocalFileHash, RemoteFileHash);
			}
		}
	}
}
