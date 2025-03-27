
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;
using customerDA_Lib.repositories;
namespace customerBO_Lib.BO
{
    public class VehicleBO
    {
        static VehicleClass veRepo = new VehicleClass();

        public static void addVehicle(customerBO_Lib.models.Vehicle vehicle)
        {
            customerDA_Lib.models.Vehicle ve = new customerDA_Lib.models.Vehicle()
            {
                vehicleId = vehicle.vehicleId,
                customerId = vehicle.customerId,
                registrationNumber = vehicle.registrationNumber,
                make = vehicle.make,
                model = vehicle.model,
                yearOfManufacture = vehicle.yearOfManufacture,
                vehicleType = vehicle.vehicleType
            };

            if (veRepo.addVehicle(ve)) // Ensure this method is implemented
            {
                Console.WriteLine("vehicle details updated");
            }
            else
            {
                Console.WriteLine("problem in entering details");
            }
        }
        public static void viewVehicledetails()
        {
            var Vehicle = veRepo.getVehicleDetails();
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}", "customerId", "registrationNumber", "make", "model", "yearOfManufacture", "vehicleType");
            foreach (var ve in Vehicle)
            {
                Console.WriteLine($"{ve}");
            }

        }

        public static void UpdateVehicle(string vehicleId)

        {
            var vehicle = veRepo.Get(vehicleId);
            if (vehicle == null)
            {

                Console.WriteLine($"{vehicleId} is invalid");
            }
            else
            {
                Console.WriteLine("Re-enter vehicle details ");
                customerDA_Lib.models.Vehicle ve = new customerDA_Lib.models.Vehicle()

                {

                    //customerId=customer.customerId,
                    vehicleId = Convert.ToInt32(Console.ReadLine()),
                    customerId = Convert.ToInt32(Console.ReadLine()),
                    registrationNumber = Console.ReadLine(),
                    make = Console.ReadLine(),
                    model = Console.ReadLine(),
                    yearOfManufacture = Convert.ToInt32(Console.ReadLine()),
                    vehicleType = Console.ReadLine(),


                };

                if (veRepo.addVehicle(ve))

                {

                    Console.WriteLine("vehicle details updated");

                }

                else

                {

                    Console.WriteLine("vehicle details are not updated");

                }
            }


        }
    }
}
    