using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileUtility
{
    public class Util
    {
        /// <summary>
        /// Accepts a file path and returns the total bytes found for all files 
        /// </summary>
        /// <param name="path">the file path</param>
        /// <returns>the total bytes</returns>
        public long ProcessFiles(string path)
        {
            long totalBytesFound = 0;
            foreach (var file in Directory.GetFiles(path))
            {

                totalBytesFound += file.Length;
                System.Threading.Thread.Sleep(20);
            }
            return totalBytesFound;
        }
    }
}
