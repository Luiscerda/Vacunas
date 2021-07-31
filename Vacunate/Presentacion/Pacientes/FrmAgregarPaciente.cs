using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Cache;
using Domain;

namespace Presentacion.Pacientes
{
    public partial class FrmAgregarPaciente : Form
    {
        PatientsModel patientsModel;
        public FrmAgregarPaciente()
        {
            InitializeComponent();
            patientsModel = new PatientsModel();
            LoadDoc();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Identification = txtIdentificacion.Text;
            patient.FirstName = txtFirstName.Text;
            patient.LastName = txtLastName.Text;
            patient.Mail = txtEmail.Text;
            patient.Age = string.IsNullOrEmpty(txtEdad.Text) ? (int)0 : Convert.ToInt32(txtEdad.Text);
            patient.Telephone = txtTelephone.Text;
            patient.DateOfBirth = Convert.ToDateTime(string.IsNullOrEmpty(dateTimeFecha.Text) ? (DateTime?)null : DateTime.Parse(dateTimeFecha.Text));
            patient.TipoDoc = cmbTiposDoc.Text;
            patient.Password = patient.Identification + patient.LastName;
            patient.UserReg = UserLoginCache.IdUser;
            patient.FechaReg = DateTime.Now;
            bool validated = ValidatedField(patient);
            if (validated)
            {
                string mensaje = patientsModel.SavePatient(patient);
                MessageBox.Show(mensaje, "Mensaje");
                this.Close();
            }
        }

        private bool ValidatedField(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.TipoDoc))
            {
                validacion.SetHighlightColor(cmbTiposDoc, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(patient.Identification))
            {
                validacion.SetHighlightColor(txtIdentificacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(patient.FirstName))
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(patient.LastName))
            {
                validacion.SetHighlightColor(txtLastName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
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
            if (patient.Age == 0)
            {
                validacion.SetHighlightColor(txtEdad, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }                      
            return true;
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                validacion.SetHighlightColor(txtIdentificacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtIdentificacion, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
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

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                validacion.SetHighlightColor(txtEdad, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtEdad, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void LoadDoc()
        {
            cmbTiposDoc.Items.Add("Registro Civil");
            cmbTiposDoc.Items.Add("Tarjeta Identidad");
            cmbTiposDoc.Items.Add("Cedula Ciudadania");
            cmbTiposDoc.Items.Add("Cedula Extranjera");
        }

        private void cmbTiposDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTiposDoc.Text))
            {
                validacion.SetHighlightColor(cmbTiposDoc, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(cmbTiposDoc, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
    }
}
