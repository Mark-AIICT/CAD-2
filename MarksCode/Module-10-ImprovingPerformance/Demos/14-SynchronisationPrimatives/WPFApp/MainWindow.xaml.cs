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
using System.Threading;

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
            ManualResetEventSlim mres1 = new ManualResetEventSlim();
            ManualResetEventSlim mres2 = new ManualResetEventSlim();
            long N = 0;
            long X = 0;

            mres1.Reset();
            mres2.Reset();

            Task T1 = new Task(() =>
                           {
                               for (long i = 0; i < 4000000M; i++)
                               {
                                   N += i;
                               }
                               mres1.Set();
                           });

            Task T2 = new Task(() =>
                            {
                                for (long i = 0; i < 4000000M; i++)
                                {
                                    X -= i;
                                }
                                mres2.Set();
                            });

            T1.Start();
            T2.Start();

            //Try commenting out the next two lines
            mres1.Wait(); //Waits for the FIRST task to execute 'Set', which is an indication that it has finished
            mres2.Wait();  //Waits for the SECOND task to execute 'Set', which is an indication that it has finished



            MessageBox.Show(string.Format("N={0}, X={1}", N, X));
        }
    }
}
