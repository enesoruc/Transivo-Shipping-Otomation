using Transivo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.BLL.Abstract
{
    public interface ICityService : IBaseService<City>
    {
        List<City> GetCitiesByCountry(int? countryID);
    }
}
