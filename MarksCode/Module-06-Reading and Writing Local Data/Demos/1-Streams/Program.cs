using System;
using System.Collections.Generic;
using System.Text;

namespace P30_System.IO_Namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\infile.txt");
            // Text in from file
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\outfile.txt");
            // Text out to file
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
            reader.Close();
            writer.Flush();
            writer.Close();

            Console.WriteLine("Press any key to continue"); Console.ReadLine();
        }
    }
}
