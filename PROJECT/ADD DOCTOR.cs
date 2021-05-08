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
    public partial class ADD_DOCTOR : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        public ADD_DOCTOR()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ADD_DOCTOR_Load(object sender, EventArgs e)
        {

            comboBox1.Text = "";
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(ID as int)),0)+1 From Doctor", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox1.Text = dt.Rows[0][0].ToString();
                this.ActiveControl = textBox3;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!((textBox6.Text.Trim().All(c => Char.IsDigit(c))) && (textBox5.Text.Trim().All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))) && (textBox3.Text.Trim().All(c => Char.IsLetter(c))) && (textBox4.Text.Trim().All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE FIELDS IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "Insert into Doctor (ID,DOCTOR_NAME,ContactNo,Gender,address_,date_of_employment,DEPARTMENT_ID,Doctor_CHARGES) values ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToString() + "',(select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME = '" + comboBox1.Text + "'),'" + textBox6.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("DOCTOR INFORMATION IS SUCCESSFULLY INSERTED");
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
        private void button2_Click(object sender, EventArgs e)
        {
            HOME H = new HOME();
            this.Close();
            H.Show();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        public void clear()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = ""; comboBox2.Text = "";
            increment();
        }
        public void increment()
        {
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(ID as int)),0)+1 From Doctor", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox1.Text = dt.Rows[0][0].ToString();
                this.ActiveControl = textBox3;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
