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
            Action<int, int, string> f = (x,  y,  z) =>
            {
                Console.WriteLine(x + y + Convert.ToInt32(z)); //if there's only one line of code you can get rid of the {}
            };
            f(3, 4, "5");

            Func<int, int, string, int> f2 = (x, y, z) => //if there's only one line of code you can get rid of the {}
            {
                return x + y + Convert.ToInt32(z);
            };
            Console.WriteLine(f2(5,6,"7"));

            Console.ReadLine();
        }

        
    }
}
