using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(a => a.FirstName).HasMaxLength(20);
            Property(a => a.LastName).HasMaxLength(20);
            Property(a => a.EMail).HasMaxLength(255);
            Property(a => a.UserName).HasMaxLength(20).IsOptional();
            Property(a => a.Password).HasMaxLength(20).IsOptional();
            Property(a => a.ActivationCode).IsOptional();
            Property(a => a.UserName).IsOptional();
            Property(a=>a.BirthDate).IsOptional();
            Property(a=>a.Phone).IsOptional().HasColumnType("char").HasMaxLength(12);
            Property(a => a.MemberDate).IsOptional();
            Property(a=>a.LastLoginDate).IsOptional();
            Property(a => a.TotalPayment).IsOptional();
            Property(a => a.AddressID).IsOptional();



            HasMany(a => a.Shippings)
                .WithRequired(a => a.User)
                .HasForeignKey(a => a.UserID);

            HasMany(a => a.Messages)
               .WithRequired(a => a.User)
               .HasForeignKey(a => a.UserID);





        }
    }
}
