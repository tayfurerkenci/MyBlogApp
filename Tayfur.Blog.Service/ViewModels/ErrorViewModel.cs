using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class ErrorViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Durum Kodu")]
        public string StatusCode { get; set; }
        [DisplayName("Durum Açıklaması")]
        public string StatusDescription { get; set; }
        [DisplayName("Mesaj")]
        public string Message { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        public DateTime DateTime { get; set; }
    }
}
