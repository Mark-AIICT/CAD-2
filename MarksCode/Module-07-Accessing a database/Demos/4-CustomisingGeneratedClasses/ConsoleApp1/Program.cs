using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            AdventureWorksEntities ctx = new AdventureWorksEntities();

            var q = from c in ctx.Contacts where c.LastName.StartsWith("A") select c;
            foreach (var item in q)
            {
                Console.WriteLine($"\n\nFormerly {item.FirstName} {item.LastName}, {item.EmailAddress}");
                item.EmailAddress = $"{item.FirstName}.{item.LastName}@advworks.com";
                Console.WriteLine(item.GenerateNotification());
            }
            ctx.SaveChanges();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public partial class Contact
    {
        public string GenerateNotification()
        {
            return $"Dear {Title} {FirstName} {LastName}, We are writing to you to let you know that we will be changing your email address to {EmailAddress}";
        }
    }
}
