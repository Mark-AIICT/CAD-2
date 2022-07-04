using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BasicEnums
{
    class Program
    {
        enum WeekDay { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        static void Main(string[] args)
        {
            //Choice 1:
            //greater chance of error
            //harder to read
            int dayOfWeek;

            dayOfWeek = 0; //Sunday
            dayOfWeek = 1; //Monday

            //Choice 2:
            //less chance of error
            //easier to read
            WeekDay holiday;
            holiday = WeekDay.Mon;

            holiday = holiday + 1;

            Console.WriteLine($"the holiday will be {holiday}");
            Console.ReadLine();


        }
    }
}
    