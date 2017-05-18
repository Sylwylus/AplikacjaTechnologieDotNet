using Application.Services;
using Autofac;
using Autofac.Integration.Mvc;
using Data;
using Data.Identity;
using Microsoft.AspNet.Identity.Owin;
using SerwisPlanszowkowy.App_Start;
using SerwisPlanszowkowy.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SerwisPlanszowkowy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetAutofacContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
       
            AutoMapperConfig.Configure();
            AddAdminAndModerator.InitialRoleUser();
  
        }

        private void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());          
       

            var data = Assembly.Load("Data");
            builder.RegisterAssemblyTypes(data);

            var domain = Assembly.Load("Domain");
            builder.RegisterAssemblyTypes(domain);

            var application = Assembly.Load("Application");
            builder.RegisterAssemblyTypes(application);

            var x = new CrudContext();
            builder.Register<CrudContext>(c => x);
            builder.Register<CustomUserStore>(c => new CustomUserStore(x)).AsImplementedInterfaces();
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            });
            builder.RegisterType<ApplicationUserManager>();
            builder.RegisterType<CrudContext>().InstancePerLifetimeScope();  
            builder.RegisterType<CommentService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<NewsService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ReviewService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<RateService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<GameService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterFilterProvider();
           
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
