using FrmTreatment;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrmPayment
{
    public partial class FormPayment : Form
    {
        public FormPayment()
        {
            InitializeComponent();
        }

        private void LoadStaffs()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT StaffID, StaffNameKH, StaffNameEN, StaffPosition FROM vStaffList", Program.Connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboStaffID.DataSource = dt;
                cboStaffID.DisplayMember = "StaffID"; 
                cboStaffID.ValueMember = "StaffID";   
                cboStaffID.SelectedIndex = -1;

                cboStaffID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboStaffID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboStaffID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtStaffNameKH.Text = drv["StaffNameKH"].ToString();
                        txtStaffNameEN.Text = drv["StaffNameEN"].ToString();
                        txtStaffPosition.Text = drv["StaffPosition"].ToString();
                    }
                    else
                    {
                        txtStaffNameKH.Clear();
                        txtStaffNameEN.Clear();
                        txtStaffPosition.Clear();
                    }
                };
            }
        }

        private void LoadPatients()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT PatientID, PatientNameEN, PatientNameKH FROM vPatientList", Program.Connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboPatientID.DataSource = dt;
                cboPatientID.DisplayMember = "PatientID";  
                cboPatientID.ValueMember = "PatientID";   
                cboPatientID.SelectedIndex = -1;

                cboPatientID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboPatientID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboPatientID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtPatientNameKH.Text = drv["PatientNameKH"].ToString();
                            txtPatientNameEN.Text = drv["PatientNameEN"].ToString();
                    }
                    else
                    {
                        txtPatientNameEN.Clear();
                        txtPatientNameKH.Clear();
                    }
                };
            }
        }

        private void LoadPayments()
        {
           

                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbPayment", Program.Connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPayments.DataSource = dt;

                    HideColumns(dgvPayments, "PatientNameKH", "PatientNameEN", "StaffPosition", "StaffNameEN", "StaffNameKH");
                }
        }

        private void HideColumns(DataGridView dgv, params string[] columnNames)
        {
            foreach (string colName in columnNames)
            {
                if (dgv.Columns.Contains(colName))
                {
                    dgv.Columns[colName].Visible = false;
                }
            }
        }

        private bool ValidatePaymentInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPaymentID.Text))
            {
                MessageBox.Show("Payment ID is required.");
                txtPaymentID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Please enter a valid amount.");
                txtAmount.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbPaymentMethod.Text))
            {
                MessageBox.Show("Please select a payment method.");
                cmbPaymentMethod.Focus();
                return false;
            }

            return true;
        }


        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (!ValidatePaymentInputs()) return;

            string query = "INSERT INTO tbPayment (PaymentID, PayDate, PaidAmount, PaymentMethod, PatientID, StaffID, StaffNameKH, StaffNameEN, StaffPosition) " +
                           "VALUES (@PaymentID, @PayDate, @PaidAmount, @PaymentMethod, @PatientID, @StaffID,@StaffNameEN,@StaffNameKH,@StaffPosition)";

            if (Program.Connection.State != ConnectionState.Open)
                Program.Connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@PaymentID", txtPaymentID.Text);
                cmd.Parameters.AddWithValue("@PayDate", dtpPayDate.Value);
                cmd.Parameters.AddWithValue("@PaidAmount", decimal.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                cmd.Parameters.AddWithValue("@StaffID", cboStaffID.SelectedValue);
                cmd.Parameters.AddWithValue("@StaffNameEN", txtStaffNameEN.Text);
                cmd.Parameters.AddWithValue("@StaffNameKH", txtStaffNameKH.Text);
                cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);

                if (!cmbPaymentMethod.Items.Contains(cmbPaymentMethod.Text))
                {
                    cmbPaymentMethod.Items.Add(cmbPaymentMethod.Text);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment inserted successfully.");
                LoadPayments();
            }
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (!ValidatePaymentInputs()) return;

            string query = "UPDATE tbPayment SET PayDate=@PayDate, PaidAmount=@PaidAmount, PaymentMethod=@PaymentMethod, " +
                           "PatientID=@PatientID, StaffID=@StaffID, StaffNameEN=@StaffNameEN, StaffNameKH=@StaffNameKH, StaffPosition= @StaffPosition WHERE PaymentID=@PaymentID";

            using (SqlCommand cmd = new SqlCommand(query, Program.Connection))
            {
                cmd.Parameters.AddWithValue("@PayDate", dtpPayDate.Value);
                cmd.Parameters.AddWithValue("@PaidAmount", decimal.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                cmd.Parameters.AddWithValue("@StaffID", cboStaffID.SelectedValue);
                cmd.Parameters.AddWithValue("@PaymentID", txtPaymentID.Text);
                cmd.Parameters.AddWithValue("@StaffNameEN", txtStaffNameEN.Text);
                cmd.Parameters.AddWithValue("@StaffNameKH", txtStaffNameKH.Text);
                cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);

                if (!cmbPaymentMethod.Items.Contains(cmbPaymentMethod.Text))
                {
                    cmbPaymentMethod.Items.Add(cmbPaymentMethod.Text);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment updated successfully.");
                LoadPayments();
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtPaymentID.Clear();
            txtAmount.Clear();
            cboPatientID.SelectedIndex = -1;
            txtPatientNameKH.Clear();
            cboStaffID.SelectedIndex = -1;
            txtStaffNameKH.Clear();
            cmbPaymentMethod.SelectedIndex = -1;
            dtpPayDate.Value = DateTime.Now;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnL_out_Click_1(object sender, EventArgs e)
        {
            LoginFrm loginFrm = new LoginFrm();
            loginFrm.Show();
            this.Hide();    
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            LoadPayments();
            LoadStaffs();
            LoadPatients();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbPayment WHERE PaymentID LIKE @PaymentID", Program.Connection))
            {
                da.SelectCommand.Parameters.AddWithValue("@PaymentID", "%" + txtSearch.Text + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPayments.DataSource = dt;
            }
        }
    }
}