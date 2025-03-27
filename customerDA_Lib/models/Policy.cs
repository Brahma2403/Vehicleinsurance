using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.models
{
    public class Policy
    {
        public int policyId { get; set; }
        public int vehicleId { get; set; }
        public string policyNumber { get; set; }
        public decimal coverageAmount { get; set; }

        public decimal premiumAmount { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string policyStatus { get; set; }
        public override string ToString()
        {
            return String.Format($"{policyId,10}{vehicleId,10}{policyNumber,10}{coverageAmount,10}{premiumAmount,10}{startDate,10}{endDate,10}{policyStatus,10}");
        }
    }

}
