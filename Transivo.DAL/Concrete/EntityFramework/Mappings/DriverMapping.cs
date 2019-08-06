using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class DriverMapping : EntityTypeConfiguration<Driver>
    {
        public DriverMapping()
        {
            Property(a => a.FirstName).HasMaxLength(50);
            Property(a => a.Lastname).HasMaxLength(50);
            Property(a => a.TC).HasMaxLength(11).HasColumnType("char");
            Property(a => a.BirthPlace).HasMaxLength(50);
            Property(a => a.Phone).HasMaxLength(12).HasColumnType("char");
            Property(a => a.EMail).HasMaxLength(255);
        }
    }
}
