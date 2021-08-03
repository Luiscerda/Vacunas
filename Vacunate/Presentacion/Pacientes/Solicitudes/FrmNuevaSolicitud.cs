using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Common;
using Common.Cache;

namespace Presentacion.Pacientes.Solicitud
{
    public partial class FrmNuevaSolicitud : Form
    {
        VacunaModel vacunaModel;
        PatientsModel patientsModel;
        SolicitudModel solicitudModel;
        public FrmNuevaSolicitud()
        {
            InitializeComponent();
            vacunaModel = new VacunaModel();
            patientsModel = new PatientsModel();
            solicitudModel = new SolicitudModel();
            LoadVacunas();
            LoadPaciente();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadVacunas()
        {
            List<Vacuna> vacunas = vacunaModel.GetVacunas().Where(c => c.Activa == true && c.Stock > 0).ToList();
            foreach (var item in vacunas)
            {
                cmbVacuna.Items.Add(item.Codigo + "-" + item.Nombre);
            }
        }
        private void LoadPaciente()
        {
            Patient patient = patientsModel.GetPatient(UserLoginCache.Identificacion.Trim());
            txtIdentificacion.Text = patient.Identification;
            txtNombre.Text = patient.FirstName + " " + patient.LastName;
            txtPatologia.Text = patient.Patologia;
            txtEdad.Text = patient.Age.ToString();
        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            Common.Solicitud solicitud = MapearSolicitud();
            bool validated = ValidatedFields(solicitud);
            if (validated)
            {
                string mensaje = solicitudModel.SaveSolicitud(solicitud);
                MessageBox.Show(mensaje,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ValidatedFields(Common.Solicitud solicitud)
        {
            if (string.IsNullOrEmpty(solicitud.CodigoVacuna))
            {
                validacion.SetHighlightColor(cmbVacuna, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
                return false;
            }
            return true;
        }
        private Common.Solicitud MapearSolicitud()
        {
            Common.Solicitud solicitud = new Common.Solicitud();
            int startIndex = cmbVacuna.Text.IndexOf('-');
            int c = cmbVacuna.Text.Length;
            int length = c - startIndex;
            var codigoVacuna = cmbVacuna.Text.Remove(startIndex, length);
            solicitud.CodigoVacuna = codigoVacuna;
            solicitud.IdentificacionPaciente = txtIdentificacion.Text;
            solicitud.FechaSolicitud = DateTime.Now;
            solicitud.UserReg = UserLoginCache.IdUser;
            solicitud.Estado = "Pendiente";
            solicitud.Codigo = DateTime.Now.Year.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Second.ToString();

            return solicitud;
        }

        private void cmbVacuna_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbVacuna.Text))
            {
                validacion.SetHighlightColor(cmbVacuna, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            }
            else
            {
                validacion.SetHighlightColor(cmbVacuna, DevComponents.DotNetBar.Validator.eHighlightColor.None);
            }
        }
    }
}
