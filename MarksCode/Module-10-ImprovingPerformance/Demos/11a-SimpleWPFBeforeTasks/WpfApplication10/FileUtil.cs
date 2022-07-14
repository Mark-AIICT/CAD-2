using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication10
{
    public class FileUtil
    {
        public long GetTotalBytes(string path)
        {
            long result = 0;
            foreach (var file in Directory.GetFiles(path))
            {
                result += File.ReadAllBytes(file).Length;
            }

            return result;
        }
    }
}
