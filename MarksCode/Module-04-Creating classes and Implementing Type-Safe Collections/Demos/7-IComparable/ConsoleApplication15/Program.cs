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

    class Town : IComparable<Town>
    {
        public int PostCode { get; set; }
        public string TownName { get; set; }

        public int CompareTo(Town other)
        {
            if (PostCode == other.PostCode)
                return 0;
            else if (PostCode > other.PostCode)
                return -1;
            else
                return 1;
        }
    }
}
