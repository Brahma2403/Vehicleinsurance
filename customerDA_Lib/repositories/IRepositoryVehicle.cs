using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDA_Lib.repositories
{
    public interface IRepositoryVehicle<T> where T : class
    {

        bool addVehicle(T entity);
        bool updateVehicleDetails(T entity);
        

        List<T> getVehicleDetails();
    }
}
