using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P30_System.IO_Namespace
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Stream inStream = new FileStream(@"C:\temp\infile.txt", FileMode.Open);
            Stream outStream = new FileStream(@"C:\temp\outfile.txt", FileMode.OpenOrCreate);


            StreamReader reader = new System.IO.StreamReader(inStream);
            StreamWriter writer = new System.IO.StreamWriter(outStream);


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
