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

        public async static Task<ShoppingCart> GetOneCartAsync(int cartNumber)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:50532/api/values/" + cartNumber.ToString());
            var s = await response.Content.ReadAsStringAsync();
            ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(s);
            return cart;
        }

        public async static Task AddCartAsync(ShoppingCart cart)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header


            var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(cart),
                                Encoding.UTF8,
                                "application/json");//CONTENT-TYPE header);

            var response = await client.PutAsync("http://localhost:50532/api/values", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public async static Task DeleteCartAsync(int cartNumber)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync("http://localhost:50532/api/values/" + cartNumber.ToString());
        }





    }
}
