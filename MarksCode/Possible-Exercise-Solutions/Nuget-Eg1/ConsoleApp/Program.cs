using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a number");
            int number = Convert.ToInt32(Console.ReadLine());
            int result = MathLib.MathOps.Cube(number);
            Console.WriteLine($"The cube of {number} is {result}");
            Console.ReadLine();
        }
    }
}
