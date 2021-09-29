using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class ArticleCategoryAdminViewModel
    {
        public ArticleViewModel Article { get; set; }
        public CategoryViewModel Category { get; set; }
        public AdminViewModel Admin { get; set; }
    }
}
