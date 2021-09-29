using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Service.ViewModels;

namespace Tayfur.Blog.Service.Abstract
{
    public interface IErrorService
    {
        List<ErrorViewModel> GetErrors();
        ErrorViewModel GetError(Guid id);
        bool AddError(ErrorViewModel entity);
        bool UpdateError(ErrorViewModel entity);
        bool DeleteError(ErrorViewModel entity);
    }
}
