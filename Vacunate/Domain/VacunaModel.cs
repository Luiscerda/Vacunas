using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common;

namespace Domain
{
    public class VacunaModel
    {
        VacunaDao vacunaDao;
        public VacunaModel()
        {
            vacunaDao = new VacunaDao();
        }
        public string SaveVacuna(Vacuna vacuna)
        {
            try
            {
                Vacuna vacunaBuscada = GetVacunaByCodigo2(vacuna.Codigo.Trim());
                if (vacunaBuscada.Codigo != null)
                {
                    vacuna.Stock = vacuna.NumeroDosis + vacunaBuscada.Stock;
                    vacunaDao.UpdateEstadoVacuna(vacunaBuscada.IdVacuna);                   
                }
                vacunaDao.SaveVacuna(vacuna);
                return "Registrada la vacuna con exito";
            }
            catch (Exception e)
            {
                return "Error " + e.Message;
            }
        }
        public Vacuna GetVacunaByCodigo2(string codigo)
        {
            return vacunaDao.GetVacunaByCodigo2(codigo);
        }
        public List<Vacuna> GetVacunas()
        {
            return vacunaDao.GetVacunas();
        }
        public string UpdateAceptarVacunas(string codigo)
        {
             vacunaDao.UpdateAceptarVacunas(codigo);
            return "Vacuna aceptada con exito";
        }
    }
}
