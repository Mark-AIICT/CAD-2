using DelegateExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtil.CallBackFunction = ShowMessage;
            Console.WriteLine("Total Bytes={0}", FileUtil.CountBytes(@"C:\windows\system32"));
            Console.ReadLine();
        }

        static void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
