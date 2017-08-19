using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BA.Entity
{
    public class Transaction
    {
        // Id
        public int ID { get; set; }

        // Baslangic - Bitis
        public DateTime TransactionStart { get; set; }
        public DateTime TransactionEnd { get; set; }

        // Ticket Id
        public int TicketNumberId { get; set; }
        public virtual TicketNumber TicketNumber { get; set; }

        // Counter No
        public int CounterId { get; set; }
        public virtual Counter Counter { get; set; }
    }
}
