using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a task that returns a string.
            Task<string> firstTask = new Task<string>(() => "Hello");

            // Create the continuation task.
            // The delegate takes the result of the antecedent task as an argument.
            Task<string> secondTask = firstTask.ContinueWith((x) =>
                                            {
                                                DoSomethingThatTakesALongTime();
                                                return String.Format($"{ x.Result}, World!");
                                            }
            );

            // Start the antecedent task.
            firstTask.Start();
            secondTask.Wait();
            Console.WriteLine(secondTask.Result);
            Console.WriteLine("Done. Press enter to exit");
            Console.ReadLine();
        }

        private static void DoSomethingThatTakesALongTime()
        {
            decimal result = 0;
            for (decimal i = 0; i < 10000000M; i++)
            {
                result += i;
            }

        }
    }
}
