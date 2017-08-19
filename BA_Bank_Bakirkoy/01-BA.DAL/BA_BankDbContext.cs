using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_BA.Entity;
using _03_BA.Mapper;

namespace _01_BA.DAL
{
    public class BA_BankDbContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BankSchedule> BankSchedule { get; set; }
        public DbSet<Counter> Coutner { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TicketNumber> TicketNumber { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<BankSetting> BankSetting { get; set; }

        public BA_BankDbContext()
            : base("BA_BankConn")
        {
            //Database.SetInitializer(new BA_BankDbInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new BankScheduleMap());
            modelBuilder.Configurations.Add(new CounterMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new TicketNumberMap());
            modelBuilder.Entity<IndividualCustomer>().ToTable("IndividualCustomer");
            modelBuilder.Entity<VIPCustomer>().ToTable("VIPCustomer");
            modelBuilder.Entity<TemporaryCustomer>().ToTable("TemporaryCustomer");

            //modelBuilder.Entity<Customer>().MapToStoredProcedures(s =>
            //{
            //    s.Update(u => u.HasName("update_customer")
            //        .Parameter(p => p.SSN, "customer_SSN")
            //        .Parameter(p => p.FirstName, "customer_FirstName")
            //        .Parameter(p => p.LastName, "customer_LastName"));
            //    s.Insert(i => i.HasName("insert_customer")
            //        .Parameter(p => p.Id, "customer_Id"));
            //    s.Delete(d => d.HasName("delete_customer")
            //        .Parameter(p => p.Id, "customer_ID"));
            //});
            //modelBuilder.Configurations.Add(new VIPCustomerMap());
            //modelBuilder.Configurations.Add(new TemporaryCustomerMap());
            //modelBuilder.Configurations.Add(new IndividualCustomerMap());
        }
    }
}
