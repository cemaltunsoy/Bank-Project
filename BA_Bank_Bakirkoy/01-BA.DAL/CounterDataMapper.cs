using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BA.DAL
{
    public class CounterDataMapper : BaseDbWorker<Counter>
    {
        //BA_BankDbContext db = new BA_BankDbContext();
        public Counter CounterControl(Counter counter)
        {
            using (db = new BA_BankDbContext())
            {
                return db.Coutner.Where(x => x.No == counter.No && x.Password == counter.Password).FirstOrDefault();
            }
        }
        public List<Counter> GetActiveCounters()  // aktif gişeler
        {
            using (db = new BA_BankDbContext())
            {
                return db.Coutner.Where(x => x.isActive == true).ToList();
            }
        }

        public List<Counter> GetIdleCounters()    // şu anda işlem yapılmayan gişeler
        {
            using (db = new BA_BankDbContext())
            {
                return GetActiveCounters().Where(x => x.Transactions.LastOrDefault() == null && x.Transactions.LastOrDefault().TransactionEnd != null).ToList();
            }
        }

        public List<Counter> GetInProcessCounters()    // şu anda işlem yapılan gişeler
        {
            using (db = new BA_BankDbContext())
            {
                return GetActiveCounters().Where(x => x.Transactions.LastOrDefault() != null && x.Transactions.LastOrDefault().TransactionEnd == null).ToList();
            }
        }
    }
}
