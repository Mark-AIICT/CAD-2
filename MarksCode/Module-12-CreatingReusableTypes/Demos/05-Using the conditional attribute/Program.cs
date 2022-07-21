#define IN_DEBUG_MODE

using System;
using System.Collections.Generic;
using System.Text;



namespace P9__Using_the_conditional_attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeFunctionOfSomeSort();
            Console.WriteLine("Press any key to continue"); Console.ReadLine();

        }

        [System.Diagnostics.Conditional("IN_DEBUG_MODE")]
        private static void SomeFunctionOfSomeSort()
        {
            //Note that this function is still compiled, it's just that the call 
            //to it won't execute unless the #define IN_DEBUG_MODE statement is 
            //included.
            Console.WriteLine("The SomeFunctionOfSomeSort function ran");
        }
    }
}
