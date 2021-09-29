using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        [DisplayName("Kategori Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }
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
    }
}
