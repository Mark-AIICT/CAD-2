﻿using Newtonsoft.Json;
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
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            List<ShoppingCart> carts = await Shopping.GetAllCartsAsync();
            lbCarts.ItemsSource = carts;
        }

        private void btnUpdateCart_Click(object sender, RoutedEventArgs e)
        {

            if (lbCarts.SelectedItem != null) {
                CartWindow cartWindow = new CartWindow();
                cartWindow.LoadData((ShoppingCart)lbCarts.SelectedValue);
                cartWindow.ShowDialog();
            }
            else
                MessageBox.Show("Please select a cart first");
        }
    }

    

}

