using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IDriverService : IBaseService<Driver>
    {
        List<Driver> GetDriversByCompanyID(int companyID);
        List<Driver> GetDriversByCompanyIDAndHasVehicle(int companyID,bool hasVehicle);
    }
}
