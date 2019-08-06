using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.BLL.Abstract;
using Transivo.DAL.Abstract;
using Transivo.DAL.Concrete.EntityFramework.DAL;
using Transivo.Model.Models;

namespace Transivo.BLL.Concrete
{
    public class AddressService : IAddressService
    {
        IAddressDAL _addressDAL;

        public AddressService(IAddressDAL addressDAL)
        {
            _addressDAL = addressDAL;
        }

        public bool Add(Address model)
        {
            return _addressDAL.Add(model) > 0;
        }

        public bool Delete(Address model)
        {
            return _addressDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            Address address = _addressDAL.Get(a => a.ID == modelID);
            return _addressDAL.Delete(address) > 0;
        }

        public Address Get(int modelID)
        {
            return _addressDAL.Get(a => a.ID == modelID);
        }

        public List<Address> GetAddressesByDisctrict(int districtID)
        {
            return _addressDAL.GetAll(a => a.DistrictID == districtID).ToList();
        }

        public List<Address> GetAll()
        {
            return _addressDAL.GetAll().ToList();
        }

        public bool Update(Address model)
        {
            return _addressDAL.Update(model) > 0;
        }
    }
}
