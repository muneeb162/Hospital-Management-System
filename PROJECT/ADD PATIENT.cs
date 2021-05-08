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

    public partial class ADD_PATIENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        public ADD_PATIENT()
        {
            InitializeComponent();
        }

        private void ADD_PATIENT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet2.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter2.Fill(this.hospitalDataSet2.EMPLOYEE);
            // TODO: This line of code loads data into the 'hospitalDataSet.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter1.Fill(this.hospitalDataSet.EMPLOYEE);
            // TODO: This line of code loads data into the 'hospitalDataSet1.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter.Fill(this.hospitalDataSet1.EMPLOYEE);
            // TODO: This line of code loads data into the 'hospitalDataSet1.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.hospitalDataSet1.Doctor);

            clear();
            //increment();
            cc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty || (!(radioButton1.Checked || radioButton2.Checked)))
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!((textBox1.Text.Trim().All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c))) && (textBox4.Text.Trim().All(c => Char.IsDigit(c))) && (textBox3.Text.Trim().All(c => Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))) && (textBox2.Text.Trim().All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c))) && (textBox7.Text.Trim().All(c => Char.IsLetter(c))) && (textBox5.Text.Trim().All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE FIELDS IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Gender = string.Empty;
                    if (radioButton1.Checked)
                    {
                        Gender = "MALE";
                    }
                    else if (radioButton2.Checked)
                    {
                        Gender = "FEMALE";
                    }
                    string Query = "Insert into PATIENTS (ID,NAME,FATHER_NAME,ADDRESS_,AGE,GENDER,PHONE_NUMBER,DATE_TIME,DEPARTMENT_ID,Doctor_ID,EMPLOYEE_ID,STATUS_) values ('" + textBox6.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Gender + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToString() + "',(select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME='" + comboBox1.Text + "'),(select ID from Doctor where DOCTOR_NAME='" + comboBox2.Text + "'),(select ID from EMPLOYEE where EMPLOYEE_FIRST_NAME='" + comboBox3.Text + "'and EMPLOYEE_LAST_NAME='" + comboBox4.Text + "'),'" + textBox7.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PATIENT INFORMATION IS SUCCESSFULLY INSERTED");
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
        public void SEARCH(string s)
        {
            con.Open();
            string Query = "select EMPLOYEE_LAST_NAME from EMPLOYEE where EMPLOYEE_FIRST_NAME LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox3.Text = dt.ToString();
            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SEARCH(comboBox3.Text);
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            increment();
        }

        public void increment()
        {
            cc();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(ID as int)),0)+1 From PATIENTS", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox6.Text = dt.Rows[0][0].ToString();
                this.ActiveControl = textBox1;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}

