using Transivo.Core.DAL.EntityFramework;
using Transivo.DAL.Abstract;
using Transivo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.DAL.Concrete.EntityFramework;

namespace Transivo.DAL.Concrete.EntityFramework.DAL
{
    public class EFDistrictDAL : EFRepositoryBase<District, TransivoDbContext>, IDistrictDAL
    {

    }
}
