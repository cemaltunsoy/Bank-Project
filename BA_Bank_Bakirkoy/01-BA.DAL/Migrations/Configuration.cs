namespace _01_BA.DAL.Migrations
{
    using _00_BA.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<_01_BA.DAL.BA_BankDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_01_BA.DAL.BA_BankDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            Admin admin = new Admin();
            admin.Username = "admin";
            admin.Password = "admin";
            context.Admin.AddOrUpdate(admin);

            BankSetting bankSetting = new BankSetting();
            bankSetting.TempCC = 0;
            context.BankSetting.AddOrUpdate(bankSetting);

            BankSchedule bankSchedule = new BankSchedule();
            bankSchedule.Open = new DateTime(2000, 01, 01, 8, 0, 0);
            bankSchedule.Close = new DateTime(2000, 01, 01, 17, 0, 0);
            bankSchedule.LaunchBreakStart = new DateTime(2000, 01, 01, 12, 00, 0);
            bankSchedule.LaunchBreakEnd = new DateTime(2000, 01, 01, 13, 0, 0);
            context.BankSchedule.AddOrUpdate(bankSchedule);

            Counter counter = new Counter();
            counter.No = "1";
            counter.Password = "123";
            context.Coutner.AddOrUpdate(counter);

            //TemporaryCustomer tempCus1 = new TemporaryCustomer() { SSN = "12345678911", FirstName = "TempCus1", LastName = "TemCus1", IsRemoved = false };
            //TemporaryCustomer tempCus2 = new TemporaryCustomer() { SSN = "12345678912", FirstName = "TempCus2", LastName = "TemCus2", IsRemoved = false };
            //TemporaryCustomer tempCus3 = new TemporaryCustomer() { SSN = "12345678913", FirstName = "TempCus3", LastName = "TemCus3", IsRemoved = false };

            //context.Customer.AddOrUpdate(tempCus1);
            //context.Customer.AddOrUpdate(tempCus2);
            //context.Customer.AddOrUpdate(tempCus3);

            //VIPCustomer vipCus1 = new VIPCustomer() { SSN = "12345678914", FirstName = "VIPCus1", LastName = "VIPCus1" };
            //VIPCustomer vipCus2 = new VIPCustomer() { SSN = "12345678915", FirstName = "VIPCus2", LastName = "VIPCus2" };
            //VIPCustomer vipCus3 = new VIPCustomer() { SSN = "12345678916", FirstName = "VIPCus3", LastName = "VIPCus3" };

            //context.Customer.AddOrUpdate(vipCus1);
            //context.Customer.AddOrUpdate(vipCus2);
            //context.Customer.AddOrUpdate(vipCus3);

            //IndividualCustomer indvCus1 = new IndividualCustomer() { SSN = "12345678917", FirstName = "IndvCus1", LastName = "IndvCus1" };
            //IndividualCustomer indvCus2 = new IndividualCustomer() { SSN = "12345678918", FirstName = "IndvCus2", LastName = "IndvCus2" };
            //IndividualCustomer indvCus3 = new IndividualCustomer() { SSN = "12345678919", FirstName = "IndvCus3", LastName = "IndvCus3" };

            //context.Customer.AddOrUpdate(indvCus1);
            //context.Customer.AddOrUpdate(indvCus2);
            //context.Customer.AddOrUpdate(indvCus3);

            //TicketNumber ticket1 = new TicketNumber() { Customer = tempCus1, IsProcessed = false, Number = 1, TakenDate = Convert.ToDateTime("2017-05-28 14:20:00") };
            //TicketNumber ticket2 = new TicketNumber() { Customer = tempCus2, IsProcessed = true, Number = 2, TakenDate = Convert.ToDateTime("2017-05-28 13:10:00") };
            //TicketNumber ticket3 = new TicketNumber() { Customer = tempCus3, IsProcessed = true, Number = 3, TakenDate = Convert.ToDateTime("2017-05-28 9:18:00") };
            //TicketNumber ticket4 = new TicketNumber() { Customer = vipCus1, IsProcessed = false, Number = 1000, TakenDate = Convert.ToDateTime("2017-05-28 11:30:00") };
            //TicketNumber ticket5 = new TicketNumber() { Customer = indvCus1, IsProcessed = true, Number = 500, TakenDate = Convert.ToDateTime("2017-05-28 10:35:00") };

            //context.TicketNumber.AddOrUpdate(ticket1);
            //context.TicketNumber.AddOrUpdate(ticket2);
            //context.TicketNumber.AddOrUpdate(ticket3);
            //context.TicketNumber.AddOrUpdate(ticket4);
            //context.TicketNumber.AddOrUpdate(ticket5);

            //Transaction transaction1 = new Transaction() { Counter = counter, TicketNumber = ticket2, TransactionStart = Convert.ToDateTime("2017-05-28 13:30:00"), TransactionEnd = Convert.ToDateTime("2017-05-28 13:35:00") };
            //Transaction transaction2 = new Transaction() { Counter = counter, TicketNumber = ticket5, TransactionStart = Convert.ToDateTime("2017-05-28 10:55:00"), TransactionEnd = Convert.ToDateTime("2017-05-28 11:02:00") };

            //context.Transaction.AddOrUpdate(transaction1);
            //context.Transaction.AddOrUpdate(transaction2);
            CreateStoredProcedureUpdateUsageCosts(context);
        }
        private void CreateStoredProcedureUpdateUsageCosts(BA_BankDbContext context)
        {
            var x = new StringBuilder();
            x.AppendLine(@"CREATE PROC sp_ChangeTemporaryCustomerType");
            x.AppendLine(@"@c_ID int,");
            x.AppendLine(@"@c_SSN nvarchar(11),");
            x.AppendLine(@"@c_firstName nvarchar(30),");
            x.AppendLine(@"@c_lastName nvarchar(20),");
            x.AppendLine(@"@c_customerType nvarchar(50)");
            x.AppendLine(@"AS");
            x.AppendLine(@"BEGIN");
            x.AppendLine(@"BEGIN TRY");
            x.AppendLine(@"BEGIN TRAN");
            x.AppendLine(@"UPDATE Customers SET");
            x.AppendLine(@"SSN = @c_SSN,");
            x.AppendLine(@"FirstName = @c_firstName,");
            x.AppendLine(@"LastName = @c_lastName");
            x.AppendLine(@"WHERE Id = @c_ID");
            x.AppendLine(@"IF (@c_customerType = 'IndividualCustomer')");
            x.AppendLine(@"BEGIN");
            x.AppendLine(@"INSERT INTO IndividualCustomer(Id) VALUES (@c_ID)");
            x.AppendLine(@"END");
            x.AppendLine(@"IF (@c_customerType = 'VIPCustomer')");
            x.AppendLine(@"BEGIN");
            x.AppendLine(@"INSERT INTO VIPCustomer(Id) VALUES (@c_ID)");
            x.AppendLine(@"END");
            x.AppendLine(@"DELETE FROM TemporaryCustomer WHERE Id= @c_ID");
            x.AppendLine(@"COMMIT TRAN");
            x.AppendLine(@"END TRY");
            x.AppendLine(@"BEGIN CATCH");
            x.AppendLine(@"ROLLBACK TRAN");
            x.AppendLine(@"END CATCH");
            x.AppendLine(@"END");
            context.Database.ExecuteSqlCommand(x.ToString());
        }
    }
}
