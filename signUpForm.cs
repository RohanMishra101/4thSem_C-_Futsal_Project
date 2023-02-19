using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Data.SqlClient;



/*use signUp
CREATE TABLE signUp_Table(
	admin_name VARCHAR(50) NOT NULL,
    contact_no VARCHAR(50) NOT NULL,
    futsal_name VARCHAR(50) NOT NULL,
    field_no INT NOT NULL,
    game_price INT NOT NULL,
    email VARCHAR(60) NOT NULL,
    admin_password VARCHAR(60) NOT NULL
);

SELECT* FROM signUp_Table;
*/




namespace CsharpForm
{
    public partial class signUpForm : Form
    {
        //Suyog Database
        //SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=signUp;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");
        
        
        //Rohan Database
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CLLMDVB\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");

        //Rohan Legion database
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeft,
                int nTop,
                int nRight,
                int nBottom,
                int nWidthEllipse,
                int nHeightEllipse
            );
        public signUpForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signUpForm_Load(object sender, EventArgs e)
        {
/*            this.FormBorderStyle = FormBorderStyle.None;*/  //use for deleting the topbar of the window form 

            signUp2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, signUp2.Width, signUp2.Height, 30, 30));//sign up rounded shape
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 60, 60));//Panel rounded shape
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0); // used for transplarant bg for the sign up panel
        }
        //SignUpLabel
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //EmailTextBox
        private void email_TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lastName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ageMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //PasswordTextbox
        private void password_TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        //confirmPasswordTextbox
        private void confirm_TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
        //signupButton
        private void signUp_Click(object sender, EventArgs e)
        {
            conn.Open();
            string AdminName = Admin_Name.Text;
            string FutsalName = textBox1.Text;
            string NoFields = textBox2.Text;
            string ContactNo = textBox3.Text;
            string Email = email_TextBox.Text;
            string GamePrice = gamePrice.Text;
            string Password= password_TextBox.Text;
            string ConfirmPassword = confirm_TextBox.Text;
            if (password_TextBox.Text != confirm_TextBox.Text)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(password_TextBox, "Not Same");
                errorProvider1.SetError(confirm_TextBox, "Not Same");
            }
            else if (password_TextBox.Text ==string.Empty || confirm_TextBox.Text==string.Empty)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(password_TextBox, "Null");
                errorProvider1.SetError(confirm_TextBox, "Null");
            }
           /* else if(AdminName == string.Empty)
            {
                errorProvider1.SetError(Admin_Name, "Null");
            }
            else if(FutsalName == string.Empty)
            {
                errorProvider1.SetError(textBox1, "Null");
            }
            else if (NoFields == string.Empty)
            {
                errorProvider1.SetError(textBox2, "Null");
            }
            else if (ContactNo == string.Empty)
            {
                errorProvider1.SetError(textBox3, "Null");
            }
            else if (Email == string.Empty)
            {
                errorProvider1.SetError(email_TextBox, "Null");
            }
            else if (GamePrice == string.Empty)
            {
                errorProvider1.SetError(gamePrice, "Null");
            }*/
            else
            {
                errorProvider1.Clear();
                MessageBox.Show("Sign Up Sucessfull!!");
                /*(admin_name,contact_no,futsal_name,field_no,game_price,email ,admin_password)*/
                string query = "Insert into signUp_Table values('" + AdminName + "','" + ContactNo + "','" + FutsalName + "','" + NoFields + "','" + GamePrice + "','" + Email + "','" + Password + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Form1 nextForm;
                this.Hide();
                nextForm = new Form1();
                nextForm.Closed += (s, args) => this.Close();
                nextForm.Show();

            }
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //FutsalNameLabel
        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        //NoOfFieldsTextbox
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
        //FutsalNameTextbox
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        //ContactNoTextbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //NoOffieldsLabel
        private void label2_Click_2(object sender, EventArgs e)
        {

        }
        //ContactNoLabel
        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        //EmailLabel
        private void label5_Click(object sender, EventArgs e)
        {

        }
        //PasswordLabel
        private void label4_Click(object sender, EventArgs e)
        {

        }
        //ConfirmPasswordLabel
        private void label7_Click(object sender, EventArgs e)
        {

        }
        //MainPassword Hidden Function
        private void button1_Click(object sender, EventArgs e)
        {
            if (password_TextBox.PasswordChar == '*')
            {
                string getPassword = password_TextBox.Text;
                password_TextBox.Text = getPassword;
                password_TextBox.PasswordChar = '\0';
            }
            else
            {
                string getPassword = password_TextBox.Text;
                password_TextBox.Text = getPassword;
                password_TextBox.PasswordChar = '*';
            }
        }
        //confirm Pssword Hidden function
        private void button2_Click(object sender, EventArgs e)
        {
            if (confirm_TextBox.PasswordChar == '*')
            {
                string getPassword = confirm_TextBox.Text;
                confirm_TextBox.Text = getPassword;
                confirm_TextBox.PasswordChar = '\0';
            }
            else
            {
                string getPassword = confirm_TextBox.Text;
                confirm_TextBox.Text = getPassword;
                confirm_TextBox.PasswordChar = '*';
            }
        }
    }
}
