using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CsharpForm
{
    /*  use EmployeeDB
  CREATE TABLE FiredEmployee(
      empName varchar(20),
      Contact varchar(10),
      Position varchar(30),
      Salary int,
      HireDate date,
      FireDate date
  );*/
 /*   use EmployeeDB
CREATE TABLE Employee(
    empName varchar(20),
    Contact varchar(10),
    Position varchar(30),
	Salary int,
	HireDate date
);*/
    public partial class Employee : UserControl
    {
        //Suyog Lab Database
        SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=EmployeeDB;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=BookingDB;Integrated Security=True");



        //Rohan Legion database
        //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CLLMDVB\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string getName=fullName.Text;
            string getContact=contact.Text;
            DateTime getDateTime=dateTimePicker1.Value;
            DateTime getHireDate = new DateTime(getDateTime.Year,getDateTime.Month,getDateTime.Day);
            string getPosition=position.Text;
            string getSalary=salary.Text;
            conn.Open();
            string query = "Insert into employee values('" + getName + "','" + getContact + "','" + getPosition + "','" + getSalary + "','" + getHireDate + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getFind = findBox.Text;
            string query = "Select empName,Contact,Position,Salary,HireDate from employee where Contact='" + getFind + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                errorProvider1.Clear();
                string getFullName = dt.Rows[0]["empName"].ToString();
                string getContact = dt.Rows[0]["Contact"].ToString();
                string getPosition = dt.Rows[0]["Position"].ToString();
                string getSalary = dt.Rows[0]["Salary"].ToString();
                string getHireDate = dt.Rows[0]["HireDate"].ToString();
                DateTime DT = DateTime.Parse(getHireDate);
                fullName.Text = getFullName;
                contact.Text = getContact;
                dateTimePicker1.Value = DT;
                position.Text = getPosition;
                salary.Text = getSalary;
            }
            else
            {
                errorProvider1.SetError(findBox, "No Such Data");
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string getName = fullName.Text;
            string getContact = contact.Text;
            DateTime getDateTime = dateTimePicker1.Value;
            DateTime getHireDate = new DateTime(getDateTime.Year, getDateTime.Month, getDateTime.Day);
            string getPosition = position.Text;
            string getSalary = salary.Text;
            conn.Open();
            string query = "Update employee set empName='" + getName + "',Contact='" + getContact + "',Position='" + getPosition + "',Salary='" + getSalary + "',HireDate='" + getHireDate + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string getName = fullName.Text;
            string getContact = contact.Text;
            DateTime getDateTime = dateTimePicker1.Value;
            DateTime getHireDate = new DateTime(getDateTime.Year, getDateTime.Month, getDateTime.Day);
            string getPosition = position.Text;
            string getSalary = salary.Text;
            DateTime dateTime = DateTime.Now;
            DateTime getFireDate= new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            conn.Open();
            string query = "Insert into FiredEmployee values('" + getName + "','" + getContact + "','" + getPosition + "','" + getSalary + "','" + getHireDate + "','" + getFireDate + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            string getFind = findBox.Text;
            string query1 = "delete from employee where Contact='"+ getFind +"'";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
    }
}
