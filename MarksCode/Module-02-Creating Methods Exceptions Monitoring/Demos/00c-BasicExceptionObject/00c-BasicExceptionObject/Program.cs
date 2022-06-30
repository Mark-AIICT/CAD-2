using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00c_BasicExceptionObject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = 3;
                x = Divide(x, 0);
                File.WriteAllText(@"c:\temp\result.txt", $"the result is {x}");
                long z = long.MaxValue;
                int w = Convert.ToInt32(z);
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("Sadly. the application failed because of a number. ");
                Console.WriteLine("Message:" + ex.Message);
                Console.WriteLine("Stack trace:" + ex.StackTrace);

            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("The application is trying to write out to a file, but you don't have access");
                Console.WriteLine("details:" + ex.Message);
            }

            //catch all other exceptions. usually we'd end the program here.
            catch (Exception ex)
            {
                Console.WriteLine("oh no. something bad has happened that we didn't expect");
                Console.WriteLine("The application has to end");
                throw;

            }
            finally
            {
                Console.WriteLine("\n\nPress enter to end");
                Console.ReadLine();
            }
        }

        static int Divide(int top, int bottom)
        {
            try
            {
                return top / bottom;
            }
            catch (Exception)
            {
                Console.WriteLine("oops divide failed");
                throw;
            }
        }
    }
}
