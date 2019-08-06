using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transivo.Model.Models;

namespace Transivo.UI.MVC.Models
{
    public class AdminCompanyDetail
    {
        public List<Driver> AktifSoforler { get; set; }
        public List<Shipping> OnayBekleyenNakliyeler { get; set; }
        public List<Shipping> OnayBekleyen4Nakliye { get; set; }
        public List<Shipping> TeslimatiBeklenenNakliyeler { get; set; }
        public List<Message> Mesajlar4 { get; set; }
        public List<Message> Mesajlar { get; set; }
        public decimal? ToplamKazanc { get; set; }
        public int OnayBekleyenNakliyeAdedi { get; set; }

        public AdminCompanyDetail()
        {
            AktifSoforler = new List<Driver>();
            OnayBekleyenNakliyeler = new List<Shipping>();
            OnayBekleyen4Nakliye = new List<Shipping>();
            TeslimatiBeklenenNakliyeler = new List<Shipping>();
            Mesajlar4 = new List<Message>();
            Mesajlar = new List<Message>();
        }
    }
}