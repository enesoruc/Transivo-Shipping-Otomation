using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transivo.BLL.Abstract;
using Transivo.Model.Models;
using Transivo.UI.MVC.Helpers;
using Transivo.UI.MVC.Models;

namespace Transivo.UI.MVC.Controllers
{
    public class AdminAccountController : Controller
    {
        
        IAdminService _adminService;
        ICountryService _countryService;
        ICityService _cityService;
        IDistrictService _districtService;
        IAdminRoleService _adminRoleService;
        ICompanyService _companyService;
        IAddressService _addressService;

        public AdminAccountController(IAdminService adminService, ICountryService countryService, ICityService cityService, IDistrictService districtService, IAdminRoleService adminRoleService, ICompanyService companyService, IAddressService addressService)
        {
            _adminService = adminService;
            _countryService = countryService;
            _districtService = districtService;
            _cityService = cityService;
            _adminRoleService = adminRoleService;
            _companyService = companyService;
            _addressService = addressService;
        }
        
        public ActionResult AdminProfileUpdate()
        {
            Admin admin = Session["admin"] as Admin;
            return View(admin);
        }

        [HttpPost]
        public ActionResult AdminProfileUpdate(Admin admin)
        {
            Admin sessionAdmin = Session["admin"] as Admin;
            try
            {
                Admin original = _adminService.Get(sessionAdmin.ID);
                original.Username = admin.Username;
                original.EMail = admin.EMail;
                original.Password = admin.Password;
                bool result = _adminService.Update(original);

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

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Admin admin = _adminService.GetAdminByUserNameAndPassword(loginModel.UserName, loginModel.Password);
                if (admin != null)
                {
                    Session["admin"] = admin;
                    return RedirectToAction("AdminHome", "Admin");
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

        public ActionResult AdminRegister()
        {
            ViewBag.Countries = _countryService.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegister(RegisterAdminAndCompanyViewModel model,HttpPostedFileBase fileUpload)
        {
            string imgName = string.Empty;
            ViewBag.Countries = _countryService.GetAll();
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Password != model.RePassword)
                    {
                        ViewBag.Message = "Şifreler uyuşmuyor";
                        return View("AdminRegister");
                    }
                    else
                    {
                        Company company = new Company();
                        company.About = model.About;
                        company.CompanyName = model.CompanyName;
                        company.Freight = model.Freight;
                        company.LogoPath = model.LogoPath;
                        company.TaxNumber = model.TaxNumber;
                        company.Phone = model.Phone;
                       

                        if (fileUpload != null)
                        {
                            Image image = Image.FromStream(fileUpload.InputStream);
                            int width = 300;
                            int height = 300;
                            imgName = "/assets/img/CompanyImages/" + company.CompanyName.Substring(0, 3) + Path.GetExtension(fileUpload.FileName);//GetExtension verilen dosyanın uzantısını geri döner
                            Bitmap bitmap = new Bitmap(image, width, height);
                            bitmap.Save(Server.MapPath(imgName));
                        }
                        company.LogoPath =imgName;
                        company.Freight = model.Freight;
                        bool resultCompany = _companyService.Add(company);

                        if (!resultCompany)
                        {
                            ViewBag.Message = "Şirket eklemede hata meydana geldi!";
                        }

                        Admin admin = new Admin();
                        admin.AdminRole = _adminRoleService.GetAdminRoleByName("Company Admin");
                        admin.EMail = model.EMail;
                        admin.Password = model.Password;
                        admin.Username = model.Username;
                        admin.Company = company;
                        bool resultAdmin = _adminService.Add(admin);
                        if (!resultAdmin)
                        {
                            ViewBag.Message = "Şirket eklemede hata meydana geldi!";
                        }

                        return View("AdminLogin");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View("AdminRegister");
                }
            }
            else
            {
                return View();
            }
        }
    }
}

