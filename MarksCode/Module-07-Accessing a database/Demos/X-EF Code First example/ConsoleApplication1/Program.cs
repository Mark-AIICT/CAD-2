using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MyInitializer());

            var person = new Person
            {
                PersonId = -1,
                FirstName = "Mark",
                LastName = "Walsh",
                BirthDate = DateTime.Now
            };



            using (var context = new MyContext())
            {
                context.Persons.Add(person);
                context.Projects.Add(new Project
                {
                    Name = "booralie",
                    ManagerId = person.PersonId,
                    Manager = person
                });
                context.SaveChanges();
            }
            Console.Write("Person saved !");
            Console.ReadLine();
        }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PersonCity { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Person Manager { get; set; }
    }


    public class MyContext : DbContext
    {
        public MyContext()
        { }

        

        public DbSet<Person> Persons { get; set; }

        public DbSet<Project> Projects { get; set; }
    }

    public class MyInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
    }

}
