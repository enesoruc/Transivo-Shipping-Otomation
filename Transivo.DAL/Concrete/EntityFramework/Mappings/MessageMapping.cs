using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class MessageMapping : EntityTypeConfiguration<Message>
    {

        public MessageMapping()
        {
            Property(a => a.Detail).HasMaxLength(500).HasColumnName("Detail");
            //Has
            //HasKey(a => new
            //{
            //    a.ID,
            //    a.CompanyID,
            //    a.UserID,
            //});
        }
    }
}
