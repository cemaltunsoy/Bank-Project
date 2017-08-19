namespace _04_BA.AdminAPP.UI
{
    partial class HomeLayout
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listWaitingCustomers = new System.Windows.Forms.ListView();
            this.listCustomersOnCounter = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Reflesher = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listWaitingCustomers
            // 
            this.listWaitingCustomers.Location = new System.Drawing.Point(20, 315);
            this.listWaitingCustomers.Name = "listWaitingCustomers";
            this.listWaitingCustomers.Size = new System.Drawing.Size(672, 203);
            this.listWaitingCustomers.TabIndex = 16;
            this.listWaitingCustomers.UseCompatibleStateImageBehavior = false;
            this.listWaitingCustomers.View = System.Windows.Forms.View.Details;
            // 
            // listCustomersOnCounter
            // 
            this.listCustomersOnCounter.FullRowSelect = true;
            this.listCustomersOnCounter.Location = new System.Drawing.Point(20, 66);
            this.listCustomersOnCounter.Name = "listCustomersOnCounter";
            this.listCustomersOnCounter.Size = new System.Drawing.Size(672, 203);
            this.listCustomersOnCounter.TabIndex = 15;
            this.listCustomersOnCounter.UseCompatibleStateImageBehavior = false;
            this.listCustomersOnCounter.View = System.Windows.Forms.View.Details;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Sirada Bekleyen Musteriler";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Islem Goren Musteriler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Admin Panel";
            // 
            // Reflesher
            // 
            this.Reflesher.Interval = 3000;
            this.Reflesher.Tick += new System.EventHandler(this.Reflesher_Tick);
            // 
            // HomeLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listWaitingCustomers);
            this.Controls.Add(this.listCustomersOnCounter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Name = "HomeLayout";
            this.Size = new System.Drawing.Size(707, 551);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listWaitingCustomers;
        private System.Windows.Forms.ListView listCustomersOnCounter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer Reflesher;
    }
}
