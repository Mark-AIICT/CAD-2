using System;
using System.Collections;
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
            ArrayList towns = new ArrayList();
            towns.Add(new Town() { PostCode = 2000, TownName = "Sydney" });
            towns.Add(new Town() { PostCode = 3000, TownName = "Melbourne" });
            towns.Add(new Town() { PostCode = 6000, TownName = "Adelaide" });
            towns.Sort(new MyComparer());
            Console.WriteLine("Use the debugger to go through this line by line. Press enter to end");
            Console.ReadLine();

        }
    }

    class Town
    {
        public int PostCode { get; set; }
        public string TownName { get; set; }
    }

    class MyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (((Town)x).TownName == ((Town)y).TownName)
                return 0;
            else if (((Town)x).TownName.Length > ((Town)y).TownName.Length)
                return -1;
            else
                return 1;
        }
    }
}
