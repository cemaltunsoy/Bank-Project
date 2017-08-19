using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_BA.Entity
{
    public class Admin
    {
        // Otomatik ID
        public int ID { get; set; }
        
        // Kullanici Adi
        public string Username { get; set; }

        // Password
        public string Password { get; set; }
    }
}
