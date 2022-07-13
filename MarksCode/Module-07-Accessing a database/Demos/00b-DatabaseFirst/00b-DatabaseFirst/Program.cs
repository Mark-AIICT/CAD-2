using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolDBEntities ctx = new SchoolDBEntities();
            foreach (var teacher in ctx.Teachers)
            {
                Console.WriteLine($"\n\nTeacher: {teacher.FirstName} {teacher.LastName}");
                Console.WriteLine("--------------------------------------------------------------------");
                foreach (var student in teacher.Students)
                {
                    Console.WriteLine($"{student}, {student.DateOfBirth.ToLongDateString()}");

                }

            }

            Console.WriteLine("Press a key to end");
            Console.ReadKey();
        }
    }
}
