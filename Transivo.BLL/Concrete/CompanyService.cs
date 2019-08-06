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
    public class CompanyService : ICompanyService
    {
        ICompanyDAL _companyDAL;

        public CompanyService(ICompanyDAL companyDAL)
        {
            _companyDAL = companyDAL;
        }
        public bool Add(Company model)
        {
            return _companyDAL.Add(model) > 0;
        }

        public bool Delete(Company model)
        {
            return _companyDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Company company = _companyDAL.Get(a => a.ID == modelID);
            return _companyDAL.Delete(company) > 0;
        }

        public Company Get(int modelID)
        {
            return _companyDAL.Get(a => a.ID == modelID);
        }


        public List<Company> GetAll()
        {
            return _companyDAL.GetAll().ToList();
        }

        public Company GetCompanyByName(string name)
        {
            return _companyDAL.Get(a => a.CompanyName == name);
        }

        public bool Update(Company model)
        {
            return _companyDAL.Update(model) > 0;
        }
    }
}
