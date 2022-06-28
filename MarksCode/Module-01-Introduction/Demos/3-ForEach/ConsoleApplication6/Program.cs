using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] filenames = Directory.GetFiles(@"C:\windows\system32");

            for (int i = 0; i < filenames.Length; i++)
            {
                Console.WriteLine(filenames[i]);
            }

            foreach (var f in filenames)
            {
                Console.WriteLine(f);
            }


            Console.WriteLine("OK, Done. Press any key to end");
            Console.ReadLine();
        }
    }
}
