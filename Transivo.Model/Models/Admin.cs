using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class Admin: BaseEntity//Name i DB'ayağa kalkerken CompanyName yap
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        //ForeignKey
        public int AdminRoleID { get; set; }
        public int CompanyID { get; set; }
        //Nav Props
        public virtual Company Company { get; set; }
        public virtual AdminRole AdminRole { get; set; }
       
    }
}
