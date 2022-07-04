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
            int dayOfWeek;

            dayOfWeek = 0; //Sunday
            dayOfWeek = 1; //Monday

            WeekDay holiday;
            holiday = WeekDay.Mon;

            holiday = holiday + 1;

            Console.WriteLine($"the holiday will be {holiday}");
            Console.ReadLine();


        }
    }
}
