using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.repositories;
using customerDA_Lib.models;

namespace customerBO_Lib.BO
{
    public class PolicyBO
    {
        static PolicyClass polRepo = new PolicyClass();
        public static void searchPolicy(string policyId)
        {
            var policy = polRepo.Get(policyId);
            if (policy == null)
            {
                Console.WriteLine($"{policyId} is invalid");
            }
            else
            {
                Console.WriteLine($"{policy}");
            }
        }
        public static void UpdatePolicy(string policyId)

        {
            var policy = polRepo.Get(policyId);
            if (policy == null)
            {

                Console.WriteLine($"{policyId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter policy details ");
                customerDA_Lib.models.Policy po = new customerDA_Lib.models.Policy()

                {

                    //customerId=customer.customerId,
                    policyId = policy.policyId,
                    vehicleId = Convert.ToInt32(Console.ReadLine()),
                    policyNumber = Console.ReadLine(),
                    coverageAmount = Convert.ToDecimal(Console.ReadLine()),
                    premiumAmount = Convert.ToDecimal(Console.ReadLine()) ,
                    startDate = Convert.ToDateTime(Console.ReadLine()),
                    endDate = Convert.ToDateTime(Console.ReadLine()),
                    policyStatus = Console.ReadLine(),


                };

                if (polRepo.Add(po))

                {

                    Console.WriteLine("policy details updated");

                }

                else

                {

                    Console.WriteLine("policy details are not updated");

                }
            }
             
            

        }

        public static void AddPolicy(customerBO_Lib.models.Policy policy)

        {

            customerDA_Lib.models.Policy pol = new customerDA_Lib.models.Policy()

            {

                //customerId=customer.customerId,

                vehicleId= policy.vehicleId,
                policyId = policy.policyId,
                policyNumber = policy.policyNumber,
                coverageAmount= policy.coverageAmount,
                premiumAmount= policy.premiumAmount,
                startDate= policy.startDate,    
                endDate= policy.endDate,   
                policyStatus= policy.policyStatus,
       

            };

            if (polRepo.Add(pol))

            {

                Console.WriteLine("customer details updated");

            }

            else

            {

                Console.WriteLine("problem in entering details");

            }

        }
        public static void ViewPolicies()
        {
            var Policy = polRepo.GetAll();
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10}{7,10}", "policyId", "vehicleId", "policyNumber", "coverageAmount", "premiumAmount", "startDate", "endDate", "policyStatus");
            foreach (var pol in Policy)
            {
                Console.WriteLine($"{pol}");
            }
        }

    }
}
