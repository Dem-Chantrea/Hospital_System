using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrmTreatment;

namespace FormPrescription
{
    public partial class FormPrescription : Form
    {
        SqlCommand cmd = new SqlCommand();

        public FormPrescription()
        {
            InitializeComponent();

        }

        private void LoadAllPrescriptionDetails()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM tbPrescriptionDetail", Program.Connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dgvShow.DataSource = dt;

                        if (dgvShow.Columns.Contains("PrescriptionID"))
                        {
                            dgvShow.Columns["PrescriptionID"].Visible = false;
                        }

                        dgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading prescription details: {ex.Message}",
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
                cboDoctorID.DisplayMember = "DoctorID"; // Show ID in ComboBox
                cboDoctorID.ValueMember = "DoctorID";   // Use ID as value
                cboDoctorID.SelectedIndex = -1;


                cboDoctorID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboDoctorID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboDoctorID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtDoctorName.Text = drv["DoctorName"].ToString();
                    }
                    else
                    {
                        txtDoctorName.Clear();
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
                cboPatientID.DisplayMember = "PatientID";   // Show ID
                cboPatientID.ValueMember = "PatientID";     // Use ID
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
                cboDiseaseID.DisplayMember = "DiseaseID";   // Show ID
                cboDiseaseID.ValueMember = "DiseaseID";     // Use ID
                cboDiseaseID.SelectedIndex = -1;

                cboDiseaseID.SelectedIndexChanged += (s, e) =>
                {
                    if (cboDiseaseID.SelectedIndex != -1)
                    {
                        DataRowView drv = cboDiseaseID.SelectedItem as DataRowView;
                        if (drv != null)
                            txtDiName.Text = drv["DiseaseName"].ToString();
                    }
                    else
                    {
                        txtDiName.Clear();
                    }
                };
            }
        }

        private void FormPrescription_Load(object sender, EventArgs e)
        {
            LoadAllPrescriptionDetails();
            LoadDoctors();
            LoadPatients();
            LoadDiseases();
        }

        private void RefreshDataGridViewAfterInsert()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadAllPrescriptionDetails();
            }
            else if (int.TryParse(txtSearch.Text, out int PrescriptionID))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "SearchPrescriptionByID", Program.Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);
                            dgvShow.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error refreshing prescription detail: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dgvShow.DataSource = null;
            }
        }


        private void btnInsertDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtID.Text, out int PrescriptionID))
                {
                    MessageBox.Show("Please enter a valid prescription ID.");
                    return;
                }



                if (!TimeSpan.TryParse(txtDu.Text, out TimeSpan duration))
                {
                    MessageBox.Show("Please enter the duration in HH:mm:ss format.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(
                    "InsertPrescriptionDetail", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                    cmd.Parameters.AddWithValue("@DiseaseID", cboDiseaseID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DiseaseName", txtDiName.Text);
                    cmd.Parameters.AddWithValue("@TreatmentMethod", txtTM.Text);
                    cmd.Parameters.AddWithValue("@Duration", duration);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("prescription detail inserted successfully.");


                    RefreshDataGridViewAfterInsert();
                    //txtID.Clear();
                    //cboDiseaseID.SelectedIndex = -1;
                    //txtDiName.Clear();
                    //txtTM.Clear();
                    //txtDu.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting Prescription detail: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtID.Text, out int PrescriptionID))
                {
                    MessageBox.Show("Please enter a valid Prescription ID.");
                    return;
                }



                if (!TimeSpan.TryParse(txtDu.Text, out TimeSpan duration))
                {
                    MessageBox.Show("Please enter the duration in HH:mm:ss format.");
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(
                    "UpdatePrescriptionDetail", Program.Connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                    cmd.Parameters.AddWithValue("@DiseaseID", cboDiseaseID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DiseaseName", txtDiName.Text);
                    cmd.Parameters.AddWithValue("@TreatmentMethod", txtTM.Text);
                    cmd.Parameters.AddWithValue("@Duration", duration);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription detail updated successfully.");

                    RefreshDataGridViewAfterInsert();
                    //txtID.Clear();
                    //cboDiseaseID.SelectedIndex = -1;
                    //txtDiName.Clear();
                    //txtTM.Clear();
                    //txtDu.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating Prescription detail: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadAllPrescriptionDetails();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                using (SqlCommand cmd = new SqlCommand(
                     "SELECT * FROM tbPrescriptionDetail WHERE CAST(PrescriptionID AS NVARCHAR(50)) LIKE @SearchPattern",
                    Program.Connection))
                {
                    cmd.Parameters.AddWithValue("@SearchPattern", $"%{searchText}%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);
                        dgvShow.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching  detail: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtID.Text.Trim(), out int PrescriptionID))
                {
                    MessageBox.Show("Please enter a valid Prescription ID.");
                    return;
                }


                if (cboPatientID.SelectedIndex == -1 || cboDoctorID.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select both a patient and a doctor.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDg.Text))
                {
                    MessageBox.Show("Please enter diagnosis.");
                    return;
                }

                DateTime prescriptionDate = dtpDate.Value;

                using (SqlCommand cmd = new SqlCommand("InsertPrescription", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                    cmd.Parameters.AddWithValue("@Diagnosis", txtDg.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateIssue", prescriptionDate);
                    cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtPatientNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtPatientNameEN.Text);
                    cmd.Parameters.AddWithValue("@DoctorID", cboDoctorID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDoctorName.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting prescription: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();
                if (!int.TryParse(txtID.Text, out int PrescriptionID))
                {
                    MessageBox.Show("Please enter a valid prescription ID.");
                    return;
                }

                if (!DateTime.TryParse(dtpDate.Text, out DateTime prescriptionDate))
                {
                    MessageBox.Show("Please enter a valid prescription Date.");
                    return;
                }


                using (SqlCommand cmd = new SqlCommand(
                    "UpdatePrescription", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                    cmd.Parameters.AddWithValue("@Diagnosis", txtDg.Text.Trim());
                    cmd.Parameters.AddWithValue("@DateIssue", prescriptionDate);
                    cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtPatientNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtPatientNameEN.Text);
                    cmd.Parameters.AddWithValue("@DoctorID", cboDoctorID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDoctorName.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("prescription updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating prescription: " + ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                //txtID.Clear();
                dtpDate.Value = DateTime.Now;
                cboDiseaseID.SelectedIndex = -1;
                txtPatientNameKH.Clear();
                txtPatientNameEN.Clear();
                cboDoctorID.SelectedIndex = -1;
                txtDoctorName.Clear();
                cboPatientID.SelectedIndex = -1;
                txtDiName.Clear();
                txtTM.Clear();
                txtDu.Clear();
                txtID.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form: " + ex.Message);
            }
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
    }
}
