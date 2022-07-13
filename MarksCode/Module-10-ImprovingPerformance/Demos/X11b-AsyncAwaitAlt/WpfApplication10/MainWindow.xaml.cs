using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        CancellationTokenSource cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        async private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileUtil util = new FileUtil();

            string pth = txtPath.Text;

            cancellationTokenSource = new CancellationTokenSource();
            Task<string> T = new Task<string>(new Func<string>(() =>
                            {
                                    long result = util.GetTotalBytes(pth, cancellationTokenSource);
                                    return string.Format("{0} has {1} total bytes", pth, result);
                            }
                    ));
  
             T.Start();
             await T;
             LB.Items.Add(T.Result);
           



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

    }
}
