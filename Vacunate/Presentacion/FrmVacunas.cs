using Presentacion.Vacunas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Common;
using Domain;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmVacunas : Form
    {
        VacunaModel vacunaModel;
        List<Vacuna> listVacunas;
        public FrmVacunas()
        {
            InitializeComponent();
            vacunaModel = new VacunaModel();
            LoadVacunas();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadVacunas();
            }
            else
            {
                LoadSearch(txtSearch.Text);
            }
        }
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridVacunas.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridVacunas.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridVacunas.CurrentRow.Cells[0].Value;
                var vacuna = vacunaModel.GetVacunaByCodigo2(id.ToString());
                FrmViewDetailsVacuna detailsVacuna = new FrmViewDetailsVacuna(vacuna);
                detailsVacuna.ShowDialog();
            }
        }
        private void btnAddVacunas_Click(object sender, EventArgs e)
        {
            FrmAddVacunas frmAgregar = new FrmAddVacunas();
            frmAgregar.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridVacunas.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridVacunas.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridVacunas.CurrentRow.Cells[0].Value;
                //var patient = patientsModel.GetPatient(id.ToString());
                //FrmModificarPaciente frmModificar = new FrmModificarPaciente(patient);
                //frmModificar.ShowDialog();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridVacunas.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridVacunas.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridVacunas.CurrentRow.Cells[0].Value;
                //var patient = patientsModel.GetPatient(id.ToString());
                //FrmEliminarPaciente frmEliminar = new FrmEliminarPaciente(patient);
                //frmEliminar.ShowDialog();
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DataTable PintarVacunas(IList<Vacuna> vacunas)
        {
            DataTable tabla = new DataTable();
            
            tabla.Columns.Add("Codigo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Stock");
            tabla.Columns.Add("Laboratorio");
            tabla.Columns.Add("Activa");
                     
            foreach (var item in vacunas)
            {
                DataRow fila = tabla.NewRow();
                fila["Codigo"] = item.Codigo;
                fila["Nombre"] = item.Nombre;
                fila["Stock"] = item.Stock.ToString();
                fila["Laboratorio"] = item.Laboratorio;
                fila["Activa"] = item.Activa == true ? "Si" : "No";
                
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        private void LoadVacunas()
        {
            List<Vacuna> vacunas = vacunaModel.GetVacunas();
            if (vacunas.Count() != 0)
            {
                GridVacunas.DataSource = PintarVacunas(vacunas);
                listVacunas = vacunas;
            }
        }
        private void LoadSearch(string parametro)
        {
            List<Vacuna> filter = listVacunas.Where(c => c.Codigo.ToUpper().Contains(parametro.ToUpper()) || c.Nombre.ToUpper().Contains(parametro.ToUpper())).ToList();
            GridVacunas.DataSource = PintarVacunas(filter);
        }
    }
}
