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
using Presentacion.Usuario;

namespace Presentacion
{
    public partial class FrmUsuarios : Form
    {
        UserModel UserModel = new UserModel();
        public FrmUsuarios()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            List<User> users = UserModel.GetUsers();
            if (users.Count() > 0)
            {
                GridUsers.DataSource = PintarUsers(users);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable PintarUsers(IList<User> users)
        {
            DataTable tabla = new DataTable();
            int cont = 0;
            tabla.Columns.Add("Num");
            tabla.Columns.Add("Usuario");
            tabla.Columns.Add("Nombre completo");
            tabla.Columns.Add("Rol");
            tabla.Columns.Add("Correo");

            foreach (var item in users)
            {
                DataRow fila = tabla.NewRow();
                cont += 1;
                fila["Num"] = cont;
                fila["Usuario"] = item.UserName;
                fila["Nombre completo"] = item.Name + " " + item.LastName;
                fila["Rol"] = item.Rol;
                fila["Correo"] = item.Mail;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAgregarUsuario frmAgregar = new FrmAgregarUsuario();
            frmAgregar.ShowDialog();
        }
    }
}
