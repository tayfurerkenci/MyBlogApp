using AutoMapper;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.DataAccess.Concrete;
using Tayfur.Blog.DataAccess.Concrete.NHibernate;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.AutoMapperConfig;
using Tayfur.Blog.Service.Concrete;

namespace Tayfur.Blog.Service.DependencyResolvers.Ninject
{
    // Ninject IOC Container Implementation
    // this process doesn't require third party tool in .NET CORE Environment
    // but here it is a must!
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            // https://stackoverflow.com/questions/48831795/c-sharp-ninject-with-automapper-in-class-library
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            this.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
            //this.Bind<Root>().ToSelf().InSingletonScope();

            // Services

            Bind<IAdminService>().To<AdminManager>();
            // Ninject does do "AdminManager adminManager=new AdminManager();" on the background !
            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICommentService>().To<CommentManager>();
            Bind<IArticleService>().To<ArticleManager>();
            Bind<IErrorService>().To<ErrorManager>();

            // Dals With EntityFramework Implementation!

            Bind<IAdminDal>().To<EfAdminDal>();
            Bind<IArticleDal>().To<EfArticleDal>();
            Bind<ICategoryDal>().To<EfCategoryDal>();
            Bind<ICommentDal>().To<EfCommentDal>();
            Bind<ITagDal>().To<EfTagDal>();
            Bind<IErrorDal>().To<EfErrorDal>();

            // Dals With NHibernate Implementation!

            //Bind<IAdminDal>().To<NhAdminDal>();
            //Bind<IArticleDal>().To<NhArticleDal>();
            //Bind<ICategoryDal>().To<NhCategoryDal>();
            //Bind<ICommentDal>().To<NhCommentDal>();
            //Bind<ITagDal>().To<NhTagDal>();
            //Bind<IErrorDal>().To<NhErrorDal>();



        }
    }
}
