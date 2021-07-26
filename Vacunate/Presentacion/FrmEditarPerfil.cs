using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentacion
{
    public partial class FrmEditarPerfil : Form
    {
        public FrmEditarPerfil()
        {
            InitializeComponent();
            LoadProile();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProile()
        {
            labelNombre.Text = UserLoginCache.FirstName + ", " + UserLoginCache.LastName;
            labelRol.Text = UserLoginCache.Rol;
            labelMail.Text = UserLoginCache.Email;
            labelFirstName.Text = UserLoginCache.FirstName;
            labelLastName.Text = UserLoginCache.LastName;
            labelUserName.Text = UserLoginCache.UserName;
        }
    }
}
