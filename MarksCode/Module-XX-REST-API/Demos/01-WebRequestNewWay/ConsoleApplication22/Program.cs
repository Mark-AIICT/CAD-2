using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
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
            Console.WriteLine("Type in an isbn (eg:  0547526563)");
            string isbn = Console.ReadLine();
            HttpClient client = new HttpClient();
            Console.WriteLine("Retrieving....\n\n");
            var response = await client.GetAsync("https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn);
            var s = await response.Content.ReadAsStringAsync();
            Console.WriteLine(s);
        }
    }
}
