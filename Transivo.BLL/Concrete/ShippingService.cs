using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.BLL.Abstract;
using Transivo.DAL.Abstract;
using Transivo.Model.Models;

namespace Transivo.BLL.Concrete
{
    public class ShippingService : IShippingService
    {
        IShippingDAL _shippingDAL;

        public ShippingService(IShippingDAL shippingDAL)
        {
            _shippingDAL = shippingDAL;
        }

        public bool Add(Shipping model)
        {
            return _shippingDAL.Add(model)>0;
        }

        public bool Delete(Shipping model)
        {
            return _shippingDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Shipping shipping = _shippingDAL.Get(a => a.ID == modelID);
            return _shippingDAL.Delete(shipping) > 0;
        }

        public Shipping Get(int modelID)
        {
            return _shippingDAL.Get(a => a.ID == modelID);
        }

        public List<Shipping> GetAll()
        {
            return _shippingDAL.GetAll().ToList();
        }
        
        public List<Shipping> GetByIsActivity(int companyID, bool activitiy)
        {
            List<Shipping> shippings = _shippingDAL.GetAll(a => a.CompanyID == companyID && a.IsActive == activitiy).ToList();
            return shippings;
        }

        public List<Shipping> GetByUserID(int userID)
        {
            return _shippingDAL.GetAll(a => a.UserID == userID).ToList();
        }

        public List<Shipping> GetByUserIDAndIsActiveAndDidItMove(int userID, bool IsActive,bool didItMove)
        {
            if (didItMove)
            {
                return _shippingDAL.GetAll(a => a.UserID == userID && a.IsActive == IsActive && a.Vehicle!=null).ToList();
            }
            else
            {
                return _shippingDAL.GetAll(a => a.UserID == userID && a.IsActive == IsActive && a.Vehicle==null).ToList();
            }
        }

        public List<Shipping> GetOnTransportShippings(int companyID)
        {
            return _shippingDAL.GetAll(a => a.CompanyID == companyID && a.IsActive==true && a.Vehicle!=null).ToList();
        }

        public List<Shipping> GetUndeliveredShippingsByCompID(int companyID)
        {
            List<Shipping> Shippings = new List<Shipping>();
            Shippings = _shippingDAL.GetAll(a => a.CompanyID == companyID && a.IsActive==true).ToList();
            return Shippings;
        }

        public bool Update(Shipping model)
        {
            return _shippingDAL.Update(model) > 0;
        }
    }
}
