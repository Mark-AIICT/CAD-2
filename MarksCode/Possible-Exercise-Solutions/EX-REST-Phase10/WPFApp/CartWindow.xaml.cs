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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private ShoppingCart _cart;
        public enum CartMode { Adding, Updating};
        private CartMode _CurrentCartMode;

        public CartWindow()
        {
            InitializeComponent();
        }

        public void LoadData(ShoppingCart cart, CartMode cartMode)
        {
            _cart = cart;
            grdCart.DataContext = _cart;
            lbItems.ItemsSource = _cart.Items;
            _CurrentCartMode = cartMode;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrentCartMode == CartMode.Updating)
                await Shopping.UpdateCartAsync(_cart);
            else
                await Shopping.AddCartAsync(_cart);
            Close();
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var currentMaxItemNumber = _cart.Items.Count>0?_cart.Items.Max(i => i.ItemNumber):0;
            _cart.Items.Add(new CartItem() { ItemNumber = currentMaxItemNumber + 1 });
            lbItems.Items.Refresh();
        }

        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (lbItems.SelectedItem != null)
            {
                _cart.Items.Remove((CartItem)lbItems.SelectedValue);
                lbItems.Items.Refresh();
            }
            else
                MessageBox.Show("Please select an item to delete first");
        }
    }
}
