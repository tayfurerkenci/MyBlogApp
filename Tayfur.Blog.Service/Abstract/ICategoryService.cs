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
    public interface ICategoryService
    {
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(Guid id);
        bool AddCategory(CategoryViewModel entity);
        bool UpdateCategory(CategoryViewModel entity);
        bool DeleteCategory(CategoryViewModel entity);
    }
}
