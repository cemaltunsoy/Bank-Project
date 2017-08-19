using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _02_BA.BLL;
using _00_BA.Entity;

namespace _04_BA.Numerator.UI
{
    public partial class GiveATicketLayout : UserControl
    {
        public GiveATicketLayout()
        {
            InitializeComponent();
        }

        NumaratorBLL numaratorBLL = new NumaratorBLL();
        Customer customer;
        TicketNumber ticketNumber;
        CustomerBLL customerBLL;

        private void btnOrder_Click(object sender, EventArgs e)
        {
            GiveATicket();
        }

        private void GiveATicket()
        {
            try
            {
                CheckControlsSSN();
                customer = numaratorBLL.GetCustomerBySSN(txtSSN.Text);
                if (customer == null)
                {
                    ShowRegisterPanel();
                }
                else
                {
                    ticketNumber = numaratorBLL.CreateTicketNumber(customer);
                    lblFullName.Text = customer.FullName;
                    lblTicketNo.Text = ticketNumber.Number.ToString();
                    lblTakenDate.Text = ticketNumber.TakenDate.ToString();
                    lblWaitingCount.Text = String.Format("Siradaki Kisi Sayisi: {0}", (numaratorBLL.GetCountOfWaitingCustomers() - 1));

                    ShowTicketInfoPanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                CheckControlsForRegister();
                customerBLL = new CustomerBLL();
                TemporaryCustomer tempCustomer = new TemporaryCustomer();
                tempCustomer.FirstName = txtFirstName.Text;
                tempCustomer.LastName = txtLastName.Text;
                tempCustomer.SSN = txtSSN.Text;
                customerBLL.AddCustomer(tempCustomer);

                ticketNumber = numaratorBLL.CreateTicketNumber(tempCustomer);
                lblFullName.Text = tempCustomer.FullName;
                lblTicketNo.Text = ticketNumber.Number.ToString();
                lblTakenDate.Text = ticketNumber.TakenDate.ToString();
                lblWaitingCount.Text = String.Format("Siradaki Kisi Sayisi: {0}", (numaratorBLL.GetCountOfWaitingCustomers() - 1));

                ShowTicketInfoPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowRegisterPanel()
        {
            txtSSN.ReadOnly = true;
            panelCustomerRegister.Visible = true;
            panelOrder.Visible = false;
            panelTicketInfo.Visible = false;
        }
        public void ShowOrderPanel()
        {
            txtSSN.ReadOnly = false;
            panelCustomerRegister.Visible = false;
            panelOrder.Visible = true;
            panelTicketInfo.Visible = false;
        }
        public void ShowTicketInfoPanel()
        {
            txtSSN.ReadOnly = true;
            panelCustomerRegister.Visible = false;
            panelOrder.Visible = false;
            panelTicketInfo.Visible = true;
            ShowInfoTimer.Start();
        }

        public void FillControls(Customer cus)
        {
            ClearControls();
            txtSSN.Text = cus.SSN;
            txtFirstName.Text = cus.FirstName;
            txtLastName.Text = cus.LastName;
            customer = cus;
        }

        private void ClearControls()
        {
            txtSSN.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            lblFullName.Text = "";
            lblTakenDate.Text = "";
            lblTicketNo.Text = "";
            lblWaitingCount.Text = "";
        }


        private void CheckExistenceOfUser()
        {
            throw new NotImplementedException();
        }

        private void CheckControlsSSN()
        {
            if (String.IsNullOrWhiteSpace(txtSSN.Text))
                throw new FormatException("T.C. no boş gecilemez!");
            if (txtSSN.Text.Length != 11)
                throw new FormatException("T.C. no eksik girildi!");
            char[] ssn = txtSSN.Text.ToCharArray();
            for (int i = 0; i < txtSSN.Text.Length; i++)
            {
                if (char.IsLetter(ssn[i]))
                    throw new FormatException("T.C. no hatalı girildi!");
            }
        }

        private void CheckControlsForRegister()
        {
            CheckControlsSSN();
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
                throw new FormatException("Isim bos gecilemez!");
            if (String.IsNullOrWhiteSpace(txtLastName.Text))
                throw new FormatException("Soyisim bos gecilemez!");
        }


        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void txtSSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ShowInfoTimer_Tick(object sender, EventArgs e)
        {
            ShowInfoTimer.Stop();
            ShowOrderPanel();
            ClearControls();
        }

        private void GiveATicketLayout_Load(object sender, EventArgs e)
        {
            try
            {
                numaratorBLL.ControlSchedulesForTicket();
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
                btnOrder.Enabled = false;
                txtSSN.ReadOnly = true;
                CheckBankAvailablity.Start();
            }
        }

        private void CheckBankAvailablity_Tick(object sender, EventArgs e)
        {
            try
            {
                numaratorBLL.ControlSchedulesForTicket();
                btnOrder.Enabled = true;
                lblWarning.Text = "";
                txtSSN.ReadOnly = false;
            }
            catch (Exception ex)
            {
                lblWarning.Text = ex.Message;
                btnOrder.Enabled = false;
                txtSSN.ReadOnly = true;
            }

        }
    }
}
