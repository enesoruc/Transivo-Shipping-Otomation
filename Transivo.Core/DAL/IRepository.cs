using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Core.DAL
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
    }
}
