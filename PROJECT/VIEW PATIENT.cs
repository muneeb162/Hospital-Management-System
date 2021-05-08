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
    public partial class VIEW_PATIENT : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEAV1KG\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        public VIEW_PATIENT()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string Query = "select P.ID,P.NAME,P.FATHER_NAME,P.ADDRESS_,P.AGE,P.GENDER,P.PHONE_NUMBER,P.DATE_TIME,D.DEPARTMENT_NAME,Doctor.DOCTOR_NAME,E.EMPLOYEE_FIRST_NAME,E.EMPLOYEE_LAST_NAME,P.STATUS_  from PATIENTS P inner join DEPARTMENT D on D.DEPARTMENT_ID=P.DEPARTMENT_ID inner join Doctor on Doctor.ID=P.Doctor_ID inner join EMPLOYEE E on E.ID=P.EMPLOYEE_ID";
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
            clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!((textBox1.Text.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c))) && (textBox4.Text.All(c => Char.IsDigit(c))) && (textBox2.Text.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c))) && (textBox7.Text.All(c => Char.IsLetter(c))) && (textBox6.Text.All(c => Char.IsDigit(c)))))
            {
                MessageBox.Show("PLEASE INSERT THE FIELDS IN CORRECT FORM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "Update PATIENTS set NAME='" + textBox1.Text.Trim() + "',FATHER_NAME='" + textBox2.Text.Trim() + "',ADDRESS_='" + textBox3.Text.Trim() + "',AGE='" + textBox4.Text.Trim() + "',GENDER='" + comboBox1.Text + "',PHONE_NUMBER='" + textBox6.Text.Trim() + "',DATE_TIME='" + dateTimePicker1.Value.ToString() + "',DEPARTMENT_ID=(select DEPARTMENT_ID from DEPARTMENT where DEPARTMENT_NAME = '" + comboBox2.Text + "'),Doctor_ID = (select ID from Doctor where DOCTOR_NAME='" + comboBox3.Text + "'),EMPLOYEE_ID=(select ID from EMPLOYEE where EMPLOYEE_FIRST_NAME='" + comboBox4.Text + "'and EMPLOYEE_LAST_NAME='" + comboBox5.Text + "'),STATUS_='" + textBox7.Text + "' where ID='" + textBox5.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("INFORMATION SUCCESSFULLY UPDATED");
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
                clear();
                rfrsh();
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Trim();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString().Trim();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Trim();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString().Trim();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString().Trim();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString().Trim();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString().Trim();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString().Trim();
            comboBox5.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString().Trim();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString().Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty || comboBox2.Text.Trim() == string.Empty || comboBox3.Text.Trim() == string.Empty || comboBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("PLEASE ENTER ALL FIELDS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();
                    string Query = "delete From PATIENTS where ID='" + textBox5.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("PATIENT INFORMATION IS SUCCESSFULLY DELETED!!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);

                }
                clear();
                rfrsh();
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

        private void VIEW_PATIENT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet1.Doctor' table. You can move, or remove it, as needed.
            this.doctorTableAdapter.Fill(this.hospitalDataSet1.Doctor);
            // TODO: This line of code loads data into the 'hospitalDataSet1.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter1.Fill(this.hospitalDataSet1.EMPLOYEE);
            // TODO: This line of code loads data into the 'hospitalDataSet2.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter.Fill(this.hospitalDataSet2.EMPLOYEE);
            // TODO: This line of code loads data into the 'hospitalDataSet.Doctor' table. You can move, or remove it, as needed.
            //this.doctorTableAdapter.Fill(this.hospitalDataSet.Doctor);

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            cc();
            try
            {
                con.Open();
                string Query = "select P.ID,P.NAME,P.FATHER_NAME,P.ADDRESS_,P.AGE,P.GENDER,P.PHONE_NUMBER,P.DATE_TIME,D.DEPARTMENT_NAME,Doctor.DOCTOR_NAME,E.EMPLOYEE_FIRST_NAME,E.EMPLOYEE_LAST_NAME,P.STATUS_  from PATIENTS P inner join DEPARTMENT D on D.DEPARTMENT_ID=P.DEPARTMENT_ID inner join Doctor on Doctor.ID=P.Doctor_ID inner join EMPLOYEE E on E.ID=P.EMPLOYEE_ID";
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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
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
                comboBox2.Items.Add(dr["DEPARTMENT_NAME"].ToString());
            }
            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            comboBox5.Text = "";
        }

        public void rfrsh()
        {
            try
            {
                con.Open();
                string Query = "select P.ID,P.NAME,P.FATHER_NAME,P.ADDRESS_,P.AGE,P.GENDER,P.PHONE_NUMBER,P.DATE_TIME,D.DEPARTMENT_NAME,Doctor.DOCTOR_NAME,E.EMPLOYEE_FIRST_NAME,E.EMPLOYEE_LAST_NAME,P.STATUS_  from PATIENTS P inner join DEPARTMENT D on D.DEPARTMENT_ID=P.DEPARTMENT_ID inner join Doctor on Doctor.ID=P.Doctor_ID inner join EMPLOYEE E on E.ID=P.EMPLOYEE_ID";
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
            clear();
        }
    }
}
