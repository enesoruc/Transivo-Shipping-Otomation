using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Core.Entity;
using Transivo.Model.Enums;

namespace Transivo.Model.Models
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Users = new HashSet<User>();
            //Type = AddressType.Delivery;
        }

        public string Name { get; set; }
        public string AddresssDetail { get; set; }
        //public AddressType Type { get; set; }

        //Foreign Keys
        public int DistrictID { get; set; }

        //Nav Props
        public virtual District District { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
