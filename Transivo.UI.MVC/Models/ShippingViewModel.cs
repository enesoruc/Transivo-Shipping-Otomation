using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transivo.Model.Models;

namespace Transivo.UI.MVC.Models
{
    public class ShippingViewModel
    {
        public List<PayType> PayTypes { get; set; }
        public List<ShipCategory> shipCategories { get; set; }
        public List<Country> Countries { get; set; }
    }
}