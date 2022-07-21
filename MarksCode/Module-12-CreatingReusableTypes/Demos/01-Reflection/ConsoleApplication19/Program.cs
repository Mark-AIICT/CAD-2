using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer() { Name = "frank", PostCode = "3000", Age = 55 };
            var xyz = new { field1 = "hello", field2 = 66 };

            LogObject(c);
            LogObject(xyz);

            Console.WriteLine("All done. Press enter to exit");
            Console.ReadLine();
        }

        public static void LogObject(object c)
        {
            Console.WriteLine("\n\n\n====================================================");
            Console.WriteLine("Logging object, type={0}", c.GetType().Name);
            Console.WriteLine("====================================================");

            foreach (var item in c.GetType().GetMembers())
            {
                if (item.MemberType == MemberTypes.Property)
                {
                    Console.WriteLine("Property:{0}\n Value:{1}\n DataType:{2}\n",
                        item.Name,
                        c.GetType().GetProperty(item.Name).GetValue(c, null),
                        c.GetType().GetProperty(item.Name).PropertyType);
                    Console.WriteLine("-----------------------------------------------------");
                }
            }
        }
    }



    public class Customer
    {
        public string Name { get; set; }
        public string PostCode { get; set; }
        public int Age { get; set; }
    }
}
