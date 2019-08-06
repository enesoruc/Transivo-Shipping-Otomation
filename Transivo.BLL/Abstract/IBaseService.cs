using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.BLL.Abstract
{
    public interface IBaseService<T>
        where T : BaseEntity
    {
        bool Add(T model);
        bool Delete(T model);
        bool Delete(int modelID);
        bool Update(T model);
        T Get(int modelID);
        List<T> GetAll();
    }
}
