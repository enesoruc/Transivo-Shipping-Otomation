using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class UserRole : BaseEntity
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public string RoleName { get; set; }

        //Nav Props
        public virtual ICollection<User> Users { get; set; }
    }
}
