using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Reporte;

namespace DataAccess
{
    public class ReporteDao : ConnectionToSql
    {
        public List<ReportEstado> GetReportEstados()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<ReportEstado> reportEstados = new List<ReportEstado>();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EstadoSolicitud";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ReportEstado estado = new ReportEstado();
                            estado.Estado = reader.GetString(0);
                            estado.Cantidad = reader.GetInt32(1);

                            reportEstados.Add(estado);
                        }
                        return reportEstados;
                    }
                    else
                    {
                        return reportEstados;
                    }
                }
            }
        }

        public ReportEdades GetReportEdades()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                //List<ReportEdades> reportEdades = new List<ReportEdades>();
                ReportEdades edad = new ReportEdades();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Edad";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                            edad.Under18 = reader.GetInt32(0);
                            edad.E18_24 = reader.GetInt32(1);
                            edad.E25_34 = reader.GetInt32(2);
                            edad.E35_44 = reader.GetInt32(3);
                            edad.E45_54 = reader.GetInt32(4);
                            edad.E55 = reader.GetInt32(5);

                        }
                        return edad;
                    }
                    else
                    {
                        return edad;
                    }
                }
            }
        }

        public List<ReportVacunas> GetReportVacunas()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<ReportVacunas> reportVacunas = new List<ReportVacunas>();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ReporteVacunas";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ReportVacunas vacuna = new ReportVacunas();
                            vacuna.Vacuna = reader.GetString(0);
                            vacuna.Cantidad = reader.GetInt32(1);

                            reportVacunas.Add(vacuna);
                        }
                        return reportVacunas;
                    }
                    else
                    {
                        return reportVacunas;
                    }
                }
            }
        }
    }
}
