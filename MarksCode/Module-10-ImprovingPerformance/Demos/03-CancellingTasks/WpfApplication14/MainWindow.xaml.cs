﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApplication14
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            Task Tsk = new Task(MyFunction, T.Text);
            Tsk.Start();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        void MyFunction(object p)
        {

            try
            {
                long result = CountOfFiles(p.ToString());
                MessageBox.Show(string.Format("There are {0} files in all directories below {1}",
                                        result, p));

               
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        long CountOfFiles(string path)
        {
            long filesInPath=0;
            try
            {
                filesInPath = Directory.GetFiles(path).LongCount();
                foreach (string dir in Directory.GetDirectories(path))
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                         throw new OperationCanceledException("You said Cancel", cancellationTokenSource.Token);
                    }
                    filesInPath += CountOfFiles(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Ignore these files/folders
            }
            return filesInPath;
        }

        

        
    }
}
