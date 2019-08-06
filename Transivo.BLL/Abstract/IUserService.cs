using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.BLL.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByUserNameAndPassword(string userName, string password);
        User GetUserByCode(Guid code);
        bool ActivateUser(User user);
        User GetUserByEmail(string email);
        
    }
}
