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
            int capacity = 5000000;
            int from = 0;
            int to = capacity;
            double[] array1 = new double[capacity];
            double[] array2 = new double[capacity];
           
            // This is a sequential implementation:
            DateTime start = DateTime.Now;
            for (int index = 0; index < capacity; index++)
            {
                array1[index] = Math.Sqrt(index);
            }
            double msFirst = DateTime.Now.Subtract(start).TotalMilliseconds;
           
            // This is the equivalent parallel implementation:
            start = DateTime.Now;
            Parallel.For(from, to, index =>
            {
                array2[index] = Math.Sqrt(index);
            });
            double msSecond = DateTime.Now.Subtract(start).TotalMilliseconds;

            MessageBox.Show(string.Format("Serial Execution={0}ms, ParallelFor Execution={1}ms", msFirst, msSecond));

        }
    }
}
