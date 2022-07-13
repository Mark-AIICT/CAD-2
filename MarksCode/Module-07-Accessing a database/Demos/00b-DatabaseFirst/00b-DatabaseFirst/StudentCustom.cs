using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00b_DatabaseFirst
{
    public partial class Student
    {
        public override string ToString()
        {
            return $"name: {FirstName} {LastName}";
        }
    }
}
