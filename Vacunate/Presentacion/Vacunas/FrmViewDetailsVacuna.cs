using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Windows.Forms;

namespace Presentacion.Vacunas
{
    public partial class FrmViewDetailsVacuna : Form
    {
        public FrmViewDetailsVacuna(Vacuna vacuna)
        {
            InitializeComponent();
            LoadVacuna(vacuna);
        }

        private void LoadVacuna(Vacuna vacuna)
        {
            txtCodigo.Text = vacuna.Codigo;
            txtNombre.Text = vacuna.Nombre;
            txtClasificacion.Text = vacuna.Clasificacion;
            txtDosis.Text = vacuna.NumeroDosis.ToString();
            txtComposicion.Text = vacuna.Composicion;
            txtConservacion.Text = vacuna.Conservacion;
            txtLaboratorio.Text = vacuna.Laboratorio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
