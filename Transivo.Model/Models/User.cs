using Transivo.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transivo.Model.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Shippings = new HashSet<Shipping>();
            Messages = new HashSet<Message>();
            TotalPayment = 0;
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public DateTime? MemberDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public decimal TotalPayment { get; set; }


        //ForeignKey
        public int UserRoleID { get; set; }
        public int? AddressID { get; set; }

        //Nav Props
        public virtual UserRole UserRole { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
