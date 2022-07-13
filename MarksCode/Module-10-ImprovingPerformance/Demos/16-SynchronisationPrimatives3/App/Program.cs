using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Barrier barrier = new Barrier(4, new Action<Barrier>((b) => Console.WriteLine("OK, barrier done")));


            decimal N = 0;
            decimal X = 0;
            decimal Y = 0;
            decimal divisor = 0;

            Task T1 = new Task(() =>
            {
                Console.WriteLine("T1 is in...");
                for (decimal i = 0; i < 40000000M; i++)
                {
                    
                    N += i;
                }
                Console.WriteLine("T1 is waiting.");
                barrier.SignalAndWait();
                Console.WriteLine("40000000! divided by {0} is {1}",divisor, N/divisor);
            });

            Task T2 = new Task(() =>
            {
                Console.WriteLine("T2 is in...");
                for (decimal i = 0; i < 8270000; i++)
                {

                    X += i;
                }
                Console.WriteLine("T2 is waiting.");
                barrier.SignalAndWait();
                Console.WriteLine("8270000! divided by {0} is {1}", divisor, X / divisor);
            });

            Task T3 = new Task(() =>
            {
                Console.WriteLine("T3 is in...");
                for (decimal i = 0; i < 220000M; i++)
                {
                    Y -= i;
                }
                Console.WriteLine("T3 is waiting.");
                barrier.SignalAndWait();
                Console.WriteLine("220000M! divided by {0} is {1}", divisor, Y / divisor);


            });

            T1.Start();
            T2.Start();
            T3.Start();

            Console.WriteLine("Type a number between 1 and 10");
            divisor = Convert.ToInt64(Console.ReadLine());

            barrier.SignalAndWait();
            Console.ReadLine();

        }
    }
}
