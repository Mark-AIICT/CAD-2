using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WindowWidth = 200;
            Customer c = new Customer() { CustomerAddress = "Melbourne", CustomerName = "Jenny" };
            DescribeObject(c);

            Supplier s = new Supplier() { SupplierAddress = "Sydney", SupplierName = "Ben" };
            DescribeObject(s);

            Console.ReadLine();

        }

        static void DescribeObject(Object theThing)
        {
            Console.WriteLine("=================");
            Console.WriteLine("The Object is a {0}",theThing.GetType().Name);
            Console.WriteLine(".................");
            foreach (var item in theThing.GetType().GetProperties())
            {
                Console.WriteLine("PropertyName:{0}, PropertyValue:{1}", item.Name, item.GetValue(theThing,null));
            }
     
            foreach (var attr in theThing.GetType().GetCustomAttributes(false))
            {
                foreach (var p in attr.GetType().GetProperties())
                {
                    Console.WriteLine("Attribute:{0}, Property:{1} Value:{2}", attr, p.Name, p.GetValue(attr,null));
                }
                
            }
            Console.WriteLine("=================");

        }
    }

    [Obsolete("Please try not to use this anymore")]
    [Serializable]
    [ImportantDetails("2017","Version1")]
    class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

    }
    
    class Supplier
    {
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }

    }

    class ImportantDetailsAttribute : Attribute
    {
        public string CYear { get; set; }
        public string CVersion { get; set; }


        public ImportantDetailsAttribute(string YearWritten, string currentVersion)
        {
            CYear = YearWritten;
            CVersion = currentVersion;
        }

    }
}
