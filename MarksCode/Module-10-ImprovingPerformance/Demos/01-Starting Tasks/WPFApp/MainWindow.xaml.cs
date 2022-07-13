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
            
             //The code that follows shows several ways of starting a task.

             Task T1 = new Task(p =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < Convert.ToDecimal(p); i++)
                                {
                                    result += i;
                                }
                                 MessageBox.Show("Task T1 has completed, result=" + result.ToString());
                            }, 40000000M);





            Task T2 = new Task(p =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < Convert.ToDecimal(p); i++)
                                {
                                    result += i;
                                }
                                MessageBox.Show("Task T2 has completed, result=" + result.ToString());
                            }, 20000000M);

            //Starting tasks, method 1
            T1.Start();
            T2.Start();

            //Starting tasks, method 2
            Task T3 =  Task.Factory.StartNew(p =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < Convert.ToDecimal(p); i++)
                                {
                                    result += i;
                                }
                                MessageBox.Show("Task T3 has completed, result=" + result.ToString());
                            }, 20000000M);

            //Starting tasks, method 3
            decimal number = 20000000M;
            Task T4 = Task.Run(() =>
                            {
                                decimal result = 0;
                                for (decimal i = 0; i < number; i++)
                                {
                                    result += i;
                                }
                                MessageBox.Show("Task T4 has completed, result=" + result.ToString());
                            });
        }
    }
}
