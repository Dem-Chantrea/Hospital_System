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

namespace FormDisease
{
    public partial class FormDisease : Form
    {
        public FormDisease()
        {
            InitializeComponent();


        }
        private void LoadAllDisease()
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tbDisease", Program.Connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dgvDs.DataSource = dt;

                        if (dgvDs.Columns.Contains("Disease"))
                        {
                            dgvDs.Columns["DiseaseID"].Visible = false;
                        }

                        dgvDs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Disease : {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshDataGridViewAfterInsert()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllDisease();
            }
            else if (int.TryParse(txtSearch.Text, out int diseaseID))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SearchDiseaseByID", Program.Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiseaseID", diseaseID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);
                            dgvDs.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error refreshing Disease: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dgvDs.DataSource = null;
            }
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtDsID.Text, out int diseaseID))
                {
                    MessageBox.Show("Please enter a valid Disease ID.");
                    return;
                }


                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spInsertDisease", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseID", txtDsID.Text);
                    cmd.Parameters.AddWithValue("@DiseaseName", txtDsName.Text);
                    cmd.Parameters.AddWithValue("@DiseaseCategory", txtDsCate.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("DiseaseID inserted successfully.");

                    RefreshDataGridViewAfterInsert();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting disease: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (!int.TryParse(txtDsID.Text, out int diseaseID))
                {
                    MessageBox.Show("Please enter a valid Disease ID.");
                    return;
                }

                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spUpdateDisease", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DiseaseID", txtDsID.Text);
                    cmd.Parameters.AddWithValue("@DiseaseName", txtDsName.Text);
                    cmd.Parameters.AddWithValue("@DiseaseCategory", txtDsCate.Text);

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
            txtDsID.Clear();
            txtDsName.Clear();
            txtDsCate.Clear();
            txtSearch.Clear();
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

        private void dgvDs_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDs.Rows.Count)
            {
                DataGridViewRow row = dgvDs.Rows[e.RowIndex];
                txtDsID.Text = row.Cells["DiseaseID"].Value.ToString();
                txtDsName.Text = row.Cells["DiseaseName"].Value.ToString();
                txtDsCate.Text = row.Cells["DiseaseCategory"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Please select a valid row.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchID = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchID))
            {
                LoadAllDisease();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                {
                    Program.Connection.Open();
                }

                if (int.TryParse(searchID, out int diseaseID))
                {
                    using (SqlCommand cmd = new SqlCommand("spSearchDiseaseByID", Program.Connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DiseaseID", diseaseID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDs.DataSource = dt;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid Disease ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching Disease: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDisease_Load(object sender, EventArgs e)
        {
            LoadAllDisease();
        }
    }
}

