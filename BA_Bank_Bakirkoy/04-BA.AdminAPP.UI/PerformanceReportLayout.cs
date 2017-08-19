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
using System.IO;

namespace _04_BA.AdminAPP.UI
{
    public partial class PerformanceReportLayout : UserControl
    {
        AdminBLL _adminBLL;
        public PerformanceReportLayout()
        {
            InitializeComponent();
            InitializeImages();
            _adminBLL = new AdminBLL();
            dateSelected.MaxDate = DateTime.Today;
            dateSelected.Value = DateTime.Today;
        }

        private void InitializeImages()
        {
            string ImagesFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
            picVIP.ImageLocation = ImagesFolderPath + @"Images\vip-512.png";
            picIndividual.ImageLocation = ImagesFolderPath + @"Images\individual-512.png";
            picTemporary.ImageLocation = ImagesFolderPath + @"Images\temporary-512.png";
        }

        private void dateSelected_ValueChanged(object sender, EventArgs e)
        {
            DisplayTransactionCounts();
        }

        private void DisplayTransactionCounts()
        {
            if (dateSelected.Value != null)
            {
                lblVIPTransactionCount.Text = _adminBLL.GetVIPCustomerCountByDate(dateSelected.Value).ToString();
                lblTemporaryTransactionCount.Text = _adminBLL.GetTemporaryCustomerCountByDate(dateSelected.Value).ToString();
                lblIndividualTransactionCount.Text = _adminBLL.GetIndividualCustomerCountByDate(dateSelected.Value).ToString();
            }
        }
    }
}
