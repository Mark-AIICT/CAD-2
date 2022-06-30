using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;


namespace TraceSourceDemo
{
    class Program
    {

        private static TraceSource mySource = new TraceSource("TraceSourceApp");
        static void Main(string[] args)
        {

            Activity1();
            Activity2();
            Activity3();
            mySource.Close();
            Console.ReadLine();


        }

        static void Activity1()
        {
            mySource.TraceEvent(TraceEventType.Error, 11, "Error message example 1.");
            mySource.TraceEvent(TraceEventType.Warning, 22, "Warning message example 1.");
        }

 
        static void Activity2()
        {
            mySource.TraceEvent(TraceEventType.Critical, 33, "Critical message example 1.");
            mySource.TraceEvent(TraceEventType.Information, 22, "Information message example 1.");

        }
        static void Activity3()
        {
            mySource.TraceEvent(TraceEventType.Error, 84, "Error message example  2.");
            mySource.TraceEvent(TraceEventType.Information, 77, "Information message example 2.");

        }



    }
}
