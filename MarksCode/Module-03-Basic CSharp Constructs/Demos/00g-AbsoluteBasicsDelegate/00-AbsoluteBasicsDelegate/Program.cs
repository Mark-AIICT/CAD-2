using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_AbsoluteBasicsDelegate
{
    class Program
    {
        delegate int MyDelegate(int val);
        
        static void Main(string[] args)
        {
            int y = 45;
            Console.WriteLine($"The cube of {y} is {Cube(y)}");

            MyDelegate m = Cube;
            Console.WriteLine($"The cube of {y} is {m(y)}");



            Console.ReadLine();
        }

        static int Cube(int x)
        {
            return x * x * x;
        }
    }
}
