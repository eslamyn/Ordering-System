using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_online_c
{
    [Serializable]
    public class customer1 
    {

         public string email{set; get;}
         public string passward{set ; get ;}
            public string name {set ; get ;} 
            public string address{set ; get ;}
            public string Creditcard { set; get; }
        public string phone { set; get; }
            List<bill> Bills;
            public customer1()
            {
                email = "";
                passward = "";
                name = "";
                address = "";
                Creditcard = "";
                phone = "";
                Bills = new List<bill>();
            }
            public customer1(string email,string passward, string name, string address,string credit, string phone)
            {
                this.email = email;
                this.passward = passward;
                this.name = name;
                this.address = address;
                this.Creditcard = credit;
                this.phone = phone;
                Bills = new List<bill>();
            }


    }
}
