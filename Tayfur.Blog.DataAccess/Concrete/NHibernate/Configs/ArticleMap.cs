using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs
{
    public class ArticleMap : ClassMap<Article>
    {
        public ArticleMap()
        {
            Id(x => x.Id);
            Map(x => x.Context);
            Map(x => x.CategoryId);
            Map(x => x.CreatedBy);
            Map(x => x.IsDeleted);
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedBy);
            Map(x => x.ModifiedDate);
            Map(x => x.Title);
            //References(x => x.Admin);
            Table("Article");
        }
    }
}
