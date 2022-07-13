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


            Task<decimal> T1 = new Task<decimal>(p =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < Convert.ToDecimal(p); i++)
                                {
                                    result += i;
                                }
                                return result;
                            }, 40000000M);

            Task<decimal> T2 = new Task<decimal>(p =>
                            {
                                decimal result2 = 0;
                                for (decimal i = 0; i < Convert.ToDecimal(p); i++)
                                {
                                    result2 += i;
                                }
                                return result2;
                            }, 20000000M);


            DateTime start = DateTime.Now;
            T1.Start();
            T2.Start();



            Task.WaitAll(T1, T2);

            double duration = DateTime.Now.Subtract(start).TotalMilliseconds;


            listBoxResults.Items.Add(String.Format("Time={0}ms, 40000000! is {1}, 20000000! is {2}",
                                                    duration,T1.Result, T2.Result));


           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.Now;
            decimal result = 0;
            for (decimal i = 0; i < 40000000M; i++)
            {
                result += i;
            }

            decimal result2 = 0;
            for (decimal i = 0; i < 20000000M; i++)
            {
                result2 += i;
            }
            double duration = DateTime.Now.Subtract(start).TotalMilliseconds;

            listBoxResults.Items.Add(String.Format("Time={0}ms, 40000000! is {1}, 20000000! is {2}",
                                                    duration, result, result2));
        }
    }
}
