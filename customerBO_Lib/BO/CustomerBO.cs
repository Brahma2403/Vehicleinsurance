using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;
using customerDA_Lib.repositories;

namespace customerBO_Lib.BO
{
    public class CustomerBO
    {
        static customerClass cusRepo = new customerClass();
        public static void updateCustomerProfile(string customerId)

        {
            var customer = cusRepo.Get(customerId);
            if (customer == null)
            {

                Console.WriteLine($"{customerId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter customer details ");
                customerDA_Lib.models.Customer co = new customerDA_Lib.models.Customer()

                {

                    //customerId=customer.customerId,
                    customerId = customer.customerId,
                    name = Console.ReadLine(),
                    email = Console.ReadLine(),
                    phone = Console.ReadLine(),
                    address = Console.ReadLine(),

         

                };

                if (cusRepo.Add(co))

                {

                    Console.WriteLine("customer details updated");

                }

                else

                {

                    Console.WriteLine("customer details are not updated");

                }
            }



        }
        public static void AddCustomer(customerBO_Lib.models.Customer customer)
        {
            customerDA_Lib.models.Customer cus = new customerDA_Lib.models.Customer()
            {
                //customerId=customer.customerId,
                name = customer.name,
                email = customer.email,
                phone = customer.phone,
                address = customer.address,
            };
            if (cusRepo.Add(cus))
            {
                Console.WriteLine("customer details updated");

            }
            else
            {
                Console.WriteLine("problem in entering details");
            }
        }

 

        public static void ViewCustomers()
        {
            var Customer = cusRepo.GetAllCustomerDetails();
            Console.WriteLine("{0,12}{1,40}{2,40}{3,40}", "customerId","name","email","address");
            foreach (var cus in Customer)
            {
                Console.WriteLine($"{cus}");
            }

        } 
    }
}
