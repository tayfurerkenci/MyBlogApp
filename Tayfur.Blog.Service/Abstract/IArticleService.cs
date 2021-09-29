using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Abstract
{
    public interface IArticleService
    {
        List<ArticleViewModel> GetArticles();
        List<ArticleCategoryAdminViewModel> GetArticlesWithCategoryAndAdmin();
        ArticleCategoryAdminViewModel GetArtWithCatAdmWithId(Guid id);
        ArticleViewModel GetArticle(Guid id);
        bool AddArticle(ArticleViewModel entity/*, List<TagViewModel> tagViewModels*/);
        bool UpdateArticle(ArticleViewModel entity);
        bool DeleteArticle(ArticleViewModel entity);
    }
}
