using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate.Configs
{
    public class ErrorMap:ClassMap<Error>
    {
        public ErrorMap()
        {
            Id(x => x.Id);
            Map(x => x.DateTime);
            Map(x => x.Message);
            Map(x => x.StatusCode);
            Map(x => x.StatusDescription);
            Table("Error");
        }
    }
}
