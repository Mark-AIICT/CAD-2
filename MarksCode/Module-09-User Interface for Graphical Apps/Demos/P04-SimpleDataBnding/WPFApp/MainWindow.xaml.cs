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
            Coffee c = new Coffee()
                {
                    Name = "Rocket",
                    Bean = "Riffle",
                    CountryOfOrigin = "PNG",
                    Strength = "5"
                };
            SPH.DataContext = c;

            ////Example of binding using a binding object
            Binding b = new Binding();
            b.Source = c;
            b.Path = new PropertyPath("Name");
            TB.SetBinding(TextBlock.TextProperty, b);

        }

        

      
    }
}
