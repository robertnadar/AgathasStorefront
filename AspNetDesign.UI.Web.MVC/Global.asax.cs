using AspNetDesign.Controller;
using AspNetDesign.Infrastructure.Configuration;
using AspNetDesign.Infrastructure.Email;
using AspNetDesign.Infrastructure.Logging;
using AspNetDesign.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetDesign.UI.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            BootStrapper.ConfigureDependencies();
            AspNetDesign.Controller.AutoMapperBootStrapper.ConfigureAutoMapper();
            Services.AutoMapperBootStrapper.ConfigureAutoMapper();
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(ObjectFactory.GetInstance<IApplicationSettings>());
            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());
            EmailServiceFactory.InitializeEmailServiceFactory(ObjectFactory.GetInstance<IEmailService>());
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());
            LoggingFactory.GetLogger().Log("Application Started");
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }
    }
}