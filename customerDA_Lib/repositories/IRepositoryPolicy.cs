using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.repositories
{
    public interface IRepositoryPolicy<T> where T : class
    {
        bool createPolicy(T entity);
        bool renewPolicy(T entity);
        

        List<T> GetAll();
       

    }
}


