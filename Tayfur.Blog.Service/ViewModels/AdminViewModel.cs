using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class AdminViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("E-posta")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("İsim")]
        public string FirstName { get; set; }
        [DisplayName("Soyisim")]
        public string LastName { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        public DateTime CreatedDate { get; set; }
    }
}
