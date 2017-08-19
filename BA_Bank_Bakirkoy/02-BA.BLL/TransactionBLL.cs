using _00_BA.Entity;
using _01_BA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BA.BLL
{
    public class TransactionBLL
    {
        private TransactionDataMapper transactionDAL;
        public void CreateTransaction(Transaction transaction)
        {
            transactionDAL = new TransactionDataMapper();
            transactionDAL.Insert(transaction);
            //ticketNumberDAL.SaveChanges();
        }
    }
}
