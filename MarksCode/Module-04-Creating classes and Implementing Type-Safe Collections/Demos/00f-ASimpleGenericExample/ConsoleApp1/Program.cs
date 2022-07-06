using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 5, y = 9;
            Console.WriteLine($"Before x={x}, y={y}");
            Swap<int>(ref x, ref y);
            Console.WriteLine($"After x={x}, y={y}");

            decimal first = 33M, second = 669M;
            Console.WriteLine($"Before first={first}, second={second}");
            Swap<decimal>(ref first, ref second);
            Console.WriteLine($"After first={first}, second={second}");
            

            string firstName = "Kiri", secondName = "Wong";
            Console.WriteLine($"Before firstName={firstName}, secondName={secondName}");
            Swap<string>(ref firstName, ref secondName);
            Console.WriteLine($"After firstName={firstName}, secondName={secondName}");

            Console.ReadLine();


        }

        static void Swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c;
        }
    }
}
