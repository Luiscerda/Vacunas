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

namespace Presentacion.Pacientes
{
    public partial class FrmSolicitarVacuna : Form
    {
        SolicitudModel solicitudModel;
        public FrmSolicitarVacuna()
        {
            InitializeComponent();
            solicitudModel = new SolicitudModel();
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
            //tabla.Columns.Add("Nombre completo");
            //tabla.Columns.Add("Correo");
            //tabla.Columns.Add("Telefono");
            //tabla.Columns.Add("Edad");
            //tabla.Columns.Add("Fecha Nacimiento");

            foreach (var item in solicituds)
            {
                DataRow fila = tabla.NewRow();
                fila["Codigo"] = item.Codigo;
                //fila["Nombre completo"] = item.FirstName + " " + item.LastName;
                //fila["Correo"] = item.Mail;
                //fila["Telefono"] = item.Telephone;
                //fila["Edad"] = item.Age;
                //fila["Fecha Nacimiento"] = item.DateOfBirth;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }
        private void LoadSolicitudes()
        {
            List<Common.Solicitud> solicituds = solicitudModel.GetSolicitudes(UserLoginCache.Identificacion);
            GridSolicitudes.DataSource = PintarSolicitudes(solicituds);
        }
    }
}
