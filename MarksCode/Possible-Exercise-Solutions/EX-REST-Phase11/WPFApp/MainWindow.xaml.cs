using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ShoppingCart> _carts;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async Task LoadData()
        {
            _carts = await Shopping.GetAllCartsAsync();
            lbCarts.ItemsSource = _carts;
            lbCarts.Items.Refresh();

        }

        private void btnUpdateCart_Click(object sender, RoutedEventArgs e)
        {

            if (lbCarts.SelectedItem != null) {
                CartWindow cartWindow = new CartWindow();
                cartWindow.LoadData((ShoppingCart)lbCarts.SelectedValue, CartWindow.CartMode.Updating);

                cartWindow.ShowDialog();
            }
            else
                MessageBox.Show("Please select a cart first");
        }

        private async void btnAddCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            ShoppingCart newCart = new ShoppingCart()
            {
                CartNumber= _carts.Count > 0 ? _carts.Max(c => c.CartNumber) + 1 : 1,
                CustomerName ="",
                Items=new List<CartItem>()
            };


            cartWindow.LoadData(newCart, CartWindow.CartMode.Adding);
            cartWindow.ShowDialog();
            await LoadData();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbCarts.SelectedItem != null)
            {
                await Shopping.DeleteCartAsync(((ShoppingCart)lbCarts.SelectedValue).CartNumber);
                await LoadData();
            }
            else
                MessageBox.Show("Please select a cart first");
        }
    }

    

}

