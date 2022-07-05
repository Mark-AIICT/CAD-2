using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ienumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerCollection cc = new CustomerCollection();

            Console.WriteLine("Customers, Forwards");
            foreach (Customer c in cc)
            {
                Console.WriteLine("Customer name: {0}, address: {1}, Post Code: {2}", c.Name, c.Address, c.PostCode);
            }

            Console.WriteLine("\n\nCustomers, Evens");
            foreach (Customer c in cc.Evens)
            {
                Console.WriteLine("Customer name: {0}, address: {1}, Post Code: {2}", c.Name, c.Address, c.PostCode);
            }


            Console.WriteLine("\n\nCustomers, Backwards");
            foreach (Customer c in cc.Backwards)
            {
                Console.WriteLine("Customer name: {0}, address: {1}, Post Code: {2}", c.Name, c.Address, c.PostCode);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
