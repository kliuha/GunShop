﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GunShop.Util.NinjectRegistration), "Start")]
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
    using System;
    using System.Web;
    using GunShop.App_Start;

    public class NinjectRegistration : NinjectModule
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));                                
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
       
    private static IKernel CreateKernel()
                {
                    var kernel = new StandardKernel();

                    KernelInstance = kernel;

                    try
                    {
                        kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                        kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                        kernel.Bind<IGunRepository>().To<GunRepository>();
                        //kernel.Bind<IPriceCalculation>().To<PriceCalculation>();
                        kernel.Bind<IOrderRepository>().To<OrderRepository>();
                        kernel.Bind<IWarehouseRepository>().To<WarehouseRepository>();
                        kernel.Bind<IReservationRepository>().To<ReservationRepository>();
                        kernel.Bind<IReservationService>().To<ReservationLoggingDecorator>();
                        kernel.Bind<IReservationService>().To<ReservationService>().WhenInjectedExactlyInto<ReservationLoggingDecorator>();
                        kernel.Bind<IPriceCalculation>().ToMethod<FinalPriceCalculationStrategy>(ctx =>
                    {
                        return new FinalPriceCalculationStrategy(new System.Collections.Generic.List<IPriceCalculation>() {
                            ctx.Kernel.Get<PriceCalculation>(),
                            ctx.Kernel.Get<AmmunitionPriceStrategy>()
                    });

                    });
                        kernel.Bind<ILogger>().ToMethod(x =>
                            new Logger(HttpContext.Current.Server.MapPath("~/App_Data")));
                return kernel;
                    }

                    catch
                    {
                        kernel.Dispose();
                        throw;
                    }
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