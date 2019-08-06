using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IUserRoleService : IBaseService<UserRole>
    {
        UserRole GetUserRoleByName(string name);
    }
}
