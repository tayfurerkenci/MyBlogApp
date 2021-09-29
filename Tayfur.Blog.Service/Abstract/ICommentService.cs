using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Entity.Concrete;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Abstract
{
    public interface ICommentService
    {
        List<CommentViewModel> GetComments();
        CommentViewModel GetComment(Guid guid);
        bool AddComment(CommentViewModel entity);
        bool UpdateComment(CommentViewModel entity);
        bool DeleteComment(CommentViewModel entity);
    }
}
