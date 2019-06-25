using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace shopping_online_c
{
    [Serializable]
    public class bill 
    {
        static int billnumber=0;
        public List<Product> products { set; get; }
        public string customer_email { set; get; }
        public string delivry_name { set; get; }
        public float total_price { set; get; }
        public int id { set; get; }
        public DateTime delivry_data { set; get; }
           public bill() {
                 billnumber++;
                 id = billnumber;
                 customer_email = "";
                 delivry_name = "";
                 products = new List<Product>();
                 delivry_data = new DateTime();
             }



        
    }


}
