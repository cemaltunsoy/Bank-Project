using _00_BA.Entity;
using _01_BA.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BA.BLL
{
    public class AdminBLL
    {
        private AdminDataMapper adminDAL;                      /// data mapperları kullanırken instance almayı unutma !.
        private CustomerDataMapper customerDAL;
        private TemporaryCustomerDataMapper tempCustomerDAL;
        private BankScheduleDataMapper bankScheduleDAL;
        private TicketNumberDataMapper ticketNumberDAL;
        private TransactionDataMapper transactionDAL;
        private CustomerBLL customerBLL;

        public bool IsValidLogin(Admin loggedAdmin)
        {
            adminDAL = new AdminDataMapper();
            if (String.IsNullOrWhiteSpace(loggedAdmin.Username))
                throw new FormatException("Kullanici adi bos gecilemez!");
            if (String.IsNullOrWhiteSpace(loggedAdmin.Password))
                throw new FormatException("Sifre bos gecilemez!");
            if (adminDAL.GetByAll(x => x.Username == loggedAdmin.Username && x.Password == loggedAdmin.Password).FirstOrDefault() == null)
                throw new FormatException("Gecersiz kullanici!");
            else
                return true;
        }

        public void AddCustomer(Customer customer)
        {
            customerBLL = new CustomerBLL();
            customerBLL.AddCustomer(customer);
        }

        public void SaveTemporaryCustomer(Customer customer)
        {
            customerDAL = new CustomerDataMapper();
            adminDAL = new AdminDataMapper();
            IsValidCustomer(customer);
            if (customer is VIPCustomer)
                adminDAL.SaveTemporaryCustomer(customer.Id, customer.SSN, customer.FirstName, customer.LastName, "VIPCustomer");
            if (customer is IndividualCustomer)
                adminDAL.SaveTemporaryCustomer(customer.Id, customer.SSN, customer.FirstName, customer.LastName, "IndividualCustomer");
            //adminDAL.SaveChanges();
        }

        private static void IsValidCustomer(Customer customer)
        {
            if (customer == null)
                throw new FormatException("Musteri bos olamaz!");
            if (String.IsNullOrWhiteSpace(customer.SSN))
                throw new ArgumentException("Musteri T.C. numarasi bos gecilemez!");
            if (String.IsNullOrWhiteSpace(customer.FirstName))
                throw new ArgumentException("Musteri adi bos gecilemez!");
            if (String.IsNullOrWhiteSpace(customer.LastName))
                throw new ArgumentException("Musteri soyadi bos gecilemez!");
        }

        // Gelen tum gecici musteriler. .Where(x => x.IsProcessed == true) sorgusunun eklenip eklenmeyecegine karar ver. Yani sadece sira alip islem yapanlar mi getirilsin.
        // DUzelt
        public List<TemporaryCustomer> GetTemporaryCustomers(DateTime date)
        {
            //if (date == null)
            //    date = DateTime.Today;
            //ticketNumberDAL = new TicketNumberDataMapper();
            //var result = ticketNumberDAL.GetByAll(x => DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(date)).Select(x => x.Customer).OfType<TemporaryCustomer>();
            //return result.ToList();
            transactionDAL = new TransactionDataMapper();
            var result2 = transactionDAL.GetByAll(x => DbFunctions.TruncateTime(x.TransactionStart) == DbFunctions.TruncateTime(date)).Select(x => x.TicketNumber).Select(x => x.Customer).OfType<TemporaryCustomer>().Where(x => x.IsRemoved == false).Distinct();
            return result2.ToList();
        }

        // Silinen gecici musteriler. Eger admin bos bir tarih gonderir ise otomatik olarak gun icerisinde silinmis olanlar getirilir.
        public List<TemporaryCustomer> GetRemovedTemporaryCustomers(DateTime date)
        {
            ////if (date == null)
            ////    date = DateTime.Today;
            //ticketNumberDAL = new TicketNumberDataMapper();
            //var result = ticketNumberDAL.GetByAll(x => DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(date)).Select(x => x.Customer).OfType<TemporaryCustomer>().Where(x => x.IsRemoved == true);
            //return result.ToList();
            tempCustomerDAL = new TemporaryCustomerDataMapper();
            //customerDAL = new CustomerDataMapper();
            var result = tempCustomerDAL.GetByAll(x => x.IsRemoved == true);
            return result.ToList();
        }

        // Geçici Müşteriyi silinmis olarak isaretle
        public void RemoveTemporaryCustomer(TemporaryCustomer tempCustomer)
        {
            tempCustomerDAL = new TemporaryCustomerDataMapper();
            tempCustomer.IsRemoved = true;
            tempCustomerDAL.Update(tempCustomer);
            //tempCustomerDAL.SaveChanges();
        }

        // Calisma saatlerini getir.
        public BankSchedule GetBankSchedule()
        {
            bankScheduleDAL = new BankScheduleDataMapper();
            return bankScheduleDAL.GetAll().ToList().LastOrDefault();
        }

        // Calışma saatlerini güncelle.
        public void SetSchedule(BankSchedule bankSchedule)
        {
            if (bankSchedule.Open >= bankSchedule.LaunchBreakStart)
                throw new Exception("Acilis saati, ogle arasi saatinden sonra olamaz!");
            if (bankSchedule.LaunchBreakStart >= bankSchedule.LaunchBreakEnd)
                throw new Exception("Ara giris saati, ara cikis saatinden sonra olamaz!");
            if (bankSchedule.LaunchBreakEnd >= bankSchedule.Close)
                throw new Exception("Ara cikis saati, cikis saatinden sonra olamaz!");

            bankScheduleDAL = new BankScheduleDataMapper();
            bankScheduleDAL.Update(bankSchedule);
            //bankScheduleDAL.SaveChanges();
        }

        // Sirada bekleyen musterileri getir.(gun icindeki);
        public List<TicketNumber> GetWaitingCustomers()
        {
            ticketNumberDAL = new TicketNumberDataMapper();
            var result = ticketNumberDAL.GetByAll(x => x.IsProcessed == false && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Today));
            return result.ToList();
        }

        // Suanda islem goren musterileri getir.
        public List<TicketNumber> GetCustomersOnCounter()
        {
            ticketNumberDAL = new TicketNumberDataMapper();
            transactionDAL = new TransactionDataMapper();
            var query = ticketNumberDAL.GetAll().Where(t => t.IsProcessed == true && 0 == (transactionDAL.GetByAll(x => x.TicketNumber.ID == t.ID).Count()));
            return query.ToList();
        }

        // Tarihe gore gelen vip musterileri sayisi.
        public int GetVIPCustomerCountByDate(DateTime date)
        {
            transactionDAL = new TransactionDataMapper();
            var vipCountQuery = transactionDAL.GetByAll(t => DbFunctions.TruncateTime(t.TransactionEnd) == DbFunctions.TruncateTime(date)).Select(x => x.TicketNumber.Customer).OfType<VIPCustomer>().Count();
            return vipCountQuery;
        }

        // Tarihe gore gelen gecici musteri sayisi.
        public int GetTemporaryCustomerCountByDate(DateTime date)
        {
            transactionDAL = new TransactionDataMapper();
            var temporaryCountQuery = transactionDAL.GetByAll(t => DbFunctions.TruncateTime(t.TransactionEnd) == DbFunctions.TruncateTime(date)).Select(x => x.TicketNumber.Customer).OfType<TemporaryCustomer>().Count();
            return temporaryCountQuery;
        }

        // Tarihe gore gelen bireysel musteri sayisi.
        public int GetIndividualCustomerCountByDate(DateTime date)
        {
            transactionDAL = new TransactionDataMapper();
            var individualCustomerCountQuery = transactionDAL.GetByAll(t => DbFunctions.TruncateTime(t.TransactionEnd) == DbFunctions.TruncateTime(date)).Select(x => x.TicketNumber.Customer).OfType<IndividualCustomer>().Count();
            return individualCustomerCountQuery;
        }

        // Ortalama sirada bekleme suresi.
        public TimeSpan GetAverageWaitingDuration()
        {
            transactionDAL = new TransactionDataMapper();
            return TimeSpan.FromSeconds(transactionDAL.GetAverageWaitingDuration());
        }

        // Ortalama islem suresi.
        public TimeSpan GetAverageTransactionDuration()
        {
            transactionDAL = new TransactionDataMapper();
            return TimeSpan.FromSeconds(transactionDAL.GetAverageTransactionDuration());

        }
    }
}