using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Core.DAL.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        TContext context;

        public EFRepositoryBase()
        {
            context = EFSingletonContext<TContext>.Instance;
        }

        public int Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            return context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return context.Set<TEntity>().ToList();
            }
            else
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public int Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
