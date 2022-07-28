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
            ShoppingCart cart = new ShoppingCart()
            {
                CartNumber = 999,
                CustomerName = "Mick",
                Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        ItemNumber=1,
                        ItemDescription="Edible Sticky Tape",
                        ItemPrice=100,
                        ItemQuantity=44
                    },
                    new CartItem()
                    {
                        ItemNumber=2,
                        ItemDescription="X-Ray glasses",
                        ItemPrice=677,
                        ItemQuantity=2
                    },
                    new CartItem()
                    {
                        ItemNumber=3,
                        ItemDescription="Invisible Clothes",
                        ItemPrice=3,
                        ItemQuantity=555
                    }
                }
            };

            await Shopping.AddCartAsync(cart);

        }
    }
}
