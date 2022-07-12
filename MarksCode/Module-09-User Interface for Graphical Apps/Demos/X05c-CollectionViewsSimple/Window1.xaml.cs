using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace CollectionViewsSimple
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCustomerCollection cc;
        public Window1()
        {
            InitializeComponent();
            cc = (ObservableCustomerCollection)((CollectionViewSource)Resources["listOfCustomers"]).Source;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(CustomerListBox.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("CustomerName", ListSortDirection.Ascending));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view =
                CollectionViewSource.GetDefaultView(CustomerListBox.ItemsSource);
            PropertyGroupDescription desc = new PropertyGroupDescription();
            desc.PropertyName = "PostCode";
            view.GroupDescriptions.Clear();
            view.GroupDescriptions.Add(desc);


        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(CustomerListBox.ItemsSource);
            view.SortDescriptions.Clear();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view =
                CollectionViewSource.GetDefaultView(CustomerListBox.ItemsSource);
            PropertyGroupDescription desc = new PropertyGroupDescription();
            view.GroupDescriptions.Clear();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource listOfCustomers = (CollectionViewSource)Resources["listOfCustomers"];

            //I wrote the following statement using a lambda expression but could have written it
            //using anonymous delegates or even create a new FilterEventHandler that accepts the
            //address of a function (as per the slides). Lambda is more elegant. Mark.

            listOfCustomers.Filter += (s, args) =>
                                        {
                                            Customer c = args.Item as Customer;
                                            if (c != null)
                                            {
                                                if (c.PostCode == "2000")
                                                    args.Accepted = true;
                                                else
                                                    args.Accepted = false;
                                            }

                                        };
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(CustomerListBox.ItemsSource);
            view.Filter = null;
        }



        private void button8_Click(object sender, RoutedEventArgs e)
        {
            
            cc.Add(new Customer() { CustomerName = "Mark", Address = "Sydney", PostCode = "2000" });
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            cc[0].CustomerName = "Billy";
            ICollectionView view = CollectionViewSource.GetDefaultView(CustomerListBox.ItemsSource);
            view.Refresh();

           
        }





    }
       

}
