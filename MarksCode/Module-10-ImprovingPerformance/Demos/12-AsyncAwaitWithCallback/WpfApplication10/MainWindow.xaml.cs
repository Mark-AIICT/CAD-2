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
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
           //last chance to catch errors here.
        }

        async private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileUtil util = new FileUtil();

            string pth = txtPath.Text;

            long result = await util.GetTotalBytesAsync(pth,UpdateProgress);

            txtResult.Text = "Result=" + result.ToString();


        }

        void UpdateProgress(string progress)
        {

            //In this application Dispatcher.BeginInvoke sometimes causes an unexpected result
            //because the label on the WPF application gets updated in the wrong order, so I 
            //changed it to Dispatcher.Invoke.
            Dispatcher.Invoke(new Action(() =>
                txtResult.Text = progress
            ));
        }
    }
}
