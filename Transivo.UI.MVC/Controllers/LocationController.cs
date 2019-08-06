using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transivo.BLL.Abstract;
using Transivo.Model.Models;

namespace Transivo.UI.MVC.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        ICountryService _countryService;
        ICityService _cityService;
        IDistrictService _districtService;

        public LocationController(ICountryService countryService,ICityService cityService,IDistrictService districtService)
        {
            _countryService = countryService;
            _cityService = cityService;
            _districtService = districtService;
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
    }
}