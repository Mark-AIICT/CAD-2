using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00a_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"c:\temp\Sentence.txt";
            FileInfo fi = new FileInfo(filePath);

            Console.WriteLine("please type a sentence");
            string data = Console.ReadLine();

            Console.WriteLine($"The file extension is {fi.Extension}");
            Console.WriteLine($"The file path is {fi.FullName}");
            Console.WriteLine($"The file directory is {fi.Directory}");
            Console.WriteLine($"The file name is {fi.Name}");

            var writer = fi.AppendText();
            writer.Write(data);
            writer.Close();

            Console.WriteLine("press any key to end");
            Console.ReadKey();




        }
    }
}
