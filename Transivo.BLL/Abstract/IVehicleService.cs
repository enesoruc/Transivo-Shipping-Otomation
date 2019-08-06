using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IVehicleService : IBaseService<Vehicle>
    {
        List<Vehicle> GetActiveVehiclesByCompanyID(int companyID,bool isActive);
        List<Vehicle> GetActiveAndIsWorkingVehiclesByCompanyID(int companyID,bool isActive,bool isWorking);
    }
}
