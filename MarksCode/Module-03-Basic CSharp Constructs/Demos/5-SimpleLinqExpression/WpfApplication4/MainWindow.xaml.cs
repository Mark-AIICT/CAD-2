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

namespace WpfApplication4
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
            LB.Items.Clear();
            var query = from f in Directory.GetFiles(T.Text)
                        where f.Contains(TC.Text)
                        orderby f descending
                        select f;

            foreach (var item in query)
            {
                LB.Items.Add(item);
            }

            MessageBox.Show($"The last file in the directory is {Directory.GetFiles(T.Text).Last()}");

        }
    }
}
