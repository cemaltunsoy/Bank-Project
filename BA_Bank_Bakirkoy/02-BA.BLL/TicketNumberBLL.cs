using _00_BA.Entity;
using _01_BA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BA.BLL
{
    public class TicketNumberBLL
    {
        TicketNumberDataMapper _ticketNumberDAL;
        public TicketNumber GetTicketNumber(int TicketNumber)
        {
            _ticketNumberDAL = new TicketNumberDataMapper();
            return _ticketNumberDAL.GetById(TicketNumber);
        }
    }
}
