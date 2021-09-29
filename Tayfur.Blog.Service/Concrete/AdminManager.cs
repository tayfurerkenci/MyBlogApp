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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal adminDal;
        private readonly IMapper mapper;

        public AdminManager(IAdminDal adminDal, IMapper mapper)
        {
            this.adminDal = adminDal;
            this.mapper = mapper;
        }

        public AdminViewModel GetUser(Guid id)
        {
            AdminViewModel adminViewModel = mapper.Map<AdminViewModel>(adminDal.Get(x=>x.Id==id));
            return adminViewModel;
        }

        public AdminViewModel LoginUser(LoginViewModel loginDto)
        {
            AdminViewModel adminViewModel= mapper.Map<AdminViewModel>(adminDal.Get(x=>x.Email==loginDto.Email && x.Password==loginDto.Password));
            return adminViewModel;
        }
    }
}
