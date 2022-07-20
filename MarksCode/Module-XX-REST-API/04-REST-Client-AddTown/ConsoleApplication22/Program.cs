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
            Console.WriteLine("Adding....\n\n");
            Console.WriteLine("New database Content....\n\n");


            Action task = new Action(RestCalls);
            Task.Run(task).Wait();


            Console.WriteLine("\n\nPress any key to end");
            Console.ReadKey();
        }

        static async void RestCalls()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                var values = new Dictionary<string, string>
                  {
                      { "PostCode", "777" },
                      { "TownName", "WaggaWagga" }
                  };

                var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(values),
                                    Encoding.UTF8,
                                    "application/json");//CONTENT-TYPE header);

                var response = await client.PutAsync("http://localhost:50532/api/values", content);
                var responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Retrieving....\n\n");
                var response2 = await client.GetAsync("http://localhost:50532/api/values");
                var s = await response2.Content.ReadAsStringAsync();

                List<Town> towns = JsonConvert.DeserializeObject<List<Town>>(s);

                foreach (var t in towns)
                {
                    Console.WriteLine($"Post Code={t.PostCode}, Town={t.TownName}");

                }

            }
            catch (WebException xcp)
            {

                Console.WriteLine(xcp.ToString());
                Console.ReadKey();
            }
            catch (Exception xcp)
            {

                Console.WriteLine(xcp.ToString());
                Console.ReadKey();
            }

        }
    }
}
