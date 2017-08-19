using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BA.Mapper
{
    public class TicketNumberMap : EntityTypeConfiguration<TicketNumber>
    {
        public TicketNumberMap()
        {
            this.HasKey(a => a.ID);
            this.Property(a => a.IsProcessed).HasColumnName("IsProcessed").IsRequired();
        }
    }
}
