using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopping_online_c
{
    public partial class Manager : Form
    {
        List<Manager> m;
        string username = "admin";
        string password = "12345";
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == username && textBox2.Text == password)
            {
                MessageBox.Show("Login succeeded");
                Manager_Options mo = new Manager_Options();
                this.Hide();
                mo.Show();
            }
            else
                MessageBox.Show("Wrong username or password");

        }

        private void button2_Click(object sender, EventArgs e)
        {
             
        
            Form1 fo = new Form1();
            this.Hide();
            fo.Show();
        
        }
    }
}
