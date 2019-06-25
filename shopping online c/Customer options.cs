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
    public partial class Customer_options : Form 
        
    {
        List<Product> Catalogue = new List<Product>();
        List<bill> bills = new List<bill>();

        List<emp> employee = new List<emp>();
        
       customer1 curraccount;        
        public Customer_options(customer1 H)
        {
            curraccount = H;
           
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_options_Load(object sender, EventArgs e)
        {
            
            label3.Text +="    "+ curraccount.email;


            if (File.Exists("Catalogue.txt"))
            {
                FileStream FS = new FileStream("Catalogue.txt", FileMode.Open);
                BinaryFormatter BF = new BinaryFormatter();

                while (FS.Position != FS.Length)
                {
                    Catalogue.Add((Product)BF.Deserialize(FS));

                }
                FS.Close();
            }
            dataGridView1.DataSource = Catalogue;

            /////////////////////////////////////////////////////////////////////////
            if (File.Exists("employee.txt"))
            {
                FileStream FS = new FileStream("employee.txt", FileMode.Open);
                BinaryFormatter BF = new BinaryFormatter();

                while (FS.Position != FS.Length)
                {
                    employee.Add((emp)BF.Deserialize(FS));

                }
                FS.Close();
            }
            ///////////////////////////////////////////////////////////////////


            if (File.Exists("bill.txt"))
            {
                FileStream FS = new FileStream("bill.txt", FileMode.Open);
                BinaryFormatter BF = new BinaryFormatter();

                while (FS.Position != FS.Length)
                {
                    bills.Add((bill)BF.Deserialize(FS));

                }
                FS.Close();
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void MakeOrder(object sender, EventArgs e)
        {
            //Show Bill<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            bill b = new bill() ;
            b.customer_email = curraccount.email;
            DateTime x = DateTime.Now;
            x = x.AddHours(2);
             List<string> pro=new List<string>();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                
                Product p=new Product();
                p.product = dataGridView2.Rows[i].Cells[0].Value.ToString();
                
                p.quantity=int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString());
                p.price=float.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                b.total_price+=p.price;
                b.delivry_data = x;
                b.products.Add(p);

                }
            ///////////////////////////////////////////////////////////////////
            for (int i = 0; i < employee.Count; i++) {
                if (employee[i].numorder < 2) {
                    employee[i].numorder++;
                    b.delivry_name = employee[i].name;
                    break;
                }

            }
           
            bills.Add(b);
            Order_Bill ob = new Order_Bill(b,curraccount);
            ob.Show();
           
         
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //check the product quantity when buying
            bool exist = false;
            for (int i = 0; i <Catalogue.Count; i++)
            {
                if (Catalogue[i].product == textBox1.Text && Catalogue[i].quantity >= int.Parse(textBox2.Text))
                {
                    Catalogue[i].quantity -= int.Parse(textBox2.Text);
                    exist = true;
                    dataGridView2.Rows.Add(textBox1.Text, textBox2.Text,Catalogue[i].price, Catalogue[i].price*int.Parse(textBox2.Text));
                }
                           
            }
            if (!exist) MessageBox.Show("The Product doesn't exist");

            textBox1.Text = "";
            textBox2.Text = "";
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            //show bill by bill id (customer enters id)

            bill g = new bill();
            customer1 l = new customer1();
           
            string o = textBox3.Text;
             bool done = false;
            for(int i=0;i<bills.Count;i++)
            {
                if (bills[i].id == int.Parse(o) && bills[i].customer_email == curraccount.email) 
                     {
                    done = true;
                    g.customer_email = bills[i].customer_email;
                    g.delivry_name = bills[i].delivry_name;
                    g.id = bills[i].id;
                    g.products = bills[i].products;
                    g.total_price = bills[i].total_price;
                    l.address = curraccount.address;
                    l.phone = curraccount.phone;

                    g.delivry_data = bills[i].delivry_data;
                    Order_Bill j = new Order_Bill(g, l);
                    j.Show();
                    break;
                }

                    }
            if (done==false) 
                {
                    MessageBox.Show("No Bill with that ID");
            }
            textBox3.Text = "";   
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //return a product 
            string o = textBox22.Text;
            string r = textBox21.Text;
            DateTime x = DateTime.Now;
           TimeSpan s=new TimeSpan();
            double f;
            bool done = false;
            for (int i = 0; i < bills.Count; i++)
            {
                if (bills[i].id == int.Parse(o))
                {
                    
                        done = true;
                        for (int u = 0; u < bills[i].products.Count; u++)
                        {
                            s = x - bills[i].delivry_data;
                            f = double.Parse(s.TotalDays.ToString());
                            if (bills[i].products[u].product == r && f <= 14)
                            {
                                for (int j = 0; j < Catalogue.Count; j++)
                                {
                                    if (Catalogue[j].product == r)
                                    {
                                        Catalogue[j].quantity += bills[i].products[u].quantity;

                                        bills[i].total_price -= bills[i].products[u].price * bills[i].products[u].quantity;
                                        bills[i].products.RemoveAt(u);
                                        Order_Bill w = new Order_Bill(bills[i], curraccount);
                                        w.Show();
                                        break;
                                    }
                                }
                            }
                        }             
                }
                
            }
            if (done == false)
            {
                MessageBox.Show("No Bill with that ID");
            }
            textBox22.Text = "";
            textBox21.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
     
        private void button6_Click(object sender, EventArgs e)
        {
           
            if (File.Exists("bill.txt")) File.Delete("bill.txt");
            Form1 fo = new Form1();
            FileStream FS = new FileStream("bill.txt", FileMode.Append);
            BinaryFormatter k = new BinaryFormatter();
            for (int i = 0; i < bills.Count(); i++) k.Serialize(FS, bills[i]);
            FS.Close();
            MessageBox.Show("Thanks for trusting us :) ");
            this.Close();
            fo.Show();
        }

      
 
    }
}
