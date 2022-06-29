using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList x;

            int filecount=GetFiles(@"C:\Windows\system32", out x);

            Console.WriteLine($"The number of files in C:\\Windows\\system32 is {filecount}. Press enter to see them all.");
            Console.ReadLine();

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("OK. Done. Press enter to finish");

            Console.ReadLine();
        }

        static int GetFiles(string path, out ArrayList fileNames)
        {
            int fileCount = 0;
            fileNames = new ArrayList();
            foreach (var item in Directory.GetFiles(path))
            {
                fileCount++;
                fileNames.Add(item);
            }


            return fileCount;
        }
    }
}
