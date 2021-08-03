using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public string Codigo { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string Patologia { get; set; }
        public int EdadPaciente { get; set; }
        public string CodigoVacuna { get; set; }
        public int UserReg { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
    }
}
