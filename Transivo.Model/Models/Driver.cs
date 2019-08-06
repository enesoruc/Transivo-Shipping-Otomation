using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class Driver: BaseEntity
    {
        public Driver()
        {
            HasVehicle = false;
        }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string TC { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Phone { get; set; }        
        public string EMail { get; set; }
        public bool HasVehicle { get; set; }

        public int VehicleID { get; set; }
        public int CompanyID { get; set; }
        //Nav Props
        public virtual Vehicle Vehicle { get; set; }
        public virtual Company Company { get; set; }
    }
}
