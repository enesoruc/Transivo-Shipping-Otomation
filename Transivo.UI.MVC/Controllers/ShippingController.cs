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
    public class ShippingController : Controller
    {
        // GET: Shipping
        ICountryService _countryService;
        ICompanyService _companyService;
        IShippingService _shippingService;
        IShipCategoryService _shipCategoryService;
        IPayTypeService _payTypeService;
        IAddressService _addressService;
        IVehicleService _vehicleService;

        public ShippingController(ICompanyService companyService, IShippingService shippingService, IShipCategoryService shipCategoryService, ICountryService countryService, IPayTypeService payTypeService, IAddressService addressService, IVehicleService vehicleService)
        {
            _companyService = companyService;
            _shippingService = shippingService;
            _shipCategoryService = shipCategoryService;
            _countryService = countryService;
            _payTypeService = payTypeService;
            _addressService = addressService;
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public ActionResult Shipping(int StartDistrictID, int ArriveDistrictID, string transportDate, decimal km = 1)
        {
            TempData["TransportDate"] = transportDate;
            TempData["StartAddress"] = StartDistrictID;
            TempData["ArrivalAddress"] = ArriveDistrictID;
            TempData["km"] = km;
            List<Company> companiesChanged = new List<Company>();
            List<Company> allCompanies = _companyService.GetAll();
            foreach (Company item in allCompanies)
            {
                item.Freight = item.Freight /** km*/;
                companiesChanged.Add(item);
            }
            ViewBag.CompaniesFreights = companiesChanged;
            return View();
        }

        public ActionResult ShippingPay(int id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ShippingViewModel shippingVM = GetShippingVM();
            return View(shippingVM);
        }

        [HttpPost]
        public ActionResult ShippingPay(int categoryID, int payTypeID, int id)
        {
            Company company = _companyService.Get(id);
            User user = Session["user"] as User;
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int startAddressID = CreateAddress(user, (int)TempData["StartAddress"], "STR", "StartAddress");
            int arrivalAddressID = CreateAddress(user, (int)TempData["ArrivalAddress"], "ARV", "ArrivalAddress");

            bool result = CreateShipping(user, company, categoryID, startAddressID, arrivalAddressID, id, payTypeID, DateTime.Now);
            if (result)
            {
                ViewBag.Message = "Sipariş Başarılı Bir Şekilde Oluşturuldu";
            }
            else
            {
                ViewBag.Message = "Sipariş Oluşturulamadı";
            }
            ShippingViewModel shippingVM = GetShippingVM();
            return View(shippingVM);
        }

        public ActionResult ListShippings()
        {
            Admin admin = Session["admin"] as Admin;
            return View(_shippingService.GetOnTransportShippings(admin.CompanyID));
        }

        public ActionResult ListWaitOK()
        {
            Admin admin = Session["admin"] as Admin;
            return View(_shippingService.GetByIsActivity(admin.CompanyID, false));
        }
        
        public ActionResult ShippingDetail(int id)
        {
            Admin admin = Session["admin"] as Admin;
            ViewBag.vehicles = _vehicleService.GetActiveAndIsWorkingVehiclesByCompanyID(admin.CompanyID, true, false);
            return View(_shippingService.Get(id));
        }

        #region ilkUpdate
        //public JsonResult Update(int id, int? vehicleID)
        //{
        //    Shipping ship= _shippingService.Get(id);
        //    ship.IsActive = true;
        //    _shippingService.Update(ship);

        //    return Json("ok", JsonRequestBehavior.AllowGet);
        //} 
        #endregion

        public JsonResult Update(ShipUpdateVM updateVM)
        {
            Vehicle vehicle = _vehicleService.Get(updateVM.vehicleID);
            vehicle.IsWorking = true;
            _vehicleService.Update(vehicle);

            Shipping ship = _shippingService.Get(updateVM.shipID);
            ship.IsActive = true;
            ship.Vehicle = vehicle;
            _shippingService.Update(ship);

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        private int CreateAddress(User user, int addressID, string nameCode, string addressDetailCode)
        {
            Address address = new Address();
            address.DistrictID = addressID;
            address.Name = nameCode + user.UserName.Substring(0, 3).ToString();
            address.AddresssDetail = addressDetailCode + user.UserName;
            bool result = _addressService.Add(address);
            return address.ID;
        }

        private bool CreateShipping(User user, Company company, int categoryID, int startAddressID, int arrivalAddressID, int companyID, int payTypeID, DateTime dateTime)
        {
            Shipping shipping = new Shipping();
            shipping.UserID = user.ID;
            shipping.ShipCategoryID = categoryID;
            shipping.StartAddressID = startAddressID;
            shipping.ArrivalAddressID = arrivalAddressID;
            shipping.CompanyID = companyID;
            shipping.PayTypeID = payTypeID;
            shipping.Km = (decimal)TempData["km"];
            shipping.Price = (company.Freight * shipping.Km).ToString();
            shipping.IsActive = false;
            shipping.ShippedDate = dateTime;
            shipping.RequiredDate = ConvertToDateTime();
            bool result = _shippingService.Add(shipping);
            return result;
        }

        private DateTime ConvertToDateTime()
        {
            string date = (TempData["transportDate"]).ToString();
            string Year = string.Empty;
            string Month = string.Empty;
            string Day = string.Empty;
            Month = date.Substring(0, 2);
            Day = date.Substring(3, 2);
            Year = date.Substring(6, 4);
            string newDate = Day + "." + Month + "." + Year;
            DateTime convertedDate = DateTime.Parse(newDate);
            return convertedDate;
        }

        private ShippingViewModel GetShippingVM()
        {
            ShippingViewModel shippingVM = new ShippingViewModel();
            shippingVM.shipCategories = _shipCategoryService.GetAll();
            shippingVM.PayTypes = _payTypeService.GetAll();
            shippingVM.Countries = _countryService.GetAll();
            return shippingVM;
        }
    }
}