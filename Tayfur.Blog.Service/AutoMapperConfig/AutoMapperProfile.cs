using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.AutoMapperConfig
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Article, ArticleViewModel>().ReverseMap();
            CreateMap<Error, ErrorViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Admin, AdminViewModel>().ReverseMap();

            // with ReverseMap method we don't need duplicate code like below.

            //CreateMap<ArticleViewModel, Article>();
            //CreateMap<ErrorViewModel, Error>();
            //CreateMap<CategoryViewModel, Category>();
            //CreateMap<TagViewModel, Tag>();
            //CreateMap<CommentViewModel, Comment>();
            //CreateMap<AdminViewModel, Admin>();
        }
    }
}
