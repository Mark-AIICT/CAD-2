using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionViewsSimple
{
    public class Town
    {
        public string PostCode { get; set; }
        public ObservableCustomersCollection customers { get; set; }
    }
}
