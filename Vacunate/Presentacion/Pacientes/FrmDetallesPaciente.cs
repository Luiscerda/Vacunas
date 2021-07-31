using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;
using System.Windows.Forms;

namespace Presentacion.Pacientes
{
    public partial class FrmDetallesPaciente : Form
    {
        PatientsModel patientsModel;
        public FrmDetallesPaciente(Patient patient)
        {
            InitializeComponent();
            patientsModel = new PatientsModel();
            LoadDetails(patient);
        }

        private void LoadDetails(Patient patient)
        {
            txtIdentificacion.Text = patient.Identification;
            txtEdad.Text = patient.Age.ToString();
            txtEmail.Text = patient.Mail;
            txtFirstName.Text = patient.FirstName;
            txtLastName.Text = patient.LastName;
            cmbTiposDoc.Text = patient.TipoDoc;
            dateTimeFecha.Text = patient.DateOfBirth.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
