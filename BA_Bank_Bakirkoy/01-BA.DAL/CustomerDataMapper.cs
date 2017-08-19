using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _01_BA.DAL
{
    public class CustomerDataMapper : BaseDbWorker<Customer>
    {
        BA_BankDbContext db;
        public Customer GetBySSN(string SSN)
        {
            using (db = new BA_BankDbContext())
            {
                return base.GetByAll(x => x.SSN == SSN).FirstOrDefault();
            }
        }

        public int GetCountOfCustomersOnCounter()
        {
            using (db = new BA_BankDbContext())
            {
                return db.TicketNumber.Where(t => t.IsProcessed == true && 0 == (db.Transaction.Where(x => x.TicketNumber.ID == t.ID).Count())).Count();
            }
        }

        public int GetCountOfWaitingCustomers()
        {
            using (db = new BA_BankDbContext())
            {
                //ticketNumberDAL.GetByAll(x => x.IsProcessed == false && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Today));
                return db.TicketNumber.Where(x => x.IsProcessed == false && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Today)).Count();
            }
        }
    }
}
