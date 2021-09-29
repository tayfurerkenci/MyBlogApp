using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class TagViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Makale")]
        public Guid ArticleId { get; set; }
        [DisplayName("Etiket")]
        public string TagName { get; set; }
    }
}
