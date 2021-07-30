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
using Domain;

namespace Presentacion.Usuario
{
    public partial class FrmModificarUsuario : Form
    {
        User _user = new User();
        UserModel userModel;
        public FrmModificarUsuario(User user)
        {
            InitializeComponent();
            LoadUser(user);
            userModel = new UserModel();
            _user = user;
        }

        private void LoadUser(User user)
        {
            txtLastName.Text = user.LastName.Trim();
            txtEmail.Text = user.Mail;
            txtFirstName.Text = user.Name;
            txtUserName.Text = user.UserName;
            txtIdentificacion.Text = user.Identification;
            txtPassword.Text = user.Password;
            txtConfirmContra.Text = user.Password;
            cmbRoles.Text = user.Rol;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _user.Name = txtFirstName.Text;
            _user.LastName = txtLastName.Text;
            _user.Mail = txtEmail.Text;
            _user.Password = txtPassword.Text;
            bool validar = ValidatedFielsUpdate(_user, txtConfirmContra.Text);
            if (validar)
            {
                string mensaje = userModel.UpdateUser(_user);
                MessageBox.Show(mensaje, "Mensaje");
                this.Close();
            }
        }

        private bool ValidatedFielsUpdate(User user, string text)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(user.Mail))
            {
                validacion.SetHighlightColor(txtEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (string.IsNullOrEmpty(txtConfirmContra.Text))
            {
                validacion.SetHighlightColor(txtConfirmContra, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            if (user.Password.Length < 6)
            {
                validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                labelConfirmPass.Visible = true;
                labelConfirmPass.Text = "Contraseña debe tener 6 o mas caracteres";
                return false;
            }
            if (user.Password != txtConfirmContra.Text)
            {
                labelConfirmPass.Visible = true;
                labelConfirmPass.Text = "Contraseñas no coinciden";
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                if (txtPassword.Text.Length < 6)
                {
                    validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = true;
                    labelConfirmPass.Text = "Contraseña debe tener 6 o mas caracteres";
                }
                else
                {
                    labelConfirmPass.Visible = false;
                    validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                }
                
            }
        }

        private void txtConfirmContra_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtConfirmContra.Text))
            {
                validacion.SetHighlightColor(txtConfirmContra, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                if (txtConfirmContra.Text != txtPassword.Text)
                {
                    validacion.SetHighlightColor(txtConfirmContra, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = true;
                    labelConfirmPass.Text = "Contraseñas no coinciden";
                }
                else
                {
                    labelConfirmPass.Visible = false;
                    validacion.SetHighlightColor(txtConfirmContra, DevComponents.DotNetBar.Validator.eHighlightColor.None);
                }
                
            }
        }

    }
}
