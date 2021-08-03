using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Common;
using System.Windows.Forms;

namespace Presentacion.Pacientes
{
    public partial class FrmEliminarPaciente : Form
    {
        string identificacionEliminar = "";
        PatientsModel patientsModel;
        public FrmEliminarPaciente(Patient patient)
        {
            InitializeComponent();
            LoadPatient(patient);
            patientsModel = new PatientsModel();
            identificacionEliminar = patient.Identification.Trim();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadPatient(Patient patient)
        {
            txtEdad.Text = patient.Age.ToString();
            txtEmail.Text = patient.Mail;
            txtFirstName.Text = patient.FirstName;
            txtLastName.Text = patient.LastName;
            txtIdentificacion.Text = patient.Identification;
            txtTelephone.Text = patient.Telephone;
            cmbTiposDoc.Text = patient.TipoDoc;
            dateTimeFecha.Text = patient.DateOfBirth.ToString();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mensaje = patientsModel.DeletePatient(identificacionEliminar);
            MessageBox.Show(mensaje,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
