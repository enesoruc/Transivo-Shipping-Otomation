using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Core.Entity;

namespace Transivo.Model.Models
{
   public class Company : BaseEntity
    {
        public Company()
        {
            Vehicles = new HashSet<Vehicle>();
            Shippings = new HashSet<Shipping>();
            Messages = new HashSet<Message>();
            Admins = new HashSet<Admin>();
            Drivers = new HashSet<Driver>();
        }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string TaxNumber { get; set; }
        public decimal Freight { get; set; }
        public string LogoPath { get; set; }
        public string About { get; set; }
        public decimal? TotalEarnings { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
