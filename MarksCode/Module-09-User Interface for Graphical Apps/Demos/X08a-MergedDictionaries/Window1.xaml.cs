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

namespace Styles
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
            string desc = "This application is an example of using Styles.\n\n" +
                         "To fully understand the example you'll need to look in \n" +
                         "the Brushresources.xaml and Controlresources.Xaml \n\n" +
                         "These 2 files dictate how buttons and textboxes will look across the  \n" +
                         "application. Be sure also to look at App.Xaml for merging  \n" +
                         "of the resource files.\n\n" +
                         "You can reference a WPF resource as a static resource or a dynamic resource by \n" +
                         "using the StaticResource and DynamicResource markup extensions. \n" +
                         "Static resources are bound at load time, which is when the loading process needs \n" +
                         "to assign the property value. \n" +
                         "Dynamic resources remain unevaluated until run time, which is when WPF \n" +
                         "evaluates the expression and provides a value.\n" +
                         "\n Mark W\n";
            MessageBox.Show(desc, "description of example", MessageBoxButton.OK, MessageBoxImage.Information);
        
        }
    }
}
