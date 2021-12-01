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
            LoadReportEdades();
            LoadReportVacunas();
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
            ReportEdades edad = reportModel.GetReportEdades();
            ArrayList rango = new ArrayList();
            ArrayList cantidades = new ArrayList();
            for (int i = 0; i <= 5; i++)
            {
                if (i == 0)
                {
                    if (edad.Under18 != 0)
                    {
                        cantidades.Add(edad.Under18);
                        rango.Add("Menor 18");
                    }
                }
                if (i == 1)
                {
                    if (edad.E18_24 != 0)
                    {
                        cantidades.Add(edad.E18_24);
                        rango.Add("Entre 18 y 24");
                    }
                }
                if (i == 2)
                {
                    if (edad.E25_34 != 0)
                    {
                        cantidades.Add(edad.E25_34);
                        rango.Add("Entre 25 y 34");
                    }
                    
                }
                if (i == 3)
                {
                    if (edad.E35_44 != 0)
                    {
                        cantidades.Add(edad.E35_44);
                        rango.Add("Entre 35 y 44");
                    }

                }
                if (i == 4)
                {
                    if (edad.E45_54 != 0)
                    {
                        cantidades.Add(edad.E45_54);
                        rango.Add("Entre 45 y 54");
                    }

                }
                if (i == 5)
                {
                    if (edad.E55 != 0)
                    {
                        cantidades.Add(edad.E55);
                        rango.Add("Mayor o igual a 55");
                    }

                }
            }
            chartEdad.Series[0].Points.DataBindXY(rango, cantidades);
        }
        private void LoadReportVacunas()
        {
            List<ReportVacunas> reportVacunas = reportModel.GetReportVacunas();
            ArrayList vacunas = new ArrayList();
            ArrayList cantidades = new ArrayList();
            foreach (var item in reportVacunas)
            {
                vacunas.Add(item.Vacuna);
                cantidades.Add(item.Cantidad);
            }
            chartEstados.Series[0].Points.DataBindXY(vacunas, cantidades);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
