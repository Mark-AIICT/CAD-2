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

            //Linq query using extensions
            //var productsToIncreasePrice = ctx.Products.Where(p => p.ListPrice > 0 && p.Name.Contains("e"));

            //Linq query using expression (SQL-like C# language)
            var productsToIncreasePrice = from p in ctx.Products
                                          where p.ListPrice > 0 && p.Name.Contains("e")
                                          select p;

            foreach (var productFound in productsToIncreasePrice)
            {
                Console.WriteLine($"\n\t\t before: {productFound.Name}, {productFound.ListPrice:C}");
                productFound.ListPrice *= 1.5M;
                Console.WriteLine($"\t\t after: {productFound.Name}, {productFound.ListPrice:C}");

            }

            ctx.SaveChanges();

            Console.WriteLine("Press a key to end");
            Console.ReadKey();
        }
    }
}
