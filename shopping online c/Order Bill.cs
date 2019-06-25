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
{[Serializable]
    public partial class Order_Bill :  Form
    {
        bill z;
        customer1 v;
        public Order_Bill(bill x,customer1 g)
        {
            v = g;
            z = x;
            InitializeComponent();
        }
        
        private void Order_Bill_Load(object sender, EventArgs e)
        {
            label2.Text +="             "+ z.customer_email;
            label3.Text +="             "+ v.address;
            label4.Text +="             "+ v.phone;
            label5.Text +="             "+ z.delivry_name;
            dataGridView1.DataSource = z.products;            
            label7.Text +="             "+ z.total_price+" $";
            label8.Text +="             "+ z.id;
            label9.Text += "            " + z.delivry_data.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
         
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
    }
}
