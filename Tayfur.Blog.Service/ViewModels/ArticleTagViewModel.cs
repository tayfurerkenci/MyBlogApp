using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.ViewModels
{
    public class ArticleTagViewModel
    {
        public ArticleViewModel Article { get; set; }
        public List<TagViewModel> Tag { get; set; }
    }
}
