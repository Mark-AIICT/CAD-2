using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS_Demo6
{
    public class TestFunctions
    {
        public static void P1_TestConstraints()
        {
            Tester<string> obj = new Tester<string>();
            Console.WriteLine("The biggest of 'z' and 'a' is {0}", 
                obj.ReturnTheBiggest("z", "a"));

            Tester<int> obj2 = new Tester<int>();
            Console.WriteLine("The biggest of '3' and '5' is {0}",
                obj2.ReturnTheBiggest(3, 5).ToString());

            Tester<Person> obj3 = new Tester<Person>();
            Person a1 = new Person();
            a1.id = "A1";
            a1.age = 44;
            Person b1 = new Person();
            b1.id = "B1";
            b1.age = 22;

            Console.WriteLine("The biggest of 'Person A1' and 'Person B1' is {0}",obj3.ReturnTheBiggest(a1, b1).id.ToString());


        }

    }


    //class Tester<T>
    //{
    //    public T test(T value)
    //    {
    //        return value;
    //    }

    //    public T ReturnTheBiggest(T x, T y)
    //    {
    //        if (x > y) //This line won't compile
    //        {
    //            return x;
    //        }
    //        else
    //        {
    //            return y;
    //        }
    //    }
    //}


    class Tester<T> where T : IComparable<T>
    {
        public T test(T value)
        {
            return value;
        }
        public T ReturnTheBiggest(T x, T y)
        {
            if (((IComparable<T>)x).CompareTo(y) > 0)
            {
                return x;
            }
            else
            {
                return y;
            }
        }
    }


    public class Person : IComparable<Person>
    {
        public string id;
        public int age;

        public int CompareTo(Person other)
        {
            if (this.age > other.age)
                return 1;
            else
                return 0;
        }


    }




}
