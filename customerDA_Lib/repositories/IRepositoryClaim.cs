using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.repositories
{
    public interface IRepositoryClaim<T> where T : class
    {
        bool fileClaim(T entity);
        bool processClaim(T entity);


        List<T> getClaimStatus();
    }
}
