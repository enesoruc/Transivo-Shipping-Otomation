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
    public class AdminService : IAdminService
    {
        IAdminDAL _adminDAL;
        public AdminService(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }
        public bool Add(Admin model)
        {
            return _adminDAL.Add(model) > 0;
        }

        public bool Delete(Admin model)
        {
            return _adminDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Admin admin = _adminDAL.Get(a => a.ID == modelID);
            return _adminDAL.Delete(admin) > 0;
        }

        public Admin Get(int modelID)
        {
            return _adminDAL.Get(a => a.ID == modelID);
        }

        public Admin GetAdminByUserNameAndPassword(string username, string password)
        {
            return _adminDAL.Get(a => a.Username == username && a.Password == password);
        }

        public List<Admin> GetAll()
        {
            return _adminDAL.GetAll().ToList();
        }

        public List<Admin> GetByID()
        {
            return _adminDAL.GetAll(a => a.AdminRole.ID == 2).ToList();
        }

        public bool Update(Admin model)
        {
            return _adminDAL.Update(model) > 0;
        }
    }
}
