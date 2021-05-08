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
    public partial class VIEW_DOCTOR : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        public VIEW_DOCTOR()
        {
            InitializeComponent();
        }

        private void VIEW_DOCTOR_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            cc();
            try
            {
                con.Open();
                string Query = "select D.ID,D.DOCTOR_NAME,D.ContactNo,D.Gender,D.address_,D.date_of_employment,z.DEPARTMENT_NAME,D.Doctor_CHARGES from Doctor D inner join DEPARTMENT z on z.DEPARTMENT_ID=D.DEPARTMENT_ID ";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = "select D.ID,D.DOCTOR_NAME,D.ContactNo,D.Gender,D.address_,D.date_of_employment,z.DEPARTMENT_NAME,D.Doctor_CHARGES from Doctor D inner join DEPARTMENT z on z.DEPARTMENT_ID=D.DEPARTMENT_ID ";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!((textBox3.Text.Trim().All(c => Char.IsDigit(c))) && (textBox4.Text.Trim().All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))) && (textBox2.Text.Trim().All(c => Char.IsLetter(c))) && (textBox5.Text.Trim().All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE FIELDS IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "Update Doctor set DOCTOR_NAME='" + textBox2.Text.Trim() + "',ContactNO='" + textBox3.Text.Trim() + "',Gender='" + comboBox2.Text + "',address_='" + textBox4.Text.Trim() + "',date_of_employment='" + dateTimePicker1.Value.ToString() + "',DEPARTMENT_ID=(select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME='" + comboBox1.Text + "'),Doctor_CHARGES='" + textBox5.Text + "' where ID='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("INFORMATION SUCCESSFULLY UPDATED");
                    Clear();
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
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete From Doctor where ID='" + textBox1.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("DOCTOR INFORMATION IS SUCCESSFULLY DELETED!!");
                    Clear();
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();

        }

        public void cc()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select DEPARTMENT_NAME FROM DEPARTMENT WHERE DEPARTMENT_ID<16";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}
