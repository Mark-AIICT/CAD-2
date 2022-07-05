using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_ListDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary myItems = new ListDictionary();

            myItems.Add("96818", "Honalulu");
            myItems.Add("77777", "New Gotbat");
            myItems.Add("98877", "Upper tree");

            Console.WriteLine(myItems["77777"]);

            Console.ReadLine();




        }
    }
}
