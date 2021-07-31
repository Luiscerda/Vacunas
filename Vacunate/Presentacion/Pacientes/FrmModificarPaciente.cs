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
using Common.Cache;

namespace Presentacion.Pacientes
{
    public partial class FrmModificarPaciente : Form
    {
        PatientsModel patientsModel;
        Patient _patient;
        public FrmModificarPaciente(Patient patient)
        {
            InitializeComponent();
            LoadPatient(patient);
            _patient = patient;
            patientsModel = new PatientsModel();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _patient.FirstName = txtFirstName.Text;
            _patient.LastName = txtLastName.Text;
            _patient.Mail = txtEmail.Text;
            _patient.Telephone = txtTelephone.Text;
            _patient.TipoDoc = cmbTiposDoc.Text;
            _patient.FechaMod = DateTime.Now;
            _patient.UserMod = UserLoginCache.IdUser;
            bool validar = ValidatedFielsUpdate(_patient);
            if (validar)
            {
                string mensaje = patientsModel.UpdatePatient(_patient);
                MessageBox.Show(mensaje, "Mensaje");
                this.Close();
            }
        }

        private bool ValidatedFielsUpdate(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.FirstName))
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(patient.LastName))
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(patient.Mail))
            {
                validacion.SetHighlightColor(txtEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(patient.Telephone))
            {
                validacion.SetHighlightColor(txtTelephone, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            return true; 
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                validacion.SetHighlightColor(txtLastName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtLastName, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                validacion.SetHighlightColor(txtEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtEmail, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTelephone.Text))
            {
                validacion.SetHighlightColor(txtTelephone, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtTelephone, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
    }
}
