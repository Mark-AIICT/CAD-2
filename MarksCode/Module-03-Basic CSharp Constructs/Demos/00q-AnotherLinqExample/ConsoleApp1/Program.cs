using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        struct Order //data type, has data, has functionality, stack data
        {
            public int ProductNumber { get; set; }
            public string ProductDescription { get; set; }
        }
       static void Main(string[] args)
        {
            List<Order> orders = new List<Order>()
            {
                new Order(){ProductNumber=111, ProductDescription="Edible sticky tape for spies"},
                new Order(){ProductNumber=222, ProductDescription="Sunglasses for a bin chicken"},
                new Order(){ProductNumber=333, ProductDescription="Ret Hat"},
                new Order(){ProductNumber=444, ProductDescription="Pair of thongs"}
            };

            var allEOrders = from x in orders 
                             where x.ProductDescription.Contains("e")
                             select x;


            foreach (var item in allEOrders)
            {
                Console.WriteLine($"ProductNumber={item.ProductNumber}, ProductDescription={item.ProductDescription}");
            }




            Console.ReadLine();
        }
    }
}
