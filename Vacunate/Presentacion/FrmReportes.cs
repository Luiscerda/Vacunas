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
    }
}
