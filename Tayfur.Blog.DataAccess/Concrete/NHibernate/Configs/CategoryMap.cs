using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            HasMany(x => x.Articles);
            Map(x => x.Description);
            Map(x => x.CategoryName);
            Map(x => x.CreatedBy);
            Map(x => x.IsDeleted);
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedBy);
            Map(x => x.ModifiedDate);
            //References(x => x.Admin);
            Table("Category");
        }
    }
}
