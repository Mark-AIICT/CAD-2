using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.ComponentModel.Composition;

namespace CalcClasses
{
    [Export(typeof(ICalculator))]
    class MySimpleCalculator : ICalculator
    {
        public string Calculate(string input)
        {
            return "Calculated: " + input;
        }
    }
}
