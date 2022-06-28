using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            Pen p = new Pen(Color.Red);


            p.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Width"]);


            Bitmap bmp = new Bitmap(500, 500);
            Graphics g = Graphics.FromImage(bmp);

            g.DrawLine(p, 0, 0, 200, 200);
            g.DrawLine(p, 200, 200, 0, -200);

            bmp.Save(@"c:\temp\b.bmp");




            Console.WriteLine("OK, Done. Now have a look in c:\\Temp");
            Console.ReadLine();
        }
    }
}
