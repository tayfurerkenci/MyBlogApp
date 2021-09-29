using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tayfur.Blog.Entity.Concrete
{
    public class Admin
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string  Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

    }
}