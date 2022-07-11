using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>()
            {
                new Person() { PersonCity = "Perth", PersonName = "Rusty" },
                new Person() { PersonCity = "Llilongwe", PersonName = "Trang" },
                new Person() { PersonCity = "Melbourne", PersonName = "Mohammad" }
            };

            string serializedData = JsonConvert.SerializeObject(people, Formatting.Indented);
            Console.WriteLine(serializedData);

            Console.WriteLine("______________________________");


            var p = JsonConvert.DeserializeObject<List<Person>>(serializedData);

            foreach (var item in p)
            {
                Console.WriteLine($"{item.PersonName} is from {item.PersonCity}" );
            }

            Console.ReadLine();

        }
    }

    class Person
    {
        public string PersonName { get; set; }
        public string PersonCity { get; set; }
    }
}
