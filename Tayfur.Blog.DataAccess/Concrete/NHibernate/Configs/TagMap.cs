using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs
{
    public class TagMap:ClassMap<Tag>
    {
        public TagMap()
        {
            Id(x => x.Id);
            Map(x => x.ArticleId);
            Map(x => x.TagName);
            //References(x => x.Article);
            Table("Tag");
        }
    }
}
