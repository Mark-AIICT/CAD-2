using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Threading;

namespace ConsoleApplication3
{
    class Program
    {
      
        static void Main(string[] args)
        {
            int row = 1;
            int col = 1;
            dynamic XL = new Application();
            XL.Visible = true;

            XL.Workbooks.Add();
            var query = System.Diagnostics.Process.GetProcesses().Where(p => p.WorkingSet64 > 70000000);
            foreach (var item in query)
            {
                XL.ActiveSheet.Cells[1, col] = item.ProcessName;
                XL.ActiveSheet.Cells[2, col] = item.WorkingSet64.ToString();

                col++;
            }

            XL.ActiveSheet.Select();


            dynamic cht = XL.Charts.Add();
            cht.ChartType = XlChartType.xl3DColumn;

            cht.Rotation = 30;
            cht.Elevation = 40;

            while (cht.Rotation < 180)
            {
                cht.Rotation += 1;
                Thread.Sleep(10);
                Thread.SpinWait(6000);
            }

            Console.WriteLine("all done.");
            Console.ReadLine();
        }
    }
}
