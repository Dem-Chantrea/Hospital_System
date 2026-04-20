using FrmTreatment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FormStaff
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }
        private DataTable staffTable; 

        private void LoadAllStaffs()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbStaff", Program.Connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    staffTable = new DataTable();
                    adapter.Fill(staffTable);

                    listBox1.DataSource = staffTable;
                    listBox1.DisplayMember = "StaffNameEN";
                    listBox1.ValueMember = "StaffID";
                }
            }

            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;

                DataRowView row = listBox1.SelectedItem as DataRowView;
                if (row != null)
                {
                    FillStaffDetails(row);
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is DataRowView row)
            {
                FillStaffDetails(row);
            }
        }

        private void FillStaffDetails(DataRowView row)
        {
            txtID.Text = row["StaffID"].ToString();
            txtKH.Text = row["StaffNameKH"].ToString();
            txtEN.Text = row["StaffNameEN"].ToString();

            string gender = row["StaffGender"].ToString();
            rdMale.Checked = gender == "Male";
            rdFemale.Checked = gender == "Female";

            dateTimePicker1.Value = Convert.ToDateTime(row["BirthDate"]);
            txtPhone.Text = row["StaffPhone"].ToString();
            txtAddress.Text = row["StaffAddress"].ToString();
            txtPosition.Text = row["StaffPosition"].ToString();
            txtSalary.Text = row["Salary"].ToString();
            dateTimePicker2.Value = Convert.ToDateTime(row["HiredDate"]);
            checkStop.Checked = Convert.ToBoolean(row["IsStopWork"]);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                listBox1.DataSource = null;
                return;
            }

            using (SqlCommand cmd = new SqlCommand("sp_SearchStaffByNameEN", Program.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffNameEN", txtSearch.Text);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    listBox1.DataSource = dt;
                    listBox1.DisplayMember = "StaffNameEN";
                    listBox1.ValueMember = "StaffID";


                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();

            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtSearch.Clear();
            txtEN.Clear();
            txtKH.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtPosition.Clear();
            txtSalary.Clear();
            rdMale.Checked= false;
            rdFemale.Checked = false;   
            dateTimePicker1.Value = DateTime.Now;
            checkStop.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateStaff", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StaffID", txtID.Text);
                    cmd.Parameters.AddWithValue("@StaffNameKH", txtKH.Text);
                    cmd.Parameters.AddWithValue("@StaffNameEN", txtEN.Text);
                    string gender = rdMale.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@StaffGender", gender);

                    cmd.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StaffPhone ", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@StaffAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@StaffPosition", txtPosition.Text);
                    cmd.Parameters.AddWithValue("@Salary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@HiredDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@IsStopWork", checkStop.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff updated successfully.");
                    LoadAllStaffs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertStaff", Program.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StaffID", txtID.Text);
                    cmd.Parameters.AddWithValue("@StaffNameKH", txtKH.Text);
                    cmd.Parameters.AddWithValue("@StaffNameEN", txtEN.Text);
                    string gender = rdMale.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@StaffGender", gender);

                    cmd.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@StaffPhone ", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@StaffAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@StaffPosition", txtPosition.Text);
                    cmd.Parameters.AddWithValue("@Salary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@HiredDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@IsStopWork", checkStop.Checked);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff inserted successfully!!");
                    LoadAllStaffs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            LoadAllStaffs();
        }
    }
}
