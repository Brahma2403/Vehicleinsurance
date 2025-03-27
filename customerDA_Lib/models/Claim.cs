using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.models
{
    public class Claim
    {
        public int claimId { get; set; }

        public int policyID { get; set; }
        public decimal claimAmount { get; set; }

        public string claimReason { get; set; }
        public DateTime claimDate { get; set; }
        public string claimStatus { get; set; }

    }
}
