using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BA.Mapper
{
    public class BankScheduleMap : EntityTypeConfiguration<BankSchedule>
    {
        public BankScheduleMap()
        {
            this.HasKey(a => a.ID);
            this.Property(a => a.Open).HasColumnName("Open").HasColumnType("datetime");
            this.Property(a => a.Close).HasColumnName("Close").HasColumnType("datetime");
            this.Property(a => a.LaunchBreakStart).HasColumnName("LaunchBreakStart").HasColumnType("datetime");
            this.Property(a => a.LaunchBreakEnd).HasColumnName("LaunchBreakEnd").HasColumnType("datetime");
        }
    }
}
