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
using Presentacion.Pacientes;

namespace Presentacion
{
    public partial class FrmPacientes : Form
    {
        PatientsModel patientsModel;
        List<Patient> listPatients = new List<Patient>();
        public FrmPacientes()
        {
            InitializeComponent();
            patientsModel = new PatientsModel();
            LoadPatients();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadPatients()
        {
            List<Patient> patients = patientsModel.GetPatients();
            if (patients.Count() > 0)
           {
                GridPacientes.DataSource = PintarPatients(patients);
                listPatients = patients;
            }
        }
        public DataTable PintarPatients(IList<Patient> patients)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Identificacion");
            tabla.Columns.Add("Nombre completo");
            tabla.Columns.Add("Correo");
            tabla.Columns.Add("Telefono");
            tabla.Columns.Add("Edad");
            tabla.Columns.Add("Fecha Nacimiento");

            foreach (var item in patients)
            {
                DataRow fila = tabla.NewRow();
                fila["Identificacion"] = item.Identification;
                fila["Nombre completo"] = item.FirstName + " " + item.LastName;
                fila["Correo"] = item.Mail;
                fila["Telefono"] = item.Telephone;
                fila["Edad"] = item.Age;
                fila["Fecha Nacimiento"] = item.DateOfBirth;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridPacientes.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridPacientes.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridPacientes.CurrentRow.Cells[0].Value;
                var patient = patientsModel.GetPatient(id.ToString());
                FrmDetallesPaciente frmDetalles = new FrmDetallesPaciente(patient);
                frmDetalles.ShowDialog();
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmAgregarPaciente frmAgregar = new FrmAgregarPaciente();
            frmAgregar.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridPacientes.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridPacientes.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridPacientes.CurrentRow.Cells[0].Value;
                var patient = patientsModel.GetPatient(id.ToString());
                FrmModificarPaciente frmModificar = new FrmModificarPaciente(patient);
                frmModificar.ShowDialog();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridPacientes.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridPacientes.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridPacientes.CurrentRow.Cells[0].Value;
                var patient = patientsModel.GetPatient(id.ToString());
                FrmEliminarPaciente frmEliminar = new FrmEliminarPaciente(patient);
                frmEliminar.ShowDialog();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadPatients();
            }
            else
            {
                LoadSearch(txtSearch.Text);
            }
        }
        private void LoadSearch(string parametro)
        {
            List<Patient> filter = listPatients.Where(c => c.Identification.ToUpper().Contains(parametro.ToUpper()) || c.FirstName.ToUpper().Contains(parametro.ToUpper()) || c.LastName.ToUpper().Contains(parametro.ToUpper())).ToList();
            GridPacientes.DataSource = PintarPatients(filter);
        }
    }
}
