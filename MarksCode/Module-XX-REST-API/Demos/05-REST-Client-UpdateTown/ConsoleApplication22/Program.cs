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
            Console.WriteLine("Updating....\n\n");
            Console.WriteLine("\n\nPress any key to end");
            Console.ReadKey();
        }

        static async void RestCallsAsync()
        {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var values = new Dictionary<string, string>
                  {
                      { "PostCode", "3333" },
                      { "TownName", "Parramatta" }
                  };

                var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(values),
                                    Encoding.UTF8,
                                    "application/json");//CONTENT-TYPE header);

                var updateResponse = await client.PostAsync("http://localhost:50532/api/values",content);
        }
    }
}
