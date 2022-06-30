using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00a_OverloadedMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The cube of 4 is " + Cube(4));
            Console.WriteLine($"The cube of 5 is " + Cube("5"));
            Console.ReadLine();

        }

        static int Cube(int x)
        {
            return x * x * x;
        }

        static int Cube(string x)
        {
            int z = Convert.ToInt32(x);
            return z * z * z;
        }
    }
}
