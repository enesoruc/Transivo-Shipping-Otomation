using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Core.DAL.EntityFramework
{
    public class EFSingletonContext<TContext>
        where TContext : DbContext, new()
    {
        private static TContext context;

        public static TContext Instance
        {
            get
            {
                if (context == null)
                {
                    context = new TContext();
                }
                return context;
            }
        }
    }
}
