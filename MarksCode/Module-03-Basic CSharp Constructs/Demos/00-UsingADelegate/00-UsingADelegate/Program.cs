using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_UsingADelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.Util util = new FileUtility.Util();

            long result = util.ProcessFiles(@"c:\windows\system32");

            Console.WriteLine($"The total bytes found is {result} ");

            Console.ReadLine();
        }
    }
}
