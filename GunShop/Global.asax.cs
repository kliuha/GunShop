using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using GunShop.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GunShop;

namespace GunShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //// внедрение зависимостей
           
           
        }
    }
}