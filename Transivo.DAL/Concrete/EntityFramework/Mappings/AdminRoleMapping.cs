using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class AdminRoleMapping : EntityTypeConfiguration<AdminRole>
    {
        public AdminRoleMapping()
        {
            Property(a => a.Name).HasMaxLength(20);
        }
    }
}
