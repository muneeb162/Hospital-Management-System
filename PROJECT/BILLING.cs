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
    public partial class BILLING : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        public BILLING()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString().Trim();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString().Trim();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString().Trim();
        }

        private void BILLING_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter Sda = new SqlDataAdapter("select isnull(max(cast(BILLING_ID as int)),0)+1 From BILLING", con);
                DataTable Dt = new DataTable();
                Sda.Fill(Dt);
                textBox1.Text = Dt.Rows[0][0].ToString();
                this.ActiveControl = textBox2;

                string Query = "select P.ID,P.NAME,P.FATHER_NAME,P.ADDRESS_,P.AGE,P.GENDER,P.PHONE_NUMBER,P.DATE_TIME,D.DEPARTMENT_ID,z.ID,E.ID,P.STATUS_,D.DEPARTMENT_CHARGES,z.Doctor_CHARGES from PATIENTS P inner join DEPARTMENT D on D.DEPARTMENT_ID=P.DEPARTMENT_ID inner join Doctor z on z.ID=P.Doctor_ID inner join EMPLOYEE E on E.ID=P.EMPLOYEE_ID ";
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
            int integr;
            bool isNum = int.TryParse(textBox10.Text.Trim(), out integr); bool isNum1 = int.TryParse(textBox11.Text.Trim(), out integr);
            if (!isNum)
            {
                MessageBox.Show("Conversion type Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isNum1)
            {
                MessageBox.Show("Conversion type Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("PLEASE ENTER ALL THE FILEDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int a, b;
                    a = int.Parse(textBox10.Text);
                    b = int.Parse(textBox11.Text);
                    textBox8.Text = Convert.ToString(a + b);
                }
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void SEARCHBYNAME(string s)
        {
            con.Open();
            string Query = "select P.ID,P.NAME,P.FATHER_NAME,P.ADDRESS_,P.AGE,P.GENDER,P.PHONE_NUMBER,P.DATE_TIME,D.DEPARTMENT_ID,z.ID,E.ID,P.STATUS_,D.DEPARTMENT_CHARGES,z.Doctor_CHARGES from PATIENTS P inner join DEPARTMENT D on D.DEPARTMENT_ID=P.DEPARTMENT_ID inner join Doctor z on z.ID=P.Doctor_ID inner join EMPLOYEE E on E.ID=P.EMPLOYEE_ID  where NAME LIKE '%" + s + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            SEARCHBYNAME(textBox9.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOME H = new HOME();
            this.Hide();
            H.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || textBox8.Text.Trim() == string.Empty || textBox10.Text.Trim() == string.Empty || textBox11.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE SELECT THE ROW", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "INSERT into BILLING (BILLING_ID,PATIENT_ID,PATIENT_NAME,PHONE_NUMBER,PATIENT_STATUS,DATE_TIME,DEPARTMENT_ID,DOCTOR_ID,TOTAL,DEPARTMENT_CHARGES,DOCTOR_CHARGES) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("INFORMATION INSERTED");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
    }
}
