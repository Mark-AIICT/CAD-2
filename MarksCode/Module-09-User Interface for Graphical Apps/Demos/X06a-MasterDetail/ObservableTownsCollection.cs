using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CollectionViewsSimple
{

    public class ObservableTownsCollection : ObservableCollection<Town>
    {
        public ObservableTownsCollection()
            : base()
        {

            ObservableCustomersCollection sydneyCustomers = new ObservableCustomersCollection();
            sydneyCustomers.Add(new Customer() { CustomerName = "fred", Address = "sydney" });
            sydneyCustomers.Add(new Customer() { CustomerName = "joe", Address = "sydney" });
            sydneyCustomers.Add(new Customer() { CustomerName = "dave", Address = "sydney" });
            sydneyCustomers.Add(new Customer() { CustomerName = "frank", Address = "sydney" });


            ObservableCustomersCollection melbourneCustomers = new ObservableCustomersCollection();
            melbourneCustomers.Add(new Customer() { CustomerName = "jane", Address = "Melbourne" });
            melbourneCustomers.Add(new Customer() { CustomerName = "zoe", Address = "Melbourne" });
            melbourneCustomers.Add(new Customer() { CustomerName = "jill", Address = "Melbourne" });
            melbourneCustomers.Add(new Customer() { CustomerName = "lyn", Address = "Melbourne" });
            melbourneCustomers.Add(new Customer() { CustomerName = "kev", Address = "Melbourne" });




            Add(new Town() { PostCode = "2000", customers = sydneyCustomers });
            Add(new Town() { PostCode = "3000", customers = melbourneCustomers });



        }

    }
}
