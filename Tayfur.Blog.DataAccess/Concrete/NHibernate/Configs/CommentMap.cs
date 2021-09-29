using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs
{
    public class CommentMap:ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(x => x.Id);
            Map(x => x.IsApproved);
            Map(x => x.CommentText);
            Map(x => x.Email);
            Map(x => x.IsDeleted);
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedBy);
            Map(x => x.ModifiedDate);
            Map(x => x.ArticleId);
            //References(x => x.Article);
            Table("Comment");
        }
    }
}
