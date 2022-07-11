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

            Console.WriteLine("please type a sentence");
            string data = Console.ReadLine();

            File.AppendAllText(filePath, data);

            Console.WriteLine($"your data was saved at {filePath}\n");
            Console.WriteLine("press any key to end");
            Console.ReadKey();




        }
    }
}
