using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            Student c = new Student();
            Console.WriteLine(c[2]);
            Console.WriteLine(c["Vijay"]);

            F(c[3]);
            Console.WriteLine("OK. Done, press enter to continue");
            Console.ReadLine();
        }

        static void F(Student CT)
        {
            Console.WriteLine(CT.StudentName);
        }
    }
}
