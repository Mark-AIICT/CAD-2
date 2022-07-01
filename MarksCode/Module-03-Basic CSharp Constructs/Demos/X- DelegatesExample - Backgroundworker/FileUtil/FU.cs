using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace FileUtil
{
    public class FU
    {
        public delegate void FileFoundDelegate(object sender, FileFoundEventArgs e);
        public event FileFoundDelegate FileFound;

        public int GetFiles(string path)
        {
            
            int filesFound = 0;
            foreach (var item in Directory.GetFiles(path))
            {
                //System.Threading.Thread.Sleep(2000);
                filesFound++;
                OnFileFound(item);
                     
            }
            return filesFound;
 
        }

        protected virtual void OnFileFound(string item)
        {
            if (null != FileFound)
                FileFound(this, new FileFoundEventArgs() { Details = item });
        }
    }

    public class FileFoundEventArgs : EventArgs
    {
        public string Details { get; set; }
    }
}
