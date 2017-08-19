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
    public class TicketNumberDataMapper : BaseDbWorker<TicketNumber>
    {
        BA_BankDbContext db;
        public override void Insert(TicketNumber entity)
        {
            using (db = new BA_BankDbContext())
            {
                db.Entry<Customer>(entity.Customer).State = System.Data.Entity.EntityState.Unchanged;
                db.TicketNumber.Add(entity);
                db.SaveChanges();
            }
        }

        public List<TicketNumber> GetUnProcessedTicketNumbers()
        {
            using (db = new BA_BankDbContext())
            {
                return base.db.TicketNumber.Include("Customer").Where(x => x.IsProcessed == false).ToList();
            }
        }

        public int GetLastVipNumber()
        {
            using (db = new BA_BankDbContext())
            {
                if (this.GetByAll(x => x.Number > 999 && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Now)).ToList().LastOrDefault() != null)
                    return this.GetByAll(x => x.Number > 999 && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Now)).ToList().LastOrDefault().Number + 1;
                else
                    return 1000;
            }
        }

        public int GetLastIndividualNumber()
        {
            using (db = new BA_BankDbContext())
            {
                if (this.GetByAll(x => x.Number > 499 && x.Number < 999 && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Now)).ToList().LastOrDefault() != null)
                    return this.GetByAll(x => x.Number > 499 && x.Number < 999 && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Now)).ToList().LastOrDefault().Number + 1;
                else
                    return 500;
            }
        }

        public int GetLastTemporaryNumber()
        {
            using (db = new BA_BankDbContext())
            {
                if (this.GetByAll(x => x.Number > 0 && x.Number < 499 && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Now)).ToList().LastOrDefault() != null)
                    return this.GetByAll(x => x.Number > 0 && x.Number < 499 && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Now)).ToList().LastOrDefault().Number + 1;
                else
                    return 1;
            }
        }

        public List<TicketNumber> GetCurrentCustomers()
        {
            using (db = new BA_BankDbContext())
            {
                var query = db.TicketNumber.Where(t => t.IsProcessed == true && (db.Transaction.Where(x => x.TicketNumber == t).Count() == 0));
                return query.ToList();
            }
        }

        public override List<TicketNumber> GetAll()
        {
            using (db = new BA_BankDbContext())
            {
                return db.TicketNumber.Include("Customer").ToList();
            }
        }

        public override List<TicketNumber> GetByAll(System.Linq.Expressions.Expression<Func<TicketNumber, bool>> exprs)
        {
            using (db = new BA_BankDbContext())
            {
                bool saveFailed = false;
                do
                {
                    try
                    {
                        return db.Set<TicketNumber>().Include("Customer").Where(exprs).ToList();
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
