using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class CompanyViewModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string TaxNumber { get; set; }
        public decimal Freight { get; set; }
        public string LogoPath { get; set; }
        public string About { get; set; }
    }
}