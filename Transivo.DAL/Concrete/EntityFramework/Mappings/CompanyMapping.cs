using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class CompanyMapping:EntityTypeConfiguration<Company>
    {
        public CompanyMapping()
        {
            Property(a => a.CompanyName).HasMaxLength(75);
            Property(a => a.Phone).HasColumnType("char").HasMaxLength(12);
            Property(a => a.TaxNumber).HasMaxLength(20);
            Property(a => a.About).HasMaxLength(1000);

            HasMany(a => a.Shippings)
                      .WithRequired(a => a.Company)
                      .HasForeignKey(a => a.CompanyID);

            HasMany(a => a.Messages)
                     .WithRequired(a => a.Company)
                     .HasForeignKey(a => a.CompanyID);
        }
       
    }
}
