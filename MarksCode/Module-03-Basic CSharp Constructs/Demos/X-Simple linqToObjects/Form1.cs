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
            new Customer(){ Name = "fred", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "jane", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "joe", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "zoe", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "dave", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "jill", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "frank", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "lyn", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "kev", Address = "Melbourne", PostCode = "3000" }

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
            var melbournepeople = customers.Where(c => c.PostCode == "3000").Select(c => new {PersonName = c.Name, HomeAddress = c.Address });

            listBox1.Items.Clear();
            foreach (var person in melbournepeople)
            {
                listBox1.Items.Add(person.PersonName + " ," + person.HomeAddress);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var melbournepeople = from c in customers
                                  where c.PostCode == "3000"
                                  select new { PersonName = c.Name, HomeAddress = c.Address };

            listBox1.Items.Clear();
            foreach (var person in melbournepeople)
            {
                listBox1.Items.Add(person.PersonName + " ," + person.HomeAddress);
            }
        }
    }
}
