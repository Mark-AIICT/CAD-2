using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _00_AnotherLinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] theFiles = Directory.GetFiles(@"C:\windows\system32");
            var xfiles = from f in theFiles
                         where f.Contains("xy")
                         select f;

            foreach (var file in xfiles)
            {
                Console.WriteLine(file);
            }

            Console.ReadLine();

        }
    }
}
