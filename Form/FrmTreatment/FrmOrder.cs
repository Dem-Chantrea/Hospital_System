using FrmTreatment;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FormOrder
{
    public partial class FrmOrder : Form
    {
        public FrmOrder()
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
                            txtMedicineName.Text = drv["MedicineStockName"].ToString();
                    }
                    else
                    {
                        txtMedicineName.Clear();
                    }
                };
            }
        }

        private void LoadAllOrderDetails()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbOrderDetail", Program.Connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dataGridView1.Columns.Contains("OrderID"))
                        {
                            dataGridView1.Columns["OrderID"].Visible = true; 
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
            UpdateTotalAmountInOrder();
        }

        private bool ValidateOrderInputs()
        {
            if (string.IsNullOrWhiteSpace(txtOrderID.Text) ||
                string.IsNullOrWhiteSpace(txtStaffNameKH.Text) ||
                string.IsNullOrWhiteSpace(txtStaffNameEN.Text) ||
                string.IsNullOrWhiteSpace(txtStaffPosition.Text))
            {
                MessageBox.Show("Please fill all Order fields.");
                return false;
            }
            if (!decimal.TryParse(txtTotal.Text, out _))
            {
                MessageBox.Show("Invalid total amount.");
                return false;
            }
            return true;
        }

        private bool ValidateOrderDetailInputs()
        {
            if (string.IsNullOrWhiteSpace(txtOrderID.Text) ||
                string.IsNullOrWhiteSpace(txtMedicineName.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtUnitprice.Text))
            {
                MessageBox.Show("Please fill all detail fields.");
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out _) ||
                !decimal.TryParse(txtUnitprice.Text, out _))
            {
                MessageBox.Show("Quantity must be integer; Unit Price must be decimal.");
                return false;
            }
            return true;
        }

        private void CalculateOrderAmount()
        {
            if (decimal.TryParse(txtQuantity.Text, out var qty) &&
                decimal.TryParse(txtUnitprice.Text, out var price))
            {
                txtSubTotal.Text = (qty * price).ToString("F2");
            }
            else
            {
                txtSubTotal.Clear();
            }
        }

        private void CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["SubTotal"].Value != null &&
                    decimal.TryParse(row.Cells["SubTotal"].Value.ToString(), out var val))
                {
                    total += val;
                }
            }
            txtTotal.Text = total.ToString("F2");
        }


        private void UpdateTotalAmountInOrder()
        {
            if (!decimal.TryParse(txtTotal.Text, out decimal total)) return;

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (var cmd = new SqlCommand(
                    "UPDATE tbOrder SET TotalAmount = @Total WHERE OrderID = @OrderID", Program.Connection))
                {
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update total: {ex.Message}");
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }


        private void FrmOrder_Load(object sender, EventArgs e)
        {
            LoadAllOrderDetails();
            LoadStaffs();
            LoadSuppliers();
            LoadMedicineStocks();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateOrderInputs()) return;

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (var cmd = new SqlCommand("InsertOrder", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text.Trim());
                    cmd.Parameters.AddWithValue("@OrderDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StaffID", cboStaffID.SelectedValue);
                    cmd.Parameters.AddWithValue("@StaffNameKH", txtStaffNameKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@StaffNameEN", txtStaffNameEN.Text.Trim());
                    cmd.Parameters.AddWithValue("@SupplierID", cboSupplierID.SelectedValue);
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text.Trim());
                    cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(txtTotal.Text));
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order inserted.");
                LoadAllOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insert error: {ex.Message}");
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }

        }

        private void btnInsertDetail_Click_1(object sender, EventArgs e)
        {
            if (!ValidateOrderDetailInputs()) return;

            decimal qty = decimal.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtUnitprice.Text);
            decimal subtotal = qty * price;
            txtSubTotal.Text = subtotal.ToString("F2");

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (var cmd = new SqlCommand("InsertOrderDetail", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text.Trim());
                    cmd.Parameters.AddWithValue("@MedicineStockID", cboMedicineStockID.SelectedValue);
                    cmd.Parameters.AddWithValue("@MedicineStockName", txtMedicineName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Quantity", qty);
                    cmd.Parameters.AddWithValue("@UnitPrice", price);
                    cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order detail inserted.");
                LoadAllOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insert detail error: {ex.Message}");
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateOrderInputs()) return;

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (var cmd = new SqlCommand("UpdateOrder", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text.Trim());
                    cmd.Parameters.AddWithValue("@OrderDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StaffID", cboStaffID.SelectedValue);
                    cmd.Parameters.AddWithValue("@StaffNameKH", txtStaffNameKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@StaffNameEN", txtStaffNameEN.Text.Trim());
                    cmd.Parameters.AddWithValue("@SupplierID", cboSupplierID.SelectedValue);
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim());
                    cmd.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text.Trim());
                    cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(txtTotal.Text));
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order updated.");
                LoadAllOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update error: {ex.Message}");
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();    
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();

            this.Hide();
        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateOrderDetailInputs()) return;

            decimal qty = decimal.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtUnitprice.Text);
            decimal subtotal = qty * price;
            txtSubTotal.Text = subtotal.ToString("F2");

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (var cmd = new SqlCommand("UpdateOrderDetail", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text.Trim());
                    cmd.Parameters.AddWithValue("@MedicineStockID", cboMedicineStockID.SelectedValue);
                    cmd.Parameters.AddWithValue("@MedicineStockName", txtMedicineName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Quantity", qty);
                    cmd.Parameters.AddWithValue("@UnitPrice", price);
                    cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Order detail updated.");
                LoadAllOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update detail error: {ex.Message}");
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtOrderID.Clear();
            cboStaffID.SelectedIndex = -1;
            txtStaffNameKH.Clear();
            txtStaffNameEN.Clear();
            cboSupplierID.SelectedIndex = -1;
            txtStaffPosition.Clear();
            txtTotal.Clear();
            dateTimePicker1.Value = DateTime.Now;
            cboMedicineStockID.SelectedIndex = -1;
            txtMedicineName.Clear();
            txtQuantity.Clear();
            txtUnitprice.Clear();
            txtSubTotal.Clear();
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllOrderDetails();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (var cmd = new SqlCommand("SearchOrderByID", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", txtSearch.Text.Trim());

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        CalculateTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}");
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void txtQuantity_TextChanged_1(object sender, EventArgs e)
        {
            CalculateOrderAmount();
        }

        private void txtUnitprice_TextChanged_1(object sender, EventArgs e)
        {
            CalculateOrderAmount();
        }
    }
}
