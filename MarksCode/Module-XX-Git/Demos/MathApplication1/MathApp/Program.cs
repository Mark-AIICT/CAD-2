using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            decimal x = 33, y = 4;
            try
            {
                Console.WriteLine("\n\nAdd");
                Console.WriteLine(Add(x, y));
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message); 
            }

            try
            {
                Console.WriteLine("\n\nSubtract");
                Console.WriteLine(Subtract(x, y));
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("\n\nDivide");
                Console.WriteLine(Divide(x, y));
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("\n\nMultiply");
                Console.WriteLine(Multiply(x, y));
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("\n\nCube");
                Console.WriteLine(Cube(x, y));
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("\n\nSquare");
                Console.WriteLine(Square(x, y));
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
