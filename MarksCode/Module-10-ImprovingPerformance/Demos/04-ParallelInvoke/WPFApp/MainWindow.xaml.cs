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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Parallel.Invoke(() =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < 40000000M; i++)
                                {
                                    result += i;
                                }
                                MessageBox.Show(String.Format("40000000! is {0}", result));
                            },

                            () =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < 20000000M; i++)
                                {
                                    result += i;
                                }
                                MessageBox.Show(String.Format("20000000! is {0}", result));
                            }
                            
                            
                            );

            

           
        }


    }
}
