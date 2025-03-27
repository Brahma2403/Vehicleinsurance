using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;

namespace customerDA_Lib.repositories
{
    public class VehicleClass : IRepositoryVehicle<Vehicle>

    {
        SqlConnection con;
 
public VehicleClass()

{

    con = new SqlConnection(ConnectionString);

    con.Open();

}
 
public string ConnectionString

        {

            get

            {

                return "Data Source=LTIN519489;Initial Catalog=PROJECT;Integrated Security=True";

            }
        }
 
        public bool addVehicle(Vehicle entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Vehicle values(@p1, @p2, @p3, @p4, @p5, @p6)", con);
              //  cmd.Parameters.Add("@p1", entity.vehicleId);
                cmd.Parameters.Add("@p1", entity.customerId);
                cmd.Parameters.Add("@p2", entity.registrationNumber);
                cmd.Parameters.Add("@p3", entity.make);
                cmd.Parameters.Add("@p4", entity.model);
                cmd.Parameters.Add("@p5", entity.yearOfManufacture);
                cmd.Parameters.Add("@p6", entity.vehicleType);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Registration operation failed - " + ex.Message);
                b = false;
            }
            return b;
        }

        public List<Vehicle> getVehicleDetails()
        {
            List<Vehicle> Vehicle = new List<Vehicle>();
            SqlCommand cmd = new SqlCommand("Select * from Vehicle", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Vehicle v = new Vehicle()
                {
                    vehicleId = Convert.ToInt32(sqldr[0]),
                    customerId = Convert.ToInt32(sqldr[1]),
                    registrationNumber = sqldr[2].ToString(),
                    make = sqldr[3].ToString(),
                    model = sqldr[4].ToString(),
                    yearOfManufacture = Convert.ToInt32(sqldr[5]),
                    vehicleType = sqldr[6].ToString(),



                };
                Vehicle.Add(v);
            }
            sqldr.Close();
            return Vehicle;
        }
        public Vehicle Get(object obj)
        {
            string vehicleId = (string)obj;
            List<Vehicle> vehicles = getVehicleDetails();
            Vehicle vehicle = vehicles.Where(v =>
            {
                return Convert.ToString(v.vehicleId) == vehicleId;
            }).FirstOrDefault();
            return vehicle;

        }
        public bool updateVehicleDetails(Vehicle entity)
        {
            bool b = false;
            try
            {


                SqlCommand cmd = new SqlCommand("UPDATE Vehicle Set customerId=@p2,registrationNumber=@p3,make=@p4,model=@p5,yearOfManufacture=@p6,vehicleType=@p7 WHERE vehicleId=@p1", con);
                cmd.Parameters.Add("@p2", entity.customerId);
                cmd.Parameters.Add("@p3", entity.registrationNumber);
                cmd.Parameters.Add("@p4", entity.make);
                cmd.Parameters.Add("@p5", entity.model);
                cmd.Parameters.Add("@p6", entity.yearOfManufacture);
                cmd.Parameters.Add("@p7", entity.vehicleType);
                cmd.Parameters.Add("@p1", entity.vehicleId);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert operation failed" + ex.Message);
                b = false;
            }
            return b;
        }
    }
}

