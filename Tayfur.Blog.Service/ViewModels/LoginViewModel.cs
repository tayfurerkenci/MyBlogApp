using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Tayfur.Blog.Service.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        //[EmailAddress]
        //[MaxLength(250)]
        [DisplayName("E-posta")]
        public string Email { get; set; }
        //[Required]
        //[MaxLength(50)]
        [DisplayName("Şifre")]
        public string Password { get; set; }
    }
}