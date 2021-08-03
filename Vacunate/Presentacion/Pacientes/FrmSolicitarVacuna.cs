using Presentacion.Pacientes.Solicitud;
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
using Domain;
using Common;

namespace Presentacion.Pacientes
{
    public partial class FrmSolicitarVacuna : Form
    {
        SolicitudModel solicitudModel;
        PatientsModel patientsModel;
        VacunaModel vacunaModel;
        public FrmSolicitarVacuna()
        {
            InitializeComponent();
            solicitudModel = new SolicitudModel();
            patientsModel = new PatientsModel();
            vacunaModel = new VacunaModel();
            LoadSolicitudes();
        }

        private void btnCloset_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmNuevaSolicitud frmNueva = new FrmNuevaSolicitud();
            frmNueva.ShowDialog();
        }
        public DataTable PintarSolicitudes(IList<Common.Solicitud> solicituds)
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
            List<Common.Solicitud> solicituds = solicitudModel.GetSolicitudes(UserLoginCache.Identificacion);
            Patient patients = patientsModel.GetPatient(UserLoginCache.Identificacion);
           
            foreach (var item in solicituds)
            {
                item.Patologia = patients.Patologia;
                item.EdadPaciente = patients.Age;
                item.NombrePaciente = patients.FirstName + " " + patients.LastName;
                Vacuna vacuna = vacunaModel.GetVacunaByCodigo2(item.CodigoVacuna);
                item.NombreVacuna = vacuna.Nombre;
            }
            GridSolicitudes.DataSource = PintarSolicitudes(solicituds);
        }
    }
}
