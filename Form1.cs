using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CsharpForm
{
    public partial class Form1 : Form
    {
        //Suyog Lab Database
        SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=signUp;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");



        //Rohan Legion database
        //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");
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
        //whole form function
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 40, 40));
            logIn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, logIn.Width, logIn.Height, 30, 30));
            email.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, email.Width, email.Height, 10, 10));
            password.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, password.Width, password.Height, 10, 10));
            signUp.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, signUp.Width, signUp.Height, 30, 30));
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        //Person Playing Football function
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //Login Function
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getMail = email.Text;
            string getPassword = password.Text;
            string query = "SELECT email,admin_password from signUp_Table where email='" + getMail + "'AND admin_password='" + getPassword + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string data1 = dt.Rows[0]["email"].ToString();
                string data2 = dt.Rows[0]["admin_password"].ToString();
                if (getMail == data1 && getPassword == data2)
                {
                    Mainmenu nextForm;
                    this.Hide();
                    nextForm = new Mainmenu();
                   /* nextForm.ShowDialog();
                    this.Show();
                    this.Hide();*/
                    nextForm.Closed += (s, args) => this.Close();
                    nextForm.Show();
                }
            }
            else if (email.Text == string.Empty && password.Text == string.Empty)
            {
                errorProvider1.SetError(email, "Empty");
                errorProvider1.SetError(password, "Empty");
            }
            else
            {
                MessageBox.Show("Wrong Email or Password");
            }
            conn.Close();
        }
        //Password Logo Function
        private void label3_Click(object sender, EventArgs e)
        {

        }
        //Email Logo function
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        //Password text function
        private void password_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string getPassword = password.Text;
            string query = "SELECT admin_password from signUp_Table where admin_password='" + getPassword + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                errorProvider1.SetError(password, "Wrong Password");
            }
            else
            {
                errorProvider1.Clear();
            }
            conn.Close();
        }
        //Email text function
        private void email_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string getMail=email.Text;
            string query = "SELECT email from signUp_Table where email='" + getMail + "'";
           
            //Rohan SQL Code
            //string query = "SELECT name from UserAdmin where name='" + getMail + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count<=0)
            {
                errorProvider1.SetError(email, "Wrong Email");
            }
            else
            {
                errorProvider1.Clear();
            }
            conn.Close();
        }
        //Admin Function
        private void signUp_Click(object sender, EventArgs e)
        {
            this.Show();
            signUpForm pageLoad = new signUpForm();
            pageLoad.Show();
        }
        //Hide Password Function
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(password.PasswordChar =='*')
            {
                string getPassword = password.Text;
                password.Text = getPassword;
                password.PasswordChar = '\0';
            }
            else
            {
                string getPassword = password.Text;
                password.Text = getPassword;
                password.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Show();
            ForgetPassword pageLoad = new ForgetPassword();
            pageLoad.Show();
        }
        //Forget Password Function
        private void button2_Click(object sender, EventArgs e)
        {
            ForgetPassword nextForm;
            this.Hide();
            nextForm = new ForgetPassword();
            nextForm.ShowDialog();
            this.Show();
        }
        //PictureBox Football logo Function
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}