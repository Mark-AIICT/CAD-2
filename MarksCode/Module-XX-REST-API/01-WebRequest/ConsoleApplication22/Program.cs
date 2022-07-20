using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Type in an isbn (eg:  0547526563)");

                string isbn = Console.ReadLine();

                Console.WriteLine("Retrieving....\n\n" );

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn);
                Stream responseStream;

                req.Method = "GET";


                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                responseStream = res.GetResponseStream();

                StreamReader sr = new StreamReader(responseStream, Encoding.ASCII);

                string s = sr.ReadToEnd();

                JObject jObject = JObject.Parse(s);




                Console.WriteLine("\nBook Description:\n\n");
                Console.WriteLine(jObject["items"][0]["volumeInfo"]["description"]);

                Console.WriteLine("\n\nPress any key to end");
                Console.ReadKey();
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
