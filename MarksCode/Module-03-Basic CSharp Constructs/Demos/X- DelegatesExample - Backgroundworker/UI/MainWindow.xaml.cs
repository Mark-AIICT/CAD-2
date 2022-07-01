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
using System.Threading;
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            f = new FileUtil.FU();
            ptrToGetFiles = f.GetFiles;
            f.FileFound += new FileUtil.FU.FileFoundDelegate(f_FileFound);
        }

        void f_FileFound(object sender, FileUtil.FileFoundEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate()
            {
                listBox1.Items.Add(e.Details);
            });
        }

     

        delegate int FuDel(string path);
        FuDel ptrToGetFiles;
        FileUtil.FU f = null;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ptrToGetFiles.BeginInvoke(textBox1.Text, HandleNumberOfFilesResult, textBox1.Text);
        }

        

        void HandleNumberOfFilesResult(IAsyncResult res)
        {
            int filesFound = ptrToGetFiles.EndInvoke(res);
            MessageBox.Show("There were " + filesFound.ToString() + " files found in folder " + res.AsyncState);
        }


    }
}
