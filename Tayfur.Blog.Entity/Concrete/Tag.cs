using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tayfur.Blog.Entity.Concrete
{
    public class Tag
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TagName { get; set; }
        public Article Article { get; set; }


    }
}