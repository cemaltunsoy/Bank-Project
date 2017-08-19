using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace _01_BA.DAL
{
    public class TransactionDataMapper : BaseDbWorker<Transaction>
    {
        BA_BankDbContext db;

        public override void Insert(Transaction entity)
        {
            using (db = new BA_BankDbContext())
            {
                db.Entry<Counter>(entity.Counter).State = System.Data.Entity.EntityState.Unchanged;
                db.Entry<TicketNumber>(entity.TicketNumber).State = System.Data.Entity.EntityState.Unchanged;
                db.Transaction.Add(entity);
                db.SaveChanges();
            }
        }
        public double GetAverageTransactionDuration()
        {

            using (db = new BA_BankDbContext())
            {
                var query = 0.0;
                if (db.Transaction.Count(x => DbFunctions.TruncateTime(x.TransactionEnd) == DbFunctions.TruncateTime(DateTime.Now)) != 0)
                {
                    query = this.GetAll().Average(x => (x.TransactionEnd - x.TransactionStart).TotalSeconds);

                }
                return query;
            }
        }
        public double GetAverageWaitingDuration()
        {

            using (db = new BA_BankDbContext())
            {
                var query = 0.0;
                if (db.Transaction.Count(x => DbFunctions.TruncateTime(x.TransactionEnd) == DbFunctions.TruncateTime(DateTime.Now)) != 0)
                {
                    query = this.GetAll().Average(x => (x.TransactionStart - x.TicketNumber.TakenDate).TotalSeconds);
                }
                return query;
            }
        }
        public override List<Transaction> GetAll()
        {
            using (db = new BA_BankDbContext())
            {
                return db.Transaction.Include("TicketNumber").Include("Counter").Include("TicketNumber.Customer").ToList();
            }
        }
        public override List<Transaction> GetByAll(System.Linq.Expressions.Expression<Func<Transaction, bool>> exprs)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        return db.Set<Transaction>().Include("TicketNumber").Include("Counter").Include("TicketNumber.Customer").Where(exprs).ToList();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;
                        throw;
                    }
                } while (saveFailed);
            }
        }
    }
}
