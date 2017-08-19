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

namespace _04_BA.Numerator.UI
{
    public partial class NumeratorMainScreen : Form
    {
        public NumeratorMainScreen()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(new GiveATicketLayout());
        }
    }
}
