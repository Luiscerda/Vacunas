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
        public SolicitudModel()
        {
            solicitudDao = new SolicitudDao();
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
    }
}
