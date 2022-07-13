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
            Task<string> secondTask = firstTask.ContinueWith((antecedent) => String.Format("{0}, World!", antecedent.Result));

            // Start the antecedent task.
            firstTask.Start();

            secondTask.Wait();
            Console.WriteLine(secondTask.Result);
            Console.WriteLine("Done. Press enter to exit");
            Console.ReadLine();
        }
    }
}
