using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int, int, string> del = null;
            del += AddSomeNUmbers;
            del(33, 66, "77");


            Func<string,int,int,int> del2 = null;
            del2 += AddSomeNUmbersRV;
            int result = del2("88", 3, 4);
            Console.WriteLine("result2={0}", result);
            Console.WriteLine("All done. press enter to exit");
            Console.ReadLine();
        }

        static void AddSomeNUmbers(int x, int y, string z)
        {
            Console.WriteLine("result={0}", x + y + System.Convert.ToInt32(z));
        }


        static int AddSomeNUmbersRV(string x, int y, int z)
        {
            return System.Convert.ToInt32(x) + y + z ;
        }
    }

   
}
