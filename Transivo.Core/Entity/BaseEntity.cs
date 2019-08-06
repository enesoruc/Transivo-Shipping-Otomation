using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Core.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
