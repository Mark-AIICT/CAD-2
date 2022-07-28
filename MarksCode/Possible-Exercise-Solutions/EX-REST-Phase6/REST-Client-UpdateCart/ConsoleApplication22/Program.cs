using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {


        static void Main(string[] args)
        {
            Action action = new Action(RestCalls);
            Task.Run(action).Wait();
            Console.WriteLine("\n\nPress any key to end");
            Console.ReadKey();
        }

        static async void RestCalls()
        {
            //Get the Cart to update
            var cart = await Shopping.GetOneCartAsync(111);

            //test adding an item
            cart.Items.Add(new CartItem
            {
                ItemNumber =777,
                ItemDescription = "Chocolate",
                ItemPrice = 4,
                ItemQuantity = 255
            });

            //test removing an item
            //cart.Items.Remove(2)

            cart.Items.Remove(cart.Items.Where(itm => itm.ItemNumber == 2).First());

            //test changing an item
            cart.Items.Where(itm => itm.ItemNumber == 1).First().ItemPrice = 9999;

            await Shopping.UpdateCartAsync(cart);

        }
    }
}
