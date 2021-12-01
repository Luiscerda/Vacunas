using Common.Reporte;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReportModel
    {
        ReporteDao reporteDao;
        public ReportModel()
        {
            reporteDao = new ReporteDao();
        }
        public List<ReportEstado> GetReportEstados()
        {
            return reporteDao.GetReportEstados();
        }
        public ReportEdades GetReportEdades()
        {
            return reporteDao.GetReportEdades();
        }
        public List<ReportVacunas> GetReportVacunas()
        {
            return reporteDao.GetReportVacunas();
        }
    }
}
