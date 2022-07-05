using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_FromDelegatestoEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility.Util util = new FileUtility.Util();
            util.FeedbackEvent += Util_FeedbackEvent;
          

            long result = util.ProcessFiles(@"c:\windows\system32");

            Console.WriteLine($"The total bytes found is {result} ");

            Console.ReadLine();
        }

        private static void Util_FeedbackEvent(string message)
        {
            Console.WriteLine(message);
        }
    }
}2

