using _00_BA.Entity;
using _01_BA.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace _02_BA.BLL
{
    public class CounterBLL
    {
        private CustomerDataMapper customerDAL = new CustomerDataMapper();
        private CounterDataMapper counterDAL = new CounterDataMapper();
        private TicketNumberDataMapper ticketNumberDAL = new TicketNumberDataMapper();
        private BankSettingDataMapper bankSettDal = new BankSettingDataMapper();
        public Counter IsValidLogin(Counter loggedCounter)
        {
            if (String.IsNullOrWhiteSpace(loggedCounter.No))
                throw new FormatException("Gise numarasi bos gecilemez!");
            if (String.IsNullOrWhiteSpace(loggedCounter.Password))
                throw new FormatException("Sifre bos gecilemez!");
            if (counterDAL.CounterControl(loggedCounter) == null)
                throw new FormatException("Gecersiz gise!");
            if (counterDAL.CounterControl(loggedCounter).isActive==true)
                throw new FormatException("Bu gişe şu anda açık");           
            else
            {
                loggedCounter = counterDAL.CounterControl(loggedCounter);
                return loggedCounter;
            }
        }


        public void ChangeActiveStateOfCounter(Counter counter)
        {
            counterDAL.Update(counter);
        }
        public List<Counter> GetAllCounters()
        {
            return counterDAL.GetAll();
        }
        public List<Counter> GetActiveCounters()
        {
            return counterDAL.GetActiveCounters();
        }
        public List<Counter> GetIdleCounters()
        {
            return counterDAL.GetIdleCounters();
        }
        public List<Counter> GetInProcessCounters()
        {
            return counterDAL.GetInProcessCounters();
        }

        public List<TicketNumber> GetWaitingTicketList()
        {
            ticketNumberDAL = new TicketNumberDataMapper();
            var result = ticketNumberDAL.GetByAll(x => x.IsProcessed == false && x.TakenDate == DateTime.Today);
            return result;
        }


        public static Queue<TicketNumber> _ticketNumberQueue = new Queue<TicketNumber>();

        public void FillTheQueue()
        {
            AdminBLL adminBLL = new AdminBLL();
            List<TicketNumber> waitingCustomers = adminBLL.GetWaitingCustomers();
            _ticketNumberQueue.Clear();
            for (int i = 0; i < waitingCustomers.Count; i++)
            {
                _ticketNumberQueue.Enqueue(waitingCustomers[i]);
            }
        }

        private int _tempCC = 0;
        BankSetting bankSetting = new BankSetting();
        private TicketNumber GetTicketNumberFromQueue(bool isActualCall)   
        {
            
            _tempCC = bankSettDal.GetTempCC();
            TicketNumber ticketNumber = _ticketNumberQueue.SkipWhile(t => !(t.Customer is VIPCustomer)).ToList().FirstOrDefault();
            if (isActualCall)
            {
                if (ticketNumber == null)
                {
                    if (_ticketNumberQueue.Count != 0)
                    {
                        if (_ticketNumberQueue.Peek().Customer is TemporaryCustomer)
                        {
                            if (_tempCC > 2)
                            {
                                ticketNumber = _ticketNumberQueue.SkipWhile(t => !((t.Customer) is IndividualCustomer)).ToList().FirstOrDefault();

                                if (ticketNumber == null)
                                {
                                    ticketNumber = _ticketNumberQueue.SkipWhile(t => !((t.Customer) is TemporaryCustomer)).ToList().FirstOrDefault();
                                    _tempCC++;
                                }
                                else
                                _tempCC = 0;
                            }
                            else
                            {
                                ticketNumber = _ticketNumberQueue.SkipWhile(t => !((t.Customer) is TemporaryCustomer)).ToList().FirstOrDefault();
                                _tempCC++;
                            }
                        }

                        else if (_ticketNumberQueue.Peek().Customer is IndividualCustomer)
                        {
                            ticketNumber = _ticketNumberQueue.SkipWhile(t => !((t.Customer) is IndividualCustomer)).ToList().FirstOrDefault();
                            _tempCC = 0;
                        }
                    }
                }
            }
            bankSetting = bankSettDal.GetActualSettings();
            bankSetting.TempCC = _tempCC;
            bankSettDal.Update(bankSetting);

            return ticketNumber;
        }
        public TicketNumber GetNextTicketNumber()
        {
            FillTheQueue();
            TicketNumber ticketnumber = GetTicketNumberFromQueue(true);
            if (ticketnumber == null)
            {
                throw new Exception("Sırada müşteri yok.");
            }
            ticketnumber.IsProcessed = true;
            ticketNumberDAL.Update(ticketnumber);

            return ticketnumber;
        }
        public bool IsNextCustomeraVIP()
        {

            FillTheQueue();
            TicketNumber ticketnumber = GetTicketNumberFromQueue(false);
            if (ticketnumber != null)
            {
                if (ticketnumber.Customer is VIPCustomer)
                {
                    return true;
                }

            }
            return false;

        }

        public Counter GetCounter(Counter counter)
        {
            counterDAL = new CounterDataMapper();
            return counterDAL.GetById(counter.ID);
        }

        public void voice(string path)
        {

            if (counterDAL != null)
            {
                SoundPlayer snd = new SoundPlayer();
                snd.SoundLocation = path + @"Sound\REMINDER.wav";
                snd.Play();
            }


        }
    }
}
