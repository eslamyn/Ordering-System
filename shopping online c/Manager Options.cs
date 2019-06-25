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
    [Serializable]
    public partial class Manager_Options : Form 
    {
    
       public List<Product> Catalogue = new List<Product>();

       List<bill> bills = new List<bill>();
        public List<emp> empolyee = new List<emp>();
        

        List<customer1> C = new List<customer1>();

        public Manager_Options( )
        {
           
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            emp f = new emp();
            f.name = textBox1.Text;

            empolyee.Add(f);
            MessageBox.Show(" employee is added successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = textBox1.Text;
            bool done = false;
            for (int i = 0; i < empolyee.Count; i++)
            {
                if (empolyee[i].name == x)
                {
                    done = true;
                    empolyee.RemoveAt(i);
                    MessageBox.Show(" employee is removed successfully");
                    break;
                }

            }
            if (done == false)
            {
                MessageBox.Show("No employee with that name");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            bill g = new bill();
            customer1 l = new customer1();
            bool exist =false;
            //int x;
            //int y;
            //int z;
            //x=int.Parse(comboBox2.Text);
            //y=int.Parse(comboBox1.Text);
            //z=int.Parse(comboBox3.Text);
            for(int i=0 ; i<bills.Count ; i++)
            {
                if ( int.Parse(comboBox2.Text)==bills[i].delivry_data.Day && int.Parse(comboBox1.Text)==bills[i].delivry_data.Month &&  int.Parse(comboBox3.Text)==bills[i].delivry_data.Year )
                {
                    exist = true;
                    for (int p = 0; p < C.Count; p++)
                    {
                        if (g.customer_email == C[p].email)
                        {
                            g.customer_email = C[p].email;
                            g.delivry_name = bills[i].delivry_name;
                            g.id = bills[i].id;
                            g.products = bills[i].products;
                            g.total_price = bills[i].total_price;
                            g.delivry_data = bills[i].delivry_data;
                            l.address = C[p].address;
                            l.phone = C[p].phone;
                            Order_Bill j = new Order_Bill(g, l);
                            j.Show();
                        }

                    }

                    

                }

            }
            if (exist == false)
            {
                MessageBox.Show("No Bills with that Date");
            }
                     
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Catalogue.Count; i++)
            {
                if (Catalogue[i].product == textBox3.Text)
                {
                    MessageBox.Show("you have " + Catalogue[i].quantity.ToString() + " from " + textBox3.Text);
                }
            }
        }

        private void Manager_Options_Load(object sender, EventArgs e)
        {
            if (File.Exists("employee.txt"))
            {
                FileStream FS = new FileStream("employee.txt", FileMode.Open);
                BinaryFormatter BF = new BinaryFormatter();

                while (FS.Position != FS.Length)
                {
                    empolyee.Add((emp)BF.Deserialize(FS));

                }
                FS.Close();
                ////////////////////////////////////////////////////
            }
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
            //////////////////////////////////////////////////////
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
            //////////////////////////////////////////////////////
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

        private void button5_Click(object sender, EventArgs e)
        {
            //Manager Add Product  >>>>>>>>>>>>>>>>

            string product = "";
            int id = 0;
            int quantity = 0;
            int price = 0;

            product = textBox4.Text;
            id = int.Parse(ProductID.Text);
            quantity = int.Parse(textBox6.Text);
            price = int.Parse(textBox7.Text);

            Product ca = new Product(product,quantity,price,id);

            Catalogue.Add(ca);

            MessageBox.Show("successfully Product Added");
        }

     private void button6_Click(object sender, EventArgs e)
        {
         //Manager Delete Product >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string product;
           
            product = textBox5.Text;
            bool exist = false;
            for (int i = 0; i < Catalogue.Count; i++)
            {
                if (Catalogue[i].product == product)
                {
                    exist = true;
                    Catalogue.RemoveAt(i);
                    MessageBox.Show("successfully product removed");
                }
            }
                if (exist == false)
                {
                    MessageBox.Show("No product with this name");

                }
            
     }

     private void tabPage1_Click(object sender, EventArgs e)
     {

     }

     private void button8_Click(object sender, EventArgs e)
     {
         if (File.Exists("employee.txt")) File.Delete("employee.txt");

         FileStream FS = new FileStream("employee.txt", FileMode.Create);
         BinaryFormatter b = new BinaryFormatter();
         for (int i = 0; i < empolyee.Count(); i++) b.Serialize(FS, empolyee[i]);
         FS.Close();

         Form1 fo = new Form1();
        if (File.Exists("Catalogue.txt")) File.Delete("Catalogue.txt");
         
             FileStream FS1 = new FileStream("Catalogue.txt", FileMode.Create);
             BinaryFormatter b2 = new BinaryFormatter();
             for (int i = 0; i < Catalogue.Count;i++)b2.Serialize(FS1, Catalogue[i]);
             FS1.Close();
             this.Close();
             fo.Show();
         }

     private void button7_Click(object sender, EventArgs e)
     {
         //Show Customer bills (the manager enters customer email)  <<<<<<<<<<<<<<<<<<<<<<<<<<<
         bill g = new bill();
         customer1 l = new customer1();
         bool exist = false;
         
         string s = textBox8.Text;
         for (int i = 0; i < C.Count; i++)
         {

             if (C[i].email == s)
             {
                 exist = true;
                 for (int y = 0; y < bills.Count; y++)
                 {

                     if (bills[y].customer_email == s && bills[y].customer_email == C[i].email)
                     {
                         
                         g.customer_email = C[i].email;
                         g.delivry_name = bills[y].delivry_name;
                         g.id = bills[y].id;
                         g.products = bills[y].products;
                         g.total_price = bills[y].total_price;
                         g.delivry_data = bills[y].delivry_data;
                         l.address = C[i].address;
                         l.phone = C[i].phone;
                         Order_Bill j = new Order_Bill(g, l);
                         j.Show();
                        
                     }
                     
                 }

                 break;
             }
           
         }
         if (exist == false) 
             MessageBox.Show("There is no bills for this E-mail");

         textBox8.Text = "";

     }

     private void label2_Click(object sender, EventArgs e)
     {

     }

     private void textBox8_TextChanged(object sender, EventArgs e)
     {

     }

     private void ProductID_TextChanged(object sender, EventArgs e)
     {

     }

     private void tabPage2_Click(object sender, EventArgs e)
     {

     }

     private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
     {

     }

     //private void tabPage1_Click(object sender, EventArgs e)
     //{

     //}

    
  
        }
    }

