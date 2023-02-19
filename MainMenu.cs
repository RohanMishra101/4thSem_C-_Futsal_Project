using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpForm
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            home1.Show();
            booking1.Hide();
            employee1.Hide();
            inventory1.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            booking1.Show();
            home1.Hide();
            employee1.Hide();
            inventory1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            home1.Hide();
            booking1.Hide();
            employee1.Show();
            inventory1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            home1.Hide();
            booking1.Hide();
            employee1.Hide();
            inventory1.Show();
        }

        private void Mainmenu_Load(object sender, EventArgs e)
        {
            home1.Show();
            booking1.Hide();
            inventory1.Hide();
            employee1.Hide();
            home1.BackColor = Color.White;
            employee1.BackColor = Color.White;
            inventory1.BackColor = Color.White;
        }

        private void inventory1_Load(object sender, EventArgs e)
        {

        }
    }
}
