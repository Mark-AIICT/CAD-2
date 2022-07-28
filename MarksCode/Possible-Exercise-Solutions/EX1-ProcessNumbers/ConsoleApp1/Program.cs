using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> allTheNumbers = new List<decimal>();

            decimal nextNumber = 0;
            while (GetNextNumber(out nextNumber))
            {
                allTheNumbers.Add(nextNumber);
            }
            Console.WriteLine("\n\n\nResults:");
            if (allTheNumbers.Count>0)
            {
                Console.WriteLine($"The smallest number was {allTheNumbers.Min()}");
                Console.WriteLine($"The largest number was {allTheNumbers.Max()}");
                Console.WriteLine($"The sum of all the numbers is {allTheNumbers.Sum()}");
                Console.WriteLine($"The average of all the numbers is {allTheNumbers.Average()}"); 
            }
            else
                Console.WriteLine("You didn't add any numbers, there's nothing to see");

            Console.ReadKey();
        }

        /// <summary>
        /// Gets the next valid decimal number from the user
        /// </summary>
        /// <param name="nextNumber">The decimal number entered by the user</param>
        /// <returns>TRUE, if the user enters a valid decimal or FALSE if they typed "done"</returns>
        static bool GetNextNumber(out decimal nextNumber)
        {
            Console.WriteLine("Type a number and press <enter>, or type 'done' to see the results");
            while (true) //keep asking the user for a number that is a valid decimal or is the word "done"
            {
                var valueEntered = Console.ReadLine();

                if (!decimal.TryParse(valueEntered, out nextNumber))
                {
                    if (valueEntered == "done")
                        return false;
                    Console.WriteLine($"{valueEntered} is not a number, please only enter decimals");
                }
                else
                    return true; 
            }
        }
    }
}
