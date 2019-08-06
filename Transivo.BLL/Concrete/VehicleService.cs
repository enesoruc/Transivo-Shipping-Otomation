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
    public class VehicleService : IVehicleService
    {
        IVehicleDAL _vehicleDAL;

        public VehicleService(IVehicleDAL vehicleDAL)
        {
            _vehicleDAL = vehicleDAL;
        }

        public bool Add(Vehicle model)
        {
            return _vehicleDAL.Add(model) > 0;
        }

        public bool Delete(Vehicle model)
        {
            return _vehicleDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Vehicle vehicle = _vehicleDAL.Get(a => a.ID == modelID);
            return _vehicleDAL.Delete(vehicle) > 0;
        }

        public Vehicle Get(int modelID)
        {
            return _vehicleDAL.Get(a => a.ID == modelID);
        }

        public List<Vehicle> GetActiveVehiclesByCompanyID(int companyID,bool isActive)
        {
            List<Vehicle> vehicles=_vehicleDAL.GetAll(a => a.CompanyID == companyID && a.IsActive==isActive).ToList();
            return vehicles;
        }

        public List<Vehicle> GetActiveAndIsWorkingVehiclesByCompanyID(int companyID, bool isActive, bool isWorking)//aktif araçları döner
        {
            List<Vehicle> vehicles = _vehicleDAL.GetAll(a => a.CompanyID == companyID && a.IsActive == isActive && a.IsWorking == isWorking).ToList();
            return vehicles;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDAL.GetAll().ToList();
        }

        public bool Update(Vehicle model)
        {
            return _vehicleDAL.Update(model) > 0;
        }
    }
}
