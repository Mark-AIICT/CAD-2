﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _00c_Directory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List of Directories");
            Console.WriteLine("-----------------------");

            foreach (var directory in Directory.GetDirectories(@"C:\windows"))
            {
                Console.WriteLine($"Directory found {directory}");
            }

            Console.WriteLine("\n\nList of Files");
            Console.WriteLine("-----------------------");
            foreach (var file in Directory.GetFiles(@"C:\windows"))
            {
                Console.WriteLine($"file found {Path.GetFileNameWithoutExtension(file)}, the file extension is  {Path.GetExtension(file)}");
            }

            Console.WriteLine("press any key to end");
            Console.ReadKey();
        }
    }
}
