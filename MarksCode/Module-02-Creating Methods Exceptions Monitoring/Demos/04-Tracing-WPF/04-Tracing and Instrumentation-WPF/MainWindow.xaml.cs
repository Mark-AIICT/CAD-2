using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _04_Tracing_and_Instrumentation_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TraceSwitch tsInformation = new TraceSwitch("GetTitlesTrace", "Trace switch for Demonstration");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Setup some trace listeners (there are several kinds you can use)
            FileStream fs = new System.IO.FileStream(@"c:\temp\TraceListenerAddedInCode.txt", System.IO.FileMode.Append);

            TextWriterTraceListener fileTraceListener = new TextWriterTraceListener(fs);
            EventLogTraceListener eventLogTraceListener = new EventLogTraceListener("MyApplication");

            System.Diagnostics.Trace.Listeners.Add(fileTraceListener);
            System.Diagnostics.Trace.Listeners.Add(eventLogTraceListener);
            System.Diagnostics.Trace.AutoFlush = true;

            //write out a line to the trace only when the switch has a certain value
            if (tsInformation.TraceInfo == true)
                System.Diagnostics.Trace.WriteLine($"\n\nJust after database fill  {DateTime.Now.ToLongTimeString()}" , "Mark");



            //Write out an error to the trace (always)
            string testString = "This is a test string";
            int i = 52;
            object[] obj = new object[] { testString, i };
            System.Diagnostics.Trace.TraceError("\nThere's an error. The first parameter is: {0} and 2nd is: {1}", obj[0],  obj[1]);

            //Write out a trace line given a certain condition
            System.Diagnostics.Trace.Assert(DateTime.Now.Hour >= 12, "\nThis is not to be run in the morning!");



            fs.Flush();
            fs.Close();
            System.Diagnostics.Trace.Listeners.Remove(fileTraceListener);
            System.Diagnostics.Trace.Listeners.Remove(eventLogTraceListener);
        }
    }


}