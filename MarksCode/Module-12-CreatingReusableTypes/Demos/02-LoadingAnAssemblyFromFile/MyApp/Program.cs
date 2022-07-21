using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"..\..\..\Calc\bin\debug\Calc.dll";

            var assembly = Assembly.LoadFrom(path);

            //** The following line also loads an assembly, it can be examined through reflection
            //** but not executed.
            //var assembly = Assembly.ReflectionOnlyLoad(File.ReadAllBytes( path));


            Type[] embeddedTypes = assembly.GetTypes();


            Console.WriteLine("--------------------------------------");
            Console.WriteLine("--Displaying Member Info          ----");
            Console.WriteLine("--------------------------------------");
            foreach (var item in embeddedTypes)
            {

                Console.WriteLine("embedded type found: {0}", item.Name);
                foreach (var f in item.GetMembers())
                {

                    if(f.MemberType == MemberTypes.Property)
                        Console.WriteLine("Property:{0}", f.Name);
                    else if(f.MemberType == MemberTypes.Method)
                        Console.WriteLine("method:{0}", f.Name);
                }

            }

            Console.WriteLine("\n\n\n--------------------------------------------");
            Console.WriteLine("---Setting properties an calling a method---");
            Console.WriteLine("--------------------------------------------");

            Type T = embeddedTypes[0];
            var constructor = T.GetConstructor(new Type[0]);
            var obj = constructor.Invoke(new object[0]);

            var x = T.GetProperty("x");
            var y = T.GetProperty("y");
            x.SetValue(obj,100);
            y.SetValue(obj,200);

            var method = T.GetMethod("Add");
            object[] parms = null;
            var result = method.Invoke(obj, parms);


            Console.WriteLine("Result={0}" + result);
            Console.WriteLine("All done. Press enter to exit");
            Console.ReadLine();
        }
    }
}
