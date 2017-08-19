using _00_BA.Entity;
using _01_BA.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BA.BLL
{
    public class NumaratorBLL
    {

        private TicketNumberDataMapper ticketNumberDAL = new TicketNumberDataMapper();
        private CounterBLL counterBLL = new CounterBLL();
        private TransactionDataMapper transactionDAL;
        private BankScheduleDataMapper bankScheduleDAL = new BankScheduleDataMapper();
        private CounterDataMapper counterDAL = new CounterDataMapper();
        private CustomerDataMapper customerDAL = new CustomerDataMapper();
        

        BankSchedule bankSchedule = new BankSchedule();
        List<Counter> ActiveCounters = new List<Counter>();

        public Customer GetCustomerBySSN(string SSN)
        {
            customerDAL = new CustomerDataMapper();
            Customer customer = customerDAL.GetBySSN(SSN);
            return customer;
        }

        public TicketNumber CreateTicketNumber(Customer customer)
        {
            ControlSchedulesForTicket();

            TicketNumber ticketNumber = new TicketNumber();

            ticketNumber.CustomerId = customer.Id;
            ticketNumber.Customer = customer;
            ticketNumber.IsProcessed = false;
            ticketNumber.TakenDate = DateTime.Now;
            ticketNumber.Number = GetTicketNumberByCustomerType(customer);

            ticketNumberDAL.Insert(ticketNumber);
            //ticketNumberDAL.SaveChanges();

            //AddToQueue(ticketNumber);

            return ticketNumber;
        }

        public double GetAvgTransactionDuration()
        {
            double avg = 0;
            transactionDAL = new TransactionDataMapper();
            // Artik bu method saniye dondurdugunden, formulun bozulmamasi icin burda gelen degeri 60.0 a boldum.
            avg = transactionDAL.GetAverageTransactionDuration() / 60.0;
            return avg;
        }

        public int GetCountOfWaitingCustomers()
        {
            return customerDAL.GetCountOfWaitingCustomers();
        }

        public int GetCountOfCustomersOnCounter()
        {
            return customerDAL.GetCountOfCustomersOnCounter();
        }

        public bool ControlSchedulesForTicket()
        {
            bool control = false;
            ActiveCounters.Clear();
            ActiveCounters = counterDAL.GetActiveCounters();
            int ActiveCounterCount = ActiveCounters.Count;
            int OnCounterTicketNumberCount = GetCountOfCustomersOnCounter();
            int WaitingCustomerCount = GetCountOfWaitingCustomers();
            double avgTransactionDuration = GetAvgTransactionDuration();
            //int InProcessCounter=counterBLL.GetInProcessCounters().Count;
            double EstimatedTotalTransactionTime = GetAvgTransactionDuration();
            bankSchedule = bankScheduleDAL.GetActualBankSchedule();
            if (ActiveCounterCount == 0)
                throw new Exception("Aktif gişe olmadığı için sıra verilemiyor.");
            if (OnCounterTicketNumberCount != 0)
                //EstimatedTotalTransactionTime = (OnCounterTicketNumberCount * avgTransactionDuration / OnCounterTicketNumberCount);
                EstimatedTotalTransactionTime = avgTransactionDuration;
            if (WaitingCustomerCount != 0)
                EstimatedTotalTransactionTime += ((WaitingCustomerCount * avgTransactionDuration) / ActiveCounterCount);
            //else
            // 
            //    EstimatedTotalTransactionTime = 0.0;

            if (DateTime.Now.TimeOfDay < bankSchedule.LaunchBreakStart.TimeOfDay && DateTime.Now.TimeOfDay > bankSchedule.Open.TimeOfDay)
            {
                if (EstimatedTotalTransactionTime < (bankSchedule.LaunchBreakStart.TimeOfDay - DateTime.Now.TimeOfDay).TotalMinutes)
                {
                    control = true;
                }
                else
                    throw new Exception("Sıra verilemiyor. Öğleden önceki işlem kapasitesi dolmuştur!");
            }
            else if (DateTime.Now.TimeOfDay < bankSchedule.Close.TimeOfDay && DateTime.Now.TimeOfDay > bankSchedule.LaunchBreakEnd.TimeOfDay)
                if (EstimatedTotalTransactionTime < (bankSchedule.Close.TimeOfDay - DateTime.Now.TimeOfDay).TotalMinutes)
                {
                    control = true;
                }
                else
                    throw new Exception("Sıra verilemiyor. Bugünkü işlem kapasitesi dolmuştur!");
            else
                throw new Exception("Banka calisma saatleri disinda sira alinamaz!");

            return control;
        }

        //public List<TicketNumber> GetWaitingCustomers()
        //{
        //    ticketNumberDAL = new TicketNumberDataMapper();
        //    var result = ticketNumberDAL.GetByAll(x => x.IsProcessed == false && DbFunctions.TruncateTime(x.TakenDate) == DbFunctions.TruncateTime(DateTime.Today));
        //    return result.ToList();
        //}
        //public List<TicketNumber> GetCustomersOnCounter()
        //{
        //    ticketNumberDAL = new TicketNumberDataMapper();
        //    transactionDAL = new TransactionDataMapper();
        //    var query = ticketNumberDAL.GetAll().Where(t => t.IsProcessed == true && 0 == (transactionDAL.GetByAll(x => x.TicketNumber.ID == t.ID).Count()));
        //    return query.ToList();
        //}

        private int GetTicketNumberByCustomerType(Customer customer)
        {
            //ticketNumberDAL = new TicketNumberDataMapper();
            int Number = 0;
            if (customer is VIPCustomer)
                Number = ticketNumberDAL.GetLastVipNumber();
            else if (customer is IndividualCustomer)
                Number = ticketNumberDAL.GetLastIndividualNumber();
            else if (customer is TemporaryCustomer)
                Number = ticketNumberDAL.GetLastTemporaryNumber();

            return Number;
        }

        /// <summary>
        /// Alttaki methodlar GetTicketNumberByCustomerType() methodunda If icerisinde kullaniliyordu, gerek olmadi icin (customer is X) kullanilmi ile degistirildi.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        //public bool isVipCustomer(Customer customer)
        //{
        //    bool result = false;
        //    if (customer is VIPCustomer)
        //        result = true;
        //    return result;
        //}

        //public bool isIndividualCustomer(Customer customer)
        //{
        //    bool result = false;
        //    if (customer is IndividualCustomer)
        //        result = true;
        //    return result;
        //}

        //public bool isTemporaryCustomer(Customer customer)
        //{
        //    bool result = false;
        //    if (customer is TemporaryCustomer)
        //        result = true;
        //    return result;
        //}

        /// <summary>
        /// Kullanilmiyor.
        /// </summary>
        /// <returns></returns>
        //public List<TicketNumber> ticketlist()
        //{
        //    ticketNumberDAL = new TicketNumberDataMapper();
        //    return ticketNumberDAL.GetAll();
        //}

        /// <summary>
        /// Kullanilmiyor.
        /// </summary>
        /// <returns></returns>
        //public TicketNumber GetLastTicketNumber()
        //{
        //    return ticketNumberDAL.GetAll().ToList().LastOrDefault();
        //}
    }
}
