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
using System.Data;

namespace CsharpForm
{
   
    public partial class ForgetPassword : Form
    {
        //Suyog Database
        //SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=signUp;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");

        //Rohan Database
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CLLMDVB\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");
        public ForgetPassword()
        {
            InitializeComponent();
        }
        //Whole ForgetPassword Form Function
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        //Change Password Button Function
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getEmail=Email.Text;
            string getPhoneNo = PhoneNo.Text;
            string getPassword = oPassword.Text;
            string conPassword = nPassword.Text;
            if(getPassword!=conPassword)
            {
                errorProvider1.SetError(oPassword, "Not the same Password");
                errorProvider1.SetError(nPassword, "Not the same Password");
                MessageBox.Show("Not the same password");
            }
            else
            {
                string query1 = "Select email From signUp_Table WHERE email='" + getEmail + "'";
                /*SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.ExecuteNonQuery();*/
                SqlCommand sqlCommand = new SqlCommand(query1, conn);
                string data = (string)sqlCommand.ExecuteScalar();
                if (getEmail == data.ToString())
                {
                    string query2 = "UPDATE signUp_Table SET email='" + getEmail + "',contact_no='" + getPhoneNo + "',admin_password='" + getPassword + "' WHERE email='" + getEmail + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.ExecuteNonQuery();
                }
                MessageBox.Show("Updated Successfully");
                Form1 nextForm;
                this.Hide();
                nextForm = new Form1();
                /* nextForm.ShowDialog();
                 this.Show();
                 this.Hide();*/
                nextForm.Closed += (s, args) => this.Close();
                nextForm.Show();
                conn.Close();
            }
            
        }
        //Find PhoneNo Button function
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getContact = FindNo.Text;
            string query = "Select email,contact_no From  signUp_Table WHERE contact_no='" + getContact + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string data1 = dt.Rows[0]["email"].ToString();
                string data2 = dt.Rows[0]["contact_no"].ToString();
                //string data2 = dt.Rows[0]["PhoneNo"].ToString();
                Email.Text = data1;
                PhoneNo.Text = data2;
            }
            else
            {
                MessageBox.Show("Account Doesnot Exist");
            }
            conn.Close();
        }
        //New Password Text Function
        private void oPassword_TextChanged(object sender, EventArgs e)
        {

        }
        //Confirm Password Text Function
        private void nPassword_TextChanged(object sender, EventArgs e)
        {
            if(oPassword.Text!=nPassword.Text)
            {
                errorProvider1.SetError(oPassword, "Not the same Password");
                errorProvider1.SetError(nPassword, "Not the same Password");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        //Phone No logo function
        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Phone No Text Function
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            conn.Open();
            string getPhone = FindNo.Text;
            //string query = "SELECT PhoneNO from UserAdmin where PhoneNo='" + getPhone + "'";
            string query = "SELECT contact_no from  signUp_Table where contact_no='" + getPhone + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                errorProvider1.SetError(FindNo, "Does Not Exist");
            }
            else
            {
                errorProvider1.Clear();
            }
            conn.Close();
        }
        //Main Girl Logo Function
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //Forget your Password Whole Place Function
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //Forget Your Password Logo Function
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Email Logo Function
        private void label5_Click(object sender, EventArgs e)
        {

        }
        //Email Text Function
        private void Email_TextChanged(object sender, EventArgs e)
        {

        }
        //Phone No Logo Function
        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Phone No Text Function
        private void PhoneNo_TextChanged(object sender, EventArgs e)
        {

        }
        //New Password Logo function
        private void label3_Click(object sender, EventArgs e)
        {

        }
        //Confirm Password Logo Function
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
