using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_online_c
{
    [Serializable]
    public class emp
    {
        public string name;
        public int numorder;


        public emp()
        {
            name = "";
            numorder = 0;

        }

        public emp(string name, int numorder)
        {
            this.name = name;
            this.numorder = numorder;
        }


    }
}
