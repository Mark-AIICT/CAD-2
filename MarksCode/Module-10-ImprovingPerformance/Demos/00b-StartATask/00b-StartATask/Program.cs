using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_StartATask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a number");
            string x = Console.ReadLine();


            Task T = new Task(p =>
            {
                Console.WriteLine("Calculation has started. Please wait....");
                DoSomethingThatTakesALongTime();
                Console.Write($"the cube of {p} is ");
                Console.WriteLine(Convert.ToInt32(p) * Convert.ToInt32(p) * Convert.ToInt32(p));
            }, x);


            T.Start();
            T.Wait();

            Console.WriteLine("Ok, we're done. press <enter> to end");
            Console.ReadLine();

        }

        private static void DoSomethingThatTakesALongTime()
        {
            decimal result = 0;
            for (decimal i = 0; i < 100000000M; i++)
            {
                result += i;
            }
        }
    }
}
 