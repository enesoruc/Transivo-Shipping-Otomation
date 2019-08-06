using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.BLL.Abstract;
using Transivo.DAL.Abstract;
using Transivo.Model.Models;

namespace Transivo.BLL.Concrete
{
    public class AdminRoleService : IAdminRoleService
    {
        IAdminRoleDAL _adminRoleDAL;

        public AdminRoleService(IAdminRoleDAL adminRoleDAL)
        {
            _adminRoleDAL = adminRoleDAL;
        }
        public bool Add(AdminRole model)
        {
            return _adminRoleDAL.Add(model) > 0;
        }

        public bool Delete(AdminRole model)
        {
            return _adminRoleDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            AdminRole adminRole = _adminRoleDAL.Get(a => a.ID == modelID);
            return _adminRoleDAL.Delete(adminRole) > 0;
        }

        public AdminRole Get(int modelID)
        {
            return _adminRoleDAL.Get(a => a.ID == modelID);
        }

        public AdminRole GetAdminRoleByName(string name)
        {
            return _adminRoleDAL.Get(a => a.Name == name);
        }

        public List<AdminRole> GetAll()
        {
           return  _adminRoleDAL.GetAll().ToList();
        }

        public bool Update(AdminRole model)
        {
            return _adminRoleDAL.Update(model) > 0;
        }
    }
}
