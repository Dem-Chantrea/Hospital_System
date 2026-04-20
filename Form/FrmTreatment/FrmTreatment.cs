using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FrmTreatment
{
    public partial class FrmTreatment : Form
    {
        SqlCommand cmd = new SqlCommand();

        public FrmTreatment()
        {
            InitializeComponent();

        }
        private void LoadAllTreatmentDetails()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tbTreatmentDetail", Program.Connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        if (dataGridView1.Columns.Contains("TreatmentID"))
                        {
                            dataGridView1.Columns["TreatmentID"].Visible = false;
                        }

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading treatment details: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctors()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT DoctorID, DoctorName FROM vDoctorList", Program.Connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboDoctorID.DataSource = dt;
                cboDoctorID.DisplayMember = "DoctorID"; 
                cboDoctorID.ValueMember = "DoctorID";  
                cboDoctorID.SelectedIndex = -1;

                cboDoctorID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboDoctorID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboDoctorID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtDocName.Text = drv["DoctorName"].ToString();
                    }
                    else
                    {
                        txtDocName.Clear();
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

        private void LoadDiseases()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT DiseaseID, DiseaseName FROM vDiseaseList", Program.Connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cboDiseaseID.DataSource = dt;
                cboDiseaseID.DisplayMember = "DiseaseID";  
                cboDiseaseID.ValueMember = "DiseaseID";    
                cboDiseaseID.SelectedIndex = -1;

                cboDiseaseID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboDiseaseID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboDiseaseID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtDiseaseName.Text = drv["DiseaseName"].ToString();
                    }
                    else
                    {
                        txtDiseaseName.Clear();
                    }
                };
            }
        }

        private void FrmTreatment_Load_1(object sender, EventArgs e)
        {
            LoadAllTreatmentDetails();
            LoadDoctors();
            LoadPatients();
            LoadDiseases();
        }

        private void RefreshDataGridViewAfterInsert()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllTreatmentDetails();
            }
            else if (int.TryParse(txtSearch.Text, out int treatmentID))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SearchTrearmentByID", Program.Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TreatmentID", treatmentID);

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
                    MessageBox.Show($"Error refreshing treatment detail: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void btnInsertGrp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtTreatmentID.Text, out int treatmentID))
                {
                    MessageBox.Show("Please enter a valid Treatment ID.");
                    return;
                }


                if (!TimeSpan.TryParse(txtDuration.Text, out TimeSpan duration))
                {
                    MessageBox.Show("Please enter the duration in HH:mm:ss format.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(
                    "InsertTreatmentDetail", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TreatmentID", treatmentID);
                    cmd.Parameters.AddWithValue("@DiseaseID", cboDiseaseID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DiseaseName", txtDiseaseName.Text);
                    cmd.Parameters.AddWithValue("@TreatmentMethod", txtTreatmentMethod.Text);
                    cmd.Parameters.AddWithValue("@Duration", duration);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Treatment detail inserted successfully.");

                    RefreshDataGridViewAfterInsert();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting treatment detail: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateGrp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtTreatmentID.Text, out int treatmentID))
                {
                    MessageBox.Show("Please enter a valid Treatment ID.");
                    return;
                }


                if (!TimeSpan.TryParse(txtDuration.Text, out TimeSpan duration))
                {
                    MessageBox.Show("Please enter the duration in HH:mm:ss format.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(
                    "UpdateTreatmentDetail", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TreatmentID", treatmentID);
                    cmd.Parameters.AddWithValue("@DiseaseID", cboDiseaseID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DiseaseName", txtDiseaseName.Text);
                    cmd.Parameters.AddWithValue("@TreatmentMethod", txtTreatmentMethod.Text);
                    cmd.Parameters.AddWithValue("@Duration", duration);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Treatment detail updated successfully.");

                    RefreshDataGridViewAfterInsert();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating treatment detail: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadAllTreatmentDetails();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tbTreatmentDetail " +
                    "WHERE CAST(TreatmentID AS NVARCHAR(50)) " +
                    "LIKE @SearchPattern", 
                    Program.Connection))
                {
                    cmd.Parameters.AddWithValue("@SearchPattern", $"%{searchText}%");

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
                MessageBox.Show($"Error searching treatment detail: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtTreatmentID.Text, out int treatmentID))
                {
                    MessageBox.Show("Please enter a valid Treatment ID.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTreatmentName.Text))
                {
                    MessageBox.Show("Please enter a Treatment Name.");
                    return;
                }

                if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime treatmentDate))
                {
                    MessageBox.Show("Please enter a valid Treatment Date.");
                    return;
                }


                using (SqlCommand cmd = new SqlCommand(
                    "InsertTreatment", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TreatmentID", treatmentID);
                    cmd.Parameters.AddWithValue("@TreatmentName", txtTreatmentName.Text);
                    cmd.Parameters.AddWithValue("@TreatmentDate", treatmentDate);
                    cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorID", cboDoctorID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtPatientNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtPatientNameEN.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDocName.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Treatment inserted successfully.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting treatment: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtTreatmentID.Text, out int treatmentID))
                {
                    MessageBox.Show("Please enter a valid Treatment ID.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTreatmentName.Text))
                {
                    MessageBox.Show("Please enter a Treatment Name.");
                    return;
                }

                if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime treatmentDate))
                {
                    MessageBox.Show("Please enter a valid Treatment Date.");
                    return;
                }


                using (SqlCommand cmd = new SqlCommand(
                    "UpdateTreatment", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TreatmentID", treatmentID);
                    cmd.Parameters.AddWithValue("@TreatmentName", txtTreatmentName.Text);
                    cmd.Parameters.AddWithValue("@TreatmentDate", treatmentDate);
                    cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtPatientNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtPatientNameEN.Text);
                    cmd.Parameters.AddWithValue("@DoctorID", cboDoctorID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDocName.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Treatment updated successfully.");         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating treatment: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                txtTreatmentID.Clear();
                txtTreatmentName.Clear();
                dateTimePicker1.Value = DateTime.Now;
                cboDiseaseID.SelectedIndex = -1;
                txtPatientNameKH.Clear();
                txtPatientNameEN.Clear();
                cboDoctorID.SelectedIndex = -1;
                txtDocName.Clear();
                cboPatientID.SelectedIndex = -1;
                txtDiseaseName.Clear();
                txtTreatmentMethod.Clear();
                txtDuration.Clear();

                txtTreatmentID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form: " + ex.Message);
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
    }
}
