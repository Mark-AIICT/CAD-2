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

namespace WpfApplication10
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


        async private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //SEE! Simple code
            txtResult.Text = "Calculating...";
            FileUtil util = new FileUtil();
            string pth = txtPath.Text;
            long result = await util.GetTotalBytesAsync(pth);
            txtResult.Text = "Result=" + result.ToString();
        }

      
    }
}
