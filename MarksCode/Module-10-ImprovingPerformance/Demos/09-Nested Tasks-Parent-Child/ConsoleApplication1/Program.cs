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
            Task parent = new Task(() =>
            {
                Console.WriteLine("Parent task starting…");
                
                Task child = new Task(() =>
                {
                    Console.WriteLine("Child task starting…");
                    decimal result = 0;
                    for (decimal i = 0; i < Convert.ToDecimal(9000000M); i++)
                    {
                        result += i;
                    }
                    Console.WriteLine("Child task completing…");
                    
                }, TaskCreationOptions.AttachedToParent);
                child.Start();
            });

            parent.Start();
            parent.Wait();
            Console.WriteLine("Parent task completed.");

            Console.WriteLine("All done. Press enter to exit");
            Console.ReadLine();
        }
    }
}
