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

        public List<ReportEdades> GetReportEdades()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<ReportEdades> reportEdades = new List<ReportEdades>();
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
                            ReportEdades edad = new ReportEdades();
                            edad.Edad = reader.GetInt32(0);
                            edad.Cantidad = reader.GetInt32(1);

                            reportEdades.Add(edad);
                        }
                        return reportEdades;
                    }
                    else
                    {
                        return reportEdades;
                    }
                }
            }
        }
    }
}
