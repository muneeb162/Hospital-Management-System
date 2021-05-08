using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PROJECT
{
    public partial class VIEW_EMPLOYEES : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        public VIEW_EMPLOYEES()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void VIEW_EMPLOYEES_Load(object sender, EventArgs e)
        {

            this.comboBox2.Text = "";
            cc();
            try
            {
                con.Open();
                string Query = "select E.ID,E.EMPLOYEE_FIRST_NAME,E.EMPLOYEE_LAST_NAME,E.ADDRESS_,E.AGE,E.GENDER,E.PHONE_NUMBER,E.DATE_TIME,D.DEPARTMENT_NAME from DEPARTMENT D inner join EMPLOYEE E on D.DEPARTMENT_ID = E.DEPARTMENT_ID";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    textBox1.Text=dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = "select E.ID,E.EMPLOYEE_FIRST_NAME,E.EMPLOYEE_LAST_NAME,E.ADDRESS_,E.AGE,E.GENDER,E.PHONE_NUMBER,E.DATE_TIME,D.DEPARTMENT_NAME from DEPARTMENT D inner join EMPLOYEE E on D.DEPARTMENT_ID = E.DEPARTMENT_ID";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!((textBox2.Text.Trim().All(c => Char.IsLetter(c))) && (textBox5.Text.Trim().All(c => Char.IsDigit(c))) && (textBox4.Text.Trim().All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))) && (textBox3.Text.Trim().All(c => Char.IsLetter(c))) && (textBox6.Text.Trim().All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE FIELDS IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "Update EMPLOYEE set EMPLOYEE_FIRST_NAME='" + textBox2.Text.Trim() + "',EMPLOYEE_LAST_NAME='" + textBox3.Text.Trim() + "',ADDRESS_='" + textBox4.Text.Trim() + "',AGE='" + textBox5.Text.Trim() + "',GENDER='" + comboBox1.Text + "',PHONE_NUMBER='" + textBox6.Text.Trim() + "',DATE_TIME='" + dateTimePicker2.Value.ToString() + "',DEPARTMENT_ID = (select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME = '" + comboBox2.Text + "') where ID='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("INFORMATION SUCCESSFULLY UPDATED");
                    clear();
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete From EMPLOYEE where ID='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("EMPLOYEE INFORMATION IS SUCCESSFULLY DELETED!!");
                    clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            HOME H = new HOME();
            this.Close();
            H.Show();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox3.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString().Trim();
            textBox4.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString().Trim();
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString().Trim();
            comboBox1.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString().Trim();
            textBox6.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString().Trim();
            dateTimePicker2.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString().Trim();
            comboBox2.Text = dataGridView2.SelectedRows[0].Cells[8].Value.ToString().Trim();
        }

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        public void cc()
        {
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID>=16";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
    }
}
