﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0}, Address={1}, PostCode={2}", Name, Address, PostCode);
        }
    }



}
