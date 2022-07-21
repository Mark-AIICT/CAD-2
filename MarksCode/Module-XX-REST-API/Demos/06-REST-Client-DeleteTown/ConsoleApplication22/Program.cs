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

            Console.WriteLine("Deleting....\n\n");
            var deleteResponse = await client.DeleteAsync("http://localhost:50532/api/values/4444");
        }
    }
}
