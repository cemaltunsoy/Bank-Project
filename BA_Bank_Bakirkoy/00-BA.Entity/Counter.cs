using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BA.Entity
{
    public class Counter
    {
        public Counter()
        {
            this.Transactions = new HashSet<Transaction>();
        }
        // ID
        public int ID { get; set; }
        // Counter No
        public string No { get; set; }
        // Password
        public string Password { get; set; }

        public bool isActive { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
