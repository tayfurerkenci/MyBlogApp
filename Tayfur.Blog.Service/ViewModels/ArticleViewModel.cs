using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tayfur.Blog.Service.ViewModels
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Kategori")]
        public Guid CategoryId { get; set; }
        
        [DisplayName("Makale Başlığı")]
        public string Title { get; set; }

        [DisplayName("Makale İçeriği")]
        [AllowHtml]
        public string Context { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Düzenlenme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        public DateTime? ModifiedDate { get; set; }

        [DisplayName("Oluşturan")]
        public Guid CreatedBy { get; set; }

        [DisplayName("Düzenleyen")]
        public Guid? ModifiedBy { get; set; }

        [DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }
    }
}
