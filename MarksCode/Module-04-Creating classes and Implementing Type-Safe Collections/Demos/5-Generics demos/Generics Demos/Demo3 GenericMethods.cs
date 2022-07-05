using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS_Demo3
{
    public class TestFunctions
    {
        public  static void P1_GenericMethods()
        {
            int x = 3; int y = 4;
            string w = "Cryosphere"; string k = "Terrasphere";

            Console.WriteLine("before swap x={0}, y={1}, w={2}, k={3}", x.ToString(), y.ToString(), w, k);

            GenericsDDLS_Demo3.TestFunctions.Swap<int>(ref x, ref y);
            GenericsDDLS_Demo3.TestFunctions.Swap<string>(ref w, ref k);


            Console.WriteLine("after swap x={0}, y={1}, w={2}, k={3}", x.ToString(), y.ToString(), w, k);
        }

        //  Exchange two arguments passed by address.
        public static void Swap<T>(ref T x, ref T y)
        {
            T tmp = x;
            x = y;
            y = tmp;
        }
    }
}
