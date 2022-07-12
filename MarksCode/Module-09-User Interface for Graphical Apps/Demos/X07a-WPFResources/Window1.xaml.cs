using System;
using System.Collections.Generic;
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

namespace WPFResources
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string desc = "This application is an example of using Resources.\n\n" +
                        "Look at the XAML to see the code. \n\n" +
                        "Resources are either Local, Application or System \n" +
                        "\n Mark W\n";
            MessageBox.Show(desc, "description of example", MessageBoxButton.OK, MessageBoxImage.Information);
             
        }

       
    }
}
