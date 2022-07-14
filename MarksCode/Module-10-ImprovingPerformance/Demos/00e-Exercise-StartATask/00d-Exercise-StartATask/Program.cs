using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00d_Exercise_StartATask
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "The ";
            string s2 = "psychopathic ";
            string s3 = "leader ";
            string s4 = "keeps saying he did nothing wrong ";


            List<string> strings = new List<string> { s1, s2, s3, s4 };

            Task<string> T = new Task<string>(p =>
            {
                DoSomethingThatTakesALongTime();
                string result = "";
                foreach (var s in (List<string>)p)
                {
                    result += s;
                }
                return result;
            }, strings);


            T.Start();
            Console.WriteLine("Processing task in background. Please wait.....");
            T.Wait();

            Console.WriteLine($"{T.Result}");

            Console.WriteLine("Ok, we're done. press <enter> to end");
            Console.ReadLine();
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

