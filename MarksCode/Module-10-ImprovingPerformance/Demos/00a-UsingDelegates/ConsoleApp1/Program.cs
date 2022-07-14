using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //delegate void MyDelegate(int x, int y, string z);
        static void Main(string[] args)
        {
            //MyDelegate x = AddThem;

            Action<int, int, string> x = AddThem;
            x(3, 4, "5");

            Func<int, int, string, int> y = AddThem2;
            Console.WriteLine(y(5,6,"7"));

            //using a lambda
            Func<int, int, string, int> T = (X,Y,Z) => X + Y + Convert.ToInt32(Z);
            Console.WriteLine(T(8, 9, "10"));




            Console.ReadLine();
        }

        static void AddThem(int x, int y, string z)
        {
            Console.WriteLine(x + y + Convert.ToInt32(z));
        }

        static int AddThem2(int x, int y, string z)
        {
            return x + y + Convert.ToInt32(z);
        }
    }
}
