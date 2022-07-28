using Cuber;
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
            Console.WriteLine("type a number");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"The cube of {number} is {MathOps.Cube(number)}");
            Console.ReadLine();
        }
    }
}
