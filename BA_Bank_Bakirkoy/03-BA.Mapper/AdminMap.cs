using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BA.Mapper
{
    public class AdminMap:EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            this.HasKey(a => a.ID);
            this.Property(a => a.Username).IsRequired().HasColumnName("Username").HasColumnType("nvarchar").HasMaxLength(20);
            this.Property(a => a.Password).IsRequired().HasColumnName("Password").HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
