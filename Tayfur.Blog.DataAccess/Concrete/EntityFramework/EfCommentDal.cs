using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Common.DataAccess.EntityFramework;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.DataAccess.Context;
using Tayfur.Blog.Entity.Concrete;

namespace Tayfur.Blog.DataAccess.Concrete
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, BlogContext>, ICommentDal
    {

    }
}
