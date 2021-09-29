using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate
{
    public class MyNHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=.;Initial Catalog=BlogDb;Integrated Security=SSPI;")
                              .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<AdminMap>()
                              .AddFromAssemblyOf<TagMap>()
                              .AddFromAssemblyOf<CategoryMap>()
                              .AddFromAssemblyOf<ArticleMap>()
                              .AddFromAssemblyOf<ErrorMap>()
                              .AddFromAssemblyOf<CommentMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
