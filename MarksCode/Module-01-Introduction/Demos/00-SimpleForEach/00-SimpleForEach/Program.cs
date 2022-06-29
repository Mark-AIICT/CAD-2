using System;

namespace _00_SimpleForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] foods = new string[] { "Cake", "Sudza", "Kiribath" };

            for (int i = 0; i < foods.Length; i++)
            {
                Console.WriteLine(foods[i]);
            }

            global::System.Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }
    }
}
