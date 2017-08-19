namespace _04_BA.BoothAPP.UI
{
    partial class CounterMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerLastName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCustomerFirstName = new System.Windows.Forms.Label();
            this.lblCustomerSSN = new System.Windows.Forms.Label();
            this.lblVIPAlarm = new System.Windows.Forms.Label();
            this.timerVIPChecker = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangeStateOfCounter = new System.Windows.Forms.Button();
            this.btnNextTicketNumber = new System.Windows.Forms.Button();
            this.btnEndTransaction = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTicketNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCustomerLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCustomerFirstName);
            this.groupBox1.Controls.Add(this.lblCustomerSSN);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Müşteri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Bilet No :";
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Location = new System.Drawing.Point(99, 170);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(0, 23);
            this.lblTicketNumber.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Soyadı   :";
            // 
            // lblCustomerLastName
            // 
            this.lblCustomerLastName.AutoSize = true;
            this.lblCustomerLastName.Location = new System.Drawing.Point(99, 126);
            this.lblCustomerLastName.Name = "lblCustomerLastName";
            this.lblCustomerLastName.Size = new System.Drawing.Size(0, 23);
            this.lblCustomerLastName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Adı          :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "TC No     :";
            // 
            // lblCustomerFirstName
            // 
            this.lblCustomerFirstName.AutoSize = true;
            this.lblCustomerFirstName.Location = new System.Drawing.Point(99, 84);
            this.lblCustomerFirstName.Name = "lblCustomerFirstName";
            this.lblCustomerFirstName.Size = new System.Drawing.Size(0, 23);
            this.lblCustomerFirstName.TabIndex = 10;
            // 
            // lblCustomerSSN
            // 
            this.lblCustomerSSN.AutoSize = true;
            this.lblCustomerSSN.Location = new System.Drawing.Point(99, 44);
            this.lblCustomerSSN.Name = "lblCustomerSSN";
            this.lblCustomerSSN.Size = new System.Drawing.Size(0, 23);
            this.lblCustomerSSN.TabIndex = 8;
            // 
            // lblVIPAlarm
            // 
            this.lblVIPAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVIPAlarm.Location = new System.Drawing.Point(12, 105);
            this.lblVIPAlarm.Name = "lblVIPAlarm";
            this.lblVIPAlarm.Size = new System.Drawing.Size(493, 33);
            this.lblVIPAlarm.TabIndex = 9;
            this.lblVIPAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerVIPChecker
            // 
            this.timerVIPChecker.Interval = 3000;
            this.timerVIPChecker.Tick += new System.EventHandler(this.tmrvipcontrol_Tick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(344, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(161, 79);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Cikis Yap";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChangeStateOfCounter
            // 
            this.btnChangeStateOfCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnChangeStateOfCounter.FlatAppearance.BorderSize = 0;
            this.btnChangeStateOfCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStateOfCounter.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeStateOfCounter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnChangeStateOfCounter.Location = new System.Drawing.Point(177, 12);
            this.btnChangeStateOfCounter.Name = "btnChangeStateOfCounter";
            this.btnChangeStateOfCounter.Size = new System.Drawing.Size(161, 79);
            this.btnChangeStateOfCounter.TabIndex = 14;
            this.btnChangeStateOfCounter.Text = "Giseyi Kapat";
            this.btnChangeStateOfCounter.UseVisualStyleBackColor = false;
            this.btnChangeStateOfCounter.Click += new System.EventHandler(this.btnCloseCounter_Click);
            // 
            // btnNextTicketNumber
            // 
            this.btnNextTicketNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnNextTicketNumber.FlatAppearance.BorderSize = 0;
            this.btnNextTicketNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextTicketNumber.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextTicketNumber.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNextTicketNumber.Location = new System.Drawing.Point(10, 12);
            this.btnNextTicketNumber.Name = "btnNextTicketNumber";
            this.btnNextTicketNumber.Size = new System.Drawing.Size(161, 79);
            this.btnNextTicketNumber.TabIndex = 13;
            this.btnNextTicketNumber.Text = "Siradaki Numara";
            this.btnNextTicketNumber.UseVisualStyleBackColor = false;
            this.btnNextTicketNumber.Click += new System.EventHandler(this.btnNextTicketNumber_Click);
            // 
            // btnEndTransaction
            // 
            this.btnEndTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEndTransaction.Enabled = false;
            this.btnEndTransaction.FlatAppearance.BorderSize = 0;
            this.btnEndTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndTransaction.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTransaction.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEndTransaction.Location = new System.Drawing.Point(10, 370);
            this.btnEndTransaction.Name = "btnEndTransaction";
            this.btnEndTransaction.Size = new System.Drawing.Size(495, 79);
            this.btnEndTransaction.TabIndex = 15;
            this.btnEndTransaction.Text = "Islemi Bitir";
            this.btnEndTransaction.UseVisualStyleBackColor = false;
            this.btnEndTransaction.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // CounterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(522, 468);
            this.ControlBox = false;
            this.Controls.Add(this.btnEndTransaction);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChangeStateOfCounter);
            this.Controls.Add(this.btnNextTicketNumber);
            this.Controls.Add(this.lblVIPAlarm);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CounterMain";
            this.Text = "Gise Formu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CounterMain_FormClosing);
            this.Load += new System.EventHandler(this.CounterMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCustomerFirstName;
        private System.Windows.Forms.Label lblCustomerSSN;
        private System.Windows.Forms.Label lblVIPAlarm;
        private System.Windows.Forms.Timer timerVIPChecker;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangeStateOfCounter;
        private System.Windows.Forms.Button btnNextTicketNumber;
        private System.Windows.Forms.Button btnEndTransaction;
    }
}