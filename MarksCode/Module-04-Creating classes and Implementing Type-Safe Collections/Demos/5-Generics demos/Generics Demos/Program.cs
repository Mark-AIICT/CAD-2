using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDDLS
{
    class Program
    {
        static void Main(string[] args)
        {

            /**************************************
             * DEMO 1 - Need 
             **************************************/

            Demo1_TheNeedFor.P1_TheProblem();
            
            
            //Demo1_TheNeedFor.P2_TheTraditionalSolution();


            //Demo1_TheNeedFor.P3_TheTraditionalSolutionAndPerformance();
            //GC.Collect();
            //Demo1_TheNeedFor.P4_GenericsSolutionAndPerformance();


            /**************************************
             * DEMO 2 - Generics and parameters
             **************************************/
            //GenericsDDLS_Demo2.TestFunctions.P1_GenericsAndParameters();
            //GenericsDDLS_Demo2.TestFunctions.P2_GenericsAndParameters();


            /**************************************
             * DEMO 3 - Generic methods
             **************************************/
            //GenericsDDLS_Demo3.TestFunctions.P1_GenericMethods();

            /**************************************
             * DEMO 4 - Generic Interfaces
             **************************************/
            //GenericsDDLS_Demo4.TestFunctions.P1_TestAdderClass();

            /**************************************
             * DEMO 5 - Generics and overloading
             **************************************/
            //GenericsDDLS_Demo5.TestFunctions.P1_TestOverloadedClassAndFunctions();

            /**************************************
            * DEMO 6 - Generics and constraints
            **************************************/
            //GenericsDDLS_Demo6.TestFunctions.P1_TestConstraints();

            /**************************************
            * DEMO 7 - Generics and constraints
            **************************************/
            //GenericsDDLS_Demo7.TestFunctions.P1_TestInheritanceConstraint();


           /**************************************
           * DEMO 8 - The new constraint
           **************************************/
            //GenericsDDLS_Demo8.TestFunctions.P1_TestTheNewConstraint();

            Console.WriteLine("press any key to end");
            Console.ReadLine();
        }

        
    }
}
