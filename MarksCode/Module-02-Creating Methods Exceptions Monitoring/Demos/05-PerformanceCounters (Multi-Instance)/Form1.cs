using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace P26_to_P30_PerformanceCounters
{
    public partial class Form1 : Form
    {

        PerformanceCounter pc;
        PerformanceCounter pc2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!PerformanceCounterCategory.Exists("Z-MultiInstanceCounter", Environment.MachineName))
            {

                CounterCreationData ccd = new CounterCreationData("TotalClicks",
                    "Measures the total number of clicks",
                    PerformanceCounterType.NumberOfItems32);

                CounterCreationData ccd2 = new CounterCreationData("ClicksPerSecond",
                    "Measures the number of clicks per second",
                    PerformanceCounterType.RateOfCountsPerSecond32);

                CounterCreationDataCollection ccdc = new CounterCreationDataCollection();
                ccdc.Add(ccd);
                ccdc.Add(ccd2);


                PerformanceCounterCategory.Create("Z-MultiInstanceCounter",
                    "This is a Test Category",
                    PerformanceCounterCategoryType.MultiInstance,
                    ccdc);

            }

            string uniqueID = DateTime.Now.Ticks.ToString();


            pc = new PerformanceCounter("Z-MultiInstanceCounter", "TotalClicks", "My.exe_" + uniqueID, false);
            pc2 = new PerformanceCounter("Z-MultiInstanceCounter", "ClicksPerSecond", "My.exe_" + uniqueID, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformanceCounterCategory pcc = new PerformanceCounterCategory("Z-MultiInstanceCounter");
            lblOut1.Text = "";



            pc.Increment();
            pc2.Increment();

            lblOut1.Text += string.Format("CounterName={0}\nCounterType={1}\nNextSample={2}\nNextValue={3}\nRawValue={4}\nInstanceName={5}\n\n",
                pc.CounterName,
                pc.CounterType.ToString(),
                pc.NextSample().RawValue,
                pc.NextValue().ToString(),
                pc.RawValue.ToString(),
                pc.InstanceName.ToString());


            lblOut1.Text += string.Format("CounterName={0}\nCounterType={1}\nNextSample={2}\nNextValue={3}\nRawValue={4}\nInstanceName={5}\n\n",
                pc2.CounterName,
                pc2.CounterType.ToString(),
                pc2.NextSample().RawValue,
                pc2.NextValue().ToString(),
                pc2.RawValue.ToString(),
                pc2.InstanceName.ToString());



        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            pc.Close();
            pc2.Close();
        }
    }
}