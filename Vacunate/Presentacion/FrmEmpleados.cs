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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridEmpleados.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridEmpleados.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridEmpleados.CurrentRow.Cells[0].Value;
                //var patient = patientsModel.GetPatient(id.ToString());
                //FrmDetallesPaciente frmDetalles = new FrmDetallesPaciente(patient);
                //frmDetalles.ShowDialog();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridEmpleados.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridEmpleados.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridEmpleados.CurrentRow.Cells[0].Value;
                //var patient = patientsModel.GetPatient(id.ToString());
                //FrmModificarPaciente frmModificar = new FrmModificarPaciente(patient);
                //frmModificar.ShowDialog();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridEmpleados.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridEmpleados.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridEmpleados.CurrentRow.Cells[0].Value;
                //var patient = patientsModel.GetPatient(id.ToString());
                //FrmEliminarPaciente frmEliminar = new FrmEliminarPaciente(patient);
                //frmEliminar.ShowDialog();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
