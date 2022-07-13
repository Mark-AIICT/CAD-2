using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        static void PlaceOrders()
        {

            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                String order = String.Format("Coffee Order {0}", i);
                queue.Enqueue(order);
                Console.WriteLine("Added {0}", order);
            }
        }
        static void ProcessOrders()
        {
           
            string order;
            while (true) //continue indefinitely
            {
                Thread.Sleep(150);
                if (queue.TryDequeue(out order))
                {
                    Console.WriteLine("Processed {0}", order);
                }
            }
        }
        static void Main(string[] args)
        {
            var taskPlaceOrders = Task.Run(() => PlaceOrders());
            Task.Run(() => ProcessOrders());  
            Task.Run(() => ProcessOrders());
            Task.Run(() => ProcessOrders());
            taskPlaceOrders.Wait();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
