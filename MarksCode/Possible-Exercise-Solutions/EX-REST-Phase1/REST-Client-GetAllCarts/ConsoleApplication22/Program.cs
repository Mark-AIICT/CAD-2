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
            var AllCarts = await Shopping.GetAllCartsAsync();
            foreach (var cart in AllCarts)
            {
                Console.WriteLine($"Cart Number={cart.CartNumber}, CustomerName={cart.CustomerName}");
            }
         
        }
    }
}
