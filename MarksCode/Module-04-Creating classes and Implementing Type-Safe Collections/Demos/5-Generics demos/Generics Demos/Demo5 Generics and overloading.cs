using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS_Demo5
{
    public class TestFunctions
    {
        public static void P1_TestOverloadedClassAndFunctions()
        {
            Truck x = new Truck(); //this uses one of the truck classes
            Truck<string> y = new Truck<string>(); //This uses the other truck class

            y.functionA("Hino");
            Truck<int, decimal> z = new Truck<int, decimal>();
        }

    }

    public class Truck
    {
    }

    public class Truck<T>
    {
        T truckKey;

        public T functionA(T s)
        {
            return s;
        }
        public T functionA(int s)
        {
            return default(T); //we used default(T) because you can't use 'null' as T 
                               //might not be nullable. 
        }
    }

    //Notice that this class and the one above have the same name
    //and they are in the same namespace. The class used can be determined
    //at compile time by the number of generics bound.
    public class Truck<T,K>
    {
        T truckKey;
        K truckColour;
    }
}
