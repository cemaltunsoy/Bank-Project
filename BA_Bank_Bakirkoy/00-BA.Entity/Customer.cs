using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BA.Entity
{
    public abstract class Customer
    {
        //public Customer()
        //{
        //    this.TicketNumbers = new HashSet<TicketNumber>();
        //}
        public int Id { get; set; }

        // T.C. No
        public string SSN { get; set; }

        // Ad
        public string FirstName { get; set; }

        // Soyad
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        //public virtual ICollection<TicketNumber> TicketNumbers { get; set; }
    }
}
