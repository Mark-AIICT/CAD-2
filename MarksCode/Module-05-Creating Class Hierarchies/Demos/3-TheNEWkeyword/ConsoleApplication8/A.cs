using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    public class A
    {
        public virtual void F()
        {
            Console.WriteLine("Function in class A");
        }
    }

    public class B:A
    {
        public override void F()
        {
            Console.WriteLine("Function in class B");
        }
    }

    public class C : B
    {
        new public virtual void F()
        {
            Console.WriteLine("Function in class C");
        }
    }

    public class D : C
    {
        public override void F()
        {
            Console.WriteLine("Function in class D");
        }
    }
}
