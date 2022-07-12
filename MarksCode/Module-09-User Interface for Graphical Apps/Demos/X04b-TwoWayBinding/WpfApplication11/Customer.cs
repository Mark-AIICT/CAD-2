using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication11
{
    class Customer:DependencyObject
    {


        public string CustomerName
        {
            get { return (string)GetValue(CustomerNameProperty); }
            set { 
                SetValue(CustomerNameProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CustomerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerNameProperty =
            DependencyProperty.Register("CustomerName", typeof(string), typeof(Customer), null);


        public string CustomerAddress
        {
            get { return (string)GetValue(CustomerAddressProperty); }
            set
            {
                SetValue(CustomerAddressProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for CustomerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomerAddressProperty =
            DependencyProperty.Register("CustomerAddress", typeof(string), typeof(Customer),  null);

    }
}
