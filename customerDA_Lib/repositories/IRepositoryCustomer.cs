using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.repositories
{
    public interface IRepositoryCustomer<T> where T : class
    {
        bool registerCustomer (T entity);
        bool updateCustomerProfile(T entity);

        List<T> GetAllCustomerDetails();




    }
}
