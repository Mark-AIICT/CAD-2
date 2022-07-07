using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00c_InheritFromGenericClass
{
    class TownList : List<Town>
    {
        public void Add(string townName, int zipCode )
        {
            this.Add(new Town() { ZipCode = zipCode, TownName = townName });
        }

        public string LastTown()
        {
            return this.Last().TownName;
        }
    }

    class Town
    {
        public int ZipCode { get; set; }
        public string TownName { get; set; }
    }
}
