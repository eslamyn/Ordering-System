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
using System.Runtime.Serialization.Formatters.Binary;

namespace shopping_online_c
{
    [Serializable]

    public partial class CustomerLogin : Form
    {
        List<customer1> C = new List<customer1>();
      
        public CustomerLogin()
        {
           
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < C.Count; i++)
            {
                if (textBox1.Text == C[i].name && textBox2.Text == C[i].passward)
                {

                    Customer_options f = new Customer_options(C[i]);
                    this.Hide();
                    f.Show();
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool done = false;

            for (int i = 0; i < C.Count; i++)
            {
                if (textBox1.Text == C[i].name && textBox2.Text == C[i].passward)
                {
                    done = true;
                    C.RemoveAt(i);
                    MessageBox.Show(" The Account UnRegister Successfuly");
                    this.Close();
                    break;
                }
            }

            if (done == false)
            {
                MessageBox.Show(" No Customer With This Email & Passward");
            }
        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists("customer.txt"))
            {
                FileStream FS = new FileStream("customer.txt", FileMode.Open);
                BinaryFormatter BF = new BinaryFormatter();

                while (FS.Position != FS.Length)
                {
                   C.Add((customer1)BF.Deserialize(FS));

                }
                FS.Close();
            }
        }



    }
}
