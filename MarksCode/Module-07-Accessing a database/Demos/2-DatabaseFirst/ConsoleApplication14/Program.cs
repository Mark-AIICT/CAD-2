using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorksEntities dc = new AdventureWorksEntities();
            

            var q = from psc in dc.ProductSubcategories
                    select psc;

            foreach (var ps in q)
            {
                Console.WriteLine(ps.Name);
                var prods = from p in ps.Products
                            where p.Name.Contains("e")
                            orderby p.ListPrice
                            select p;
                foreach (var prd in prods)
                {
                    Console.WriteLine("    {0}, {1:C}", prd.Name, prd.ListPrice);
                }
            }
            Console.Read();
        }
    }
}
