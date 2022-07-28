using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class ShoppingCart
    {
        public int CartNumber { get; set; }
        public string CustomerName { get; set; }
        public List<CartItem> Items { get; set; }
    }

    public class CartItem
    {
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemQuantity { get; set; }
    }

    public class Shopping
    {
        public async static Task<List<ShoppingCart>> GetAllCartsAsync()
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50532/api/values");
            var s = await response.Content.ReadAsStringAsync();
            List<ShoppingCart> carts = JsonConvert.DeserializeObject<List<ShoppingCart>>(s);
            return carts;
        }



    }
}
