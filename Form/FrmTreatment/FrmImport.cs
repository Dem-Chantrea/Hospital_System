using FrmTreatment;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FormImport
{
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }

        private void LoadAllImportDetails()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbImportDetail", Program.Connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dataGridView1.Columns.Contains("ImportID"))
                        {
                            dataGridView1.Columns["ImportID"].Visible = true;
                        }

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}");
            }
            CalculateTotalAmount();
            UpdateTotalAmountInImport();
        }

        private void CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ImportAmount"].Value != null && decimal.TryParse(row.Cells["ImportAmount"].Value.ToString(), out decimal amount))
                {
                    total += amount;
                }
            }
            txtTotalAmount.Text = total.ToString("F2");
        }

        private bool ValidateImportInputs()
        {
            if (string.IsNullOrWhiteSpace(txtImportID.Text))
            {
                MessageBox.Show("Please fill in all import fields.");
                return false;
            }
            return true;
        }

        private bool ValidateImportDetailInputs()
        {
            if (string.IsNullOrWhiteSpace(txtImportID.Text) ||
                string.IsNullOrWhiteSpace(txtImportqty.Text) ||
                string.IsNullOrWhiteSpace(txtImportUP.Text))
            {
                MessageBox.Show("Please fill in all import detail fields.");
                return false;
            }
            return true;
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

        private void LoadSuppliers()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT SupplierID, SupplierName FROM vSupplierList", Program.Connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboSupplierID.DataSource = dt;
                cboSupplierID.DisplayMember = "SupplierID";
                cboSupplierID.ValueMember = "SupplierID";   
                cboSupplierID.SelectedIndex = -1;

                cboSupplierID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboSupplierID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboSupplierID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtSupplierName.Text = drv["SupplierName"].ToString();
                    }
                    else
                    {
                        txtSupplierName.Clear();
                    }
                };
            }
        }

        private void LoadMedicineStocks()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT MedicineStockID, MedicineStockName FROM vMedicineStockList", Program.Connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboMedicineStockID.DataSource = dt;
                cboMedicineStockID.DisplayMember = "MedicineStockID"; 
                cboMedicineStockID.ValueMember = "MedicineStockID";   
                cboMedicineStockID.SelectedIndex = -1;

                cboMedicineStockID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboMedicineStockID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboMedicineStockID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtMedName.Text = drv["MedicineStockName"].ToString();
                    }
                    else
                    {
                        txtMedName.Clear();
                    }
                };
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateImportInputs()) return;
            decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount);

            try
            {

                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spInsertImport", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", txtImportID.Text);
                    cmd.Parameters.AddWithValue("@ImportDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StaffID", cboStaffID.SelectedValue);
                    cmd.Parameters.AddWithValue("@StaffNameEN", txtStaffNameEN.Text);
                    cmd.Parameters.AddWithValue("@StaffNameKH", txtStaffNameKH.Text);
                    cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", cboSupplierID.SelectedValue);
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                    cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = totalAmount;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Import inserted successfully.");
                    LoadAllImportDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting import: " + ex.Message);
            }
        }

        private void btnInsertDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateImportDetailInputs()) return;

            int.TryParse(txtImportqty.Text, out int qty);
            decimal.TryParse(txtImportUP.Text, out decimal price);
            decimal amount = qty * price;

            try
            {

                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spInsertImportDetail", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", txtImportID.Text);
                    cmd.Parameters.AddWithValue("@MedicineStockID", cboMedicineStockID.SelectedValue);
                    cmd.Parameters.AddWithValue("@MedicineStockName", txtMedName.Text);
                    cmd.Parameters.AddWithValue("@ImportQty", qty);
                    cmd.Parameters.Add("@ImportUnitPrice", SqlDbType.Money).Value = price;
                    cmd.Parameters.Add("@ImportAmount", SqlDbType.Money).Value = amount;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Import detail inserted successfully.");
                    RefreshDataGridViewAfterInsert();
                    LoadAllImportDetails(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting import detail: " + ex.Message);
            }
            UpdateTotalAmountInImport();
        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateImportDetailInputs()) return;

            int.TryParse(txtImportqty.Text, out int qty);
            decimal.TryParse(txtImportUP.Text, out decimal price);
            decimal amount = qty * price;

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spUpdateImportDetail", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", txtImportID.Text);
                    cmd.Parameters.AddWithValue("@MedicineStockID", cboMedicineStockID.SelectedValue);
                    cmd.Parameters.AddWithValue("@MedicineStockName", txtMedName.Text);
                    cmd.Parameters.AddWithValue("@ImportQty", qty);
                    cmd.Parameters.Add("@ImportUnitPrice", SqlDbType.Money).Value = price;
                    cmd.Parameters.Add("@ImportAmount", SqlDbType.Money).Value = amount;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Import detail updated successfully.");
                    RefreshDataGridViewAfterInsert();
                    LoadAllImportDetails(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating import detail: " + ex.Message);
            }
            UpdateTotalAmountInImport();
        }    

        private void CalculateImportAmount()
        {
            if (decimal.TryParse(txtImportqty.Text, out decimal qty) && decimal.TryParse(txtImportUP.Text, out decimal price))
            {
                txtImportAmount.Text = (qty * price).ToString("F2");
            }
            else
            {
                txtImportAmount.Clear();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllImportDetails();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spSearchImportByID", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", txtSearch.Text);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        CalculateTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridViewAfterInsert()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllImportDetails();
            }
            else if (int.TryParse(txtSearch.Text, out int importID))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SearchImportByID", Program.Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ImportID", importID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error refreshing import detail: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtImportID.Clear();
            cboStaffID.SelectedIndex=-1;
            txtStaffNameEN.Clear();
            txtStaffPosition.Clear();
            cboSupplierID.SelectedIndex=-1;
            txtTotalAmount.Clear();
            cboMedicineStockID.SelectedIndex=-1;
            txtImportAmount.Clear();
            txtImportqty.Clear();
            txtImportUP.Clear();
            txtSearch.Clear();
            dataGridView1.DataSource = null;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            LoadAllImportDetails();
            LoadStaffs();
            LoadSuppliers();
            LoadMedicineStocks();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();

            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateImportInputs()) return;
            decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount);

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spUpdateImport", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImportID", txtImportID.Text);
                    cmd.Parameters.AddWithValue("@ImportDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StaffID", cboStaffID.SelectedValue);
                    cmd.Parameters.AddWithValue("@StaffNameEN", txtStaffNameEN.Text);
                    cmd.Parameters.AddWithValue("@StaffNameKH", txtStaffNameKH.Text);
                    cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);
                    cmd.Parameters.AddWithValue("@SupplierID", cboSupplierID.SelectedValue);
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                    cmd.Parameters.Add("@TotalAmount", SqlDbType.Money).Value = totalAmount;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Import updated successfully.");
                    LoadAllImportDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating import: " + ex.Message);
            }
        }
        private void UpdateTotalAmountInImport()
        {
            decimal.TryParse(txtTotalAmount.Text, out decimal totalAmount);

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE tbImport SET TotalAmount = @TotalAmount WHERE ImportID = @ImportID", Program.Connection))
                {
                    cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@ImportID", txtImportID.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update total amount in tbImport: " + ex.Message);
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                {
                    Program.Connection.Close();
                }
            }
        }


        private void txtImportqty_TextChanged(object sender, EventArgs e)
        {
            CalculateImportAmount();
        }

        private void txtImportUP_TextChanged(object sender, EventArgs e)
        {
            CalculateImportAmount();
        }

    }
}
