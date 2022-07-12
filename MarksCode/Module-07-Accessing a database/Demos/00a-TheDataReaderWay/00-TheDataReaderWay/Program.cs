using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_TheDataReaderWay
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            //define connection to SQL Server
            SqlConnection cnx = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True");

            //define the caommand to run
            SqlCommand cmd = new SqlCommand("select * from student", cnx);

            //run the command
            cnx.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt32(reader["Id"]),                
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                    ClassId = Convert.ToInt32(reader["ClassId"])
                });
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}, {student.DateOfBirth.ToLongDateString()}");

            }

    cnx.Close();

            Console.WriteLine("Press a key to end");
            Console.ReadKey();

        }

        class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int ClassId { get; set; }

        }
    }
}
