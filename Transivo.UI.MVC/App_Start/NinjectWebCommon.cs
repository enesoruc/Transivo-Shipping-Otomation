[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Transivo.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Transivo.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Transivo.UI.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Transivo.BLL.Abstract;
    using Transivo.BLL.Concrete;
    using Transivo.BLL.IOC.Ninject;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAddressService>().To<AddressService>();
            kernel.Bind<ICityService>().To<CityService>();
            kernel.Bind<IAdminService>().To<AdminService>();
            kernel.Bind<IAdminRoleService>().To<AdminRoleService>();
            kernel.Bind<ICountryService>().To<CountryService>();
            kernel.Bind<IDistrictService>().To<DistrictService>();
            kernel.Bind<IDriverService>().To<DriverService>();
            //kernel.Bind<IDriverVehicleService>().To<DriverVehicleService>();
            kernel.Bind<IMessageService>().To<MessageService>();
            kernel.Bind<IPayTypeService>().To<PayTypeService>();
            kernel.Bind<IShipCategoryService>().To<ShipCategoryService>();
            kernel.Bind<IShippingService>().To<ShippingService>();
            kernel.Bind<IUserRoleService>().To<UserRoleService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IVehicleService>().To<VehicleService>();
            kernel.Bind<ICompanyService>().To<CompanyService>();
            kernel.Load<DalModule>();
        }
    }
}
