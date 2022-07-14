using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00d_Exercise_StartATask
{
    delegate string MyDelegate(List<string> s);
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "The ";
            string s2 = "psychopathic ";
            string s3 = "leader ";

            List<string> strings = new List<string> { s1, s2, s3 };

            MyDelegate pointerToMyJoiningFunction = JoinStrings;

            Task<string> T = new Task<string>(new Func<List<string>,string>>(JoinStrings), strings);


            T.Start();
            T.Wait();

            Console.WriteLine($"{T.Result}");

            Console.WriteLine("Ok, we're done. press <enter> to end");
            Console.ReadLine();
            }

        static string JoinStrings(List<string> x)
        {

            string result = "";
            foreach (var item in x)
            {
                result += item;
            }
            return result;
        }
    

        private static void DoSomethingThatTakesALongTime()
        {
            decimal result = 0;
            for (decimal i = 0; i < 30000000M; i++)
            {
                result += i;
            }
        }
    }

}

