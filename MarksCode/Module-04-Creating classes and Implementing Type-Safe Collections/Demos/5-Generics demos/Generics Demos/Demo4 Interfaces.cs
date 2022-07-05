using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS_Demo4
{

    public class TestFunctions
    {
        public static void P1_TestAdderClass()
        {
            IAdder<int> A1 = new Adder();
            int result = A1.Add(23, 55);
            Console.WriteLine("Result1=" + result.ToString());

            IAdder<decimal> A2 = new Adder();
            decimal result2 = A2.Add(45.77M, 88.99M);
            Console.WriteLine("Result2=" + result2.ToString());

            //IAdder<double> A3 = new Adder();  //This line does not compile because the adder class does not implement the IAdder<double> interface
            //double result3 = A3.Add(23D, 55D);
            //Console.WriteLine("Result3=" + result3.ToString());

            IAdder<decimal> A4 = new Adder2<decimal>();
            decimal result4 = A4.Add(66, 44);
            Console.WriteLine("Result4=" + result4.ToString());


        }

    }

    public interface IAdder<T>
    {
        T Add(T n1, T n2);
    }

    //Notice here that the class implementing the interface 
    //IS resolving the type of the generic at compile time.
    public class Adder : IAdder<int>, IAdder<decimal>
    {
        // Implementation of IAdder<int>.Add
        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        // Implementation of IAdder<decimal>.Add
        public decimal Add(decimal n1, decimal n2)
        {
            return n1 + n2;
        }
    }

    //Notice here that the class implementing the interface 
    //is not resolving the type of the generic at compile time.
    //Instead, it will be thr responsibility of the user of the class
    //to resilve the type.
    public class Adder2<T> : IAdder<T>
    {
        public T Add(T n1, T n2)
        {
            //return n1 + n2; //This does not compile

            return n1;
        }
    }
}
