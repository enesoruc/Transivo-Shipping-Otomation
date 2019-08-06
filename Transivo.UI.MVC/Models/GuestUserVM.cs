using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class GuestUserVM
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EMail alanı boş geçilemez!")]
        [StringLength(255, ErrorMessage = "En fazla 255 karakter olabilir!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesaj alanı boş geçilemez!")]
        [StringLength(500, ErrorMessage = "En fazla 500 karakter olabilir!")]
        public string Message { get; set; }

        public int GuestUserID { get; set; }
    }
}