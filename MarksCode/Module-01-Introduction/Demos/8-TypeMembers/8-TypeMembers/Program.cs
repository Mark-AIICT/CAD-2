using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_TypeMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 44;
            Console.WriteLine(x.ToString());

            string y;
            Console.WriteLine("Enter a number");
            y = Console.ReadLine();

            //OK
            //Console.WriteLine($"{y} divided by 3 is {Convert.ToInt32(y)/3}");

            //Better
            if (int.TryParse(y, out x))
            {
                Console.WriteLine($"{x} divided by 3 is {Convert.ToInt32(x) / 3}");
            }
            else
            {
                Console.WriteLine($"{y} is not an integer");
            }


            Console.ReadLine();
            
        }
    }
}
                    