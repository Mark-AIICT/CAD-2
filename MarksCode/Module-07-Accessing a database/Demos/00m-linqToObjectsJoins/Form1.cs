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
            new Customer(){ Name = "fred", PostCode = "2000", Age=33 },
            new Customer(){ Name = "jane", PostCode = "3000", Age=24 },
            new Customer(){ Name = "joe", PostCode = "2000", Age=53 },
            new Customer(){ Name = "zoe", PostCode = "3000", Age=64 },
            new Customer(){ Name = "dave", PostCode = "2000", Age=25 },
            new Customer(){ Name = "jill", PostCode = "3000", Age=27 },
            new Customer(){ Name = "frank", PostCode = "2000", Age=28 },
            new Customer(){ Name = "lyn", PostCode = "3000", Age=39 },
            new Customer(){ Name = "kev", PostCode = "3000" , Age=34}

        };

        Town[] towns = new Town[]{
                new Town(){PostCode="2000", TownName="Sydney"},
                new Town(){PostCode="3000", TownName="Melbourne"}
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

            var townsAndCustomers = towns.Join(customers, t => t.PostCode, c => c.PostCode, (t, c) => new {place=t.TownName, cust=c.Name});

            listBox1.Items.Clear();
            foreach (var item in townsAndCustomers)
            {
                listBox1.Items.Add(string.Format("Place={0}, Customer={1}",item.place, item.cust));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            var townsAndCustomers = from t in towns
                                    join c in customers on t.PostCode equals c.PostCode
                                    select new { place = t.TownName, cust = c.Name };

            listBox1.Items.Clear();
            foreach (var item in townsAndCustomers)
            {
                listBox1.Items.Add(string.Format("Place={0}, Customer={1}", item.place, item.cust));
            }

        }

       
    }
}
