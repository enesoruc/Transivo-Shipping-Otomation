using Transivo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.BLL.Abstract
{
    public interface IDistrictService : IBaseService<District>
    {
        List<District> GetDistrictsByCity(int cityID);
    }
}
