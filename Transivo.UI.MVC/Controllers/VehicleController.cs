using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transivo.BLL.Abstract;
using Transivo.Model.Models;
using Transivo.UI.MVC.Models;

namespace Transivo.UI.MVC.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        IVehicleService _vehicleService;
        IDriverService _driverService;

        public VehicleController(IVehicleService vehicleService, IDriverService driverService)
        {
            _vehicleService = vehicleService;
            _driverService = driverService;
        }

        public ActionResult ListVehicles()
        {
            Admin admin = Session["admin"] as Admin;
            List<Vehicle> vehicles = _vehicleService.GetActiveVehiclesByCompanyID(admin.CompanyID, true);
            return View(vehicles);
        }

        public ActionResult VehicleRegister()
        {
            Admin admin = Session["admin"] as Admin;
            List<Driver> drivers = _driverService.GetDriversByCompanyIDAndHasVehicle(admin.CompanyID, false);
            ViewBag.drivers = drivers;
            return View();
        }

        public JsonResult Delete(int id)
        {
            Vehicle vehicle = _vehicleService.Get(id);
            _vehicleService.Delete(vehicle);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            Admin admin = Session["admin"] as Admin;
            List<Driver> drivers = _driverService.GetDriversByCompanyID(admin.CompanyID);
            ViewBag.drivers = drivers;
            Vehicle vehicle = _vehicleService.Get(id);
            return View(vehicle);
        }

        [HttpPost]
        public ActionResult Update(Vehicle updateVehicle, int driverID)
        {
            Admin admin = Session["admin"] as Admin;
            bool result = false;
            try
            {
                result = UpdateVehicle(updateVehicle, admin.CompanyID, driverID);
            }
            catch (Exception ex)
            {
                throw;
            }
            if (result)
            {
                ViewBag.result = "Güncelleme Başarılı";
            }
            else
            {
                ViewBag.result = "Güncelleme İşlemi Başarısız";
            }
            return View();
        }

        private bool UpdateVehicle(Vehicle updateVehicle, int adminCompanyID, int driverID)
        {
            Vehicle vehicle = _vehicleService.Get(updateVehicle.ID);
            vehicle.Driver = _driverService.Get(driverID);
            vehicle.Brand = updateVehicle.Brand;
            vehicle.CarClass = updateVehicle.CarClass;
            vehicle.ChasisNo = updateVehicle.ChasisNo;
            vehicle.Color = updateVehicle.Color;
            vehicle.CommercialName = updateVehicle.CommercialName;
            vehicle.CompanyID = adminCompanyID;
            vehicle.CreatedDate = updateVehicle.CreatedDate;
            vehicle.CylinderVolume = updateVehicle.CylinderVolume;
            vehicle.DocumentSerialNo = updateVehicle.DocumentSerialNo;
            vehicle.FuelType = updateVehicle.FuelType;
            vehicle.Genus = updateVehicle.Genus;
            vehicle.MaxLoadWeight = updateVehicle.MaxLoadWeight;
            vehicle.ModelYear = updateVehicle.ModelYear;
            vehicle.MotorNo = updateVehicle.MotorNo;
            vehicle.MotorPower = updateVehicle.MotorPower;
            vehicle.NotaryName = updateVehicle.NotaryName;
            vehicle.NotarySalesNo = updateVehicle.NotarySalesNo;
            vehicle.NoterySalesDate = updateVehicle.NoterySalesDate;
            vehicle.Plate = updateVehicle.Plate;
            vehicle.PowerToWeightRatio = updateVehicle.PowerToWeightRatio;
            vehicle.PurposeOf = updateVehicle.PurposeOf;
            vehicle.RegistrationDate = updateVehicle.RegistrationDate;
            vehicle.RegistrationFirstDate = updateVehicle.RegistrationFirstDate;
            vehicle.RegistrationNo = updateVehicle.RegistrationNo;
            vehicle.SeatsOfNumber = updateVehicle.SeatsOfNumber;
            vehicle.Type = updateVehicle.Type;
            vehicle.WeightNet = updateVehicle.WeightNet;
            vehicle.WeightWeigher = updateVehicle.WeightWeigher;
            bool result = _vehicleService.Update(vehicle);

            return result;
        }

        public ActionResult VehicleDetail(int id)
        {
            Vehicle vehicle = _vehicleService.Get(id);
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VehicleRegister(VehicleRegisterViewModel newVehicleModel, int driverID)//ship category i çek ona göre amaç seçtir id den kaydet
        {
            bool result = false;
            bool result2 = false;
            try
            {
                Vehicle newVehicle = RegisterVehicle(newVehicleModel, driverID);
                Driver driver = _driverService.Get(driverID);
                driver.HasVehicle = true;
                result2 = _driverService.Update(driver);
                result = _vehicleService.Add(newVehicle);
            }
            catch (Exception)
            {
                ViewBag.result = "Bir Hata Oluştu";
            }

            if (result && result2)
            {
                ViewBag.result = "Araç Kaydı Başarılı Bir Şekilde Oluşturuldu";
            }
            else
            {
                ViewBag.result = "Kayıt Oluşturulurken Bir Hata Oluştu";
            }

            return View();
        }

        public Vehicle RegisterVehicle(VehicleRegisterViewModel newVehicle, int id)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Plate = newVehicle.Plate;
            vehicle.RegistrationFirstDate = newVehicle.RegistrationFirstDate;
            vehicle.RegistrationDate = newVehicle.RegistrationDate;
            vehicle.RegistrationNo = newVehicle.RegistrationNo;
            vehicle.Brand = newVehicle.Brand;
            vehicle.Type = newVehicle.Type;
            vehicle.CommercialName = newVehicle.CommercialName;
            vehicle.ModelYear = newVehicle.ModelYear;
            vehicle.CarClass = newVehicle.CarClass;
            vehicle.Genus = newVehicle.Genus;
            vehicle.Color = newVehicle.Color;
            vehicle.MotorNo = newVehicle.MotorNo;
            vehicle.ChasisNo = newVehicle.ChasisNo;
            vehicle.WeightNet = newVehicle.WeightNet;
            vehicle.WeightWeigher = newVehicle.WeightWeigher;
            vehicle.SeatsOfNumber = newVehicle.SeatsOfNumber;
            vehicle.CylinderVolume = newVehicle.CylinderVolume;
            vehicle.FuelType = newVehicle.FuelType;
            vehicle.PurposeOf = newVehicle.PurposeOf;
            vehicle.MaxLoadWeight = newVehicle.MaxLoadWeight;
            vehicle.MotorPower = newVehicle.MotorPower;
            vehicle.PowerToWeightRatio = newVehicle.PowerToWeightRatio;
            vehicle.NoterySalesDate = newVehicle.NoterySalesDate;
            vehicle.NotarySalesNo = newVehicle.NotarySalesNo;
            vehicle.NotaryName = newVehicle.NotaryName;
            vehicle.DocumentSerialNo = newVehicle.DocumentSerialNo;
            Admin admin = Session["admin"] as Admin;
            vehicle.CompanyID = admin.CompanyID;
            vehicle.Driver = _driverService.Get(id);
            return vehicle;
        }
    }
}