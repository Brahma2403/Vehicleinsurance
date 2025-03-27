using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.models
{
    public class Vehicle
    {
        public int vehicleId { get; set; }
        public int customerId { get; set; }
        public string registrationNumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int yearOfManufacture { get; set; }
        public string vehicleType { get; set; }
        public override string ToString()
        {
            return String.Format($"{customerId,10}{registrationNumber,10}{make,10}{model,10}{yearOfManufacture,10}{vehicleType,10}");
        }



    }
}
