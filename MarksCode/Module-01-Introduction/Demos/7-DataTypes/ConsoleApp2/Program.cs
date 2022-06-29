using System;
using System.Data.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int price;
            price = 0;
            Console.WriteLine($"price is {price}");

            Console.WriteLine($"The largest integer is {int.MaxValue}");
            Console.WriteLine($"The largest long is {long.MaxValue}");
            Console.WriteLine($"The largest float is {float.MaxValue}");
            Console.WriteLine($"The largest double is {double.MaxValue}");
            Console.WriteLine($"The largest decimal is {decimal.MaxValue}");


            Console.WriteLine(DateTime.Now.Hour>12?"It's afternoon":"It's Morning");

            StringBuilder sb = new StringBuilder();

            int x = new int();
            
            Console.ReadLine();
        }
    }
}
