using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var outer = Task.Run(() =>
            {
                Console.WriteLine("Outer task starting…");
                var inner = Task.Run(() =>
                {
                    Console.WriteLine("Nested task starting…");
                    decimal result = 0;
                    for (decimal i = 0; i < Convert.ToDecimal(9000000M); i++)
                    {
                        result += i;
                    }
                    Console.WriteLine("Nested task completing…");
                });
            });
            outer.Wait();
            Console.WriteLine("Outer task completed.");


            Console.WriteLine("All done. Press enter to exit");
            Console.ReadLine();
        }
    }
}
