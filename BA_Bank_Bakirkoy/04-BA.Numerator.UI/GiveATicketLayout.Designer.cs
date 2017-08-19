namespace _04_BA.Numerator.UI
{
    partial class GiveATicketLayout
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panelCustomerRegister = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblTicketNo = new System.Windows.Forms.Label();
            this.lblTakenDate = new System.Windows.Forms.Label();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.panelTicketInfo = new System.Windows.Forms.Panel();
            this.lblWaitingCount = new System.Windows.Forms.Label();
            this.ShowInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.lblWarning = new System.Windows.Forms.Label();
            this.CheckBankAvailablity = new System.Windows.Forms.Timer(this.components);
            this.panelCustomerRegister.SuspendLayout();
            this.panelOrder.SuspendLayout();
            this.panelTicketInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(47, 19);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(29, 17);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "Ad:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(117, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(131, 26);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(117, 47);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(131, 26);
            this.txtLastName.TabIndex = 4;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(25, 51);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(52, 17);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Soyad:";
            // 
            // txtSSN
            // 
            this.txtSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSN.Location = new System.Drawing.Point(151, 38);
            this.txtSSN.MaxLength = 11;
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(131, 30);
            this.txtSSN.TabIndex = 6;
            this.txtSSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSSN_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(187, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "T.C. No:";
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOrder.Location = new System.Drawing.Point(24, 14);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(232, 59);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.Text = "Sıra Al";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // panelCustomerRegister
            // 
            this.panelCustomerRegister.Controls.Add(this.label1);
            this.panelCustomerRegister.Controls.Add(this.btnRegister);
            this.panelCustomerRegister.Controls.Add(this.lblFirstName);
            this.panelCustomerRegister.Controls.Add(this.txtFirstName);
            this.panelCustomerRegister.Controls.Add(this.lblLastName);
            this.panelCustomerRegister.Controls.Add(this.txtLastName);
            this.panelCustomerRegister.Location = new System.Drawing.Point(83, 85);
            this.panelCustomerRegister.Name = "panelCustomerRegister";
            this.panelCustomerRegister.Size = new System.Drawing.Size(273, 192);
            this.panelCustomerRegister.TabIndex = 10;
            this.panelCustomerRegister.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "*Sıra Almak İçin Kayıt Olmalısınız..";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Trebuchet MS", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegister.Location = new System.Drawing.Point(16, 104);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(232, 59);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Kaydol";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(16, 16);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(240, 32);
            this.lblFullName.TabIndex = 12;
            this.lblFullName.Text = "Ad Soyad";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTicketNo
            // 
            this.lblTicketNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketNo.Location = new System.Drawing.Point(16, 56);
            this.lblTicketNo.Name = "lblTicketNo";
            this.lblTicketNo.Size = new System.Drawing.Size(240, 54);
            this.lblTicketNo.TabIndex = 13;
            this.lblTicketNo.Text = "9999";
            this.lblTicketNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTakenDate
            // 
            this.lblTakenDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTakenDate.Location = new System.Drawing.Point(16, 148);
            this.lblTakenDate.Name = "lblTakenDate";
            this.lblTakenDate.Size = new System.Drawing.Size(240, 28);
            this.lblTakenDate.TabIndex = 1;
            this.lblTakenDate.Text = "1/1/2017 12:12";
            this.lblTakenDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTakenDate.Click += new System.EventHandler(this.lblFirstName_Click);
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.btnOrder);
            this.panelOrder.Location = new System.Drawing.Point(83, 85);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(273, 192);
            this.panelOrder.TabIndex = 14;
            // 
            // panelTicketInfo
            // 
            this.panelTicketInfo.Controls.Add(this.lblTicketNo);
            this.panelTicketInfo.Controls.Add(this.lblWaitingCount);
            this.panelTicketInfo.Controls.Add(this.lblTakenDate);
            this.panelTicketInfo.Controls.Add(this.lblFullName);
            this.panelTicketInfo.Location = new System.Drawing.Point(83, 85);
            this.panelTicketInfo.Name = "panelTicketInfo";
            this.panelTicketInfo.Size = new System.Drawing.Size(273, 192);
            this.panelTicketInfo.TabIndex = 15;
            this.panelTicketInfo.Visible = false;
            // 
            // lblWaitingCount
            // 
            this.lblWaitingCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingCount.Location = new System.Drawing.Point(16, 118);
            this.lblWaitingCount.Name = "lblWaitingCount";
            this.lblWaitingCount.Size = new System.Drawing.Size(240, 22);
            this.lblWaitingCount.TabIndex = 1;
            this.lblWaitingCount.Text = "Siradaki Kisi Sayisi: 99";
            this.lblWaitingCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaitingCount.Click += new System.EventHandler(this.lblFirstName_Click);
            // 
            // ShowInfoTimer
            // 
            this.ShowInfoTimer.Interval = 3000;
            this.ShowInfoTimer.Tick += new System.EventHandler(this.ShowInfoTimer_Tick);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(107, 68);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 17);
            this.lblWarning.TabIndex = 14;
            // 
            // CheckBankAvailablity
            // 
            this.CheckBankAvailablity.Interval = 5000;
            this.CheckBankAvailablity.Tick += new System.EventHandler(this.CheckBankAvailablity_Tick);
            // 
            // GiveATicketLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelTicketInfo);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.panelCustomerRegister);
            this.Name = "GiveATicketLayout";
            this.Size = new System.Drawing.Size(448, 343);
            this.Load += new System.EventHandler(this.GiveATicketLayout_Load);
            this.panelCustomerRegister.ResumeLayout(false);
            this.panelCustomerRegister.PerformLayout();
            this.panelOrder.ResumeLayout(false);
            this.panelTicketInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Panel panelCustomerRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblTicketNo;
        private System.Windows.Forms.Label lblTakenDate;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Panel panelTicketInfo;
        private System.Windows.Forms.Timer ShowInfoTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWaitingCount;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Timer CheckBankAvailablity;
    }
}
