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
using System.IO;

namespace _04_BA.BoothAPP.UI
{
    public partial class CounterLogin : BorderlessFormDesign
    {
        public CounterLogin()
        {
            InitializeComponent();
            string ImagesFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
            this.txtCounterNo.ImageBackColor = Color.FromArgb(224, 224, 224);
            this.txtCounterNo.SetTextBoxImage(ImagesFolderPath + @"Images\userhead.png");
            this.txtCounterNo.HintText = "Username";
            this.txtPassword.ImageBackColor = Color.FromArgb(224, 224, 224);
            this.txtPassword.SetTextBoxImage(ImagesFolderPath + @"Images\lock.png");
            this.txtCounterNo.HintText = "Password";
            this.txtPassword.PasswordChar = '*';
        }
        CounterBLL _counterBLL = new CounterBLL();
        Counter _counter = new Counter();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                Counter loggedCounter = new Counter();
                loggedCounter.No = txtCounterNo.Text;
                loggedCounter.Password = txtPassword.Text;
                if (_counterBLL.IsValidLogin(loggedCounter) != null)
                {
                    _counter = _counterBLL.IsValidLogin(loggedCounter);
                    OpenMainForm(_counter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenMainForm(Counter loggedCounter)
        {
            this.Hide();
            CounterMain form = new CounterMain(loggedCounter);
            form.Show();
        }

        private void CounterLogin_Load(object sender, EventArgs e)
        {

        }

        private void CounterLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
