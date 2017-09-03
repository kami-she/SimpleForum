using AutoMapper;
using Data;
using ForumWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumWebApplication
{
    public class AutomapperConfig
    {
        public static IMapper CreateMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserLoginViewModel>();
                cfg.CreateMap<UserLoginViewModel, User>();
                cfg.CreateMap<User, UserRegisterViewModel>();
                cfg.CreateMap<UserRegisterViewModel, User>();
            });
            return config.CreateMapper();
        }
    }
}