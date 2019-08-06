using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class City : BaseEntity
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        public string Name { get; set; }

        //Foreign Keys
        public int CountryID { get; set; }

        //Nav Props
        public virtual ICollection<District> Districts { get; set; }
        public virtual Country Country { get; set; }
    }
}
