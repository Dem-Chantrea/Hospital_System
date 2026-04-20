using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;
using FrmTreatment;


namespace FrmMedicineStock
{
    public partial class FrmMedicineStock : Form
    {
        public FrmMedicineStock()
        {
            InitializeComponent();
        }

        private void LoadAllMedicineStock()
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tbMedicineStock", Program.Connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dgvMDC.DataSource = dt;

                        if (dgvMDC.Columns.Contains("MedicineStock"))
                        {
                            dgvMDC.Columns["MedicineStockID"].Visible = false;
                        }

                        dgvMDC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Medicine : {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridViewAfterInsert()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllMedicineStock();
            }
            else if (int.TryParse(txtSearch.Text, out int MedicineStockID))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SearchMedicineStockByID", Program.Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MedicineStockID", MedicineStockID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);
                            dgvMDC.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error refreshing Medicine stock: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dgvMDC.DataSource = null;
            }
        }


        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtmdsID.Text, out int medicineStockID))
                {
                    MessageBox.Show("Please enter a valid Medicine stock ID.");
                    return;
                }


                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spInsertMedicineStock", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineStockID", medicineStockID);
                    cmd.Parameters.AddWithValue("@MedicineStockName", txtmdsName.Text);
                    cmd.Parameters.AddWithValue("@Category", txtCate.Text);
                    cmd.Parameters.AddWithValue("@StockQty", int.Parse(txtSqty.Text));
                    cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUP.Text));


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("MedicineStock inserted successfully.");

                    RefreshDataGridViewAfterInsert();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting medicine stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                {
                    Program.Connection.Close();
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (!int.TryParse(txtmdsID.Text, out int medicineStockID))
                {
                    MessageBox.Show("Please enter a valid medicine stock ID.");
                    return;
                }

                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spUpdateMedicineStock", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineStockID", medicineStockID);
                    cmd.Parameters.AddWithValue("@MedicineStockName", txtmdsName.Text);
                    cmd.Parameters.AddWithValue("@Category", txtCate.Text);
                    cmd.Parameters.AddWithValue("@StockQty", int.Parse(txtSqty.Text));
                    cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUP.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Disease updated successfully.");

                    RefreshDataGridViewAfterInsert();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Disease: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                {
                    Program.Connection.Close();
                }
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtmdsID.Clear();
            txtmdsName.Clear();
            txtCate.Clear();
            txtSqty.Clear();
            txtUP.Clear();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchID = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchID))
            {
                LoadAllMedicineStock();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                if (int.TryParse(searchID, out int medecineStockID))
                {
                    using (SqlCommand cmd = new SqlCommand("SearchMedicineStockByID", Program.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MedicineStockID", medecineStockID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvMDC.DataSource = dt;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid medicine stock ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching Medicine Stock: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMDC_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMDC.Rows.Count)
            {
                DataGridViewRow row = dgvMDC.Rows[e.RowIndex];
                txtmdsID.Text = row.Cells["MedicineStockID"].Value.ToString();
                txtmdsName.Text = row.Cells["MedicineStockName"].Value.ToString();
                txtCate.Text = row.Cells["Category"].Value.ToString();
                txtSqty.Text = row.Cells["StockQty"].Value.ToString();
                txtUP.Text = row.Cells["UnitPrice"].Value.ToString();
            }
        }

        private void FrmMedicineStock_Load_1(object sender, EventArgs e)
        {
            LoadAllMedicineStock();
        }
    }
}
