using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transivo.BLL.Abstract;
using Transivo.Model.Models;
using Transivo.UI.MVC.Helpers;
using Transivo.UI.MVC.Models;

namespace Transivo.UI.MVC.Controllers
{
    public class UserAccountController : Controller
    {
        IUserService _userService;
        IUserRoleService _userRoleService;
        ICountryService _countryService;
        ICityService _cityService;
        IDistrictService _districtService;
        ICompanyService _companyService;
        IAddressService _addressService;

        public UserAccountController(IUserService userService, IUserRoleService userRoleService, ICountryService countryService, ICityService cityService, IDistrictService districtService, ICompanyService companyService, IAddressService addressService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _countryService = countryService;
            _districtService = districtService;
            _cityService = cityService;
            _companyService = companyService;
            _addressService = addressService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUserByUserNameAndPassword(loginModel.UserName, loginModel.Password);
                if (user != null && !user.IsActive)
                {
                    ViewBag.hata = "Üyeliğinizi aktifleştirmediniz!";
                    return View();
                }
                else if (user != null && user.IsActive)
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.hata = "Böyle Bir Kullanıcı Bulunamadı";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Countries = _countryService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterUserViewModel model)
        {
            ViewBag.Countries = _countryService.GetAll();
            try
            {
                if (model.Password != model.RePassword)
                {
                    ViewBag.Message = "Şifreler uyuşmuyor";
                    return View("Register");
                }
                else
                {
                    Address address = new Address();
                    address.Name = model.AddressName;
                    address.AddresssDetail = model.AddressDetail;
                    address.District = _districtService.Get(model.DistrictID); //böyle yaptık ki districtten instance alsın ve onun üzerinden getirsin districti
                    address.District.City = _cityService.Get(model.CityID);
                    address.District.City.Country = _countryService.Get(model.CountryID);
                    bool isAddressAdd = _addressService.Add(address);
                    if (!isAddressAdd)
                    {
                        ViewBag.Message = "Adres eklerken hata meydana geldi!";
                    }

                    User user = new User();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserRole = _userRoleService.GetUserRoleByName("Standart");
                    user.BirthDate = model.BirthDate.Date;
                    user.EMail = model.EMail;
                    user.Password = model.Password;
                    user.UserName = model.UserName;
                    user.Phone = model.Phone;
                    user.AddressID = address.ID;
                    user.IsActive = false;
                    user.ActivationCode = Guid.NewGuid();
                    bool result = _userService.Add(user);
                    if (result)
                    {
                        result = MailHelper.SendMail(model.EMail, user.ActivationCode);
                        ViewBag.Message = result ? "Aktivasyon maili gönderilmiştir. Mailinizi kontrol ediniz." : "Aktivasyon maili gönderilemedi!!";
                    }
                    else
                    {
                        ViewBag.Message = "Kullanıcı eklerken hata meydana geldi!";
                    }
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Register");
            }
        }

        public ActionResult Activate(Guid code)
        {
            User user = _userService.GetUserByCode(code);
            if (user != null)
            {
                _userService.ActivateUser(user);
                ViewBag.Result = "Üyeliğiniz aktifleştirilmiştir";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "Böyle bir kullanıcı bulunamadı!";
                return RedirectToAction("Register");
            }
        }
    }
}

