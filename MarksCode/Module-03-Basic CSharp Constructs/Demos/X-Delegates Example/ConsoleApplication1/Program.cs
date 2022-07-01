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
            UtilsApp.FileUtil fu = new UtilsApp.FileUtil();
            fu.ProgressUpdate += fu_ProgressUpdate;

            int result = fu.GetFileCount(@"C:\windows\system32");
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static void fu_ProgressUpdate(object sender, UtilsApp.ProgressEventArgs e)
        {
            Console.WriteLine(e.ProgressInfo);
        }



   
    }
}
