using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        BackgroundWorker bw;
        FileUtil.FU fu = null;
        int totalFilesFound = 0;
        public MainWindow()
        {
           
            InitializeComponent();
            fu = new FileUtil.FU();
            fu.FileFound += new FileUtil.FU.FileFoundDelegate(fu_FileFound);

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
           
        }

        void fu_FileFound(object sender, FileUtil.FileFoundEventArgs e)
        {
            Dispatcher.Invoke(new ThreadStart(()=>
            {
                listBox1.Items.Add(e.Details);
            }));
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Finished, " + totalFilesFound.ToString() + " files found");
        }


        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            totalFilesFound=fu.GetFiles(e.Argument.ToString());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            bw.RunWorkerAsync(@"C:\windows\debug");
        }
    }
}
