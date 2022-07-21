using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// A set of methods to upload and download chunks of a file using MTOM
/// </summary>
[WebService(Namespace = "URN://MTOMChunker")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MTOM : System.Web.Services.WebService
{
    private string UploadPath;
     
    public MTOM()
    {
        UploadPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"].ToString());
        if (!Directory.Exists(UploadPath))
            CustomSoapException("Upload Folder not found", "The folder " + UploadPath + " does not exist");
    }    

    #region Upload
    /// <summary>
    /// Append a chunk of bytes to a file.
    /// The client must ensure that all messages are in sequence. 
    /// This method always overwrites any existing file with the same name
    /// </summary>
    /// <param name="FileName">The name of the file that this chunk belongs to, e.g. MyImage.TIFF</param>
    /// <param name="buffer">The byte array</param>
    /// <param name="Offset">The size of the file (if the server reports a different size, an exception is thrown)</param>
    /// <param name="BytesRead">The length of the buffer</param>
    [WebMethod]
    public void AppendChunk(string FileName, byte[] buffer, long Offset, int BytesRead)
    {
        string FilePath = UploadPath + "\\" + FileName;

        // make sure that the file exists, except in the case where the file already exists and offset=0, i.e. a new upload, in this case create a new file to overwrite the old one.
        bool FileExists = File.Exists(FilePath);
        if (!FileExists || (File.Exists(FilePath) && Offset == 0))
            File.Create(FilePath).Close();       
        long FileSize = new FileInfo(FilePath).Length;

        // if the file size is not the same as the offset then something went wrong....
        if (FileSize != Offset)
            CustomSoapException("Transfer Corrupted", String.Format("The file size is {0}, expected {1} bytes", FileSize, Offset));
        else
        {
            // offset matches the filesize, so the chunk is to be inserted at the end of the file.
            using(FileStream fs = new FileStream(FilePath, FileMode.Append))
                fs.Write(buffer, 0, BytesRead);
        }
    }
    #endregion

    #region download

    /// <summary>
    /// Download a chunk of a file from the Upload folder on the server. 
    /// </summary>
    /// <param name="FileName">The FileName to download</param>
    /// <param name="Offset">The offset at which to fetch the next chunk</param>
    /// <param name="BufferSize">The size of the chunk</param>
    /// <returns>The chunk as a byte[]</returns>
    [WebMethod]
    public byte[] DownloadChunk(string FileName, long Offset, int BufferSize)
    {
        string FilePath = UploadPath + "\\" + FileName;
        
        // check that requested file exists
        if (!File.Exists(FilePath))
            CustomSoapException("File not found", "The file " + FilePath + " does not exist");

        long FileSize = new FileInfo(FilePath).Length;

        // if the requested Offset is larger than the file, bail out.
        if (Offset > FileSize)
            CustomSoapException("Invalid Download Offset", String.Format("The file size is {0}, received request for offset {1}", FileSize, Offset));
        
        // open the file to return the requested chunk as a byte[]
        byte[] TmpBuffer;
        int BytesRead;
        using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
        {
            fs.Seek(Offset, SeekOrigin.Begin);	// this is relevent during a retry. otherwise, it just seeks to the start
            TmpBuffer = new byte[BufferSize];
            BytesRead = fs.Read(TmpBuffer, 0, BufferSize);	// read the first chunk in the buffer (which is re-used for every chunk)
        }
        if (BytesRead != BufferSize)
        {
            // the last chunk will almost certainly not fill the buffer, so it must be trimmed before returning
            byte[] TrimmedBuffer = new byte[BytesRead];
            Array.Copy(TmpBuffer, TrimmedBuffer, BytesRead);
            return TrimmedBuffer;
        }
        else
            return TmpBuffer;
    }

    /// <summary>
    /// Get the number of bytes in a file in the Upload folder on the server.
    /// The client needs to know this to know when to stop downloading
    /// </summary>
    [WebMethod]
    public long GetFileSize(string FileName)
    {
        string FilePath = UploadPath + "\\" + FileName;

        // check that requested file exists
        if (!File.Exists(FilePath))
            CustomSoapException("File not found", "The file " + FilePath + " does not exist");

        return new FileInfo(FilePath).Length;
    }

    /// <summary>
    /// Return a list of filenames from the Upload folder on the server
    /// </summary>
    [WebMethod]
    public List<string> GetFilesList()
    {
        List<string> files = new List<string>();
        foreach (string s in Directory.GetFiles(UploadPath))
            files.Add(Path.GetFileName(s));
        return files;
    }
    #endregion

    #region file hashing
    [WebMethod]
    public string CheckFileHash(string FileName)
    {
        string FilePath = UploadPath + "\\" + FileName;
        SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        byte[] hash;
        using(FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096))
            hash = sha1.ComputeHash(fs);
        return BitConverter.ToString(hash);
    }
    #endregion

    #region Exception Handling
    /// <summary>
    /// Throws a soap exception.  It is formatted in a way that is more readable to the client, after being put through the xml serialisation process
    /// Typed exceptions don't work well across web services, so these exceptions are sent in such a way that the client
    /// can determine the 'name' or type of the exception thrown, and any message that went with it, appended after a : character.
    /// </summary>
    /// <param name="exceptionName"></param>
    /// <param name="message"></param>
    public static void CustomSoapException(string exceptionName, string message)
    {
        throw new System.Web.Services.Protocols.SoapException(exceptionName + ": " + message, new System.Xml.XmlQualifiedName("BufferedUpload"));
    }

    /// <summary>
    /// A dummy method to check the connection to the web service
    /// </summary>
    [WebMethod]
    public void Ping()
    {
    }
    #endregion
}