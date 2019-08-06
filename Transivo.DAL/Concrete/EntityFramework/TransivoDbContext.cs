using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.DAL.Concrete.EntityFramework.Mappings;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework
{
    public class TransivoDbContext : DbContext
    {
        public TransivoDbContext()
            :base("Server=.;Database=Transivo;Trusted_Connection=True")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(a => a.PropertyType == typeof(string))
                .Configure(a => a.IsRequired());

            modelBuilder.Properties()
                            .Where(a => a.PropertyType == typeof(decimal))
                            .Configure(a => a.HasPrecision(4, 2));

            modelBuilder.Properties()
                .Where(a => a.PropertyType == typeof(DateTime))
                .Configure(a => a.HasColumnType("datetime"));

            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new AdminMapping());
            modelBuilder.Configurations.Add(new CountryMapping());
            modelBuilder.Configurations.Add(new DistrictMapping());
            modelBuilder.Configurations.Add(new DriverMapping());
            //modelBuilder.Configurations.Add(new DriverVehicleMapping());
            modelBuilder.Configurations.Add(new MessageMapping());
            modelBuilder.Configurations.Add(new PayTypeMapping());
            modelBuilder.Configurations.Add(new ShippingMapping());
            modelBuilder.Configurations.Add(new ShipCategoryMapping());
            modelBuilder.Configurations.Add(new AdminRoleMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserRoleMapping());
            modelBuilder.Configurations.Add(new VehicleMapping());
            modelBuilder.Configurations.Add(new CompanyMapping());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        //public DbSet<DriverVehicle> DriverVehicles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShipCategory> ShipCategories { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        
        public DbSet<Company> Companies { get; set; }
    }
}
