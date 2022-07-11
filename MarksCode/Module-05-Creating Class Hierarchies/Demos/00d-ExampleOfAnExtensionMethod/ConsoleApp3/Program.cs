using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = "the tree got into the shopping cart which got into the car, which got into the spaceship";

            Console.WriteLine($"The word 'into' appears {words.WordCount("into")} Times");

            Console.ReadLine();
        }
    }
    public static class SpecialStringMethods
    {
        public static int WordCount(this string theStringBeingSearched, string searchString)
        {
            var words = theStringBeingSearched.Split(' ');
            int result = 0;
            foreach (var word in words)
            {
                if (word == searchString)
                    result++;
            }
            return result;
        }
    }
}
