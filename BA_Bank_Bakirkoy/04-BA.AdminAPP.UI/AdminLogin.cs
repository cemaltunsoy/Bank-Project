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

namespace _04_BA.AdminAPP.UI
{
    public partial class AdminLogin : BorderlessFormDesign
    {
        AdminBLL _adminBLL = new AdminBLL();
        Admin tempAdmin;
        public AdminLogin()
        {
            InitializeComponent();
            string ImagesFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
            this.txtUsername.ImageBackColor = Color.FromArgb(224, 224, 224);
            this.txtUsername.SetTextBoxImage(ImagesFolderPath + @"Images\userhead.png");
            this.txtUsername.HintText = "Username";
            this.txtPassword.ImageBackColor = Color.FromArgb(224, 224, 224);
            this.txtPassword.SetTextBoxImage(ImagesFolderPath + @"Images\lock.png");
            this.txtUsername.HintText = "Password";
            this.txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                tempAdmin = new Admin();
                tempAdmin.Username = txtUsername.Text;
                tempAdmin.Password = txtPassword.Text;
                if (_adminBLL.IsValidLogin(tempAdmin))
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
