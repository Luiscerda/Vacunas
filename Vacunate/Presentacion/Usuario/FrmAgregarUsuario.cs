using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using Common;
using Domain;

namespace Presentacion.Usuario
{
    public partial class FrmAgregarUsuario : Form
    {
        UserModel userModel;
        public FrmAgregarUsuario()
        {
            InitializeComponent();
            userModel = new UserModel();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Mail = txtEmail.Text;
            user.Password = txtPassword.Text;
            user.Rol = "Administrator";
            user.UserName = txtUserName.Text;
            user.Identification = txtIdentificacion.Text;
            string validar = ValidatedFields(user,txtConfirmPassword.Text);
            if (validar == "Prosiga")
            {
                string mensaje = userModel.SaveUser(user);
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearField();
            }
            else
            {
                ValidatedFielBorder(validar);
            }
           
            
           
        }
        public string ValidatedFields(User user,string confirmPassword)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                return "Campo primer nombre obligatorio";
            }
            else
            {
                if (string.IsNullOrEmpty(user.LastName))
                {
                    return "Campo Apellido obligatorio";
                }
                else
                {
                    if (string.IsNullOrEmpty(user.Mail))
                    {
                        return "Campo Correo obligatorio";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(user.UserName))
                        {
                            return "Campo nombre usuario obligatorio";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(user.Password))
                            {
                                return "Campo contraseña obligatorio";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(confirmPassword))
                                {
                                    return "Campo confirmacion de contraseña obligatorio";
                                }
                                else
                                {
                                    if (user.Password.Trim() != confirmPassword.Trim())
                                    {
                                        return "Las contraseñas no coinciden";
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(user.Identification))
                                        {
                                            return "Campo Identificacion obligatorio";
                                        }
                                        else
                                        {
                                            return "Prosiga";
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtEmail, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtLastName, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtUserName, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtConfirmPassword, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void ValidatedFielBorder(string validar)
        {
            switch (validar)
            {
                case "Campo Identificacion obligatorio":
                    txtIdentificacion.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtIdentificacion, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Campo primer nombre obligatorio":
                    txtFirstName.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtFirstName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Campo Apellido obligatorio":
                    txtLastName.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtLastName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Campo Correo obligatorio":
                    txtEmail.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtEmail, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Campo nombre usuario obligatorio":
                    txtUserName.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtUserName, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Campo contraseña obligatorio":
                    txtPassword.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Campo confirmacion de contraseña obligatorio":
                    txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
                    validacion.SetHighlightColor(txtConfirmPassword, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                    labelConfirmPass.Visible = false;
                    break;
                case "Las contraseñas no coinciden":
                    labelConfirmPass.Visible = true;
                    labelConfirmPass.Text = validar;
                    break;
                default:
                    labelConfirmPass.Visible = false;
                    break;
            }
        }
        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            validacion.SetHighlightColor(txtIdentificacion, DevComponents.DotNetBar.Validator.eHighlightColor.None);
        }
        private void ClearField()
        {
            txtIdentificacion.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
