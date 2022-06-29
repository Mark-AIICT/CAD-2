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

            mySource.Listeners["console"].Filter = new EventTypeFilter(SourceLevels.Error); //This statement mandates that all messages processed by the "console" listener must be at least an error. 
            
            //mySource.Switch.Level = SourceLevels.All; //This statement will override any settings in the configuration file.

            //mySource.Listeners["console"].Filter = configFilter; // Restore the original filter settings.

            Activity1();
            Activity2();
            Activity3();
            mySource.Close();
            Console.ReadLine();


        }

        static void Activity1()
        {
            mySource.TraceEvent(TraceEventType.Error, 1, "Error message.");
            mySource.TraceEvent(TraceEventType.Warning, 2, "Warning message.");
        }

 
        static void Activity2()
        {
            mySource.TraceEvent(TraceEventType.Critical, 3, "Critical message.");
            mySource.TraceInformation("Informational message.");
        }
        static void Activity3()
        {
            mySource.TraceEvent(TraceEventType.Error, 4,
                "Error message.");
            mySource.TraceInformation("Informational message.");
        }



    }
}
