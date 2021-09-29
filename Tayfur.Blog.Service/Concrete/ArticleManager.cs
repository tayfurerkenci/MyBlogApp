using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.Entity.Concrete;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Concrete
{
    public class ArticleManager : IArticleService
    {

        private readonly ITagDal tagDal;
        private readonly IArticleDal articleDal;
        private readonly ICategoryDal categoryDal;
        private readonly IAdminDal adminDal;
        private readonly IMapper mapper;

        public ArticleManager(ITagDal tagDal, IArticleDal articleDal, IMapper mapper,
            IAdminDal adminDal, ICategoryDal categoryDal)
        {
            this.articleDal = articleDal;
            this.tagDal = tagDal;
            this.adminDal = adminDal;
            this.categoryDal = categoryDal;
            this.mapper = mapper;
        }
        public bool AddArticle(ArticleViewModel article/*, List<TagViewModel> tagViewModels*/)
        {
            bool result = false;
            try
            {
                // Tag Operations are not working properly because of the bootstrap tag manager plugin :/

                //using (TransactionScope scope = new TransactionScope())
                //{

                    Article art = mapper.Map<Article>(article);
                    result = articleDal.Add(art);
                    //if (result)
                    //{
                    //    if (tagViewModels != null)
                    //    {
                    //        List<Tag> tags= mapper.Map<List<Tag>>(tagViewModels);

                    //        foreach (var tag in tags)
                    //        {
                    //            tagDal.Add(tag);
                    //        }
                    //    }
                    //}
                //}
            }
            catch (Exception ex)
            {

                return false;
            }
            return result;
        }

        public bool DeleteArticle(ArticleViewModel entity)
        {
            Article art = mapper.Map<Article>(entity);
            return articleDal.Delete(art);
        }

        public List<ArticleViewModel> GetArticles()
        {
            List<ArticleViewModel> articleViewModel = mapper.Map<List<ArticleViewModel>>(articleDal.GetAll());
            return articleViewModel;
        }

        public ArticleViewModel GetArticle(Guid id)
        {
            ArticleViewModel articleViewModel = mapper.Map<ArticleViewModel>(articleDal.Get(x=>x.Id==id));
            return articleViewModel;
        }

        public bool UpdateArticle(ArticleViewModel entity)
        {
            Article art = mapper.Map<Article>(entity);
            return articleDal.Update(art);
        }

        public List<ArticleCategoryAdminViewModel> GetArticlesWithCategoryAndAdmin()
        {
            var articles = articleDal.GetAll();
            var categories = categoryDal.GetAll();
            var admins = adminDal.GetAll();

            var artCatAd = (from a in articles
                            join c in categories on a.CategoryId equals c.Id
                            join adm in admins on a.CreatedBy equals adm.Id
                            select new ArticleCategoryAdminViewModel
                            {
                                Admin = new AdminViewModel
                                {
                                    Id = adm.Id,
                                    CreatedDate = adm.CreatedDate,
                                    Email = adm.Email,
                                    FirstName = adm.FirstName,
                                    LastName = adm.LastName,
                                    Password = adm.Password
                                },
                                Article = new ArticleViewModel
                                {
                                    Id = a.Id,
                                    CategoryId = a.CategoryId,
                                    Context = a.Context,
                                    CreatedBy = a.CreatedBy,
                                    CreatedDate = a.CreatedDate,
                                    IsDeleted = a.IsDeleted,
                                    ModifiedBy = a.ModifiedBy,
                                    ModifiedDate = a.ModifiedDate,
                                    Title = a.Title
                                },
                                Category = new CategoryViewModel
                                {
                                    Id = c.Id,
                                    CategoryName = c.CategoryName,
                                    ModifiedBy = c.ModifiedBy,
                                    ModifiedDate = c.ModifiedDate,
                                    CreatedBy = c.CreatedBy,
                                    CreatedDate = c.CreatedDate,
                                    Description = c.Description,
                                    IsDeleted = c.IsDeleted
                                }
                            }).OrderByDescending(a=>a.Article.CreatedDate).ToList();
                
            return artCatAd;
        }
        public ArticleCategoryAdminViewModel GetArtWithCatAdmWithId(Guid id)
        {
            var articles = articleDal.GetAll();
            var categories = categoryDal.GetAll();
            var admins = adminDal.GetAll();

            var artCatAd = (from a in articles
                            where a.Id==id
                            join c in categories on a.CategoryId equals c.Id
                            join adm in admins on a.CreatedBy equals adm.Id
                            select new ArticleCategoryAdminViewModel
                            {
                                Admin = new AdminViewModel
                                {
                                    Id = adm.Id,
                                    CreatedDate = adm.CreatedDate,
                                    Email = adm.Email,
                                    FirstName = adm.FirstName,
                                    LastName = adm.LastName,
                                    Password = adm.Password
                                },
                                Article = new ArticleViewModel
                                {
                                    Id = a.Id,
                                    CategoryId = a.CategoryId,
                                    Context = a.Context,
                                    CreatedBy = a.CreatedBy,
                                    CreatedDate = a.CreatedDate,
                                    IsDeleted = a.IsDeleted,
                                    ModifiedBy = a.ModifiedBy,
                                    ModifiedDate = a.ModifiedDate,
                                    Title = a.Title
                                },
                                Category = new CategoryViewModel
                                {
                                    Id = c.Id,
                                    CategoryName = c.CategoryName,
                                    ModifiedBy = c.ModifiedBy,
                                    ModifiedDate = c.ModifiedDate,
                                    CreatedBy = c.CreatedBy,
                                    CreatedDate = c.CreatedDate,
                                    Description = c.Description,
                                    IsDeleted = c.IsDeleted
                                }
                            }).FirstOrDefault();

            return artCatAd;
        }
    }
}
