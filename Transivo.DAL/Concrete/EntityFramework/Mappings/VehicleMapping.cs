using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class VehicleMapping : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMapping()
        {
            Property(a => a.Plate).HasMaxLength(10);
            Property(a => a.Brand).HasMaxLength(20);
            Property(a => a.Type).HasMaxLength(20);
            Property(a => a.CommercialName).HasMaxLength(15);
            Property(a => a.CarClass).HasMaxLength(15);
            Property(a => a.Genus).HasMaxLength(15);
            Property(a => a.Color).HasMaxLength(15);
            Property(a => a.FuelType).HasMaxLength(15);
            Property(a => a.PurposeOf).HasMaxLength(20);
            Property(a => a.NotaryName).HasMaxLength(50);
            Property(a => a.DocumentSerialNo).HasMaxLength(15);

            HasRequired(a => a.Driver)
                .WithOptional(a => a.Vehicle)
                .Map(a=>a.MapKey("DriverID"));
        }
    }
}
