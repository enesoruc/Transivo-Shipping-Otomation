using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IShippingService : IBaseService<Shipping>
    {
        List<Shipping> GetByIsActivity(int companyID,bool activitiy);
        List<Shipping> GetUndeliveredShippingsByCompID(int companyID);
        List<Shipping> GetOnTransportShippings(int companyID);
        List<Shipping> GetByUserID(int userID);
        List<Shipping> GetByUserIDAndIsActiveAndDidItMove(int userID,bool IsActive,bool didItMove);
    }
}
