using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataAccess;

namespace Domain
{
    public class SolicitudModel
    {
        SolicitudDao solicitudDao;
        VacunaDao vacunaDao;
        public SolicitudModel()
        {
            solicitudDao = new SolicitudDao();
            vacunaDao = new VacunaDao();
        }
        public string SaveSolicitud(Solicitud solicitud)
        {
            try
            {
                var solicitudBuscada = solicitudDao.GetSolicitudEstado(solicitud.IdentificacionPaciente);
                if (solicitudBuscada.Estado == "Pendiente")
                {
                    return "No puede realizar una nueva solicitud , tiene una pendiente";
                }
                else
                {
                    solicitudDao.SaveSolicitud(solicitud);
                    return "Solicitud enviada con exito";
                }
            }
            catch (Exception e)
            {
                return "Error " + e.Message;
            }
        }
        public List<Solicitud> GetSolicitudes(string identificacionPaciente)
        {
            return solicitudDao.GetSolicitudes(identificacionPaciente);
        }
        public List<Solicitud> GetSolicitudes()
        {
            return solicitudDao.GetSolicitudes();
        }

        public Solicitud GetSolicitudByCodigo(string codigo)
        {
            return solicitudDao.GetSolicitudByCodigo(codigo);
        }
        public string UpdateEstadoSolicitud(string codigo, string estado, string codigoVacuna)
        {
            try
            {
                solicitudDao.UpdateEstadoSolicitud(codigo, estado);
                if (estado.Trim() == "Rechazada")
                {
                    return "Solicitud rechazada";
                }
                else
                {
                    vacunaDao.UpdateAceptarVacunas(codigoVacuna.Trim());
                    return "Solicitud aprobada";
                }
                
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
           
        }
    }
}
