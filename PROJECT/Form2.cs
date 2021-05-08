using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width>=700)
            {
                timer.Stop();
                Form2 F1 = new Form2();
                this.Hide();
                F1.Show();
            }
        }
    }
}
