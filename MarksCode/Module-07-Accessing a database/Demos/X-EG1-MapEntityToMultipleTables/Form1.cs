using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;

namespace MapEntityToMultipleTables
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SchoolEntities objCtx = new SchoolEntities();
            ObjectQuery<Instructor> instructorQuery = objCtx.Person.OfType<Instructor>();

            instructorBindingSource.DataSource = instructorQuery.Execute(MergeOption.OverwriteChanges);

        }
    }
}
