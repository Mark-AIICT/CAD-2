using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            D myObj = new D();
            ProcessObject(myObj);
            Console.ReadLine();

        }

        static void ProcessObject(A obj)
        {
            obj.F();
        }
    }
}
