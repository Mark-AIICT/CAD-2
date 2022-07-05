using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericsDDLS
{
    class Demo1_TheNeedFor
    {
        public static void P1_TheProblem()
        {
            //Look mum, no compile errors!
            ArrayList x = new ArrayList();
            x.Add(22);
            x.Add(33);
            x.Add("cat");

            foreach (int var in x)
            {
                Console.WriteLine(var.ToString());
            }
        }

        public static void P2_TheTraditionalSolution()
        {
            IntegerCollection x = new IntegerCollection();
            x.Add(22);
            x.Add(33);
            //x.Add("cat");  //causes a compile error. GOOD !

            foreach (int var in x)
            {
                Console.WriteLine(var.ToString());
            }
        }

        public static void P3_TheTraditionalSolutionAndPerformance()
        {
            Console.WriteLine("Running P3_TheTraditionalSolutionAndPerformance...Wait)");
            DateTime start = DateTime.Now;

            IntegerCollection x = new IntegerCollection(); //we defined the integercollection class
            for (int i = 0; i < 5000000; i++)
            {
                x.Add(i);
            }
            
            foreach (int var in x)
            {
                int y = 0;
                y = var; //Un-Box here
                y = y + 1;
            }

            Console.WriteLine("Total time (using collections): " + DateTime.Now.Subtract(start).TotalMilliseconds.ToString() + " milliseconds");




        }

        public static void P4_GenericsSolutionAndPerformance()
        {
            Console.WriteLine("Running P4_GenericsSolutionAndPerformance...Wait)");
            DateTime start = DateTime.Now;


            List<int> x = new List<int>();

            for (int i = 0; i < 5000000; i++)
            {
                x.Add(i);
            }


            foreach (int var in x)
            {
                int y = 0;
                y = var;
                y = y + 1;
            }

            Console.WriteLine("Total time (using generic list): " + DateTime.Now.Subtract(start).TotalMilliseconds.ToString() + " milliseconds");




        }

    }

    public class IntegerCollection : CollectionBase
    {
        public void Add(int item)
        {
            this.List.Add(item);
        }

        public void Remove(int item)
        {
            this.List.Remove(item);
        }

        public int this[int index]
        {
            get
            {
                return ((int)(this.List[index]));
            }
            set
            {
                this.List[index] = value;
            }
        }
    }
}
