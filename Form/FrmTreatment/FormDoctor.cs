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

namespace FormDoctor
{
    public partial class FormDoctor : Form
    {
        public FormDoctor()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private DataTable doctorTable;
        private void LoadAllDoctors()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbDoctor", Program.Connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    doctorTable = new DataTable();
                    adapter.Fill(doctorTable);

                    listBox1.DataSource = doctorTable;
                    listBox1.DisplayMember = "DoctorName";
                    listBox1.ValueMember = "DoctorID";
                }
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;

                DataRowView row = listBox1.SelectedItem as DataRowView;
                if (row != null)
                {
                    FillDoctorDetails(row);
                }
            }

        }

        private void FillDoctorDetails(DataRowView row)
        {
            txtID.Text = row["DoctorID"].ToString();
            txtName.Text = row["DoctorName"].ToString();

            string gender = row["DoctorGender"].ToString();
            rdMale.Checked = gender == "Male";
            rdFemale.Checked = gender == "Female";

            dateTimePicker1.Value = Convert.ToDateTime(row["DoctorBirthDate"]);
            txtPhone.Text = row["DoctorPhone"].ToString();
            txtAddress.Text = row["DoctorAddress"].ToString();
            txtSalary.Text = row["DoctorSalary"].ToString();
            dateTimePicker2.Value = Convert.ToDateTime(row["DoctorHiredDate"]);
            checkStop.Checked = Convert.ToBoolean(row["StoppedWork"]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is DataRowView row)
            {
                FillDoctorDetails(row);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                listBox1.DataSource = null;
                return;
            }

            using (SqlCommand cmd = new SqlCommand("SearchDoctorByName", Program.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchName", txtSearch.Text);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listBox1.DataSource = dt;
                    listBox1.DisplayMember = "DoctorName";
                    listBox1.ValueMember = "DoctorID";


                }
            }
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
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
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            dateTimePicker1.Value = DateTime.Now;
            checkStop.Checked = false;
            rdFemale.Checked = false;
            rdMale.Checked = false;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDoctor", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoctorID", txtID.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", txtName.Text);
                    string gender = rdMale.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@DoctorGender", gender);

                    cmd.Parameters.AddWithValue("@DoctorBirthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@DoctorPhone ", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@DoctorAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DoctorSalary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@DoctorHiredDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StoppedWork", checkStop.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor updated successfully.");
                    LoadAllDoctors();
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

                using (SqlCommand cmd = new SqlCommand("InsertDoctor", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DoctorID", txtID.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", txtName.Text);
                    string gender = rdMale.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@DoctorGender", gender);

                    cmd.Parameters.AddWithValue("@DoctorBirthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@DoctorPhone ", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@DoctorAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DoctorSalary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@DoctorHiredDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StoppedWork", checkStop.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor inserted successfully.");
                    LoadAllDoctors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
        }

        private void FormDoctor_Load(object sender, EventArgs e)
        {
            LoadAllDoctors();
        }
    }
}
