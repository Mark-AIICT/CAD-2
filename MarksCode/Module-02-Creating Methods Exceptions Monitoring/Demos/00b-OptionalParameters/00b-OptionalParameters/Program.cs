using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_OptionalParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddThem(44, 55, 77, 88));
            Console.WriteLine(AddThem(44, 55, 77));
            Console.WriteLine(AddThem(44, 55));
            Console.WriteLine(AddThem(44, 55, d:6));

            Console.ReadLine();



        }

        static int AddThem(int a, int b, int c=0, int d=0)
        {
            return a + b + c + d;
        }
    }
}
