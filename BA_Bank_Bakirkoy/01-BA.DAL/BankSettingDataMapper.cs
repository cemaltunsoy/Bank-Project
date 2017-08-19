using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BA.DAL
{
    public class BankSettingDataMapper:BaseDbWorker<BankSetting>
    {
        BA_BankDbContext db;
        public int GetTempCC()
        {
            using (db = new BA_BankDbContext())
            {
                return db.BankSetting.ToList().LastOrDefault().TempCC;
            }
        }

        public BankSetting GetActualSettings()
        {
            using (db = new BA_BankDbContext())
            {
                return db.BankSetting.ToList().LastOrDefault();
            }
        }

    }

    
}
