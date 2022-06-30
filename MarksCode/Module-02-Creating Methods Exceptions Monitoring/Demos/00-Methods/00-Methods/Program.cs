using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int y = 9;
            int result = Cube(y);
            Console.WriteLine($"The cube of {y} is {result} ");
            Console.ReadLine();

        }

        static int Cube(int x)
        {
            return x * Square(x);
        }

        static int Square(int x)
        {
            return x * x;
        }


    }
}
