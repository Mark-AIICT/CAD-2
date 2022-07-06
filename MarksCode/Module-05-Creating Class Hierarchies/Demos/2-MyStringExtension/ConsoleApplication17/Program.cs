using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "jsjjdhhsuwuwudbh";
            string y = "ajjs@sjjs.com";

            Console.WriteLine($" {x} is valid?  {x.IsValidEmail()}");
            Console.WriteLine($" {y} is valid?  {y.IsValidEmail()}");

            Console.WriteLine("Press enter to end");

            Console.ReadKey();
             
        }
    }
    static class MyExtraStuff
    {

        static public bool IsValidEmail(this string email)
        {
            Regex regex = new Regex(
                      "([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1" +
                      ",3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
                    RegexOptions.IgnoreCase
                    | RegexOptions.CultureInvariant
                    | RegexOptions.IgnorePatternWhitespace
                    | RegexOptions.Compiled
                    );

            bool IsOK = false;

            if (regex.Match(email).Captures.Count > 0 &&
                regex.Match(email).Captures[0].ToString() == email)
                IsOK = true;

            return IsOK;
        }
    }
}
