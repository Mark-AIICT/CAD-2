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

                Console.WriteLine("Retrieving....\n\n" );

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:50532/api/values/1111");
                Stream responseStream;

                req.Method = "GET";

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                responseStream = res.GetResponseStream();

                StreamReader sr = new StreamReader(responseStream, Encoding.ASCII);

                string s = sr.ReadToEnd();
                Town t = JsonConvert.DeserializeObject<Town>(s);
                Console.WriteLine($"Post Code={t.PostCode}, Town={t.TownName}");
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
