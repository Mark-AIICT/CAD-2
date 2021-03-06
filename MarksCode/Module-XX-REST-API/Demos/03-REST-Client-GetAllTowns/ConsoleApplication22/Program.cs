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
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {


        static void Main(string[] args)
        {
            Action action = new Action(RestCallsAsync);
            Task.Run(action).Wait();


            Console.WriteLine("\n\nPress any key to end");
            Console.ReadKey();
        }

        static async void RestCallsAsync()
        {

            HttpClient client = new HttpClient();

            Console.WriteLine("Retrieving....\n\n");
            var response = await client.GetAsync("http://localhost:50532/api/values");
            var s = await response.Content.ReadAsStringAsync();

            List<Town> towns = JsonConvert.DeserializeObject<List<Town>>(s);

            foreach (var t in towns)
            {
                Console.WriteLine($"Post Code={t.PostCode}, Town={t.TownName}");

            }

            Console.WriteLine("\n\nPress any key to end");
            Console.ReadKey();

        }
    }
}
