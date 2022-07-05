using System;
using System.Collections.Generic;
using System.Text;

namespace P26__Private_constructors__Singleton_pattern_
{
    class Program
    {
        static void Main(string[] args)
        {

            Singleton s = Singleton.GetSingleton();
            Console.WriteLine("object S: " + s.TimeObjectCreated());


            Singleton s2 = Singleton.GetSingleton();
            Console.WriteLine("object S2: " + s2.TimeObjectCreated());
            Console.WriteLine("Press any key to continue"); Console.ReadLine();
        }

       
        
        public class Singleton
        {
            private static Singleton m_Singleton;
            private static DateTime m_timeCreated;
            private Singleton()
            {
                m_timeCreated = DateTime.Now;
            }

            public static Singleton GetSingleton()
            {
                if (m_Singleton == null)
                    m_Singleton = new Singleton();

                return m_Singleton;
            }

            public string TimeObjectCreated()
            {
                return "Object created: " + m_timeCreated.ToLongTimeString();
            }

        }

        
    }
}
