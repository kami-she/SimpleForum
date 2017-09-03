using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Data;
using Services;
using Services.Impl;

namespace ForumWebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            var mapper = AutomapperConfig.CreateMapperConfiguration();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container
               .RegisterType<IForumContext, ForumContext>(new PerResolveLifetimeManager())
               .RegisterType<IUserService, UserService>()
               .RegisterInstance(mapper);


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}