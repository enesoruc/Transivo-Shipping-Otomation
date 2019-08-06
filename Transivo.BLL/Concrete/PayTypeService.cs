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
    public class PayTypeService : IPayTypeService
    {
        IPayTypeDAL _payTypeDAL;

        public PayTypeService(IPayTypeDAL payTypeDAL)
        {
            _payTypeDAL = payTypeDAL;
        }

        public bool Add(PayType model)
        {
            return _payTypeDAL.Add(model) > 0;
        }

        public bool Delete(PayType model)
        {
            return _payTypeDAL.Delete(model) > 0;
        }

        public bool Delete(int modelID)
        {
            PayType payType = _payTypeDAL.Get(a => a.ID == modelID);
            return _payTypeDAL.Delete(payType) > 0;
        }

        public PayType Get(int modelID)
        {
            return _payTypeDAL.Get(a => a.ID == modelID);
        }

        public List<PayType> GetAll()
        {
            return _payTypeDAL.GetAll().ToList();
        }

        public bool Update(PayType model)
        {
            return _payTypeDAL.Update(model) > 0;
        }
    }
}
