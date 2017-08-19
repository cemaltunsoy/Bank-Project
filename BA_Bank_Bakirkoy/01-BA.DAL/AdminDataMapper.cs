using _00_BA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _01_BA.DAL
{
    public class AdminDataMapper : BaseDbWorker<Admin>
    {
        //BA_BankDbContext db = new BA_BankDbContext();
        // Don't need it here. Instead moved expreesion to BLL layer.
        //public Admin AdminControl(Admin admin)
        //{
        //    return db.Admin.Where(x => x.Username == admin.Username && x.Password == admin.Password).FirstOrDefault();
        //}

        public void SaveTemporaryCustomer(int id, string ssn, string firstname, string lastname, string customerType)
        {
            using (db = new BA_BankDbContext())
            {
                db.Database.ExecuteSqlCommandAsync("sp_ChangeTemporaryCustomerType @c_ID, @c_SSN, @c_FirstName, @c_LastName, @c_customerType",
                          new SqlParameter("@c_ID", id),
                          new SqlParameter("@c_SSN", ssn),
                          new SqlParameter("@c_FirstName", firstname),
                          new SqlParameter("@c_LastName", lastname),
                          new SqlParameter("@c_customerType", customerType)
                          ).Wait();
                db.SaveChanges();
            }
        }
    }
}
