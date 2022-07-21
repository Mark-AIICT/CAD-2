using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class MyClass
    {

        public int x { get; set; }
        public int y { get; set; }

        public decimal Add()
        {
            return x + y;
        }

        public decimal Multiply()
        {
            return x * y ;
        }

    }
}
