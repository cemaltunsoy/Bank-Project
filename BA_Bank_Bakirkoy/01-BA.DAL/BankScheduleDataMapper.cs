using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BA.DAL
{
    public class BankScheduleDataMapper : BaseDbWorker<BankSchedule>
    {
        BA_BankDbContext db;
        public BankSchedule GetActualBankSchedule()
        {
            using (db = new BA_BankDbContext())
            {
                BankSchedule bankSchedule = new BankSchedule();

                bankSchedule = db.BankSchedule.ToList().LastOrDefault();

                if (bankSchedule == null)
                {
                    bankSchedule.Open = Convert.ToDateTime("0001-01-01 9:00:00");
                    bankSchedule.LaunchBreakStart = Convert.ToDateTime("0001-01-01 12:00:00");
                    bankSchedule.LaunchBreakEnd = Convert.ToDateTime("0001-01-01 13:00:00");
                    bankSchedule.Close = Convert.ToDateTime("0001-01-01 17:00:00");
                }
                return bankSchedule;
            }
        }
    }
}
