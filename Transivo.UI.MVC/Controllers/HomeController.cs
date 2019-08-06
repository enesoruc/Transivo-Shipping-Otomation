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
    public class HomeController : Controller
    {

        ICompanyService _companyService;
        IUserRoleService _userRoleService;
        IUserService _userService;
        IMessageService _messageService;
        ICountryService _countryService;
        ICityService _cityService;
        IDistrictService _districtService;
        IAddressService _addressService;
        IVehicleService _vehicleService;

        public HomeController(ICompanyService companyService, IUserRoleService userRoleService, IUserService userService, IMessageService messageService, ICountryService countryService, ICityService cityService, IDistrictService districtService, IAddressService addressService,IVehicleService vehicleService)
        {
            _companyService = companyService;
            _userRoleService = userRoleService;
            _userService = userService;
            _messageService = messageService;
            _countryService = countryService;
            _cityService = cityService;
            _districtService = districtService;
            _addressService = addressService;
            _vehicleService = vehicleService;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.CountriesArrive = _countryService.GetAll();
            ViewBag.Users = _userService.GetAll().Count();
            ViewBag.Companies = _companyService.GetAll().Count();
            ViewBag.Vehicles = _vehicleService.GetAll().Count();
            return View();
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel indexViewModel)
        {
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.CountriesArrive = _countryService.GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult GetCitiesByCountry(int id)
        {
            Country currentCountry = _countryService.Get(id);
            var cities = _cityService.GetCitiesByCountry(currentCountry.ID);
            return Json(new SelectList(cities.ToArray(), "ID", "Name"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDistrictByCity(int id)
        {
            City currentCity = _cityService.Get(id);
            var districts = _districtService.GetDistrictsByCity(currentCity.ID);
            return Json(new SelectList(districts.ToArray(), "ID", "Name"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Contact(GuestUserVM guestUser)
        {
            if (ModelState.IsValid)
            {
                User user;
                bool result = false;
                try
                {
                    user = SendMessageToCompany(guestUser);

                    result = _userService.Add(user);
                    guestUser.GuestUserID = user.ID;

                    Company currentCompany = _companyService.GetCompanyByName("Transivo");

                    Message currentMessage = new Message();
                    currentMessage.Detail = guestUser.Message;
                    currentMessage.User = _userService.Get(guestUser.GuestUserID);
                    currentMessage.Company = currentCompany;
                    bool resultMessage = _messageService.Add(currentMessage);

                    if (result && resultMessage)
                    {
                        ViewBag.result = "Mesajınız Başarılı Bir Şekilde İletildi Size En Kısa Zamanda Dönüş Yapacağız";
                        ViewBag.isSend = "Gönderildi";
                    }
                    else
                    {
                        ViewBag.result = "Bir Hata Oluştu. İlgili Alanların Doğruluğunu Kontrol Ediniz.";
                    }
                }
                catch (Exception)
                {
                    ViewBag.result = "Bir Hata Oluştu";
                }
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Companies()
        {
            TempData["Companies"] = _companyService.GetAll();
            return View();
        }

        public ActionResult SSS()
        {
            return View();
        }

        public ActionResult CompanyDetail(int id)
        {
            int idm = id;
            //try
            //{
            //    bool result = int.TryParse(this.RouteData.Values["id"].ToString(), out idm);
            //}
            //catch (Exception ex)
            //{
            //    return RedirectToAction("Companies");
            //}

            if (idm == 0)
            {
                return RedirectToAction("Companies");
            }
            else
            {
                Company comp = _companyService.Get(idm);
                if (comp != null)
                {
                    CompanyViewModel cvm = new CompanyViewModel();
                    cvm.About = comp.About;
                    cvm.CompanyName = comp.CompanyName;
                    cvm.Freight = comp.Freight;
                    cvm.LogoPath = comp.LogoPath;
                    cvm.Phone = comp.Phone;
                    cvm.ID = comp.ID;
                    cvm.TaxNumber = comp.TaxNumber;

                    List<Company> companies = _companyService.GetAll();
                    List<Company> Get4Companies = new List<Company>();
                    int counter = 0;
                    for (int i = 0; i < companies.Count; i++)
                    {
                        if (comp.ID != companies[i].ID)
                        {
                            if (counter < 3)
                            {
                                Get4Companies.Add(companies[i]);
                                counter++;
                            }
                        }
                    }
                    ViewBag.Companies = Get4Companies;
                    return View(cvm);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult CompanyDetail(string name, string surname, string email, string message)
        {
            bool resultEnd = false;
            User currentUser = new User();
            bool result;
            try
            {
                int idm = 0;
                result = int.TryParse(RouteData.Values["id"].ToString(), out idm);
                if (result && idm != 0)
                {
                    currentUser.FirstName = name;
                    currentUser.LastName = surname;
                    currentUser.EMail = email;
                    currentUser.UserRoleID = 2;
                    currentUser.IsActive = false;
                    bool result1 = false;
                    //try
                    //{
                        result1 = _userService.Add(currentUser);
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw;
                    //}
                    //finally
                    //{
                        User user = new User();
                        user = _userService.GetUserByEmail(currentUser.EMail);
                        Message msg = new Message();
                        msg.IsActive = true;
                        msg.Detail = message;
                        msg.CreatedDate = DateTime.Now;
                        msg.CompanyID = idm;
                        msg.UserID = user.ID;
                        resultEnd = _messageService.Add(msg);
                    //}

                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Companies");
            }

            if (resultEnd)
            {
                ViewBag.Message = "Mesajınız başarı ile gönderildi.";
            }
            return RedirectToAction("CompanyDetail");
        }

        #region Pasif Shipping
        //[HttpPost]
        //public ActionResult Shipping()
        //{
        //    List<Company> companiesChanged = new List<Company>();
        //    List<Company> allCompanies = _companyService.GetAll();
        //    //foreach (Company item in allCompanies)
        //    //{
        //    //    item.Freight = item.Freight * km;
        //    //    companiesChanged.Add(item);
        //    //}
        //    ViewBag.CompaniesFreights = companiesChanged;
        //    return View();
        //}
        #endregion

        //[HttpPost]
        //public ActionResult Shipping(decimal km = 1)
        //{
        //    List<Company> companiesChanged = new List<Company>();
        //    List<Company> allCompanies = _companyService.GetAll();
        //    foreach (Company item in allCompanies)
        //    {
        //        item.Freight = item.Freight * km;
        //        companiesChanged.Add(item);
        //    }
        //    ViewBag.CompaniesFreights = companiesChanged;
        //    return View();
        //}

        public User SendMessageToCompany(GuestUserVM guestUser)
        {
            User user = new User();
            user.FirstName = guestUser.FirstName;
            user.LastName = guestUser.LastName;
            user.EMail = guestUser.Email;
            user.UserRole = _userRoleService.GetUserRoleByName("Guest");
            return user;
        }
    }
}
