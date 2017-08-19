using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BA.Entity
{
    public class BankSchedule
    {
        public int ID { get; set; }
        //Acilis
        public DateTime Open { get; set; }
        //YemekBas.
        public DateTime LaunchBreakStart { get; set; }
        //YemekBitis
        public DateTime LaunchBreakEnd { get; set; }
        //Kapanis
        public DateTime Close { get; set; }
    }
}
