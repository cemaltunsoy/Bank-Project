using _00_BA.Entity;
using _02_BA.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_BA.BoothAPP.UI
{
    public partial class CounterMain : Form
    {
        private string soundsfolderpath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
        public CounterMain(Counter counter)
        {
            InitializeComponent();
            counter.isActive = true;
            _counterBLL.ChangeActiveStateOfCounter(counter);
            this.counter = counter;
        }
        CounterBLL _counterBLL = new CounterBLL();
        CustomerBLL _customerBLL = new CustomerBLL();
        NumaratorBLL _numaratorBLL = new NumaratorBLL();
        TransactionBLL _transactionBLL = new TransactionBLL();
        TicketNumberBLL _ticketNumberBLL = new TicketNumberBLL();

        Counter counter = null;
        Transaction transaction = null;

        private void TransactionStart(TicketNumber currentTicket)
        {
            transaction = new Transaction();
            transaction.Counter = _counterBLL.GetCounter(counter);
            transaction.TicketNumber = currentTicket;
            transaction.TransactionStart = DateTime.Now;
            PrintSelectedTicketInformation(transaction.TicketNumber);

            btnExit.Enabled = false;
            btnChangeStateOfCounter.Enabled = false;
            btnEndTransaction.Enabled = true;
            btnNextTicketNumber.Enabled = false;
        }

        private void TransactionEnd()
        {
            try
            {
                transaction.TransactionEnd = DateTime.Now;

                _transactionBLL.CreateTransaction(transaction);
                transaction = null;
                btnNextTicketNumber.Enabled = true;
                ClearFormControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintSelectedTicketInformation(TicketNumber ticketNumber)
        {
            lblCustomerFirstName.Text = ticketNumber.Customer.FirstName;
            lblCustomerLastName.Text = ticketNumber.Customer.LastName;
            lblCustomerSSN.Text = ticketNumber.Customer.SSN;
            lblTicketNumber.Text = ticketNumber.Number.ToString();
        }

        private Customer GetCustomer(int CustomerId)
        {
            return _customerBLL.GetCustomer(CustomerId);
        }


        private void btnIslemBitir_Click(object sender, EventArgs e)
        {

        }

        private void ClearFormControls()
        {
            lblCustomerFirstName.Text = "";
            lblCustomerLastName.Text = "";
            lblCustomerSSN.Text = "";
            lblTicketNumber.Text = "";
            btnEndTransaction.Enabled = false;

            btnExit.Enabled = true;
            btnChangeStateOfCounter.Enabled = true;
            btnNextTicketNumber.Enabled = true;
            btnEndTransaction.Enabled = false;
        }



        private void tmrvipcontrol_Tick(object sender, EventArgs e)
        {
            if (_counterBLL.IsNextCustomeraVIP())
            {
                lblVIPAlarm.Text = "Sırada VIP Müşteri Var.";
                if (lblVIPAlarm.ForeColor == Color.Red)
                    lblVIPAlarm.ForeColor = Color.Black;
                else
                {
                    lblVIPAlarm.ForeColor = Color.Red;
                }

            }
            else
            {
                lblVIPAlarm.Text = "";
            }

        }

        private void CounterMain_Load(object sender, EventArgs e)
        {
            timerVIPChecker.Start();
            this.Text = String.Format("Giris yapilan gise no: {0}", counter.No);
        }

        private void CounterMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnNextTicketNumber_Click(object sender, EventArgs e)
        {
          
            try
            {
                TransactionStart(_counterBLL.GetNextTicketNumber());
                _counterBLL.voice(soundsfolderpath);
            }
            catch (Exception ex)
            {
                timerVIPChecker.Stop();
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCloseCounter_Click(object sender, EventArgs e)
        {
            if (counter.isActive)
            {
                btnChangeStateOfCounter.Text = "Giseyi Aç";
                btnNextTicketNumber.Enabled = false;
                counter.isActive = false;
            }
            else if (!counter.isActive)
            {
                btnChangeStateOfCounter.Text = "Giseyi Kapat";
                btnNextTicketNumber.Enabled = true;
                counter.isActive = true;
            }
            _counterBLL.ChangeActiveStateOfCounter(counter);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            counter.isActive = false;
            _counterBLL.ChangeActiveStateOfCounter(counter);

            CounterLogin frm = new CounterLogin();
            frm.Show();
            this.Hide();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            TransactionEnd();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                counter.isActive = false;
                _counterBLL.ChangeActiveStateOfCounter(counter);
            }

        }
    }
}
