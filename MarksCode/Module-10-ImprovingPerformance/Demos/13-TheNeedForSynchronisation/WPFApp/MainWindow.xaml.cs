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

            long N = 0;
            Parallel.Invoke(() =>
                            {
                               
                                for (long i = 0; i < 4000000M; i++)
                                {
                                    N += 1;
                                }
                            },

                            () =>
                            {

                                for (long i = 0; i < 4000000M; i++)
                                {
                                    N -= 1;
                                }
                               
                            }
                            
                            
                            );

            MessageBox.Show(string.Format("N should be zero, but it's {0}", N.ToString()));

            

           
        }


    }
}
