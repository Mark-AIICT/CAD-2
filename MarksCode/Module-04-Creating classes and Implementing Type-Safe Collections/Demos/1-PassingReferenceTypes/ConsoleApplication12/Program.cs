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
            MyClass p = new MyClass();
            p.MyProperty = 7;
            f1(p);
            Console.WriteLine($"The value of p.MyProperty is {p.MyProperty}");
            Console.WriteLine("Press enter to end");
            Console.ReadLine();
        }

        static void f1(MyClass x)
        {
            x.MyProperty++;
        }
    }

    struct MyClass
    {
        public int MyProperty { get; set; }
    }
}
