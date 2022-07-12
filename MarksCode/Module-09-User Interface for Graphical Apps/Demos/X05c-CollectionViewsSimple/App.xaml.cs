using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace CollectionViewsSimple
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ObservableCustomerCollection occ = new ObservableCustomerCollection();
        CustomerCollection cc = new CustomerCollection();
        
        public CustomerCollection Customers
        {
            get
            {
                return  cc;

            }
        }

        public ObservableCustomerCollection CustomersObservable
        {
            get
            {
                return  occ;

            }
        }


    }

   
}
