using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.MaxValue;
            long b = long.MaxValue;
            Console.WriteLine($"a is {a}, b is {b}");


            //b = a;

            a = (int)b;
            //OR, better
            //a = Convert.ToInt32(b);

            Console.WriteLine($"a is {a}, b is {b}");
            Console.ReadLine();

        }
    }
}
