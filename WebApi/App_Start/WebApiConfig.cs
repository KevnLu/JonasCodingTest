using log4net;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using System;
using System.Linq;
using System.Web.Http;
using WebApi.ActionFilters;


namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Web API configuration and services

            //Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new GlobalExceptionFilter());
        }
    }

    public class LoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(context => LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)).InSingletonScope();
        }
    }
}
