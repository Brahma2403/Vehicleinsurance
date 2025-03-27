using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;

namespace customerDA_Lib.repositories
{
    public class customerClass : IRepositoryCustomer<Customer>
    {
        SqlConnection con;
        public customerClass()
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



        public bool Add(Customer entity)
        {
            bool b = false;
            try
            {
                

                SqlCommand cmd = new SqlCommand("insert into Customer values(@p1, @p2,@p3, @p4 )", con);
                cmd.Parameters.Add("@p1", entity.name);
                cmd.Parameters.Add("@p2", entity.email);
                cmd.Parameters.Add("@p3", entity.phone);
                cmd.Parameters.Add("@p4", entity.address);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Registration operation failed-"+ ex.Message);
                b = false;
            }
            return b;
            
        }
        

        public bool updateCustomerProfile(Customer entity)
        {
            bool b = false;
            try
            {


                SqlCommand cmd = new SqlCommand("UPDATE Customer Set name=@p2,email=@p3,phone=@p4,address=@p5 where customerId=@p1", con);

                cmd.Parameters.Add("@p2", entity.name);
                cmd.Parameters.Add("@p3", entity.email);
                cmd.Parameters.Add("@p4", entity.phone);
                cmd.Parameters.Add("@p5", entity.address);
                cmd.Parameters.Add("@p5", entity.customerId);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("update operation failed" + ex.Message);
                b = false;
            }
            return b;
        }
    

        public Customer Get(object obj)
        {
            string customerId = (string)obj;
            List<Customer> customers = GetAllCustomerDetails();
            Customer customer = customers.Where(c =>
            {
                return Convert.ToString(c.customerId) == customerId;
            }).FirstOrDefault();
            return customer;

        }
        public List<Customer> GetAllCustomerDetails()
        {
            List<Customer> Customer = new List<Customer>();
            SqlCommand cmd = new SqlCommand("Select * from Customer", con);
            SqlDataReader sqldr=cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Customer c = new Customer()
                {
                    customerId = Convert.ToInt32(sqldr[0]),
                    name = sqldr[1].ToString(),
                    email = sqldr[2].ToString(),
                    phone = sqldr[3].ToString(),
                    address = sqldr[4].ToString(),



                };
                Customer.Add(c);



            }
            sqldr.Close();
            return Customer;
        }   

        public bool registercustomer(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool registerCustomer(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
