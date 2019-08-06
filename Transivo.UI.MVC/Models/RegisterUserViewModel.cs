using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transivo.Model.Models;

namespace Transivo.UI.MVC.Models
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Doğum Tarihi alanı boş geçilemez!")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Adres Başlığı alanı boş geçilemez!")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [StringLength(255, ErrorMessage = "En fazla 255 karakter olabilir!")]
        public string AddressDetail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telefon alanı boş geçilemez!")]
        [RegularExpression(@"^([0-9]{2})[-. ]?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Telefon bilgisi 12 haneli olmalıdır!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "EMail alanı boş geçilemez!")]
        [StringLength(255, ErrorMessage = "En fazla 255 karakter olabilir!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Tekrar alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string RePassword { get; set; }

        public int DistrictID { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
    }
}