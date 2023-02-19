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

namespace CsharpForm
{
    public partial class inventory : UserControl
    {
        //Suyog Lab Database
        //SqlConnection conn = new SqlConnection(@"Data Source=GWTN141-4;Initial Catalog=InventoryDB;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LHHH1S3\SQLEXPRESS;Initial Catalog=BookingDB;Integrated Security=True");



        //Rohan Legion database
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-3ORSUC9H;Initial Catalog=signUp;Integrated Security=True");
        //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CLLMDVB\SQLEXPRESS;Initial Catalog=signUp;Integrated Security=True");
        public inventory()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime getDateTime = dateTimePicker1.Value;
            DateTime getPurchaseDate = new DateTime(getDateTime.Year, getDateTime.Month, getDateTime.Day);
            string getInvName = Inv.Text;
            int getQuantity = Int32.Parse(qty.Text);
            int getPrice = Int32.Parse(price.Text);
            int getTotal = getQuantity*getPrice;
            int getAmount = getTotal;
            Amt.Text= getAmount.ToString();
            conn.Open();
            string query = "Insert into Inventory values('" + getPurchaseDate + "','" + getInvName + "','"+ getQuantity +"','"+ getPrice +"','" + getAmount +"')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            DisplayData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            conn.Open();
            dataGridView1.Refresh();
            string query = "Select PurchaseDate,InventoryName,Quantity,Price,Amount from Inventory";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void inventory_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}
