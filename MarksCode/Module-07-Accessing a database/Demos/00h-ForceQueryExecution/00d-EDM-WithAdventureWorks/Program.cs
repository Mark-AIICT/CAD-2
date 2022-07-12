using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00d_EDM_WithAdventureWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorksEntities ctx = new AdventureWorksEntities();
            Console.WriteLine("Type something that should be in the product Name");
            var chars = Console.ReadLine();


            var x_Products = (from p in ctx.Products
                             where p.Name.Contains(chars)
                             select new { Prodname = p.Name, Price = p.ListPrice }).ToList(); //ToList causes the query to run here

            chars = "x";

            foreach (var prd in x_Products)   //linq query runs here
            {
                Console.WriteLine($"{prd.Prodname}\t\t\t{prd.Price:C}");
            }

            Console.WriteLine("Press a key to end");
            Console.ReadKey();
        }
    }
}
