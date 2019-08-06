using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.DAL.Abstract;
using Transivo.DAL.Concrete.EntityFramework.DAL;

namespace Transivo.BLL.IOC.Ninject
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAddressDAL>().To<EFAddressDAL>();
            Bind<ICityDAL>().To<EFCityDAL>();
            Bind<IAdminDAL>().To<EFAdminDAL>();
            Bind<IAdminRoleDAL>().To<EFAdminRoleDAL>();
            Bind<ICountryDAL>().To<EFCountryDAL>();
            Bind<IDistrictDAL>().To<EFDistrictDAL>();
            Bind<IDriverDAL>().To<EFDriverDAL>();
            Bind<IMessageDAL>().To<EFMessageDAL>();
            Bind<IPayTypeDAL>().To<EFPayTypeDAL>();
            Bind<IShippingCategoryDAL>().To<EFShipCategoryDAL>();
            Bind<IShippingDAL>().To<EFShippingDAL>();
            Bind<IUserDAL>().To<EFUserDAL>();
            Bind<IUserRoleDAL>().To<EFUserRoleDAL>();
            Bind<IVehicleDAL>().To<EFVehicleDAL>();
            Bind<ICompanyDAL>().To<EFCompanyDAL>();
        }
    }
}
