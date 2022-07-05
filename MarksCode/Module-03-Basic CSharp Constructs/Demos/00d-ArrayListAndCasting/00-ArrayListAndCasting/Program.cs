using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_ArrayListAndCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList items = new ArrayList();
            items.Add(3);

            //int result = items[0]; //this doesn't compile. why not? items[0] is an object, not an int

            int result = (int)items[0]; //convert from object to int

            Console.WriteLine($"result is {result}");
            Console.ReadLine();

        }
    }
}
