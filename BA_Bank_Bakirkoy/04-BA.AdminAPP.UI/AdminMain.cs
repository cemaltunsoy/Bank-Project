using _00_BA.Entity;
using _02_BA.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_BA.AdminAPP.UI
{
    public partial class AdminMain : Form
    {
        AdminBLL _adminBLL = new AdminBLL();
        AdminLogin _adminLoginForm;
        public AdminMain()
        {
            InitializeComponent();
            // Display login form before main form shows up.
            _adminLoginForm = new AdminLogin();
            _adminLoginForm.ShowDialog();
            flowLayoutPanel1.Controls.Add(new HomeLayout());
            //listBox1.DataSource = _adminBLL.GetCustomersOnCounter();
            //listBox2.DataSource = _adminBLL.GetWaitingCustomers();
            //lblAverageTransactionDuration.Text = _adminBLL.GetAverageTransactionDuration().ToString();
            //lblAverageWaitingDuration.Text = _adminBLL.GetAverageWaitingDuration().ToString();
            //listBox3.DataSource = _adminBLL.GetTemporaryCustomers(DateTime.Today);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new DashboardLayout());
        }

        private void btnPerformanceReport_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new PerformanceReportLayout());
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new AddNewCustomerLayout());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new HomeLayout());
        }

        private void btnSetBankSchedule_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(new BankScheduleLayout());
        }
    }
}
