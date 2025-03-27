using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDA_Lib.models;

namespace customerDA_Lib.repositories
{
    public class claimClass : IRepositoryClaim<Claim>
    {
        SqlConnection con;
        public claimClass()
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


        public bool Add(Claim entity)
        {
            bool b = false;
            try
            {


                SqlCommand cmd = new SqlCommand("insert into Claim values(@p1, @p2, @p3, @p4, @p5)", con);
              //  cmd.Parameters.Add("@p1", entity.claimId);
                cmd.Parameters.Add("@p1", entity.policyID);
                cmd.Parameters.Add("@p2", entity.claimAmount);
                cmd.Parameters.Add("@p3", entity.claimReason);
                cmd.Parameters.Add("@p4", entity.claimDate);
                cmd.Parameters.Add("@p5", entity.claimStatus);


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


        public bool fileClaim(Claim entity)
        {
            throw new NotImplementedException();
        }

        public List<Claim> getClaimStatus()
        {
            throw new NotImplementedException();
        }

        public bool processClaim(Claim entity)
        {
            throw new NotImplementedException();
        }
    }
}
