using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerBO_Lib.BO;
using customerBO_Lib.models;
namespace customerApp
{
    public  class Program
    {
        public static void Main(string[] args)
        {

            while(true)
            {
                Console.WriteLine("1.Enter Customer details");
                Console.WriteLine("2.Update customer details");
                Console.WriteLine("3.view aLL customers");
                Console.WriteLine("4.Add Vehicle Details");
                Console.WriteLine("5.view Vehicle details ");
                Console.WriteLine("6.Add policy details ");
                
                Console.WriteLine("7.Add Claim details");
                Console.WriteLine("8.View All Policies");
                Console.WriteLine("9.update policy details");
                Console.WriteLine("10.search policy details with valid policy Id");
                Console.WriteLine("11.Exit");
                int option=Convert.ToInt32(Console.ReadLine());
                
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Wish to add customer deatils? Press Y");
                        string ans=Console.ReadLine();
                        while(ans.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter name, email, phone and address");
                            customerBO_Lib.models.Customer c = new customerBO_Lib.models.Customer()
                            {
                                name = Console.ReadLine(),
                                email=Console.ReadLine(),
                                phone=Console.ReadLine(),
                                address=Console.ReadLine(),
                            };
                            CustomerBO.AddCustomer(c);
                            Console.WriteLine("Wish to add customer details? Press Y");
                            ans=Console.ReadLine();
                        }


                        break;
                        case 2:
                        Console.WriteLine("enter valid customer Id, for update");
                        string id = Console.ReadLine();
                        CustomerBO.updateCustomerProfile(id);
                        
                        break;
                        case 3:
                        CustomerBO.ViewCustomers();
                        break;
                    case 4:
                        Console.WriteLine("Wish to add Vehicle deatils? Press Y");

                        string ans3 = Console.ReadLine();

                        while (ans3.ToUpper()[0] == 'Y')

                        {

                            Console.WriteLine("customerId,registrationNumber,make,model,yearOfManufacture,vehicleType(Car,Bike,Truck)");

                            Vehicle v = new Vehicle()

                            {

                                //vehicleId = Convert.ToInt32(Console.ReadLine()),

                                customerId = Convert.ToInt32(Console.ReadLine()),

                                registrationNumber = Console.ReadLine(),

                                make = Console.ReadLine(),

                                model = Console.ReadLine(),

                                yearOfManufacture = Convert.ToInt32(Console.ReadLine()),

                                vehicleType = Console.ReadLine(),

                            };

                           VehicleBO.addVehicle(v);

                            Console.WriteLine("Wish to add vehicle details? Press Y");

                            ans3 = Console.ReadLine();

                        }
                        break;

                    case 5:
                        VehicleBO.viewVehicledetails();
                        break;
                       
                    case 6:
                        Console.WriteLine("Wish to add Policy details Press Y");
                        string ans1 = Console.ReadLine();
                        while (ans1.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter policyId,VehilceId,policy number,coverage amount,premium amount,startdate,enddate and policystatus");
                            Policy p = new Policy()
                            {
                                vehicleId = Convert.ToInt32(Console.ReadLine()),
                                policyNumber = Console.ReadLine(),
                                coverageAmount = Convert.ToDecimal(Console.ReadLine()),
                                premiumAmount = Convert.ToDecimal(Console.ReadLine()),
                                startDate = DateTime.Parse(Console.ReadLine()),
                                endDate = DateTime.Parse(Console.ReadLine()),
                                policyStatus = Console.ReadLine()


                            };
                            PolicyBO.AddPolicy(p);
                            Console.WriteLine("Wish to add Policy details Press Y");
                            ans1 = Console.ReadLine();
                        }
                        break;
                    case 7:
                        Console.WriteLine("Wish to add claim deatils? Press Y");
                        string ans2 = Console.ReadLine();
                        while (ans2.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter  policyId, claimAmount, claimReason, claimDate and claimStatus");
                            Claim c = new Claim()
                            {
                                //claimId = Convert.ToInt32(Console.ReadLine()),
                                policyID = Convert.ToInt32(Console.ReadLine()),
                                claimAmount = Convert.ToDecimal(Console.ReadLine()),
                                claimReason = Console.ReadLine(),
                                claimDate = DateTime.Parse(Console.ReadLine()),
                                claimStatus = Console.ReadLine(),
                            };
                            ClaimBO.AddClaim(c);
                            Console.WriteLine("Wish to add claim details? Press Y");
                            ans = Console.ReadLine();
                        }

                        break;

                        case 8:
                        PolicyBO.ViewPolicies();
                        break;
                    case 9:
                        Console.WriteLine("enter valid policy Id, for update");
                        string id1=Console.ReadLine();
                        PolicyBO.UpdatePolicy(id1);
                        break;
                    case 10:
                        Console.WriteLine("Enter a valid policy Id:");
                        string id4 = Console.ReadLine();
                        PolicyBO.searchPolicy(id4);
                        break;
                    case 11:
                        Console.WriteLine("Terminated");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option, Enter correct option");
                        break;

                }
            }
            
        }
    }
}
