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
    public class DriverService : IDriverService
    {
        IDriverDAL _driverDAL;

        public DriverService(IDriverDAL driverDAL)
        {
            _driverDAL = driverDAL;
        }

        public bool Add(Driver model)
        {
            return _driverDAL.Add(model) > 0;
        }

        public bool Delete(Driver model)
        {
            return _driverDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Driver driver = _driverDAL.Get(a => a.ID == modelID);
            return _driverDAL.Delete(driver) > 0;
        }

        public Driver Get(int modelID)
        {
            return _driverDAL.Get(a => a.ID == modelID);
        }

        public List<Driver> GetAll()
        {
            return _driverDAL.GetAll().ToList();
        }

        public List<Driver> GetDriversByCompanyID(int companyID)
        {
            return _driverDAL.GetAll(a => a.CompanyID == companyID).ToList();
        }

        public List<Driver> GetDriversByCompanyIDAndHasVehicle(int companyID, bool hasVehicle)
        {
            return _driverDAL.GetAll(a => a.CompanyID == companyID && a.HasVehicle == hasVehicle).ToList();
        }

        public bool Update(Driver model)
        {
            return _driverDAL.Update(model) > 0;
        }
    }
}
