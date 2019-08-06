using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transivo.BLL.Abstract;
using Transivo.Model.Models;

namespace Transivo.UI.MVC.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        IShippingService _shippingService;

        public UserController(IUserService userService,IShippingService shippingService)
        {
            _userService = userService;
            _shippingService = shippingService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shipping()
        {
            User user = Session["user"] as User;
            if (user==null)
            {
                return RedirectToAction("Login", "UserAccount");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Shipping(int value)//shipping comment sayfasında yıldızları yap panpa numeric up down la sayı al kaydet db ye sonra firmaları listelerken buna göre ortalama alıp bas yıldızları
        {
            List<Shipping> shippings = new List<Shipping>();
            User user = Session["user"] as User;
            switch (value)
            {
                case 1:
                    shippings= _shippingService.GetByUserIDAndIsActiveAndDidItMove(user.ID,false,false);
                    break;
                case 2:
                    shippings= _shippingService.GetByUserIDAndIsActiveAndDidItMove(user.ID, true, true);
                    break;
                case 3:
                    shippings= _shippingService.GetByUserIDAndIsActiveAndDidItMove(user.ID, false, true);
                    break;
            }
            return View(shippings);
        }
    }
}