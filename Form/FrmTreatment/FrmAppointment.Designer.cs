namespace FormAppointment
{
    partial class FormAppointment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtAppointmentID = new System.Windows.Forms.TextBox();
            this.lbDuration = new System.Windows.Forms.Label();
            this.lbDoctorID = new System.Windows.Forms.Label();
            this.lbAppointmentDate = new System.Windows.Forms.Label();
            this.lbAppointmentID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbApDate = new System.Windows.Forms.Label();
            this.lbDoctorName = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboDoctorID = new System.Windows.Forms.ComboBox();
            this.cboPatientID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatientNameKH = new System.Windows.Forms.TextBox();
            this.txtPatientNameEN = new System.Windows.Forms.TextBox();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(750, 121);
            this.dataGridView1.TabIndex = 63;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(179, 207);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(391, 25);
            this.txtSearch.TabIndex = 62;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearch.Location = new System.Drawing.Point(10, 215);
            this.lbSearch.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(161, 17);
            this.lbSearch.TabIndex = 61;
            this.lbSearch.Text = "Search (Appointment ID):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(156, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 19);
            this.label3.TabIndex = 69;
            this.label3.Text = "©Copyright ISAD _A3_G26_GROUP1 (2025).";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 19);
            this.label2.TabIndex = 68;
            this.label2.Text = "APPOINTMENT\'S INFORMATION";
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLogout.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(637, 380);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(118, 29);
            this.btnLogout.TabIndex = 67;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(321, 380);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(130, 29);
            this.btnNew.TabIndex = 66;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(174, 380);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 29);
            this.btnUpdate.TabIndex = 65;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.AutoSize = true;
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnInsert.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(21, 380);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(130, 29);
            this.btnInsert.TabIndex = 64;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(494, 380);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 29);
            this.btnClose.TabIndex = 71;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(390, 90);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 25);
            this.dateTimePicker1.TabIndex = 59;
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(631, 90);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(132, 25);
            this.txtDuration.TabIndex = 58;
            // 
            // txtAppointmentID
            // 
            this.txtAppointmentID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppointmentID.Location = new System.Drawing.Point(113, 92);
            this.txtAppointmentID.Name = "txtAppointmentID";
            this.txtAppointmentID.Size = new System.Drawing.Size(132, 25);
            this.txtAppointmentID.TabIndex = 52;
            // 
            // lbDuration
            // 
            this.lbDuration.AutoSize = true;
            this.lbDuration.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDuration.Location = new System.Drawing.Point(516, 96);
            this.lbDuration.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(62, 17);
            this.lbDuration.TabIndex = 51;
            this.lbDuration.Text = "Duration:";
            // 
            // lbDoctorID
            // 
            this.lbDoctorID.AutoSize = true;
            this.lbDoctorID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoctorID.Location = new System.Drawing.Point(14, 167);
            this.lbDoctorID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDoctorID.Name = "lbDoctorID";
            this.lbDoctorID.Size = new System.Drawing.Size(72, 17);
            this.lbDoctorID.TabIndex = 49;
            this.lbDoctorID.Text = "Doctor ID:";
            // 
            // lbAppointmentDate
            // 
            this.lbAppointmentDate.AutoSize = true;
            this.lbAppointmentDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentDate.Location = new System.Drawing.Point(18, 136);
            this.lbAppointmentDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAppointmentDate.Name = "lbAppointmentDate";
            this.lbAppointmentDate.Size = new System.Drawing.Size(0, 17);
            this.lbAppointmentDate.TabIndex = 45;
            // 
            // lbAppointmentID
            // 
            this.lbAppointmentID.AutoSize = true;
            this.lbAppointmentID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentID.Location = new System.Drawing.Point(10, 103);
            this.lbAppointmentID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAppointmentID.Name = "lbAppointmentID";
            this.lbAppointmentID.Size = new System.Drawing.Size(106, 17);
            this.lbAppointmentID.TabIndex = 44;
            this.lbAppointmentID.Text = "Appointment ID:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 80);
            this.label1.TabIndex = 43;
            // 
            // lbApDate
            // 
            this.lbApDate.AutoSize = true;
            this.lbApDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApDate.Location = new System.Drawing.Point(262, 96);
            this.lbApDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbApDate.Name = "lbApDate";
            this.lbApDate.Size = new System.Drawing.Size(119, 17);
            this.lbApDate.TabIndex = 72;
            this.lbApDate.Text = "Appointment Date:";
            // 
            // lbDoctorName
            // 
            this.lbDoctorName.AutoSize = true;
            this.lbDoctorName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoctorName.Location = new System.Drawing.Point(14, 131);
            this.lbDoctorName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbDoctorName.Name = "lbDoctorName";
            this.lbDoctorName.Size = new System.Drawing.Size(72, 17);
            this.lbDoctorName.TabIndex = 75;
            this.lbDoctorName.Text = "Patient ID:";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(571, 159);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(192, 25);
            this.txtStatus.TabIndex = 78;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(516, 165);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(47, 17);
            this.lbStatus.TabIndex = 77;
            this.lbStatus.Text = "Status:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = global::FrmTreatment.Properties.Resources.Appointment1;
            this.pictureBox1.Location = new System.Drawing.Point(52, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // cboDoctorID
            // 
            this.cboDoctorID.FormattingEnabled = true;
            this.cboDoctorID.Location = new System.Drawing.Point(113, 162);
            this.cboDoctorID.Name = "cboDoctorID";
            this.cboDoctorID.Size = new System.Drawing.Size(132, 25);
            this.cboDoctorID.TabIndex = 79;
            // 
            // cboPatientID
            // 
            this.cboPatientID.FormattingEnabled = true;
            this.cboPatientID.Location = new System.Drawing.Point(113, 125);
            this.cboPatientID.Name = "cboPatientID";
            this.cboPatientID.Size = new System.Drawing.Size(132, 25);
            this.cboPatientID.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 81;
            this.label4.Text = "Patient Name KH:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(516, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 83;
            this.label5.Text = "Patient Name EN:";
            // 
            // txtPatientNameKH
            // 
            this.txtPatientNameKH.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientNameKH.Location = new System.Drawing.Point(389, 121);
            this.txtPatientNameKH.Name = "txtPatientNameKH";
            this.txtPatientNameKH.Size = new System.Drawing.Size(119, 30);
            this.txtPatientNameKH.TabIndex = 85;
            // 
            // txtPatientNameEN
            // 
            this.txtPatientNameEN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientNameEN.Location = new System.Drawing.Point(631, 121);
            this.txtPatientNameEN.Name = "txtPatientNameEN";
            this.txtPatientNameEN.Size = new System.Drawing.Size(132, 25);
            this.txtPatientNameEN.TabIndex = 86;
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctorName.Location = new System.Drawing.Point(389, 159);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(119, 25);
            this.txtDoctorName.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(274, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 87;
            this.label6.Text = "Doctor Name:";
            // 
            // FormAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 421);
            this.Controls.Add(this.txtDoctorName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPatientNameEN);
            this.Controls.Add(this.txtPatientNameKH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPatientID);
            this.Controls.Add(this.cboDoctorID);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbDoctorName);
            this.Controls.Add(this.lbApDate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtAppointmentID);
            this.Controls.Add(this.lbDuration);
            this.Controls.Add(this.lbDoctorID);
            this.Controls.Add(this.lbAppointmentDate);
            this.Controls.Add(this.lbAppointmentID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(791, 460);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(791, 460);
            this.Name = "FormAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment\'s Form";
            this.Load += new System.EventHandler(this.FormAppointment_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtAppointmentID;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.Label lbDoctorID;
        private System.Windows.Forms.Label lbAppointmentDate;
        private System.Windows.Forms.Label lbAppointmentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbApDate;
        private System.Windows.Forms.Label lbDoctorName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cboDoctorID;
        private System.Windows.Forms.ComboBox cboPatientID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPatientNameKH;
        private System.Windows.Forms.TextBox txtPatientNameEN;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label label6;
    }
}

