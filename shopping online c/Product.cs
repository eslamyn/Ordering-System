using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_online_c
{
    [Serializable]
   public class Product
    {
        public string product { set; get; }
            public int quantity { set; get; }
            public float price { set; get; }
            public int id { set; get; }
            public Product()
            {
                product = "";
                quantity = 0;
                price = 0;
                id =0;
            }

            public Product(string product, int quantity, float price , int id)
            {
                this.product = product;
                this.quantity = quantity;
                this.price = price;
                this.id = id;
            }


    }
}
