using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UtilsApp
{
    public class FileUtil
    {
        public delegate void FBDelegate(object sender, ProgressEventArgs e);
        public event FBDelegate ProgressUpdate;

        public int GetFileCount(string path)
        {
            int count=0;
            foreach (var file in Directory.GetFiles(path))
            {
                if (count % 30 == 0)
                {
                    System.Threading.Thread.Sleep(50);
                    if (ProgressUpdate != null)
                        ProgressUpdate(this,
                                       new ProgressEventArgs() { ProgressInfo = "Processed " + count.ToString() + " files" });
                }

                count++;
            }
            return count;
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public string ProgressInfo { get; set; }
    }
}
