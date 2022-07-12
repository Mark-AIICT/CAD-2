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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Example of binding using a data context
            List<Coffee> Coffees = new List<Coffee> {
                    new Coffee(){Name = "Rocket",   Bean = "Riffle", CountryOfOrigin = "PNG", Strength = "5" },
                    new Coffee(){Name = "Fanatic",   Bean = "Aribica", CountryOfOrigin = "Kenya", Strength = "4" },
                    new Coffee(){Name = "Espresso",   Bean = "Aribica", CountryOfOrigin = "Brazil", Strength = "3" }
            };

            cfList.ItemsSource = Coffees;

           

        }

        

      
    }
}
