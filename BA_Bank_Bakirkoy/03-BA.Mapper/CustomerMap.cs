using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BA.Mapper
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasKey(a => a.Id);
            this.Property(a => a.SSN).IsRequired().HasColumnName("SSN").HasColumnType("nvarchar").HasMaxLength(11).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_SSN", 1) { IsUnique = true }));
            this.Property(a => a.FirstName).IsRequired().HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(30);
            this.Property(a => a.LastName).IsRequired().HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(20);
            //this.HasMany(a => a.TicketNumbers).WithOptional(a => a.Customer).Map(m => m.MapKey("CustomerID"));
        }
    }
}
