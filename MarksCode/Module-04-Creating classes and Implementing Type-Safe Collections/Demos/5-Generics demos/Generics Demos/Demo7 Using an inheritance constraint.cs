using System;
using System.Collections.Generic;
using System.Text;


namespace GenericsDDLS_Demo7
{
    public class TestFunctions
    {
        public static void P1_TestInheritanceConstraint()
        {
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            b.Text = "hello";

            System.Windows.Forms.TextBox t = new System.Windows.Forms.TextBox();
            t.Text = "frog";

            Console.WriteLine(ControlUtilities<System.Windows.Forms.Button>.ReturnText(b));
            Console.WriteLine(ControlUtilities<System.Windows.Forms.TextBox>.ReturnText(t));

        }
    }

    public class ControlUtilities<T> where T : System.Windows.Forms.Control
    {
        public static string ReturnText(T var)
        {
            return var.Text.ToUpper();
        }
    }
}
