using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AdventureWorksEntities1 ctx = new AdventureWorksEntities1();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            customerBindingSource.DataSource = ctx.Customer;

        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            ctx.SaveChanges();
        }
    }
}
