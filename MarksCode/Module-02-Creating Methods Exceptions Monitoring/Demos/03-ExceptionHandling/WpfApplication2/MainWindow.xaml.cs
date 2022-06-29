using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApplication2
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
            decimal n1;
            decimal n2;

            try
            {
                if (decimal.TryParse(T1.Text, out n1) && decimal.TryParse(T2.Text, out n2))
                {
                    R.Text = (n1 / n2).ToString();
                    File.AppendAllText(@"C:\temp\Log.txt", Environment.NewLine +
                                                        string.Format("{0} divide {1} is {2}",
                                                                        n1, n2, R.Text));
                }
                else
                    R.Text = "Try numbers next time";
            }
            catch (DivideByZeroException)
            {
                R.Text = "ZeroDivide. Please Fix it";
            }

            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        private static void HandleError(Exception ex)
        {
            try
            {
                Guid ticketNumber = Guid.NewGuid();
                MessageBox.Show(string.Format("The application has crashed. please phone IT and quote ticket number {0}", ticketNumber));
                File.WriteAllText(@"C:\temp\Error.txt", string.Format("Ticket:{0}, full details: {1}",
                                                ticketNumber, ex));
            }
            catch (Exception)
            {
                //log execption (some other way) here
                throw;
            }
        }
    }
}
