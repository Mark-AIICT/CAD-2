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

            foreach (var productcategory in ctx.ProductCategories)
            {
                Console.WriteLine($"{productcategory.Name}");
                foreach (var productsubcategory in productcategory.ProductSubcategories)
                {
                    Console.WriteLine($"\t{productsubcategory.Name}");
                    foreach (var product in productsubcategory.Products)
                    {
                        Console.WriteLine($"\t\t before: {product.Name}, {product.ListPrice:C}");
                        product.ListPrice *= 1.1M;
                        Console.WriteLine($"\t\t after: {product.Name}, {product.ListPrice:C}");


                    }
                }
            }

            ctx.SaveChanges();

            Console.WriteLine("Press a key to end");
            Console.ReadKey();
        }
    }
}
