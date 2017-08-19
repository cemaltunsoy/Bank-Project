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
    public partial class AddNewCustomerLayout : UserControl
    {
        AdminBLL _adminBLL;
        TemporaryCustomer tempCustomer;
        public AddNewCustomerLayout()
        {
            InitializeComponent();
            InitializeCustomerTypes();
            PrepareControls();
            //FetchDailyCustomers(dateCustomerFilter.Value);
        }

        private void PrepareControls()
        {
            cmbCustomerType.SelectedIndex = 0;
            listTemporaryCustomers.DisplayMember = "FullName";
            dateCustomerFilter.MaxDate = DateTime.Today;
        }

        private void InitializeCustomerTypes()
        {
            cmbCustomerType.Items.Add("Bireysel Musteri");
            cmbCustomerType.Items.Add("VIP Musteri");
        }

        private void dateCustomerFilter_ValueChanged(object sender, EventArgs e)
        {
            FetchDailyCustomers(dateCustomerFilter.Value);
        }

        private void FetchDailyCustomers(DateTime date)
        {
            try
            {
                _adminBLL = new AdminBLL();
                if (dateCustomerFilter.Value != null)
                {
                    if (chkDeletedCustomers.Checked)
                    {
                        listTemporaryCustomers.DataSource = _adminBLL.GetRemovedTemporaryCustomers(date);
                        temporaryCustomerListContextMenu.Enabled = false;
                    }
                    else
                    {
                        listTemporaryCustomers.DataSource = _adminBLL.GetTemporaryCustomers(date);
                        temporaryCustomerListContextMenu.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listTemporaryCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listTemporaryCustomers.SelectedIndex != -1)
            {
                FillControls((TemporaryCustomer)listTemporaryCustomers.SelectedItem);
            }
        }

        public void FillControls(TemporaryCustomer customer)
        {
            ClearControls();
            txtID.Text = customer.Id.ToString();
            txtSSN.Text = customer.SSN;
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            tempCustomer = customer;
        }

        private void ClearControls()
        {
            listTemporaryCustomers.SelectedIndex = -1;
            txtID.Clear();
            txtSSN.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            cmbCustomerType.SelectedIndex = 0;
        }

        private void chkDeletedCustomers_CheckedChanged(object sender, EventArgs e)
        {
            FetchDailyCustomers(dateCustomerFilter.Value);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                _adminBLL = new AdminBLL();
                CheckControls();
                CreateNewCustomer();
                ClearControls();
                FetchDailyCustomers(dateCustomerFilter.Value);
                MessageBox.Show("Musteri basari ile kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateNewCustomer()
        {
            Customer newCustomer;
            if (cmbCustomerType.SelectedIndex == 0)
                newCustomer = new IndividualCustomer();
            else
                newCustomer = new VIPCustomer();

            newCustomer.SSN = txtSSN.Text;
            newCustomer.FirstName = txtFirstName.Text;
            newCustomer.LastName = txtLastName.Text;

            if (tempCustomer == null)
            {
                _adminBLL.AddCustomer(newCustomer);
            }
            else
            {
                newCustomer.Id = tempCustomer.Id;
                _adminBLL.SaveTemporaryCustomer(newCustomer);
            }
        }

        private void CheckExistenceOfUser()
        {
            throw new NotImplementedException();
        }

        private void CheckControls()
        {
            if (String.IsNullOrWhiteSpace(txtSSN.Text))
                throw new FormatException("T.C. no bos gecilemez!");
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
                throw new FormatException("Isim bos gecilemez!");
            if (String.IsNullOrWhiteSpace(txtLastName.Text))
                throw new FormatException("Soyisim bos gecilemez!");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listTemporaryCustomers.SelectedIndex != -1)
            {
                // IEntityTracking hatasini cozdu? Bunu yapmadan once direkt
                _adminBLL.RemoveTemporaryCustomer((TemporaryCustomer)listTemporaryCustomers.SelectedItem);//diyorduk. Bu sekilde hata aliyoruz.
                //tempCustomer = (TemporaryCustomer)listTemporaryCustomers.SelectedItem;
                //TemporaryCustomer t = new TemporaryCustomer();
                //t.Id = tempCustomer.Id;
                //t.FirstName = tempCustomer.FirstName;
                //t.LastName = tempCustomer.LastName;
                //t.SSN = tempCustomer.SSN;


                //_adminBLL.RemoveTemporaryCustomer(t);
                //tempCustomer = null;
                FetchDailyCustomers(dateCustomerFilter.Value);
            }
        }

        private void txtSSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            tempCustomer = null;
        }
    }
}
