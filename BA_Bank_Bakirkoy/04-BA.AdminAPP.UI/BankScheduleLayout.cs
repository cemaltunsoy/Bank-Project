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

namespace _04_BA.AdminAPP.UI
{
    public partial class BankScheduleLayout : UserControl
    {
        AdminBLL _adminBLL = new AdminBLL();
        BankSchedule bankSchedule;
        public BankScheduleLayout()
        {
            InitializeComponent();
            FetchCurrentTimeTable();
        }

        private void FetchCurrentTimeTable()
        {
            try
            {
                bankSchedule = _adminBLL.GetBankSchedule();
                timePickerOpen.Value = bankSchedule.Open;
                timePickerClose.Value = bankSchedule.Close;
                timePickerBreakStart.Value = bankSchedule.LaunchBreakStart;
                timePickerBreakEnd.Value = bankSchedule.LaunchBreakEnd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSetBankSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                SaveNewTimeTable();
                MessageBox.Show("Calisma saatleri basari ile guncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveNewTimeTable()
        {
            bankSchedule.Open = timePickerOpen.Value;
            bankSchedule.Close = timePickerClose.Value;
            bankSchedule.LaunchBreakStart = timePickerBreakStart.Value;
            bankSchedule.LaunchBreakEnd = timePickerBreakEnd.Value;
            _adminBLL.SetSchedule(bankSchedule);
        }
    }
}
