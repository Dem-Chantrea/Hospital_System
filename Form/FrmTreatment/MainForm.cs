using FormOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FrmTreatment
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginFrm loginForm = new LoginFrm();
            loginForm.Show();

            this.Hide();
        }

        private void btnTreatment_Click(object sender, EventArgs e)
        {
            FrmTreatment treatmentForm = new FrmTreatment();
            treatmentForm.Show();
            this.Hide();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FormImport.FormImport importForm = new FormImport.FormImport();
            importForm.Show();
            this.Hide();
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            FormAppointment.FormAppointment appointmentForm = new FormAppointment.FormAppointment();
            appointmentForm.Show();
            this.Hide();
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            FormPrescription.FormPrescription prescriptionForm = new FormPrescription.FormPrescription();
            prescriptionForm.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e) {}

        private void btnPayment_Click(object sender, EventArgs e)
        {
            FrmPayment.FormPayment paymentForm = new FrmPayment.FormPayment();
            paymentForm.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
           FormOrder.FrmOrder orderForm = new FormOrder.FrmOrder();
            orderForm.Show();
            this.Hide();
        }

        private void btnMedicineStock_Click(object sender, EventArgs e)
        {
            FrmMedicineStock.FrmMedicineStock medicineStockForm = new FrmMedicineStock.FrmMedicineStock();
            medicineStockForm.Show();
            this.Hide();
        }

        private void btnDisease_Click(object sender, EventArgs e)
        {
            FormDisease.FormDisease diseaseForm = new FormDisease.FormDisease();
            diseaseForm.Show();
            this.Hide();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FormSupplier.FormSupplier supplierForm = new FormSupplier.FormSupplier();
            supplierForm.Show();
            this.Hide();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            FormStaff.FormStaff staffForm = new FormStaff.FormStaff();
            staffForm.Show();
            this.Hide();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            FormDoctor.FormDoctor doctorForm = new FormDoctor.FormDoctor();
            doctorForm.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            FormPatient.FormPatient patientForm = new FormPatient.FormPatient();
            patientForm.Show();
            this.Hide();
        }
    }
}
