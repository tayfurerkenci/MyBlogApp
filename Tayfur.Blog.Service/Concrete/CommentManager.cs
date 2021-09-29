using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.Entity.Concrete;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal commentDal;

        private readonly IMapper mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            this.commentDal = commentDal;
            this.mapper = mapper;
        }
        public bool AddComment(CommentViewModel entity)
        {
            Comment com = mapper.Map<Comment>(entity);
            return commentDal.Add(com);
        }

        public bool DeleteComment(CommentViewModel entity)
        {
            Comment com = mapper.Map<Comment>(entity);
            return commentDal.Delete(com);
        }

        public CommentViewModel GetComment(Guid id)
        {
            CommentViewModel commentViewModel = mapper.Map<CommentViewModel>(commentDal.Get(x => x.Id == id));
            return commentViewModel;
        }

        public List<CommentViewModel> GetComments()
        {
            List<CommentViewModel> commentViewModels = mapper.Map<List<CommentViewModel>>(commentDal.GetAll());
            return commentViewModels;
        }

        public bool UpdateComment(CommentViewModel entity)
        {
            Comment com = mapper.Map<Comment>(entity);
            return commentDal.Update(com);
        }
    }
}
