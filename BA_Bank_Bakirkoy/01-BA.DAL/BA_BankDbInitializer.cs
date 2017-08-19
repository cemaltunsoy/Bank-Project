using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace _01_BA.DAL
{
    public class BA_BankDbInitializer : DropCreateDatabaseIfModelChanges<BA_BankDbContext>
    {
        protected override void Seed(BA_BankDbContext context)
        {
            //Admin admin = new Admin();
            //admin.Username = "admin";
            //admin.Password = "admin";

            //context.Admin.AddOrUpdate(admin);
            ////context.SaveChanges();     // ????

            //BankSchedule bankSchedule = new BankSchedule();
            //bankSchedule.Open = Convert.ToDateTime("0001-01-01 9:00:00");
            //bankSchedule.LaunchBreakStart = Convert.ToDateTime("0001-01-01 12:00:00");
            //bankSchedule.LaunchBreakEnd = Convert.ToDateTime("0001-01-01 13:00:00");
            //bankSchedule.Close = Convert.ToDateTime("0001-01-01 17:00:00");

            //context.BankSchedule.AddOrUpdate(bankSchedule);

            //Counter counter = new Counter();
            //counter.No = "1";
            //counter.Password = "123";

            //context.Coutner.AddOrUpdate(counter);

            //base.Seed(context);
        }
    }
}
