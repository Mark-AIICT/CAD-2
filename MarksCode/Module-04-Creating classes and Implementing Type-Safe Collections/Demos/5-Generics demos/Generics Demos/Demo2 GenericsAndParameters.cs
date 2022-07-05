using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS_Demo2
{
    public class TestFunctions
    {
        public static void P1_GenericsAndParameters()
        {
            Person p1 = new Person("Mark");
            Person p2 = new Person("Wayne");
            Company c = new Company("DDLS");

            /* Example of using the relation class */
            Relation<Person, Company> rel1 =
                new Relation<Person, Company>(p1, c);

            Relation<Person, Company> rel2 =
                new Relation<Person, Company>(p2, c);

            Console.WriteLine(rel1.Thing2.CompanyName); //note the type safety!
            Console.WriteLine(rel1.Thing1.PersonName); //note the type safety!
        }

        public static void P2_GenericsAndParameters()
        {
            Person p1 = new Person("Mark");
            Person p2 = new Person("Wayne");
            Company c = new Company("DDLS");

            Person p3 = new Person("Jenny");
            Person p4 = new Person("Zoran");
            Company c2 = new Company("IBM");

            /* Example of using the relation class */
            Relation<Person, Company> rel1 =
                new Relation<Person, Company>(p1, c);

            Relation<Person, Company> rel2 =
                new Relation<Person, Company>(p2, c);

            Relation<Person, Company> rel3 =
                new Relation<Person, Company>(p3, c2);

            Relation<Person, Company> rel4 =
                new Relation<Person, Company>(p4, c2);


            List<Relation<Person, Company>> relations = new List<Relation<Person, Company>>();
            relations.Add(rel1);
            relations.Add(rel2);
            relations.Add(rel3);
            relations.Add(rel4);

            foreach(Person p in  GetEmployees(relations, c))
            {
                Console.WriteLine(p.PersonName + " Works for " + c.CompanyName);
            };
        }

        private static List<Person> GetEmployees(List<Relation<Person, Company>> relations, Company company)
        {
            List<Person> result = new List<Person>();
            foreach (Relation<Person,Company> rel in relations)
            {
                if (rel.Thing2 == company)
                {
                    result.Add(rel.Thing1);
                }
            }
            return result;
        }
    }

    public class Relation<T1, T2>
    {
        public readonly T1 Thing1;
        public readonly T2 Thing2;

        public Relation(T1 obj1, T2 obj2)
        {
            this.Thing1 = obj1;
            this.Thing2 = obj2;
        }


    }

    public class Company
    {

        public Company(string name)
        {
            this.CompanyName = name;
        }

        private string m_CompanyName;

        public string CompanyName
        {
            get { return m_CompanyName; }
            set { m_CompanyName = value; }
        }
	
    }

    public class Person
    {
        private string m_PersonName;

        public string PersonName
        {
            get { return m_PersonName; }
            set { m_PersonName = value; }
        }

        public Person(string PersonName)
        {
            this.PersonName = PersonName;
        }
	
    }


}
