using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form1 : Form
    {
        Customer[] customers = new Customer[] {
            new Customer(){ Name = "fred", Address = "sydney", PostCode = "2000", Age=33 },
            new Customer(){ Name = "jane", Address = "Melbourne", PostCode = "3000", Age=24 },
            new Customer(){ Name = "joe", Address = "sydney", PostCode = "2000", Age=53 },
            new Customer(){ Name = "zoe", Address = "Melbourne", PostCode = "3000", Age=64 },
            new Customer(){ Name = "dave", Address = "sydney", PostCode = "2000", Age=25 },
            new Customer(){ Name = "jill", Address = "Melbourne", PostCode = "3000", Age=27 },
            new Customer(){ Name = "frank", Address = "sydney", PostCode = "2000", Age=28 },
            new Customer(){ Name = "lyn", Address = "Melbourne", PostCode = "3000", Age=39 },
            new Customer(){ Name = "kev", Address = "Melbourne", PostCode = "3000" , Age=34}

        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Customer Count: {0}, Average Age: {1}, Max Age: {2}",
                                        customers.Count(),
                                        customers.Average(c => c.Age),
                                        customers.Max(c => c.Age)));



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var customersByPostCode = customers.GroupBy(c => c.PostCode);


            listBox1.Items.Clear();
            foreach (var pc in customersByPostCode)
            {
                listBox1.Items.Add(String.Format("Post Code: {0}, Total Customers: {1}",pc.Key, pc.Count()));
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var customersByPostCode = from c in customers
                                      group c by c.PostCode into grp
                                      select grp;

            
            listBox1.Items.Clear();
            foreach (var pc in customersByPostCode)
            {
                listBox1.Items.Add(String.Format("Post Code: {0}, Total Customers: {1}", pc.Key, pc.Count()));
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var customersByAge = customers.GroupBy(c =>
                {
                    if (c.Age < 30) return "under 30 years old";
                    else if (c.Age >= 30 && c.Age < 40) return "30 to 40 years old";
                    else if (c.Age >= 40 && c.Age < 50) return "40 to 50 years old";
                    else if (c.Age >= 50 && c.Age < 60) return "50 to 60 years old";
                    else if (c.Age >= 60 && c.Age < 70) return "60 to 70 years old";
                    return "error";
                });


            listBox1.Items.Clear();
            foreach (var pc in customersByAge.OrderBy(s=>s.Key))
            {
                listBox1.Items.Add(String.Format("Age Bracket: {0}, Total Customers: {1}", pc.Key, pc.Count()));
            }
        }
    }
}
