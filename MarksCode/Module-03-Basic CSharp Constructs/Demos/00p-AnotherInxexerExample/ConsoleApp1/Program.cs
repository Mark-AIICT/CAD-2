using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public enum OrderNumberSection { Category=1, OrderN=2};
        struct Order //data type, has data, has functionality, stack data
        {
            private string _orderNumber; //field
            public string OrderNumber //property (read only)
            {
                get { return _orderNumber; }
            }
            public Order(string orderNumber) //Constructor. usually iniatlize the structure's data
            {
                _orderNumber = orderNumber;
            }
            public string this[OrderNumberSection section] //Indexer
            {
                get
                {
                    if (section == OrderNumberSection.Category)
                    {
                        return _orderNumber.Substring(0, 4);
                    }
                    else
                    {
                        return _orderNumber.Substring(5, 8);

                    }
                }
            }
        }
2        static void Main(string[] args)
        {
            Order order1 = new Order("ACME-28837740");
            Console.WriteLine($"First Order number: {order1.OrderNumber}");
            Console.WriteLine($"First Order Category: {order1[OrderNumberSection.Category]}");
            Console.WriteLine($"First Order OrderN: {order1[OrderNumberSection.OrderN]}");
            Console.ReadLine();
        }
    }
}
