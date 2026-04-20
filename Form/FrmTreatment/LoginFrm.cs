using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmTreatment
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim().ToLower();
            string password = txtPwd.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Focus();
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPwd.Focus();
            }
            else
            {      
                if (username == "HPMS".ToLower() && password == "111")
                {
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Focus();
                }
            }
        }
    }
}
