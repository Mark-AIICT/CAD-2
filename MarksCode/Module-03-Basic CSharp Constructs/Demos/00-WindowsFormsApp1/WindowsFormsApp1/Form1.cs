using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += BC;
            button1.Click += BC2;
            button2.Click += BC2;
        }

        private void BC2(object sender, EventArgs e)
        {
            MessageBox.Show($"The button you pressed was '{((Button)sender).Text}'");
        }

        private void BC(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
2