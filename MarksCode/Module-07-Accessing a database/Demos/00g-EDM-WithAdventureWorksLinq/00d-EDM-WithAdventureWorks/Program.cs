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


            var avgProductprice = ctx.Products.Average(prod => prod.ListPrice);

            Console.WriteLine($"The average product price in the database is {avgProductprice:C}");
            Console.WriteLine("Press a key to end");
            Console.ReadKey();
        }
    }
}
