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

namespace Presentacion.Usuario
{
    public partial class FrmViewDetails : Form
    {
        User _user = new User();
        public FrmViewDetails(User user)
        {
            InitializeComponent();
            _user = user;
            LoadDetails();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDetails()
        {
            txtLastName.Text = _user.LastName.Trim();
            txtEmail.Text = _user.Mail;
            txtFirstName.Text = _user.Name;
            txtUserName.Text = _user.UserName;
            txtIdentificacion.Text = _user.Identification;
            txtPassword.Text = _user.Password;
            cmbRoles.Text = _user.Rol;
        }
    }
}
