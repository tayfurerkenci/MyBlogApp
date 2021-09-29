using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.Entity.Concrete;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.AutoMapperConfig;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        private readonly IMapper mapper;
        //Do some work here. 
        //And when we want to map do something like the following. 
        //var result = _mapper.Map<TypeIWantToMapTo>(originalObject);
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            this.categoryDal = categoryDal;
            this.mapper = mapper;
        }
        public bool AddCategory(CategoryViewModel entity)
        {
            Category cat = mapper.Map<Category>(entity);
            return categoryDal.Add(cat);
        }

        public bool DeleteCategory(CategoryViewModel entity)
        {
            Category cat = mapper.Map<Category>(entity);
            return categoryDal.Delete(cat);
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> categoryViewModels = mapper.Map<List<CategoryViewModel>>(categoryDal.GetAll());
            return categoryViewModels;
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            CategoryViewModel categoryViewModel = mapper.Map<CategoryViewModel>(categoryDal.Get(x=>x.Id==id));
            return categoryViewModel;
        }

        public bool UpdateCategory(CategoryViewModel entity)
        {
            Category cat = mapper.Map<Category>(entity);
            return categoryDal.Update(cat);
        }
    }
}
