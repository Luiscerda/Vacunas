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
        List<User> listUser = new List<User>();
        public FrmUsuarios()
        {
            InitializeComponent();
            GridUsers.ClearSelection();
            LoadUsers();
        }
        public void LoadUsers()
        {
            List<User> users = UserModel.GetUsers();
            if (users.Count() > 0)
            {
                GridUsers.DataSource = PintarUsers(users);
                listUser = users;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable PintarUsers(IList<User> users)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Num");
            tabla.Columns.Add("Usuario");
            tabla.Columns.Add("Identificacion");
            tabla.Columns.Add("Nombre completo");
            tabla.Columns.Add("Correo");

            foreach (var item in users)
            {
                DataRow fila = tabla.NewRow();
                fila["Num"] = item.Id;
                fila["Usuario"] = item.UserName;
                fila["Identificacion"] = item.Identification;
                fila["Nombre completo"] = item.Name + " " + item.LastName;
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
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridUsers.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridUsers.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridUsers.CurrentRow.Cells[0].Value;
                var User = UserModel.GetUserById(Convert.ToInt32(id));
                FrmViewDetails viewDetails = new FrmViewDetails(User);
                viewDetails.ShowDialog();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridUsers.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridUsers.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridUsers.CurrentRow.Cells[0].Value;
                var User = UserModel.GetUserById(Convert.ToInt32(id));
                FrmModificarUsuario modificarUsuario = new FrmModificarUsuario(User);
                modificarUsuario.ShowDialog();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridUsers.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridUsers.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridUsers.CurrentRow.Cells[0].Value;
                var User = UserModel.GetUserById(Convert.ToInt32(id));
                FrmEliminarUsuario eliminarUsuario = new FrmEliminarUsuario(User);
                eliminarUsuario.ShowDialog();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadUsers();
            }
            else
            {
                LoadSearch(txtSearch.Text);
            }
        }
        private void LoadSearch(string parametro)
        {
            List<User> filter = listUser.Where(c => c.Mail.ToUpper().Contains(parametro.ToUpper()) || c.UserName.ToUpper().Contains(parametro.ToUpper()) || c.Name.ToUpper().Contains(parametro.ToUpper())).ToList();
            GridUsers.DataSource = PintarUsers(filter);
        }
    }
}
