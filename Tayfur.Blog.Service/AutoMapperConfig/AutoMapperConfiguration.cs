using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Service.AutoMapperConfig
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });

            var mapper = config.CreateMapper();

            #region Obsolote since v9.0

            //Mapper.Initialize(x =>
            //{
            //    x.AddProfile<MyMappings>();
            //}); 
            #endregion
        }
    }
}
