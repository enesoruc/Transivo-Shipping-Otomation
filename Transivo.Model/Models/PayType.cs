using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class PayType : BaseEntity
    {
        public PayType()
        {
            Shippings = new HashSet<Shipping>();
        }

        public string TypeName { get; set; }

        //Foreign Key

        //Nav Props
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
