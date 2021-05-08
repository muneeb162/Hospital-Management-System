using PROJECT.Properties;
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
    public partial class HOME : Form
    {
        bool isCollapsed;

        public HOME()
        {
            InitializeComponent();
        }

        private void HOME_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADD_EMPLOYEES ae = new ADD_EMPLOYEES();
            this.Hide();
            ae.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VIEW_EMPLOYEES ve = new VIEW_EMPLOYEES();
            this.Hide();
            ve.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BILLING B = new BILLING();
            this.Hide();
            B.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            ADD_PATIENT form2 = new ADD_PATIENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (isCollapsed)
            {
                button1.Image = Resources.Collapse_Arrow_20px;
                panel2.Height += 10;
                if (panel2.Size == panel2.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button1.Image = Resources.Expand_Arrow_20px;
                panel2.Height -= 10;
                if (panel2.Size == panel2.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }


        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            this.panel3.Controls.Clear();
            VIEW_PATIENT form2 = new VIEW_PATIENT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            ADD_EMPLOYEES form2 = new ADD_EMPLOYEES() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            VIEW_EMPLOYEES form2 = new VIEW_EMPLOYEES() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button5.Image = Resources.Collapse_Arrow_20px;
                panel4.Height += 10;
                if (panel4.Size == panel4.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button5.Image = Resources.Expand_Arrow_20px;
                panel4.Height -= 10;
                if (panel4.Size == panel4.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            ADD_EMPLOYEES form2 = new ADD_EMPLOYEES() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            VIEW_EMPLOYEES form2 = new VIEW_EMPLOYEES() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button8.Image = Resources.Collapse_Arrow_20px;
                panel5.Height += 10;
                if (panel5.Size == panel5.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button8.Image = Resources.Expand_Arrow_20px;
                panel5.Height -= 10;
                if (panel5.Size == panel5.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            ADD_DOCTOR form2 = new ADD_DOCTOR() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            VIEW_DOCTOR form2 = new VIEW_DOCTOR() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            BILLING form2 = new BILLING() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; this.panel3.Controls.Add(form2);
            form2.Show();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }
    }
}
