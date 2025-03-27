using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;

namespace customerDA_Lib.repositories
{

    public class PolicyClass : IRepositoryPolicy<Policy>
    {
        SqlConnection con;
        public PolicyClass()
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
        public bool Add(Policy entity)
        {
            bool b = false;
            try
            {


                SqlCommand cmd = new SqlCommand("insert into policy values(@p1, @p2,@p3, @p4, @p5, @p6, @p7)", con);
                cmd.Parameters.Add("@p1", entity.vehicleId);
                cmd.Parameters.Add("@p2", entity.policyNumber);
                cmd.Parameters.Add("@p3", entity.coverageAmount);
                cmd.Parameters.Add("@p4", entity.premiumAmount);
                cmd.Parameters.Add("@p5", entity.startDate);
                cmd.Parameters.Add("@p6", entity.endDate);
                cmd.Parameters.Add("@p7", entity.policyStatus);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Registration operation failed-" + ex.Message);
                b = false;
            }
            return b;

        }
       

        public List<Policy> GetAll()
        {
            List<Policy> policys = new List<Policy>();

            SqlCommand cmd = new SqlCommand("Select * from Policy", con);

            SqlDataReader sqldr = cmd.ExecuteReader();

            while (sqldr.Read())

            {

                Policy p = new Policy()

                {

                    policyId = Convert.ToInt32(sqldr[0]),

                    vehicleId = Convert.ToInt32(sqldr[1]),

                    policyNumber = (sqldr[2]).ToString(),

                    coverageAmount = Convert.ToDecimal(sqldr[3]),

                    premiumAmount = Convert.ToDecimal(sqldr[4]),
                    startDate = Convert.ToDateTime(sqldr[5]),
                    endDate = Convert.ToDateTime(sqldr[6]),
                    policyStatus = sqldr[7].ToString(),


                };

                policys.Add(p);


            }

            sqldr.Close();

            return policys;

        }
        public Policy Get(object obj)
        {
            string policyId = (string)obj;
            List<Policy> policies = GetAll();
            Policy policy = policies.Where(p =>
            { return Convert.ToString(p.policyId) == policyId;
            }).FirstOrDefault();
            return policy; 

        }
        
        public bool createPolicy(Policy entity)
        {
            throw new NotImplementedException();
        }



        public bool renewPolicy(Policy entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Policy entity)
        {
            bool b = false;
           try
            {


                SqlCommand cmd = new SqlCommand("UPDATE Policy Set vehicleId=@p2,policyNumber=@p3,coverageAmount=@p4,premiumAmount=@p5,startDate=@p6,endDate=@p7,policyStatus=@p8 where policyId=@p1", con);
                
                cmd.Parameters.Add("@p2", entity.vehicleId);
                cmd.Parameters.Add("@p3", entity.policyNumber);
                cmd.Parameters.Add("@p4", entity.coverageAmount);
                cmd.Parameters.Add("@p5", entity.premiumAmount);
                cmd.Parameters.Add("@p6", entity.startDate);
                cmd.Parameters.Add("@p7", entity.endDate);
                cmd.Parameters.Add("@p8", entity.policyStatus);
                cmd.Parameters.Add("@p1", entity.policyId);
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
    }
        
    }

