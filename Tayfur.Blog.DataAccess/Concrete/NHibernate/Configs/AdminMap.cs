using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs
{
    public class AdminMap:ClassMap<Admin>
    {
        public AdminMap()
        {
            Id(x => x.Id);
            HasMany(x => x.Articles);
            HasMany(x => x.Categories);
            Map(x => x.Email);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Password);
            Map(x => x.CreatedDate);
            Table("Admin");
        }
    }
}
