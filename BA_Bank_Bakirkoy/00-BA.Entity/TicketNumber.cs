using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BA.Entity
{
    public class TicketNumber
    {
        // ID
        public int ID { get; set; }

        // No
        public int Number { get; set; }

        // CustomerID
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        // AlinmaTarih
        public DateTime TakenDate { get; set; }

        // Islendi Mi?
        public bool IsProcessed { get; set; }
    }
}
