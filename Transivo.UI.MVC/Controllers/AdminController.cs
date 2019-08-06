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
    public class AdminController : Controller
    {
        // GET: Admin
        IDriverService _driverService;
        IMessageService _messageService;
        IShippingService _shippingService;

        public AdminController(IDriverService driverService,IMessageService messageService,IShippingService shippingService)
        {
            _driverService = driverService;
            _messageService = messageService;
            _shippingService = shippingService;
        }
        
        AdminCompanyDetail adminCompanyDetail;
        public ActionResult AdminHome()
        {
            adminCompanyDetail = new AdminCompanyDetail();
            Admin admin = Session["admin"] as Admin;
            Session["messages"] = _messageService.GetByID(admin.CompanyID);
            GetMessages(admin.Company.ID);

            List<Driver> drivers = _driverService.GetDriversByCompanyID(admin.CompanyID);
            adminCompanyDetail.AktifSoforler= drivers;
            GetShippings(admin.CompanyID,false);
            adminCompanyDetail.ToplamKazanc = admin.Company.TotalEarnings;
            adminCompanyDetail.TeslimatiBeklenenNakliyeler = _shippingService.GetUndeliveredShippingsByCompID(admin.CompanyID);
            return View(adminCompanyDetail);
        }

        private void GetShippings(int companyID,bool activity)
        {
            List<Shipping> shippings = _shippingService.GetByIsActivity(companyID, activity);
            adminCompanyDetail.OnayBekleyenNakliyeAdedi = shippings.Count();
            int counter = 0;
            for (int i = 0; i < shippings.Count; i++)
            {
                if (counter < 4)
                {
                    adminCompanyDetail.OnayBekleyen4Nakliye.Add(shippings[i]);
                    counter++;
                }
                else
                {
                    adminCompanyDetail.OnayBekleyenNakliyeler.Add(shippings[i]);
                }
            }
        }

        private void GetMessages(int ID)
        {
            List<Message> messages = _messageService.GetByID(ID);
            int counter = 0;
            for (int i = 0; i < messages.Count; i++)
            {
                if (counter < 4)
                {
                    adminCompanyDetail.Mesajlar4.Add(messages[i]);
                    counter++;
                }
                else
                {
                    adminCompanyDetail.Mesajlar.Add(messages[i]);
                }
            }
            ViewBag.messages = adminCompanyDetail.Mesajlar4;
        }
    }
}