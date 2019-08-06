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
    public class ShipCategoryService : IShipCategoryService
    {
        IShippingCategoryDAL _shippingCategoryDAL;
        public ShipCategoryService(IShippingCategoryDAL shippingCategoryDAL)
        {
            _shippingCategoryDAL = shippingCategoryDAL;
        }
        public bool Add(ShipCategory model)
        {
            return _shippingCategoryDAL.Add(model) > 0;
        }

        public bool Delete(ShipCategory model)
        {
            return _shippingCategoryDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            ShipCategory shipCategory = _shippingCategoryDAL.Get(a => a.ID == modelID);
            return _shippingCategoryDAL.Delete(shipCategory) > 0;
        }

        public ShipCategory Get(int modelID)
        {
            return _shippingCategoryDAL.Get(a => a.ID == modelID);
        }

        public List<ShipCategory> GetAll()
        {
            return _shippingCategoryDAL.GetAll().ToList();
        }

        public bool Update(ShipCategory model)
        {
            return _shippingCategoryDAL.Update(model) > 0;
        }
    }
}
