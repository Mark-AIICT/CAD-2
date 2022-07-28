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

namespace Phase_11_POC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async Task LoadData()
        {
            Person p = new Person()
            {
                FirstName = "KongChaiMonkul",
                LastName = "Natartirivat"
            };


            p.PropertyChanged += P_PropertyChanged;

            grd.DataContext = p;
        }

        private void P_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (btnSave != null)
                btnSave.IsEnabled = true;
        }

  

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saved!!!!!");
        }
    }
}
