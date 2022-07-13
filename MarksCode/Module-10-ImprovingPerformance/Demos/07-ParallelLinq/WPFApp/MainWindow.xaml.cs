using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Customer[] customers = new Customer[] {
            new Customer(){ Name = "fred", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "jane", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "joe", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "zoe", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "dave", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "jill", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "frank", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "lyn", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "kev", Address = "Melbourne", PostCode = "3000" }

                                                    };

            var query = from c in customers.AsParallel()
                        where c.Name.Contains("e")
                        select c.Name;

            foreach (var item in query)
            {
                lb.Items.Add(item);
            }


        }
    }
}
