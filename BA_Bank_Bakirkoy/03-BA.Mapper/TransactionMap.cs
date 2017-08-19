using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BA.Mapper
{
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            this.HasKey(a => a.ID);
            this.Property(a => a.TransactionStart).IsRequired().HasColumnName("TransactionStart").HasColumnType("Datetime");
            this.Property(a => a.TransactionEnd).IsRequired().HasColumnName("TransactionEnd").HasColumnType("Datetime");
            this.HasOptional(a => a.TicketNumber).WithRequired().Map(m => m.MapKey("TicketID"));
        }
    }
}
