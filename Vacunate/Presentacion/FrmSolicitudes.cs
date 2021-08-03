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
using Common.Cache;
using Domain;

namespace Presentacion
{
    public partial class FrmSolicitudes : Form
    {
        SolicitudModel solicitudModel;
        PatientsModel patientsModel;
        VacunaModel vacunaModel;
        public FrmSolicitudes()
        {
            InitializeComponent();
            solicitudModel = new SolicitudModel();
            patientsModel = new PatientsModel();
            vacunaModel = new VacunaModel();
            LoadSolicitudes();
        }
        public DataTable PintarSolicitudes(IList<Solicitud> solicituds)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Codigo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Edad");
            tabla.Columns.Add("Vacuna");
            tabla.Columns.Add("Estado");
            tabla.Columns.Add("Fecha Solicitud");

            foreach (var item in solicituds)
            {
                DataRow fila = tabla.NewRow();
                fila["Codigo"] = item.Codigo;
                fila["Nombre"] = item.NombrePaciente;
                fila["Edad"] = item.EdadPaciente;
                fila["Vacuna"] = item.NombreVacuna;
                fila["Estado"] = item.Estado;
                fila["Fecha Solicitud"] = item.FechaSolicitud.ToShortDateString();

                tabla.Rows.Add(fila);
            }

            return tabla;
        }

        private void LoadSolicitudes()
        {
            List<Solicitud> solicituds = solicitudModel.GetSolicitudes();
            if (solicituds.Count() > 0)
            {
                foreach (var item in solicituds)
                {
                    Patient patients = patientsModel.GetPatient(item.IdentificacionPaciente);
                    item.Patologia = patients.Patologia;
                    item.EdadPaciente = patients.Age;
                    item.NombrePaciente = patients.FirstName + " " + patients.LastName;
                    Vacuna vacuna = vacunaModel.GetVacunaByCodigo2(item.CodigoVacuna);
                    item.NombreVacuna = vacuna.Nombre;
                }
                GridSolicitudes.DataSource = PintarSolicitudes(solicituds);
            }

            
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            Int32 selectedColumnCount = GridSolicitudes.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedColumnCount != GridSolicitudes.Columns.Count)
            {
                MessageBox.Show("Seleccione una fila", "Error");
            }
            else
            {
                var id = GridSolicitudes.CurrentRow.Cells[0].Value;
                var solicitud = solicitudModel.GetSolicitudByCodigo(id.ToString());
                FrmRecibirSolicitud frmRecibir = new FrmRecibirSolicitud(solicitud);
                frmRecibir.ShowDialog();
            }
        }
    }
}
