using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS_Demo8
{
    public class TestFunctions
    {
        public static void P1_TestTheNewConstraint()
        {
            int[] integers = CreateArray<int>(20);

            System.Windows.Forms.Button[] buttons = 
                CreateArray<System.Windows.Forms.Button>(35);
        }

        public static T[] CreateArray<T>(int numberElements) where T : new()
        {
            T[] arrayValues = new T[numberElements];
            for (int i = 0; i < numberElements; i++)
            {
                arrayValues[i] = new T();
            }

            return arrayValues;
        }
    }



}
