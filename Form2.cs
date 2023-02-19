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
using System.Collections;

namespace CsharpForm
{
    public partial class Form2 : Form
    {
        //Suyog Database
        //SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=signUp;Integrated Security=True");
        //Suyog college database
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");
        //Rohan Legion database
        //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
            conn.Open();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string queryString = "Select ImageName,ImageData from Images";
            SqlCommand command = new SqlCommand(queryString, conn);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                try
                {
                   /* Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }*/
                    pictureBox1.Image = Properties.Resources.istockphoto_845329690_612x612;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Invalid image format: " + ex.Message);
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Not enough memory to create image: " + ex.Message);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("File not found: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                openFileDialog.FileName = dt.Rows[0]["ImageData"].ToString();
                pictureBox1.Visible = true;
                pictureBox1.Invalidate();
                pictureBox1.Parent.Refresh();
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
   /*     use signUp
  CREATE TABLE Images(
    ImageName varchar(255),
    ImageData varchar(500),
);*/
        private void button1_Click(object sender, EventArgs e)
        {
            top:
            pictureBox1.Visible = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            /*pictureBox1.Invalidate();*/
            pictureBox1.Parent.Refresh();
            openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    goto top;
                }
               
            }
            conn.Open();
            string query = "SELECT count(*) from Images";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (count > 0)
            {
                string queryString1 = "UPDATE Images SET ImageName=@ImageName,ImageData=@ImageData";
                using (SqlCommand command = new SqlCommand(queryString1, conn))
                {
                    command.Parameters.AddWithValue("@ImageName", Path.GetFileName(openFileDialog.FileName));
                    command.Parameters.AddWithValue("@ImageData", Path.GetFullPath(openFileDialog.FileName));
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                string queryString = "INSERT INTO Images (ImageName, ImageData) VALUES (@ImageName, @ImageData)";
                using (SqlCommand command = new SqlCommand(queryString, conn))
                {
                    command.Parameters.AddWithValue("@ImageName", Path.GetFileName(openFileDialog.FileName));
                    command.Parameters.AddWithValue("@ImageData", Path.GetFullPath(openFileDialog.FileName));
                    command.ExecuteNonQuery();
                }
            }
        conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
