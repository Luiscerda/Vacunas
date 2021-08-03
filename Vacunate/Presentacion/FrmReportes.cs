using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Reporte;
using Domain;

namespace Presentacion
{
    public partial class FrmReportes : Form
    {
        ReportModel reportModel;
        public FrmReportes()
        {
            InitializeComponent();
            reportModel = new ReportModel();
            LoadReportEstados();
            LoadReportEdades();
        }
        
        private void LoadReportEstados()
        {
            List<ReportEstado> reportEstados = reportModel.GetReportEstados();
            ArrayList estado = new ArrayList();
            ArrayList cantidades = new ArrayList();
            foreach (var item in reportEstados)
            {
                estado.Add(item.Estado);
                cantidades.Add(item.Cantidad);
            }
            chartEstados.Series[0].Points.DataBindXY(estado, cantidades);
        }
        private void LoadReportEdades()
        {
            List<ReportEdades> edades = reportModel.GetReportEdades();
            ArrayList rango = new ArrayList();
            ArrayList cantidades = new ArrayList();
            foreach (var item in edades)
            {
                if (item.Edad < 18)
                {
                    item.Rango = "Menor 18";
                }
                else if (item.Edad >= 18 && item.Edad < 24)
                {
                    item.Rango = "Entre 18 y 24";
                }
                else if (item.Edad >= 24 && item.Edad < 34)
                {
                    item.Rango = "Entre 24 y 34";
                }
                else if (item.Edad >= 34 && item.Edad < 44)
                {
                    item.Rango = "Entre 44 y 54";
                }
                else
                {
                    item.Rango = "Mayor de 50";
                }
                rango.Add(item.Rango);
                cantidades.Add(item.Cantidad);
            }
            chartEdad.Series[0].Points.DataBindXY(rango, cantidades);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
