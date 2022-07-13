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
        public async Task<long> GetTotalBytesAsync(string path, Action<string> callback)
        {
            long result = 0;
            Task Tsk = new Task(p =>
            {
                if (callback != null)
                    callback("Processing files below " + path);

                foreach (var file in Directory.GetFiles(path))
                {
                    if (callback != null)
                        callback("bytes so far " + result.ToString());

                    result += File.ReadAllBytes(file).Length;
                }
            }, path);

            Tsk.Start();
            await Tsk;

            return result;
        }
    }
}
