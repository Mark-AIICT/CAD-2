using System;
using System.Collections.Generic;
using System.Text;

namespace WinApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public int Age { get; set; }
    }

    public class Town
    {
        public string PostCode { get; set; }
        public string TownName { get; set; }
    }
}
