using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transivo.UI.MVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez!")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olabilir!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter olabilir!")]
        public string Password { get; set; }
    }
}