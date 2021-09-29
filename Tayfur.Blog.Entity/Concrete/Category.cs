using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tayfur.Blog.Entity.Concrete
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("Admin")]
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual Admin Admin { get; set; }
    }
}