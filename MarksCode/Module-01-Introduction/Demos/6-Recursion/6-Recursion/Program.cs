using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            long value = Factorial(10);
            Console.Out.WriteLine(value);
            
        }
        static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
    }
}
