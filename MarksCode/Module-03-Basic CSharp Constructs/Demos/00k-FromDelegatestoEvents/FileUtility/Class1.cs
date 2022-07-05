using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUtility
{
    public class Util
    {
        public delegate void FeedbackMessage(string message);
        public event FeedbackMessage FeedbackEvent;

        public FeedbackMessage pointerToFeedback;


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
                if (FeedbackEvent != null)
                    FeedbackEvent($"Processing file: {file}");
                totalBytesFound += file.Length;
                System.Threading.Thread.Sleep(20);
            }
            return totalBytesFound;
        }
    }
}
