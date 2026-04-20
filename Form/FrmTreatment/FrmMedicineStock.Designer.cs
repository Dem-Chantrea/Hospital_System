using System.Drawing;
using System.Windows.Forms;

namespace FrmMedicineStock
{
    partial class FrmMedicineStock
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmdsID = new System.Windows.Forms.TextBox();
            this.txtmdsName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvMDC = new System.Windows.Forms.DataGridView();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMDC)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orchid;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 64);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrmTreatment.Properties.Resources.MedicineStock;
            this.pictureBox1.Location = new System.Drawing.Point(25, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(123, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(306, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "©Copyright ISAD_A3_G26_GROUP1 (2025).";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "MEDICINE STOCK\'S INFORMATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "MedicineStock ID";
            // 
            // txtmdsID
            // 
            this.txtmdsID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmdsID.Location = new System.Drawing.Point(221, 97);
            this.txtmdsID.Name = "txtmdsID";
            this.txtmdsID.Size = new System.Drawing.Size(408, 26);
            this.txtmdsID.TabIndex = 2;
            // 
            // txtmdsName
            // 
            this.txtmdsName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmdsName.Location = new System.Drawing.Point(221, 139);
            this.txtmdsName.Name = "txtmdsName";
            this.txtmdsName.Size = new System.Drawing.Size(408, 26);
            this.txtmdsName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "MedicineStock Name";
            // 
            // txtCate
            // 
            this.txtCate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCate.Location = new System.Drawing.Point(221, 181);
            this.txtCate.Name = "txtCate";
            this.txtCate.Size = new System.Drawing.Size(408, 26);
            this.txtCate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Category";
            // 
            // txtSqty
            // 
            this.txtSqty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSqty.Location = new System.Drawing.Point(221, 225);
            this.txtSqty.Name = "txtSqty";
            this.txtSqty.Size = new System.Drawing.Size(408, 26);
            this.txtSqty.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "StockQty";
            // 
            // txtUP
            // 
            this.txtUP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUP.Location = new System.Drawing.Point(221, 270);
            this.txtUP.Name = "txtUP";
            this.txtUP.Size = new System.Drawing.Size(408, 26);
            this.txtUP.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Unit Price";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(221, 323);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(372, 26);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Search (MedicineStock ID)";
            // 
            // dgvMDC
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMDC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMDC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMDC.Location = new System.Drawing.Point(26, 365);
            this.dgvMDC.Name = "dgvMDC";
            this.dgvMDC.RowHeadersVisible = false;
            this.dgvMDC.Size = new System.Drawing.Size(600, 123);
            this.dgvMDC.TabIndex = 13;
            this.dgvMDC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMDC_CellContentClick_1);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightPink;
            this.btnInsert.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnInsert.Location = new System.Drawing.Point(26, 513);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(99, 42);
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightPink;
            this.btnUpdate.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(147, 513);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 42);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightPink;
            this.btnNew.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.Location = new System.Drawing.Point(269, 513);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(99, 42);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(401, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 42);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogout.Font = new System.Drawing.Font("Sitka Banner", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(530, 513);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(99, 42);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // FrmMedicineStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 566);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgvMDC);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSqty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmdsName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtmdsID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(671, 605);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(671, 605);
            this.Name = "FrmMedicineStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicineStock\'s Form ";
            this.Load += new System.EventHandler(this.FrmMedicineStock_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMDC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox txtmdsID;
        private TextBox txtmdsName;
        private Label label3;
        private TextBox txtCate;
        private Label label4;
        private TextBox txtSqty;
        private Label label5;
        private TextBox txtUP;
        private Label label6;
        private TextBox txtSearch;
        private Label label7;
        private DataGridView dgvMDC;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnNew;
        private Button btnClose;
        private Button btnLogout;
        private Label label8;
        private PictureBox pictureBox1;
    }
}