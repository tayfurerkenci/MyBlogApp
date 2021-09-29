using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Makale")]
        public Guid ArticleId { get; set; }
        [DisplayName("E-posta")]
        public string Email { get; set; }
        [DisplayName("Yorum")]
        public string CommentText { get; set; }
        [DisplayName("Onaylandı Mı?")]
        public bool IsApproved { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Düzenlenme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Düzenleyen")]
        public Guid? ModifiedBy { get; set; }
        [DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }
    }
}
