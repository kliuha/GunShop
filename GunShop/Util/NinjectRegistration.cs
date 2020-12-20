[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GunShop.Util.NinjectRegistration), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GunShop.Util.NinjectRegistration), "Stop")]
namespace GunShop.Util
{

using Ninject.Modules;
using GunShop.Domai.Interfaces;
using GunShop.Infrastructure.Bussiness;
using GunShop.Infrastructure.Data;
using GunShop.Services.Interfaces;
using Ninject.Web.Common;
 using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common.WebHost;

    public class NinjectRegistration : NinjectModule
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            var kernel = new StandardKernel();
            KernelInstance = kernel;
            kernel.Bind<IGunRepository>().To<GunRepository>();
            kernel.Bind<IPriceCalculation>().To<PriceCalculation>();
           
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        public static new IKernel KernelInstance;
        public override void Load()
        {
            
        }
    }
}