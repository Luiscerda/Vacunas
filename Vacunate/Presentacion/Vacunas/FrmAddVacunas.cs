using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Cache;
using Domain;
using System.Windows.Forms;

namespace Presentacion.Vacunas
{
    public partial class FrmAddVacunas : Form
    {
        VacunaModel vacunaModel;
        public FrmAddVacunas()
        {
            InitializeComponent();
            vacunaModel = new VacunaModel();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                validacion.SetHighlightColor(txtCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                validacion.SetHighlightColor(txtNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtNombre, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtLaboratorio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLaboratorio.Text))
            {
                validacion.SetHighlightColor(txtLaboratorio, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtLaboratorio, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtDosis_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosis.Text))
            {
                validacion.SetHighlightColor(txtDosis, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtDosis, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtClasificacion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClasificacion.Text))
            {
                validacion.SetHighlightColor(txtClasificacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtClasificacion, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtComposicion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComposicion.Text))
            {
                validacion.SetHighlightColor(txtComposicion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtComposicion, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void txtConservacion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConservacion.Text))
            {
                validacion.SetHighlightColor(txtConservacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(txtConservacion, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private void cmbGrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbGrados.Text))
            {
                validacion.SetHighlightColor(cmbGrados, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(cmbGrados, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
        private bool ValidatedField(Vacuna vacuna)
        {
            if (string.IsNullOrEmpty(vacuna.Codigo))
            {
                validacion.SetHighlightColor(txtCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(vacuna.Nombre))
            {
                validacion.SetHighlightColor(txtNombre, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(vacuna.Laboratorio))
            {
                validacion.SetHighlightColor(txtLaboratorio, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(vacuna.NumeroDosis.ToString()))
            {
                validacion.SetHighlightColor(txtDosis, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(vacuna.Clasificacion))
            {
                validacion.SetHighlightColor(txtClasificacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(vacuna.Composicion))
            {
                validacion.SetHighlightColor(txtComposicion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(vacuna.Conservacion))
            {
                validacion.SetHighlightColor(txtConservacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(cmbGrados.Text))
            {
                validacion.SetHighlightColor(cmbGrados, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (vacuna.NumeroDosis == 0)
            {
                validacion.SetHighlightColor(txtDosis, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            return true;
        }
        private Vacuna MapearVacuna()
        {
            Vacuna vacuna = new Vacuna();
            vacuna.Codigo = txtCodigo.Text;
            vacuna.Nombre = txtNombre.Text;
            vacuna.Laboratorio = txtLaboratorio.Text;
            vacuna.NumeroDosis = string.IsNullOrEmpty(txtDosis.Text) ? (int)0 : Convert.ToInt32(txtDosis.Text);
            vacuna.Clasificacion = txtClasificacion.Text;
            vacuna.Composicion = txtComposicion.Text;
            vacuna.Conservacion = txtConservacion.Text + cmbGrados.Text;
            vacuna.FechaReg = DateTime.Now;
            vacuna.UserReg = UserLoginCache.IdUser;
            vacuna.Stock = vacuna.NumeroDosis;
            return vacuna;
        }
        private void btnSaveVacuna_Click(object sender, EventArgs e)
        {
            Vacuna vacunaMapeada = MapearVacuna();
            bool validacion = ValidatedField(vacunaMapeada);
            if (validacion)
            {
                string mensaje = vacunaModel.SaveVacuna(vacunaMapeada);
                MessageBox.Show(mensaje,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDosis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtConservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
