using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataAccess;

namespace Domain
{
    public class PatientsModel
    {
        PatientsDao PatientsDao; 
        public PatientsModel()
        {
            PatientsDao = new PatientsDao();
        }

        public bool GetPatientsByIdentification(string identification)
        {
            return PatientsDao.GetPatientByIdentification(identification.Trim());
        }

        public string SavePatient(Patient patient)
        {
            try
            {
                bool response = PatientsDao.GetPatientByIdentification(patient.Identification.Trim());
                if (response)
                {
                    return "La identificacion del paciente ya se encuentra registrada";
                }
                else
                {
                    PatientsDao.SavePatient(patient);
                    return "Registro con exito";
                }
            }
            catch (Exception e)
            {
                return "Error " + e.Message;
            }
        }
    }
}
