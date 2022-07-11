using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap(400, 400);
            Pen p = new Pen(Color.Red);
            p.Width = 10;

            Graphics gh = Graphics.FromImage(bmp);
            gh.DrawLine(p, 0, 0, 100, 100);
            bmp.Save("C:\\temp\\mydrawing.bmp");
        }
    }
}
