using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace customerBO_Lib.models
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

    }
}
