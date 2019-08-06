using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Core.Entity;

namespace Transivo.Model.Models
{
    public class AdminRole : BaseEntity
    {
        public AdminRole()
        {
            Admins = new HashSet<Admin>();

        }

        public string Name { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
    }
}
