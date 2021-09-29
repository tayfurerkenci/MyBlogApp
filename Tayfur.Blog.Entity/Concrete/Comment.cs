using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tayfur.Blog.Entity.Concrete
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CommentText { get; set; }
        public bool IsApproved { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Article Article { get; set; }

    }
}