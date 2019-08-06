using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class RegisterAdminAndCompanyViewModel
    {
        public RegisterAdminAndCompanyViewModel()
        {
            Freight = 0M;
            LogoPath = "http://i2.haber7.net//haber/haber7/photos/2018/11/sirket_kurmak_300_tlye_dustu_1521121713_3898.jpg";
        }

        [Required(ErrorMessage = "EMail alanı boş geçilemez!")]
        [StringLength(255, ErrorMessage = "En fazla 255 karakter olabilir!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmamaktadır!")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçielez!")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olabilir!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şirket Adı alanı boş geçilemez!")]
        [StringLength(75, ErrorMessage = "En fazla 75 karakter olabilir!")]
        public string CompanyName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
        [RegularExpression(@"^([0-9]{2})[-. ]?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Telefon bilgisi 12 haneli olmalıdır!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vergi Numarası alanı boş geçilemez")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string TaxNumber { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş geçilemez!")]
        [StringLength(1000, ErrorMessage ="En fazla 1000 karakter olabilir!")]
        public string About { get; set; }

        public decimal Freight { get; set; }
        public string LogoPath { get; set; }
    }
}