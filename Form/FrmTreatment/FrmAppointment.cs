using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrmTreatment;

namespace FormAppointment
{
    public partial class FormAppointment : Form
    {
        public FormAppointment()
        {
            InitializeComponent();
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
                            txtDoctorName.Text = drv["DoctorName"].ToString();
                    }
                    else
                    {
                        txtDoctorName.Clear();
                    }
                };
            }
        }

        private void LoadAllAppointments()
        {
            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbAppointment", Program.Connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    //dataGridView1.Columns["AppointmentID"].Visible = false;
                    dataGridView1.Columns["PatientNameEN"].Visible = false;
                    dataGridView1.Columns["DoctorName"].Visible = false;
                    dataGridView1.Columns["PatientNameKH"].Visible = false;
              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message);
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PatientNameKH")
            {
                e.CellStyle.Font = new Font("Khmer OS Battambong", 11, FontStyle.Regular);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtAppointmentID.Clear();
            txtDuration.Clear();
            txtStatus.Clear();
            cboPatientID.SelectedIndex = -1;
            txtPatientNameKH.Clear();
            txtPatientNameEN.Clear();
            cboDoctorID.SelectedIndex = -1;
            txtDoctorName.Clear();
            txtSearch.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }


        private void FormAppointment_Load_1(object sender, EventArgs e)
        {
            LoadAllAppointments();
            LoadDoctors();
            LoadPatients();

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();

            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                LoadAllAppointments();
                return;
            }

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbAppointment WHERE CAST(AppointmentID AS NVARCHAR) LIKE @search", Program.Connection))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string query = "INSERT INTO tbAppointment (AppointmentID, AppointmentDate, Duration, AppointmentStatus, PatientID, DoctorID, PatientNameKH, PatientNameEN, DoctorName) " +
                           "VALUES (@AppointmentID, @AppointmentDate, @Duration, @AppointmentStatus, @PatientID, @DoctorID, @PatientNameKH, @PatientNameEN, @DoctorName)";

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, Program.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AppointmentID", txtAppointmentID.Text);
                    cmd.Parameters.AddWithValue("@AppointmentDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Duration", TimeSpan.Parse(txtDuration.Text));
                    cmd.Parameters.AddWithValue("@AppointmentStatus", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtPatientNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtPatientNameEN.Text);
                    cmd.Parameters.AddWithValue("@DoctorID", cboDoctorID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDoctorName.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Appointment inserted successfully.");
                    LoadAllAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string query = "UPDATE tbAppointment SET " +
               "AppointmentDate = @AppointmentDate, " +
               "Duration = @Duration, " +
               "AppointmentStatus = @AppointmentStatus, " +
               "PatientID = @PatientID, " +
               "PatientNameKH = @PatientNameKH, " +        
               "PatientNameEN = @PatientNameEN, " +         
               "DoctorID = @DoctorID, " +                   
               "DoctorName = @DoctorName " +
               "WHERE AppointmentID = @AppointmentID";

            try
            {
                if (Program.Connection.State != ConnectionState.Open)
                    Program.Connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, Program.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AppointmentID", txtAppointmentID.Text);
                    cmd.Parameters.AddWithValue("@AppointmentDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Duration", TimeSpan.Parse(txtDuration.Text));
                    cmd.Parameters.AddWithValue("@AppointmentStatus", txtStatus.Text);
                    cmd.Parameters.AddWithValue("@PatientID", cboPatientID.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtPatientNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtPatientNameEN.Text);
                    cmd.Parameters.AddWithValue("@DoctorID", cboDoctorID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDoctorName.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Appointment updated successfully.");
                    LoadAllAppointments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
            finally
            {
                if (Program.Connection.State == ConnectionState.Open)
                    Program.Connection.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtAppointmentID.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text) ||
                string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            if (!TimeSpan.TryParse(txtDuration.Text, out _))
            {
                MessageBox.Show("Invalid Duration format. Use HH:mm:ss.");
                return false;
            }

            return true;
        }

    }
}
