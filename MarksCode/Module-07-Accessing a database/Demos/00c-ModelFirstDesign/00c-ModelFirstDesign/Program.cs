using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00c_ModelFirstDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            TownsModelContainer ctx = new TownsModelContainer();

            ctx.Towns.Add(new Town() { Id = 222, TownName = "Wangaratta" });

            ctx.SaveChanges();
        }
    }
}
