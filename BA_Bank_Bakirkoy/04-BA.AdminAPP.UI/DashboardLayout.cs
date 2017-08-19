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
using System.IO;

namespace _04_BA.AdminAPP.UI
{
    public partial class DashboardLayout : UserControl
    {
        AdminBLL _adminBLL;
        CounterBLL _counterBLL;
        NumaratorBLL _numeratorBLL;
        string ImagesFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
        private int AllCounterCount = 0;
        private int ActiveCounterCount = 0;
        private int LastAllCounterCount = 0;
        private int LastActiveCounterCount = 0;
        public DashboardLayout()
        {
            InitializeComponent();
            _adminBLL = new AdminBLL();
            _counterBLL = new CounterBLL();
            _numeratorBLL = new NumaratorBLL();
            FetchLiveData();
            StatReflesher.Start();
            LoadCounters();
        }
        
        private void LoadCounters()
        {
            List<Counter> AllCounters = _counterBLL.GetAllCounters();
            panelCounters.Controls.Clear();
            for (int i = 0; i < AllCounters.Count; i++)
            {

                GroupBox gb = new GroupBox();

                gb.Size = new Size(80, 120);
                gb.Location = new Point(i * 85, 30);
                gb.Text = "Gişe " + AllCounters[i].No;
                gb.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                gb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                if (AllCounters[i].isActive)
                {
                    pb.Image = Image.FromFile(ImagesFolderPath + @"Images\ActiveCounter.png");
                }
                else
                    pb.Image = Image.FromFile(ImagesFolderPath + @"Images\InactiveCounter.png");
                gb.Controls.Add(pb);
                panelCounters.Controls.Add(gb);
            }
        }

        private void StatReflesher_Tick(object sender, EventArgs e)
        {
            FetchLiveData();
            //
            
            AllCounterCount = _counterBLL.GetAllCounters().Count;
            ActiveCounterCount = _counterBLL.GetActiveCounters().Count;
            if (LastActiveCounterCount != ActiveCounterCount || AllCounterCount != LastAllCounterCount)
            {
                LoadCounters();
                LastAllCounterCount = AllCounterCount;
                LastActiveCounterCount = ActiveCounterCount;
            }
        }

        private void FetchLiveData()
        {
            lblCurrentCustomerCount.Text = (_numeratorBLL.GetCountOfWaitingCustomers() + _numeratorBLL.GetCountOfCustomersOnCounter()).ToString();
            lblAverageWaitingTime.Text = String.Format("{0} dakika", _adminBLL.GetAverageWaitingDuration().ToString(@"mm\:ss"));
            lblAverageTransactionTime.Text = String.Format("{0} dakika", _adminBLL.GetAverageTransactionDuration().ToString(@"mm\:ss"));
        }

    }
}
