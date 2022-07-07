using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();
            towns.Add(new Town() { PostCode = 2000, TownName = "Sydney" });
            towns.Add(new Town() { PostCode = 3000, TownName = "Melbourne" });
            towns.Add(new Town() { PostCode = 6000, TownName = "Adelaide" });
            towns.Sort();


            Console.WriteLine("Use the debugger to go through this line by line. Press enter to end");
            Console.ReadLine();


        }
    }

    class Town : IComparable
    {
        public int PostCode { get; set; }
        public string TownName { get; set; }

        public int CompareTo(Object other)
        {
            if (PostCode == ((Town)other).PostCode)
                return 0; //they are the same
            else if (PostCode > ((Town)other).PostCode)
                return -1; //the postcde of the current object is larger than the object being compared with
            else
                return 1; //the postcde of the current object is samller than the object being compared with
        }
    }
}
