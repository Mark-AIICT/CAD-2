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
            Action task = new Action(RestCalls);
            Console.WriteLine("Updating....\n\n");
            Console.WriteLine("New database content....\n\n");

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
                      { "PostCode", "3333" },
                      { "TownName", "Dubbo" }
                  };

                var content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(values),
                                    Encoding.UTF8,
                                    "application/json");//CONTENT-TYPE header);


                var updateResponse = await client.PostAsync("http://localhost:50532/api/values",content);


                //show the new database content
                var response = await client.GetAsync("http://localhost:50532/api/values");
                var responseString = await response.Content.ReadAsStringAsync();


                List<Town> towns = JsonConvert.DeserializeObject<List<Town>>(responseString);

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
