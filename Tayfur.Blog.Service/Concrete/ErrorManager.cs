using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.DataAccess.Abstract;
using Tayfur.Blog.Service.Abstract;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Concrete
{
    public class ErrorManager:IErrorService
    {
        private readonly IErrorDal errorDal;
        private readonly IMapper mapper;

        public ErrorManager(IErrorDal errorDal, IMapper mapper)
        {
            this.errorDal = errorDal;
            this.mapper = mapper;
        }

        public bool AddError(ErrorViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteError(ErrorViewModel entity)
        {
            throw new NotImplementedException();
        }

        public ErrorViewModel GetError(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ErrorViewModel> GetErrors()
        {
            throw new NotImplementedException();
        }

        public bool UpdateError(ErrorViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
