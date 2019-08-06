using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IAdminRoleService : IBaseService<AdminRole>
    {
        AdminRole GetAdminRoleByName(string name);
    }
}
