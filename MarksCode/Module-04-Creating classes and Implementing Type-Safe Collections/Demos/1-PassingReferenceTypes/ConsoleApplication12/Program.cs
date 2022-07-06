using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            Thing p = new Thing();
            p.MyProperty = 7;
            f1(p);
            Console.WriteLine($"The value of p.MyProperty is {p.MyProperty}");
            Console.WriteLine("Press enter to end");
            Console.ReadLine();
        }

        static void f1(Thing x)
        {
            x.MyProperty++;
        }
    }

    class Thing //try changing this to a struct and re-running it. Can you explain what is happening?
    {
        public int MyProperty { get; set; }
    }
}
