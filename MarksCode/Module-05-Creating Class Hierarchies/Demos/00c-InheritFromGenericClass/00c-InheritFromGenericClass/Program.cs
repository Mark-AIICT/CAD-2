using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00c_InheritFromGenericClass
{
    class Program
    {
        static void Main(string[] args)
        {
            TownList towns = new TownList();
            towns.Add("Banana",11111);
            towns.Add("Woollongong",66666);
            towns.Add("Coogee", 4444 );


            Console.WriteLine($"The last town is {towns.LastTown()}\n\n");

            foreach (var item in towns)
            {
                Console.WriteLine($"{item.TownName}, {item.ZipCode}");
            }

            Console.ReadLine();



        }
    }
}
