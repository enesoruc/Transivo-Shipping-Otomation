using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public string Name { get; set; }

        //Foreign Keys

        //Nav Props
        public virtual ICollection<City> Cities { get; set; }
    }
}
