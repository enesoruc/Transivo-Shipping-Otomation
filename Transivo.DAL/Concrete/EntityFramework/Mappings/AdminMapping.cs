﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transivo.Model.Models;

namespace Transivo.DAL.Concrete.EntityFramework.Mappings
{
    public class AdminMapping : EntityTypeConfiguration<Admin>
    {
        public AdminMapping()
        {
          
            Property(a => a.EMail).HasMaxLength(255);
            Property(a => a.Password).HasMaxLength(20);
            Property(a => a.Username).HasMaxLength(30);
        }
    }
}
