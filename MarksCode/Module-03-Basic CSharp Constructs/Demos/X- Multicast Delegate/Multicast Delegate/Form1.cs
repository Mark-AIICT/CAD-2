using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multicast_Delegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void D(string item);
        private void button1_Click(object sender, EventArgs e)
        {
            D d1 = AddToListBox;
            D d2 = AddToListBox;
            D d3 = AddToListBox;


            d3 = D.Combine(d1, d2) as D;

            d3(System.DateTime.Now.ToLongTimeString());

        }

        void AddToListBox(string item)
        {
            listBox1.Items.Add(item);
        }
    }
}
