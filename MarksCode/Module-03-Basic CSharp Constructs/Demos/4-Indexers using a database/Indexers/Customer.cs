using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Indexers
{
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return StudentName + ", " + StudentID;
        }

        public Student this[int index]
        {
            get
            {
                SqlConnection cn = new SqlConnection(@"Data Source= (localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select * from Student", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                for (int i = 0; i < index; i++)
                {
                    dr.Read();
                }


                return new Student() { StudentID = dr[0].ToString(), StudentName = dr[1].ToString() };


            }
            set { /* set the specified index to value here */ }
        }

        public Student this[string index]
        {
            get
            {

                SqlConnection cn = new SqlConnection(@"Data Source= (localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(string.Format("Select * from Student where FirstName='{0}'",index), cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                return new Student() { StudentID = dr[0].ToString(), StudentName = dr[1].ToString() };


            }
            //set { /* set the specified index to value here */ }
        }


    }
}
