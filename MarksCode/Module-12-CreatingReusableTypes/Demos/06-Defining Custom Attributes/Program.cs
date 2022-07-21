using System;
using System.Collections.Generic;
using System.Text;

namespace P14__Defining_Custom_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            employee emp = new employee();
            emp.FullName = "Mark";
            emp.City = "Sydney";

            Frog frog = new Frog();
            frog.FrogColour = "Green";
            frog.FrogSpecies = "Bombina orientalis";

            Utility.LogAnObject(emp);
            Utility.LogAnObject(frog);



            Console.WriteLine(@"OK, Done. Now look at c:\temp\Company.txt, c:\temp\emp.txt and c:\frog.txt");

            Console.ReadLine();
        }
    }
    


    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class MLoggerAttribute : System.Attribute
    {
        string m_FileLocation;

        public MLoggerAttribute(string FileLocation)
        {
            m_FileLocation = FileLocation;
        }

        public string FileLocation
        {
            get
            {
                return m_FileLocation;
            }
        }

    }

    [MLogger(@"C:\temp\emp.txt")]
    [MLogger(@"C:\temp\Company.txt")]
    public class employee
    {
        public string FullName;
        public string City;

        public override string ToString()
        {
            return "Employee fullname is " + FullName + ", city is " + City;
        }
    }

    [MLogger(@"C:\temp\Frog.txt")]
    public class Frog
    {
        public string FrogColour;
        public string FrogSpecies;

        public override string ToString()
        {
            return "FrogColour is " + FrogColour + ", species is " + FrogSpecies;
        }
    }

    public class Utility
    {
        public static void LogAnObject(object obj)
        {
            //work out where to log the object from the attribute
            string LogPath;

            System.Reflection.MemberInfo typeInfo;
            typeInfo = obj.GetType();

            if (typeInfo.IsDefined(typeof(MLoggerAttribute), false))  //determine if the object supports the MLogger attribute
            {
                foreach (Attribute att in typeInfo.GetCustomAttributes(false))
                {
                    if (att is MLoggerAttribute) //ensure that the current attribute is MLogger
                    {
                        MLoggerAttribute m = (MLoggerAttribute)att;
                        LogPath = m.FileLocation;

                        System.IO.File.AppendAllText(LogPath, obj.ToString());
                    }
                }
            }

        }
    }
}
