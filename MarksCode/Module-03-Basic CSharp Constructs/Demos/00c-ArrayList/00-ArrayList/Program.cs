using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList listofthings = new ArrayList();
            listofthings.Add("pencil");
            listofthings.Add(23);
            listofthings.Add(25.77M);

            int itemNumber = 1;
            foreach (var item in listofthings)
            {
                
                Console.WriteLine($"item {itemNumber++} is {item}");
            }

            Console.ReadLine();


        }
    }
}
