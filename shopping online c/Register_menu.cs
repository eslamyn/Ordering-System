using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace shopping_online_c
{
    public partial class Register_menu : Form
    {
         

       
        List<customer1> f = new List<customer1>();
        customer1 c = new customer1();

        public Register_menu()
        {
          
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerLogin lo = new CustomerLogin();
            Customer ca = new Customer();
            c.email = textBox1.Text;
            c.passward = textBox2.Text;
            c.name = textBox3.Text;
            c.address = textBox4.Text;
            c.Creditcard = textBox6.Text;
            c.phone = textBox5.Text;
            MessageBox.Show("Thanks for registration !! press ok to login ^^");
            f.Add(c);

            if (File.Exists("customer.txt"))
            {
                FileStream FS = new FileStream("customer.txt", FileMode.Append);
                BinaryFormatter k = new BinaryFormatter();
                for (int i = 0; i < f.Count(); i++) k.Serialize(FS, f[i]);
                FS.Close();
            }
            this.Close();
            ca.Hide();
            lo.Show();
            
        }

        private void Register_menu_Load(object sender, EventArgs e)
        {

        }
    }
}
