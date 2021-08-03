using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmRecibirSolicitud : Form
    {
        SolicitudModel solicitudModel;
        PatientsModel patientsModel;
        VacunaModel vacunaModel;
        public FrmRecibirSolicitud(Solicitud solicitud)
        {
            InitializeComponent();
            solicitudModel = new SolicitudModel();
            patientsModel = new PatientsModel();
            vacunaModel = new VacunaModel();
            LoadSolicitud(solicitud);
        }

        private void LoadSolicitud(Solicitud solicitud)
        {
            Patient patient = patientsModel.GetPatient(solicitud.IdentificacionPaciente);
            Vacuna vacuna = vacunaModel.GetVacunaByCodigo2(solicitud.CodigoVacuna);
            txtCodigoSolicitud.Text = solicitud.Codigo;
            txtCodigoVacuna.Text = vacuna.Codigo;
            txtVacuna.Text = vacuna.Nombre;
            txtIdentificacionPaciente.Text = patient.Identification;
            txtNombrePaciente.Text = patient.FirstName;
            txtApellidoPaciente.Text = patient.LastName;
            txtEdadPaciente.Text = patient.Age.ToString();
            txtPatologiaPaciente.Text = patient.Patologia;
            txtFechaSolicitud.Text = solicitud.FechaSolicitud.ToString();
            txtEstado.Text = solicitud.Estado;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            string mensaje = solicitudModel.UpdateEstadoSolicitud(txtCodigoSolicitud.Text, "Rechazada");
            MessageBox.Show(mensaje,"Mensaje");
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string mensaje = solicitudModel.UpdateEstadoSolicitud(txtCodigoSolicitud.Text, "Aceptada");
            MessageBox.Show(mensaje, "Mensaje");
            this.Close();
        }
    }
}
