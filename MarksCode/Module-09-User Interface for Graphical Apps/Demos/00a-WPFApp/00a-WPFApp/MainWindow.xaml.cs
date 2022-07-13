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

namespace _00a_WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var filepath in System.IO.Directory.GetFiles("c:\\windows"))
            {
                lbFiles.Items.Add(filepath);
            }
        }

        private void buttonpress(object sender, RoutedEventArgs e)
        {
            dateTextBlock.Text = $"last time message was displayed: {DateTime.Now.ToLongTimeString()}";
            MessageBox.Show($"the entered text is \"{enteredText.Text}\"");
        }

        private void ListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"you double clicked \"{lbFiles.SelectedItem}\"");
        }
    }
}
