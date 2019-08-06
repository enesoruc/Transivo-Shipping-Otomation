using Transivo.Core.DAL.EntityFramework;
using Transivo.DAL.Abstract;
using Transivo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.DAL.Concrete.EntityFramework;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.DAL
{
    public class EFAddressDAL : EFRepositoryBase<Address, TransivoDbContext>, IAddressDAL
    {

    }
}
