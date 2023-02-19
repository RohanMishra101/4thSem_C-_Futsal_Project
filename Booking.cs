using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CsharpForm
{

    /*CREATE DATABASE Bookingdb
        
    SCREATE TABLE Booking(
        fullName VARCHAR(30) NOT NULL,
        Contact VARCHAR(20) NOT NULL,
        BookingDate VARCHAR(30),
	    SHour VARCHAR(10) NOT NULL,
        SMin VARCHAR(10) NOT NULL,
	    SAMPM VARCHAR(5) NOT NULL,
        EHour VARCHAR(10) NOT NULL,
	    EMin VARCHAR(10) NOT NULL,
        EAMPM VARCHAR(5) NOT NULL,
		GameStart TIME NOT NULL,
		GameEnd TIME NOT NULL,
        Game_Start VARCHAR(10),
	    Game_End VARCHAR(10)
    );
	SELECT * FROM Booking;
*/
    public partial class Booking : UserControl
    {
        //Suyog Lab Database
        SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=Bookingdb;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");



        //Rohan Legion database
       // SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CLLMDVB\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");
        public Booking()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string getName=FullName.Text;
            string getContact = Contact.Text;
            DateTime getDateTime = dateTimePicker1.Value;
            DateTime getBookingDate = new DateTime(getDateTime.Year, getDateTime.Month, getDateTime.Day);
            string getStartH = SHour.Text;
            string getStartM = SMin.Text;
            string getSAMPM =SAMPM.Text;
            string getEndH = Ehour.Text;
            string getEndM=EMin.Text;
            string getEAMPM = EAMPM.Text;
            string getStart = getStartH+":"+getStartM+" "+getSAMPM;
            string getEnd = getEndH + ":" + getEndM+" "+getEAMPM;
            DateTime gStart = DateTime.ParseExact(getStart,"h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            DateTime gEnd = DateTime.ParseExact(getEnd,"h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            if (Int32.Parse(getStartH) > 12|| Int32.Parse(getStartH) <1|| Int32.Parse(getStartM) > 60 || Int32.Parse(getStartM) < 0 || Int32.Parse(getEndH) > 12 || Int32.Parse(getStartH) < 1 || Int32.Parse(getStartM) > 60 || Int32.Parse(getStartM) < 0)
            {
                errorProvider1.SetError(SHour, "Wrong Input");
            }
            else
            {
                conn.Open();
                string query = "Select BookingDate,GameStart,GameEnd from Booking where GameStart<='"+gStart+"' AND GameEnd>'"+gStart+"'";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(label4, "Booking Exists");
                }
                else
                {
                    conn.Open();
                    string query1 = "Select BookingDate,GameStart,GameEnd from Booking where GameStart<'" + gEnd + "' AND GameEnd>='" + gEnd + "'";
                    SqlCommand sqlCommand1 = new SqlCommand(query1, conn);
                    SqlDataAdapter sda1 = new SqlDataAdapter(sqlCommand1);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    conn.Close();
                    if (dt1.Rows.Count > 0)
                    {
                        errorProvider1.SetError(label4, "Booking Exists");
                    }
                    else
                    {
                        conn.Open();
                        string query2 = "Select BookingDate,GameStart,GameEnd from Booking where GameStart>='" + gStart + "' AND GameEnd<='" + gEnd + "'";
                        SqlCommand sqlCommand2 = new SqlCommand(query2, conn);
                        SqlDataAdapter sda2 = new SqlDataAdapter(sqlCommand2);
                        DataTable dt2 = new DataTable();
                        sda1.Fill(dt2);
                        conn.Close();
                        if (dt2.Rows.Count > 0)
                        {
                            errorProvider1.SetError(label4, "Booking Exists");
                        }
                        else
                        {
                            conn.Open();
                            string query3 = "Insert into Booking values('" + getName + "','" + getContact + "','" + getStartH + "','" + getStartM + "','" + getSAMPM + "','" + getEndH + "','" + getEndM + "','" + getEAMPM + "','" + gStart + "','" + gEnd + "','" + getStart + "','" + getEnd + "','"+ getBookingDate +"')";
                            SqlCommand cmd = new SqlCommand(query3, conn);
                            cmd.ExecuteNonQuery();
                            int hrs = gEnd.Hour - gStart.Hour;
                            int price = 1500 * hrs;
                            MessageBox.Show("Your Total Price is " + price);
                            DisplayData();
                            conn.Close();
                        }
                    }
                }

            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DisplayData();
           /* conn.Open();
            string getStartH = SHour.Text;
            string getStartM = SMin.Text;
            string getSAMPM = SAMPM.Text;
            string getEndH = Ehour.Text;
            string getEndM = EMin.Text;
            string getEAMPM = EAMPM.Text;
            string getStart = getStartH + ":" + getStartM + " " + getSAMPM;
            string getEnd = getEndH + ":" + getEndM + " " + getEAMPM;
            DateTime gStart = DateTime.ParseExact(getStart, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            DateTime gEnd = DateTime.ParseExact(getEnd, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
            string query = "Select BookingDate,GameStart,GameEnd from Booking where GameStart<='" + gStart + "' AND GameEnd>='" + gEnd + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               errorProvider1.SetError(label4, "Booking Exists");
            }*/
        }

        private void DisplayData()
        {
            conn.Close();
            conn.Open();
            dataGridView1.Refresh();
            string query = "Select fullName,Contact,BookingDate,Game_Start,Game_End from Booking";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string getFind = findBox.Text;
            string query = "Select fullName,Contact,BookingDate,SHour,SMin,SAMPM,EHour,EMin,EAMPM from Booking where Contact='" + getFind + "'";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                errorProvider1.Clear();
                string getFullName = dt.Rows[0]["fullName"].ToString();
                string getContact = dt.Rows[0]["Contact"].ToString();
                string getBookingDate = dt.Rows[0]["BookingDate"].ToString();
                DateTime DT = DateTime.Parse(getBookingDate);
                string getPSHour = dt.Rows[0]["SHour"].ToString();
                string getPSMin = dt.Rows[0]["SMin"].ToString();
                string getSAMPM = dt.Rows[0]["SAMPM"].ToString();
                string getPEHour = dt.Rows[0]["EHour"].ToString();
                string getPEMin = dt.Rows[0]["EMin"].ToString();
                string getEAMPM = dt.Rows[0]["EAMPM"].ToString();
               /* int getSHour = Int32.Parse(getPSHour);
                int getSMin = Int32.Parse(getPSMin);
                int getEHour = Int32.Parse(getPEHour);
                int getEMin = Int32.Parse(getPEMin);*/
                FullName.Text = getFullName;
                Contact.Text = getContact;
                dateTimePicker1.Value = DT;
                SHour.Text = getPSHour;
                SMin.Text = getPSMin;
                SAMPM.Text = getSAMPM;
                Ehour.Text = getPEHour;
                EMin.Text = getPEMin;
                EAMPM.Text = getEAMPM;
            }
            else
            {
                errorProvider1.SetError(findBox, "No Such Data");
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Gstart = SHour.Text + ":" + SMin.Text + " "+SAMPM.Text;
            string Gend = Ehour.Text + ":" + EMin.Text + " " + EAMPM.Text;
            DateTime getDateTime = dateTimePicker1.Value;
            DateTime getBookingDate = new DateTime(getDateTime.Year, getDateTime.Month, getDateTime.Day);
            string Uquery = "Update Booking set fullName='" + FullName.Text + "',Contact='" + Contact.Text + "',BookingDate='" + getBookingDate + "',SHour='" + Int32.Parse(SHour.Text) + "',SMin='" + Int32.Parse(SMin.Text) + "',SAMPM='"+ SAMPM.Text +"',EHour='"+ Int32.Parse(Ehour.Text)+"',EMin='"+ Int32.Parse(EMin.Text)+"',EAMPM='"+EAMPM.Text+ "',GStart='" + Gstart + "',GEnd='" + Gend + "' where Contact='"+ findBox.Text +"'";
            SqlCommand cmd = new SqlCommand(Uquery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            DisplayData();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
