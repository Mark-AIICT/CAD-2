using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _04_Tracing_and_Instrumentation_WPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!EventLog.SourceExists("MyApplication", Environment.MachineName))
            {
                EventLog.CreateEventSource("MyApplication", "MyApplicationLog");
            }

            EventLog.WriteEntry("MyApplication", TextBox1.Text, EventLogEntryType.Warning);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\temp\log.txt", TextBox1.Text);
        }
    }
}
