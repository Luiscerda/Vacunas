using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Vacuna
    {
        public int IdVacuna { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int NumeroDosis { get; set; }
        public int UserReg { get; set; }
        public DateTime FechaReg { get; set; }
        public string Laboratorio { get; set; }
        public string Composicion { get; set; }
        public string Conservacion { get; set; }
        public int UserMod { get; set; }
        public DateTime FechaMod { get; set; }
        public string Clasificacion { get; set; }
        public int Stock { get; set; }
        public bool Activa { get; set; }
    }
}
