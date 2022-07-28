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

            Console.WriteLine("Cart:");
            Console.WriteLine($"\tCart Number={cart.CartNumber}, CustomerName={cart.CustomerName}");
            Console.WriteLine("\tItems:");

            foreach (var item in cart.Items)
            {
                Console.WriteLine($"\t\tnumber={item.ItemNumber}, Description={item.ItemDescription}, Quantity={item.ItemQuantity}, Price={item.ItemPrice:C}");

            }


        }
    }
}
