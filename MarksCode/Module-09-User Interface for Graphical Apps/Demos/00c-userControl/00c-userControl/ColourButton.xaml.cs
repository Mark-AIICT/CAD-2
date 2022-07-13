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

namespace _00c_userControl
{
    /// <summary>
    /// Interaction logic for ColourButton.xaml
    /// </summary>
    public partial class ColourButton : UserControl
    {
        public ColourButton()
        {
            InitializeComponent();
        }

        public Brush ButtonColour {
            get
            {

                return btn.Background;
            }
            set
            {
                btn.Background = value;
                btn.Content = $"Colour: {ButtonColour}";
            }
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The colour of the button pressed is {ButtonColour}");
        }
    }
}
