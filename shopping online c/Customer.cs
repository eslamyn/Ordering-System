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
    public partial class Customer : Form
    {
        List<customer1> C = new List<customer1>();
        
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer1 h = new customer1();
            Register_menu rm = new Register_menu();
            this.Hide();
            rm.Show();
            C.Add(h);
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            CustomerLogin co = new CustomerLogin();
            this.Hide();
            co.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1();
            this.Hide();
            fo.Show();
        }
        private void Customer_Load(object sender, EventArgs e)
        {

        }

       
    }
}
