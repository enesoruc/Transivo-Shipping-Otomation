using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class Message : BaseEntity
    {
       
        public int CompanyID { get; set; }
        public int UserID { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public string Detail { get; set; }

    }
}
