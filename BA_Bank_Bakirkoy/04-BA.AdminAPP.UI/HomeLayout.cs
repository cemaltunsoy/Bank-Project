using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _00_BA.Entity;
using _02_BA.BLL;

namespace _04_BA.AdminAPP.UI
{
    public partial class HomeLayout : UserControl
    {
        AdminBLL _adminBLL;
        ListViewItem _tempListItem;
        public HomeLayout()
        {
            InitializeComponent();
            _adminBLL = new AdminBLL();
            InitialalizeListView(listCustomersOnCounter);
            InitialalizeListView(listWaitingCustomers);
            FillCustomersOnCounterList();
            FillWaitingCustomersList();
            Reflesher.Start();
        }

        private void FillWaitingCustomersList()
        {
            listWaitingCustomers.Items.Clear();
            foreach (TicketNumber item in _adminBLL.GetWaitingCustomers())
            {
                _tempListItem = new ListViewItem();
                _tempListItem.Text = item.Number.ToString();
                _tempListItem.SubItems.Add(item.TakenDate.ToShortTimeString());
                _tempListItem.SubItems.Add(item.Customer.FirstName);
                _tempListItem.SubItems.Add(item.Customer.LastName);
                _tempListItem.SubItems.Add(item.Customer.SSN);
                listWaitingCustomers.Items.Add(_tempListItem);
            }
        }

        private void FillCustomersOnCounterList()
        {
            listCustomersOnCounter.Items.Clear();
            foreach (TicketNumber item in _adminBLL.GetCustomersOnCounter())
            {
                _tempListItem = new ListViewItem();
                _tempListItem.Text = item.Number.ToString();
                _tempListItem.SubItems.Add(item.TakenDate.ToShortTimeString());
                _tempListItem.SubItems.Add(item.Customer.FirstName);
                _tempListItem.SubItems.Add(item.Customer.LastName);
                _tempListItem.SubItems.Add(item.Customer.SSN);
                listCustomersOnCounter.Items.Add(_tempListItem);
            }
        }

        public void InitialalizeListView(ListView listview)
        {
            // Set the view to show details.
            listview.View = View.Details;
            // Allow the user to edit item text.
            listview.LabelEdit = false;
            // Allow the user to rearrange columns.
            listview.AllowColumnReorder = false;
            // Display check boxes.
            listview.CheckBoxes = false;
            // Select the item and subitems when selection is made.
            listview.FullRowSelect = true;
            // Display grid lines.
            listview.GridLines = false;
            listview.AllowColumnReorder = false;

            // Create columns for the items and subitems.
            listview.Columns.Add("Numara", (int)(listview.Width * .10), HorizontalAlignment.Left);
            listview.Columns.Add("Saat", (int)(listview.Width * .15), HorizontalAlignment.Left);
            listview.Columns.Add("Ad", (int)(listview.Width * .25), HorizontalAlignment.Left);
            listview.Columns.Add("Soyad", (int)(listview.Width * .25), HorizontalAlignment.Left);
            listview.Columns.Add("TC", (int)(listview.Width * .25), HorizontalAlignment.Left);
        }

        private void Reflesher_Tick(object sender, EventArgs e)
        {
            FillCustomersOnCounterList();
            FillWaitingCustomersList();
        }
    }
}
