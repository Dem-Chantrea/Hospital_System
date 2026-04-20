using FrmTreatment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormSupplier
{
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
        }

        private void LoadAllSuppliers()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbSupplier", Program.Connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSup.DataSource = dt;
                    dgvSup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllSuppliers();
                return;
            }

            using (SqlCommand cmd = new SqlCommand("SearchSupplierByID", Program.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierID", txtSearch.Text);


                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSup.DataSource = dt;
                }
            }
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertSupplier", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                    cmd.Parameters.AddWithValue("@SupplierPhone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@SupplierAddress", txtSupplierAdd.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Suppliers inserted successfully.");
                    LoadAllSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateSupplier", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierID", byte.Parse(txtSupplierID.Text));
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                    cmd.Parameters.AddWithValue("@SupplierPhone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@SupplierAddress", txtSupplierAdd.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier updated successfully.");
                    LoadAllSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtPhone.Clear();
            txtSupplierAdd.Clear();
            txtSearch.Clear();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            MainForm mainfrm = new MainForm();
            mainfrm.Show();
            this.Close();
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();
            this.Hide();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            LoadAllSuppliers();
        }

    }
}
