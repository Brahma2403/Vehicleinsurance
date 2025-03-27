using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;
using customerDA_Lib.repositories;

namespace customerBO_Lib.BO
{
    public class ClaimBO
    {
        static claimClass claRepo = new claimClass();
        public static void AddClaim(customerBO_Lib.models.Claim claim)
        {
            customerDA_Lib.models.Claim cla = new customerDA_Lib.models.Claim()
            {
                claimId = claim.claimId,
                policyID = claim.policyID,
                claimAmount = claim.claimAmount,
                claimReason = claim.claimReason,
                claimDate = claim.claimDate,
                claimStatus = claim.claimStatus,

            };
            if (claRepo.Add(cla))
            {
                Console.WriteLine("claim details updated");

            }
            else
            {
                Console.WriteLine("problem in entering details");
            }

        }
    }
}
