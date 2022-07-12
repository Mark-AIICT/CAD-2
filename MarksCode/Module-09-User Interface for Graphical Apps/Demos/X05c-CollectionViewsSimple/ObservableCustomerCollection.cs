using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CollectionViewsSimple
{

    //This is one of the ways that I can create a collection of customers to 
    //bind to. It's probably the easiest and best way.
    public class ObservableCustomerCollection : ObservableCollection<Customer>
    {
        public ObservableCustomerCollection()
            : base()
        {
            Add(new Customer(){ CustomerName = "fred", Address = "sydney", PostCode = "2000" });
            Add(new Customer(){ CustomerName = "jane", Address = "Melbourne", PostCode = "3000" });
            Add(new Customer(){ CustomerName = "joe", Address = "sydney", PostCode = "2000" });
            Add(new Customer(){ CustomerName = "zoe", Address = "Melbourne", PostCode = "3000" });
            Add(new Customer(){ CustomerName = "dave", Address = "sydney", PostCode = "2000" });
            Add(new Customer(){ CustomerName = "jill", Address = "Melbourne", PostCode = "3000" });
            Add(new Customer(){ CustomerName = "frank", Address = "sydney", PostCode = "2000" });
            Add(new Customer(){ CustomerName = "lyn", Address = "Melbourne", PostCode = "3000" });
            Add(new Customer(){ CustomerName = "kev", Address = "Melbourne", PostCode = "3000" });

        }




    }
}
