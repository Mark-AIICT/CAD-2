using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "A";

            DateTime start = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                x += "B";
            }
            Double duration = DateTime.Now.Subtract(start).TotalMilliseconds;

            Console.WriteLine("string took {0} milliseconds", duration.ToString());
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            StringBuilder s = new StringBuilder();

            start = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                s.Append("B");
            }
            duration = DateTime.Now.Subtract(start).TotalMilliseconds;

            Console.WriteLine("StringBuilder took {0} milliseconds", duration.ToString());
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }
    }
}
