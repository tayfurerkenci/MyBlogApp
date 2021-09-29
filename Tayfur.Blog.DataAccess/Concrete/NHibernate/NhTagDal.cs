using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.DataAccess.NHibernate;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete.NHibernate
{
    public class NhTagDal : NhEntityRepositoryBase<Tag>, ITagDal
    {
    }
}
