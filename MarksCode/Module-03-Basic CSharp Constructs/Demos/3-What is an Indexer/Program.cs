using System;
using System.Collections.Generic;
using System.Text;

namespace P18__What_is_an_Indexer
{
    class Program
    {
        static void Main(string[] args)
        {

            Company c = new Company();
            c.AddEmployee("Joe", "Sydney");
            c.AddEmployee("Ang", "Parramatta");

            Console.WriteLine(c[0]);
            Console.WriteLine(c[1]);

            Console.WriteLine(c["Ang"]);
            Console.WriteLine("Press any key to continue"); Console.ReadLine();

        }


    }

    public class employee
    {
        public string FullName;
        public string City;
    }

    public class Company
    {
        private employee[] Employees;

        public void AddEmployee(string FullName, string City)
        {
            if (Employees == null)
            {
                Employees = new employee[1];
            }
            else
            {
                employee[] newEmployeeArray = new employee[Employees.Length + 1];
                Employees.CopyTo(newEmployeeArray, 0);
                Employees = newEmployeeArray;
            }

            Employees[Employees.GetUpperBound(0)] = new employee();
            Employees[Employees.GetUpperBound(0)].FullName = FullName;
            Employees[Employees.GetUpperBound(0)].City = City;


        }

        public string this[int index]
        {
            get
            {
                return "Employee " + index.ToString() + " is " + Employees[index].FullName;
            }
        }

        public string this[string fullname]
        {
            get
            {
                employee empFound = null;
                foreach (employee emp in Employees)
                {
                    if (emp.FullName == fullname)
                    {
                        empFound = emp;
                        break;
                    }

                }

                if (empFound != null)

                    return "Employee city is " + empFound.City;
                else
                    return "Employee not found";


            }
        }


    }


}

