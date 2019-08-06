using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Core.Entity;

namespace Transivo.Model.Models
{
    public class ShipCategory : BaseEntity
    {
        public ShipCategory()
        {
            Shippings = new HashSet<Shipping>();
        }

        public string Name { get; set; }

        //Foreign Key

        //Nav Props
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
