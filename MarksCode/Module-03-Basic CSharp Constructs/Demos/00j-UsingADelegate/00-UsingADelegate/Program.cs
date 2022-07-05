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
            util.pointerToFeedback = ProcessFeedback;

            long result = util.ProcessFiles(@"c:\windows\system32");

            Console.WriteLine($"The total bytes found is {result} ");

            Console.ReadLine();
        }

        static void ProcessFeedback(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
                                                    