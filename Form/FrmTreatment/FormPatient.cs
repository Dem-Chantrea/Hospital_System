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

namespace FormPatient
{
    public partial class FormPatient : Form
    {
        private DataTable patientTable;

        public FormPatient()
        {
            InitializeComponent();

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void LoadAllPatients()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbPatient", Program.Connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    patientTable = new DataTable();
                    adapter.Fill(patientTable);

                    listBox1.DataSource = patientTable;
                    listBox1.DisplayMember = "PatientNameEN";
                    listBox1.ValueMember = "PatientID";
                }
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;

                DataRowView row = listBox1.SelectedItem as DataRowView;
                if (row != null)
                {
                    FillPatientDetails(row);
                }
            }

        }

        private void FillPatientDetails(DataRowView row)
        {
            txtID.Text = row["PatientID"].ToString();
            txtNameKH.Text = row["PatientNameKH"].ToString();
            txtNameEN.Text = row["PatientNameEN"].ToString();

            string gender = row["PatientGender"].ToString();
            rdMale.Checked = gender == "Male";
            rdFemale.Checked = gender == "Female";

            dateTimePicker1.Value = Convert.ToDateTime(row["PatientBirthDate"]);
            txtPhone.Text = row["PatientPhone"].ToString();
            txtAddress.Text = row["PatientAddress"].ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is DataRowView row)
            {
                FillPatientDetails(row);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                listBox1.DataSource = null;
                return;
            }

            using (SqlCommand cmd = new SqlCommand("SearchPatientByNameEN", Program.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientNameEN", txtSearch.Text);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listBox1.DataSource = dt;
                    listBox1.DisplayMember = "PatientNameEN";
                    listBox1.ValueMember = "PatientID";
                }
            }
        }

        private void btnLogOut_Click_2(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();

            this.Hide();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtID.Clear();
            txtSearch.Clear();
            txtNameKH.Clear();
            txtNameEN.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            rdFemale.Checked = false;
            rdMale.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePatient", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientID", txtID.Text);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtNameEN.Text);
                    string gender = rdMale.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@PatientGender", gender);

                    cmd.Parameters.AddWithValue("@PatientBirthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@PatientPhone ", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@PatientAddress", txtAddress.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient updated successfully.");
                    LoadAllPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("InsertPatient", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientID", txtID.Text);
                    cmd.Parameters.AddWithValue("@PatientNameKH", txtNameKH.Text);
                    cmd.Parameters.AddWithValue("@PatientNameEN", txtNameEN.Text);
                    string gender = rdMale.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@PatientGender", gender);

                    cmd.Parameters.AddWithValue("@PatientBirthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@PatientPhone ", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@PatientAddress", txtAddress.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient inserted successfully.");
                    LoadAllPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
        }

        private void FormPatient_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
        }
    }
}
