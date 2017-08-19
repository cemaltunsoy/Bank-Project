using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_BA.AdminAPP.UI
{
    public partial class TextBoxWithImage : UserControl
    {
        private TextBox TextBox { get { return this.txtContent; } }
        private PictureBox Icon { get { return this.picIcon; } }


        public String Text
        {
            get { return TextBox.Text; }
            set { TextBox.Text = value; }
        }
        public Color ImageBackColor
        {
            get { return Icon.BackColor; }
            set { Icon.BackColor = value; }
        }

        public char PasswordChar
        {
            get { return TextBox.PasswordChar; }
            set { TextBox.PasswordChar = value; }
        }

        public void SetTextBoxImage(Image image)
        {
            this.Icon.Image = image;
        }

        public void SetTextBoxImage(String imagepath)
        {
            this.Icon.ImageLocation = imagepath;
        }

        public string HintText { get; set; }

        public Color HintTextColor { get; set; }


        public TextBoxWithImage()
        {
            InitializeComponent();
            this.TextBox.AutoSize = false;
            this.TextBox.BorderStyle = BorderStyle.None;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (TextBox.Text == HintText)
            {
                TextBox.Text = "";
                TextBox.ForeColor = ForeColor;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (TextBox.Text == "")
            {
                TextBox.Text = HintText;
                TextBox.ForeColor = HintTextColor;
            }
        }
    }
}
