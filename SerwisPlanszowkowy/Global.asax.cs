using SerwisPlanszowkowy.App_Start;
using SerwisPlanszowkowy.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
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
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //  Database.SetInitializer(new DatabaseInitializer());//
            //  using (var context = new CrudContext())//
            // {//
            //    context.Database.Initialize(true);//
            //  }//

            AutoMapperConfig.Configure();
            AddAdminAndModerator.InitialRoleUser();
        }
    }
}
