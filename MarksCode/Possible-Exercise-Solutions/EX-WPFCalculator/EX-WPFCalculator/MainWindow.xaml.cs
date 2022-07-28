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

namespace EX_WPFCalculator
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

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                if (tbResult != null)
                {
                    decimal firstNumber = 0;
                    decimal secondNumber = 0;
                    if (decimal.TryParse(txtFirstNumber.Text, out firstNumber) && decimal.TryParse(txtSecondNumber.Text, out secondNumber))
                    {
                        switch (cbOperation.SelectedValue)
                        {
                            case "Add":
                                tbResult.Text = (firstNumber + secondNumber).ToString();
                                break;
                            case "Subtract":
                                tbResult.Text = (firstNumber - secondNumber).ToString();
                                break;
                            case "Divide":
                                tbResult.Text = (firstNumber / secondNumber).ToString();
                                break;
                            case "Multiply":
                                tbResult.Text = (firstNumber * secondNumber).ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        tbResult.Text = "Please type valid decimal numbers";
                }
            }
            catch (Exception ex)
            {

                tbResult.Text = $"Calulation not possible. Reason: {ex.Message}";
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calculate();
        }
    }
}
