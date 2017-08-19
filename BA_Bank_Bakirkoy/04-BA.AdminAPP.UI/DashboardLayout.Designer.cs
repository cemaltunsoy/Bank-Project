namespace _04_BA.AdminAPP.UI
{
    partial class DashboardLayout
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StatReflesher = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentCustomerCount = new System.Windows.Forms.Label();
            this.lblAverageWaitingTime = new System.Windows.Forms.Label();
            this.lblAverageTransactionTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCounters = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Musteri Sayisi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ortalama Bekleme Suresi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ortalama Islem Suresi:";
            // 
            // StatReflesher
            // 
            this.StatReflesher.Interval = 2000;
            this.StatReflesher.Tick += new System.EventHandler(this.StatReflesher_Tick);
            // 
            // lblCurrentCustomerCount
            // 
            this.lblCurrentCustomerCount.AutoSize = true;
            this.lblCurrentCustomerCount.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentCustomerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblCurrentCustomerCount.Location = new System.Drawing.Point(250, 66);
            this.lblCurrentCustomerCount.Name = "lblCurrentCustomerCount";
            this.lblCurrentCustomerCount.Size = new System.Drawing.Size(52, 20);
            this.lblCurrentCustomerCount.TabIndex = 3;
            this.lblCurrentCustomerCount.Text = "label4";
            // 
            // lblAverageWaitingTime
            // 
            this.lblAverageWaitingTime.AutoSize = true;
            this.lblAverageWaitingTime.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageWaitingTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblAverageWaitingTime.Location = new System.Drawing.Point(250, 109);
            this.lblAverageWaitingTime.Name = "lblAverageWaitingTime";
            this.lblAverageWaitingTime.Size = new System.Drawing.Size(52, 20);
            this.lblAverageWaitingTime.TabIndex = 4;
            this.lblAverageWaitingTime.Text = "label5";
            // 
            // lblAverageTransactionTime
            // 
            this.lblAverageTransactionTime.AutoSize = true;
            this.lblAverageTransactionTime.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverageTransactionTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblAverageTransactionTime.Location = new System.Drawing.Point(250, 151);
            this.lblAverageTransactionTime.Name = "lblAverageTransactionTime";
            this.lblAverageTransactionTime.Size = new System.Drawing.Size(52, 20);
            this.lblAverageTransactionTime.TabIndex = 5;
            this.lblAverageTransactionTime.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(37, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dashboard";
            // 
            // panelCounters
            // 
            this.panelCounters.AutoScroll = true;
            this.panelCounters.Location = new System.Drawing.Point(41, 246);
            this.panelCounters.Name = "panelCounters";
            this.panelCounters.Size = new System.Drawing.Size(650, 166);
            this.panelCounters.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(37, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gişeler";
            // 
            // DashboardLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAverageTransactionTime);
            this.Controls.Add(this.lblAverageWaitingTime);
            this.Controls.Add(this.lblCurrentCustomerCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelCounters);
            this.Name = "DashboardLayout";
            this.Size = new System.Drawing.Size(744, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer StatReflesher;
        private System.Windows.Forms.Label lblCurrentCustomerCount;
        private System.Windows.Forms.Label lblAverageWaitingTime;
        private System.Windows.Forms.Label lblAverageTransactionTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelCounters;
        private System.Windows.Forms.Label label5;
    }
}
