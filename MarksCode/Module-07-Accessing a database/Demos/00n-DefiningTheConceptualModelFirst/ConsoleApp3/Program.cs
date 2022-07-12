using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            townsAndSuppliersContainer ctx = new townsAndSuppliersContainer();

            ctx.Towns.Add(new Town()
            {
                TownId = 1,
                Suppliers = new List<Supplier>
                                        { new Supplier
                                            {
                                                ContactId = 22,
                                                BusinessNumber = "AAA",
                                                ContactAddress = "aa st",
                                                Capitlization = 466666M,
                                                ContactName = "ACME"
                                            }
                                        }
            });

            ctx.SaveChanges();
        }
    }
}
