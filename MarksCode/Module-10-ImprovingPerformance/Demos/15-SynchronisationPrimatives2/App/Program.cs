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
            SemaphoreSlim sph = new SemaphoreSlim(2); //two people are allowed at a time into the nightclub
            CountdownEvent cde = new CountdownEvent(3); //three people must have had a dance before the app is complete

            long N = 0;
            long X = 0;
            long Y = 0;

            Task T1 = new Task(() =>
            {
                sph.Wait(); //bouncer lets them in 
                Console.WriteLine("T1 is in...");

                //time for dancing
                for (long i = 0; i < 40000000M; i++)
                {
                    N += i;
                }
                Console.WriteLine("T1 is done...releasing semaphore");
                sph.Release(); //person leaves
                cde.Signal(1);  //Says on the way out "I just did some dancing"
               

            });

            Task T2 = new Task(() =>
            {
                sph.Wait();
                Console.WriteLine("T2 is in...");
                for (long i = 0; i < 40000000M; i++)
                {
                    X -= i;
                }
                Console.WriteLine("T2 is done...releasing semaphore");
                sph.Release();
                cde.Signal(1);


            });

            Task T3 = new Task(() =>
            {
                sph.Wait();
                Console.WriteLine("T3 is in...");
                for (long i = 0; i < 40000000M; i++)
                {
                    Y -= i;
                }
                Console.WriteLine("T3 is done...releasing semaphore");
                sph.Release();
                cde.Signal(1);


            });

            T1.Start();
            T2.Start();
            T3.Start();

            cde.Wait();

           

            Console.WriteLine(string.Format("N={0}, X={1}, y={2}", N, X, Y));
            Console.ReadLine();

        }
    }
}
