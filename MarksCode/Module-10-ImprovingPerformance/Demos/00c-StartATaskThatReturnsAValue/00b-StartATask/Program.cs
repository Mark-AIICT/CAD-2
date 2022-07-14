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


            Task<int> T = new Task<int>(p =>
            {
                DoSomethingThatTakesALongTime();
                return Convert.ToInt32(p) * Convert.ToInt32(p) * Convert.ToInt32(p);
            }, x);


            T.Start();
            T.Wait();

            Console.WriteLine($"The cube of {x} is {T.Result}");

            Console.WriteLine("Ok, we're done. press <enter> to end");
            Console.ReadLine();

        }

        private static void DoSomethingThatTakesALongTime()
        {
            decimal result = 0;
            for (decimal i = 0; i < 30000000M; i++)
            {
                result += i;
            }
        }
    }
}
 