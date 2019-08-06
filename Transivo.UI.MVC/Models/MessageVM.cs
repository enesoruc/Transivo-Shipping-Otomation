using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class MessageVM
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string CreatedDate { get; set; }
        public string Detail { get; set; }
    }
}