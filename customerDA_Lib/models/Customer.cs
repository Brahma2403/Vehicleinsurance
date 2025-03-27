using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.models
{
    public class Customer
    {
        internal string Customername;

        public int customerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public override string ToString()
        {
            return String.Format($"{customerId,12}{name,40}{email,40}{address,40}");
        }

    }
}
