using BrainSystem.OS.MVC.App_Start;
using BrainSystem.OS.MVC.AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BrainSystem.OS.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();

            //Implementar sei registro de DI

            //DependencyResolver.SetResolver(SimpleInjectorContainer.RegisterServices());
        }
    }
}
