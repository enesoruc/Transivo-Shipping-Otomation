using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class DriverRegisterViewModel
    {
        public int DriverID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
    }
}