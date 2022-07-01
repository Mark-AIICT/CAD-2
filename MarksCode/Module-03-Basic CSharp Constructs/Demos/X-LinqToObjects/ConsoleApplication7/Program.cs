using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = from f in Directory.GetFiles(@"C:\windows\system32")
                    where f.ToLower().Contains("px")
                    orderby f descending
                    select f;

            foreach (var fle in q)
            {
                Console.WriteLine(fle);
            }

            Console.ReadLine();


        }
    }
}
