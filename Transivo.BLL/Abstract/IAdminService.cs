using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IAdminService : IBaseService<Admin>
    {
        Admin GetAdminByUserNameAndPassword(string username, string password);
       List<Admin> GetByID();
    }
}
