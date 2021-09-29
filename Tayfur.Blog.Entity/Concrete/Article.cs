using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tayfur.Blog.Entity.Concrete
{
    public class Article
    {
        public Guid Id { get; set; }

        //[DisplayName("Kategori")]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(250)]
        //[DisplayName("Makale Başlığı")]
        public string Title { get; set; }
        [Required]
        [MinLength(50)]
        //[DisplayName("Makale İçeriği")]
        public string Context { get; set; }

        //[DisplayName("Oluşturulma Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        //[DisplayName("Düzenlenme Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy hh:mm}")]
        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedDate { get; set; }

        //[DisplayName("Oluşturan")]
        [ForeignKey("Admin")]
        public Guid CreatedBy { get; set; }

        //[DisplayName("Düzenleyen")]
        public Guid? ModifiedBy { get; set; }

        //[DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }

        public virtual Admin Admin { get; set; }
    }
}