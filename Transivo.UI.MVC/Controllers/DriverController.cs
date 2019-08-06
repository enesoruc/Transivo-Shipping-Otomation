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
    public class DriverController : Controller
    {
        IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        // GET: Driver
        public ActionResult DriverDetail(int id)
        {
            Driver driver = _driverService.Get(id);
            return View(driver);
        }

        public ActionResult ListDrivers()
        {
            Admin admin = Session["admin"] as Admin;
            List<Driver> drivers = _driverService.GetDriversByCompanyID(admin.CompanyID);
            return View(drivers);
        }

        public ActionResult EditDriver(int id)
        {
            Driver driver = _driverService.Get(id);
            return View(driver);
        }

        public JsonResult Delete(int id)
        {
            Driver driver = _driverService.Get(id);
            _driverService.Delete(driver);
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            Driver driver = _driverService.Get(id);
            return View(driver);
        }

        [HttpPost]
        public ActionResult Update(Driver driver)
        {
            Admin admin = Session["admin"] as Admin;
            bool result = false;
            try
            {
                Driver original = _driverService.Get(driver.ID);
                original.FirstName = driver.FirstName;
                original.Lastname = driver.Lastname;
                original.BirthDate = driver.BirthDate;
                original.TC = driver.TC;
                original.Phone = driver.Phone;
                original.BirthPlace = driver.BirthPlace;
                original.CompanyID = admin.CompanyID;
                result = _driverService.Update(original);

                if (result)
                {
                    ViewBag.result = "İşlem Başarılı";
                }
                else
                {
                    ViewBag.result = "Güncelleme İşlemi Başarısız";
                }
            }
            catch (Exception)
            {
                ViewBag.result = "Bir Hata Oluştu";
            }
            return View();
        }

        public ActionResult DriverRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DriverRegister(DriverRegisterViewModel newDriver,int? id)
        {
            Driver driver;
            bool result = false;
            try
            {
                driver = new Driver();
                driver.FirstName = newDriver.FirstName;
                driver.Lastname = newDriver.LastName;
                driver.TC = newDriver.TC;
                driver.BirthDate = newDriver.BirthDate;
                driver.BirthPlace = newDriver.BirthPlace;
                driver.Phone = newDriver.Phone;
                driver.EMail = newDriver.EMail;
                Admin admin = Session["admin"] as Admin;
                driver.CompanyID = admin.CompanyID;
                result = _driverService.Add(driver);
            }
            catch (Exception)
            {
                ViewBag.result = "Bir Hata Oluştu";
            }

            if (result)
            {
                ViewBag.result = "Kayıt Başarılı Bir Şekilde Oluşturuldu";
            }
            else
            {
                ViewBag.result = "Kayıt Oluşturulurken Bir Hata Oluştu";
            }
            return View();
        }


    }
}