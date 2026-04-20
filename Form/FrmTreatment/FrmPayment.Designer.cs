using System;

namespace FrmPayment
{
    partial class FormPayment
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

        private System.Windows.Forms.TextBox txtPaymentID;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.TextBox txtPatientNameKH;
        private System.Windows.Forms.TextBox txtStaffNameKH;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnL_out;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvPayments;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPaymentID = new System.Windows.Forms.TextBox();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtPatientNameKH = new System.Windows.Forms.TextBox();
            this.txtStaffNameKH = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnL_out = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboPatientID = new System.Windows.Forms.ComboBox();
            this.cboStaffID = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStaffNameEN = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPatientNameEN = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStaffPosition = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPaymentID
            // 
            this.txtPaymentID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentID.Location = new System.Drawing.Point(142, 86);
            this.txtPaymentID.Name = "txtPaymentID";
            this.txtPaymentID.Size = new System.Drawing.Size(150, 25);
            this.txtPaymentID.TabIndex = 0;
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPayDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayDate.Location = new System.Drawing.Point(442, 83);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(176, 25);
            this.dtpPayDate.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(142, 117);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 25);
            this.txtAmount.TabIndex = 2;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Transfer"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(442, 117);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(176, 25);
            this.cmbPaymentMethod.TabIndex = 3;
            // 
            // txtPatientNameKH
            // 
            this.txtPatientNameKH.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientNameKH.Location = new System.Drawing.Point(446, 254);
            this.txtPatientNameKH.Name = "txtPatientNameKH";
            this.txtPatientNameKH.Size = new System.Drawing.Size(172, 30);
            this.txtPatientNameKH.TabIndex = 5;
            // 
            // txtStaffNameKH
            // 
            this.txtStaffNameKH.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffNameKH.Location = new System.Drawing.Point(142, 186);
            this.txtStaffNameKH.Name = "txtStaffNameKH";
            this.txtStaffNameKH.Size = new System.Drawing.Size(150, 30);
            this.txtStaffNameKH.TabIndex = 7;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Cyan;
            this.btnInsert.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(12, 438);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 30);
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Cyan;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(142, 438);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Cyan;
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(270, 438);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(398, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnL_out
            // 
            this.btnL_out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnL_out.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnL_out.Location = new System.Drawing.Point(518, 438);
            this.btnL_out.Name = "btnL_out";
            this.btnL_out.Size = new System.Drawing.Size(100, 30);
            this.btnL_out.TabIndex = 12;
            this.btnL_out.Text = "Log Out";
            this.btnL_out.UseVisualStyleBackColor = false;
            this.btnL_out.Click += new System.EventHandler(this.btnL_out_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(169, 292);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(419, 25);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvPayments
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPayments.Location = new System.Drawing.Point(12, 323);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.Size = new System.Drawing.Size(606, 99);
            this.dgvPayments.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Payment ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(321, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Payment Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Patient ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Patient Name KH";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Staff ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Staff Name KH";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Search (Payment ID):";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(-2, -4);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(648, 73);
            this.label10.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 19);
            this.label2.TabIndex = 42;
            this.label2.Text = "PAYMENT\'S INFORMATION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "©Copyright ISAD _A3_G26_GROUP1 (2025).";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(321, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 44;
            this.label11.Text = "Payment Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 17);
            this.label12.TabIndex = 45;
            this.label12.Text = "Amount";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = global::FrmTreatment.Properties.Resources.payment;
            this.pictureBox1.Location = new System.Drawing.Point(41, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // cboPatientID
            // 
            this.cboPatientID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPatientID.FormattingEnabled = true;
            this.cboPatientID.Location = new System.Drawing.Point(142, 226);
            this.cboPatientID.Name = "cboPatientID";
            this.cboPatientID.Size = new System.Drawing.Size(476, 25);
            this.cboPatientID.TabIndex = 47;
            // 
            // cboStaffID
            // 
            this.cboStaffID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStaffID.FormattingEnabled = true;
            this.cboStaffID.Location = new System.Drawing.Point(142, 155);
            this.cboStaffID.Name = "cboStaffID";
            this.cboStaffID.Size = new System.Drawing.Size(150, 25);
            this.cboStaffID.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(321, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 17);
            this.label13.TabIndex = 50;
            this.label13.Text = "Staff Name EN";
            // 
            // txtStaffNameEN
            // 
            this.txtStaffNameEN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffNameEN.Location = new System.Drawing.Point(442, 155);
            this.txtStaffNameEN.Name = "txtStaffNameEN";
            this.txtStaffNameEN.Size = new System.Drawing.Size(176, 25);
            this.txtStaffNameEN.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 259);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 17);
            this.label14.TabIndex = 52;
            this.label14.Text = "Patient Name EN";
            // 
            // txtPatientNameEN
            // 
            this.txtPatientNameEN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientNameEN.Location = new System.Drawing.Point(142, 257);
            this.txtPatientNameEN.Name = "txtPatientNameEN";
            this.txtPatientNameEN.Size = new System.Drawing.Size(150, 25);
            this.txtPatientNameEN.TabIndex = 51;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(321, 195);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 17);
            this.label15.TabIndex = 54;
            this.label15.Text = "Staff Position";
            // 
            // txtStaffPosition
            // 
            this.txtStaffPosition.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffPosition.Location = new System.Drawing.Point(442, 191);
            this.txtStaffPosition.Name = "txtStaffPosition";
            this.txtStaffPosition.Size = new System.Drawing.Size(176, 25);
            this.txtStaffPosition.TabIndex = 53;
            // 
            // FormPayment
            // 
            this.ClientSize = new System.Drawing.Size(630, 480);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtStaffPosition);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPatientNameEN);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtStaffNameEN);
            this.Controls.Add(this.cboStaffID);
            this.Controls.Add(this.cboPatientID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaymentID);
            this.Controls.Add(this.dtpPayDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.txtPatientNameKH);
            this.Controls.Add(this.txtStaffNameKH);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnL_out);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvPayments);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(646, 519);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(646, 519);
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment\'s Form";
            this.Load += new System.EventHandler(this.FormPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnL_out_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboPatientID;
        private System.Windows.Forms.ComboBox cboStaffID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStaffNameEN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPatientNameEN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStaffPosition;
    }
}

