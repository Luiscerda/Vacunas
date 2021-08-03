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
    public partial class FrmEliminarUsuario : Form
    {
        int id = 0;
        UserModel userModel;
        public FrmEliminarUsuario(User user)
        {
            InitializeComponent();
            userModel = new UserModel();
            LoadUser(user);
            id = user.Id;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadUser(User user)
        {
            txtLastName.Text = user.LastName.Trim();
            txtEmail.Text = user.Mail;
            txtFirstName.Text = user.Name;
            txtUserName.Text = user.UserName;
            txtIdentificacion.Text = user.Identification;
            txtPassword.Text = user.Password;
            cmbRoles.Text = user.Rol;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mensaje = userModel.DeleteUser(id);
            MessageBox.Show(mensaje,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
