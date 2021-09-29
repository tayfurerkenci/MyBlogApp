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
    public interface IAdminService
    {
        AdminViewModel LoginUser(LoginViewModel loginDto);
        AdminViewModel GetUser(Guid guid);
    }
}
