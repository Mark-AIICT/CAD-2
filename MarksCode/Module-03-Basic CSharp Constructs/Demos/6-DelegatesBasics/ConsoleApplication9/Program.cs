using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        delegate int X(int val);
        static X PointerToCube;

        static void Main(string[] args)
        {
            int a = 5;
            PointerToCube = Cube;
            Console.WriteLine($" the cube of {a} is {PointerToCube(a)}");
            Console.WriteLine("OK, done. press enter to end");
            Console.ReadLine();
        }

        static int Cube(int x)
        {
            return x * x * x;
        }
    }
}
