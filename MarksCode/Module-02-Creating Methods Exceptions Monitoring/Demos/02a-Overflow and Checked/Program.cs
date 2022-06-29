using System;
using System.Collections.Generic;
using System.Text;

namespace P58_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            long L = long.MaxValue;
            int I;


            //checked(I = (int)L);  //this would raise an exception
            
            I = (int)L;             //this does not raise an exception.

            Console.WriteLine("I={0}, L={1}",I,L);
            Console.ReadLine();
        }
    }
}
