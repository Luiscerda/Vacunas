using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmRecuperarContraseña : Form
    {
        public FrmRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "Usuario o Correo";
                txtUserName.ForeColor = Color.Black;
            }
        }
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Usuario o Correo")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.RoyalBlue;
            }
        }
        private void MsgResultado(string mensaje)
        {
            labelResultado.Text = mensaje;
            labelResultado.Visible = true;
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() != "Usuario o Correo")
            {
                var userModel = new UserModel();
                var resultado = userModel.RecoveryPassword(txtUserName.Text.Trim());
                MsgResultado(resultado);
            }
            else
            {
                MsgResultado("Debe ingresar un nombre de usuario o un correo electronico");
            }
        }
    }
}
