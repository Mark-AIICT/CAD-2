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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace LayoutPanels
{
    /// <summary>
    /// Interaction logic for VirtualisingStackPanel.xaml
    /// </summary>
    public partial class VirtualisingStackPanel : Window
    {
        public VirtualisingStackPanel()
        {
            InitializeComponent();

            ObservableCollection<Button> oc = new ObservableCollection<Button>();

            for (int i = 0; i < 20000; i++)
            {
                Button b = new Button();
                b.Content = "Button " + i.ToString();
                oc.Add(b);
            }


        }
    }
}
