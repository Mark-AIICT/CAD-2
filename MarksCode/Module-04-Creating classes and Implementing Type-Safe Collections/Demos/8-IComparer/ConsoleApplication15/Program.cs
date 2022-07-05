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
            towns.Sort(new MyComparer());

        
        }
    }

    class Town
    {
        public int PostCode { get; set; }
        public string TownName { get; set; }
    }

    class MyComparer : IComparer<Town>
    {
        public int Compare(Town x, Town y)
        {
            if (x.TownName == y.TownName)
                return 0;
            else if (x.TownName.Length > y.TownName.Length)
                return -1;
            else
                return 1;
        }
    }
}
