using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DelegateExample
{
    public struct FileUtil
    {
        public delegate void FeedbackFormat(string message);

        static public event FeedbackFormat ProcessingFile;

       

        static public long CountBytes(string path)
        {
            long totalBytes=0;
            foreach (var file in Directory.GetFiles(path))
            {
                try
                {
                    if (ProcessingFile != null)
                        ProcessingFile("File being processed=" + file);
                    totalBytes += File.ReadAllBytes(file).Length;
                }
                catch (Exception)
                {
 
                }
            }
            return totalBytes;
        }
    }
}
