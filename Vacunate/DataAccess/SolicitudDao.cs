using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class SolicitudDao : ConnectionToSql
    {
        public void SaveSolicitud(Solicitud solicitud)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert Into Solicitudes (Codigo,CodigoVacuna,IdentificacionPaciente,Estado,FechaReg,UserReg) values" +
                        "(@codigo,@codigoVacuna,@identificacionPaciente,@estado,@fechaReg,@userReg)";
                    command.Parameters.AddWithValue("@codigo", solicitud.Codigo);
                    command.Parameters.AddWithValue("@codigoVacuna", solicitud.CodigoVacuna);
                    command.Parameters.AddWithValue("@identificacionPaciente", solicitud.IdentificacionPaciente);
                    command.Parameters.AddWithValue("@estado", solicitud.Estado);
                    command.Parameters.AddWithValue("@fechaReg", solicitud.FechaSolicitud);
                    command.Parameters.AddWithValue("@userReg", solicitud.UserReg);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public Solicitud GetSolicitudEstado(string identificacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                Solicitud solicitud = new Solicitud();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Solicitudes where IdentificacionPaciente=@id";
                    command.Parameters.AddWithValue("@id", identificacion);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            solicitud.Codigo = reader.GetString(1);
                            solicitud.CodigoVacuna = reader.GetString(2);
                            solicitud.IdentificacionPaciente = reader.GetString(3);
                            solicitud.Estado = reader.GetString(4);
                            solicitud.FechaSolicitud = reader.GetDateTime(5);
                            solicitud.UserReg = reader.GetInt32(7);

                        }
                        return solicitud;
                    }
                    else
                    {
                        return solicitud;
                    }
                }
            }
        }

        public List<Solicitud> GetSolicitudes(string identificacionPaciente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<Solicitud> solicituds = new List<Solicitud>();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Solicitudes where IdentificacionPaciente=@identificacion";
                    command.Parameters.AddWithValue("@identificacion", identificacionPaciente);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Solicitud solicitud = new Solicitud();
                            solicitud.Codigo = reader.GetString(1);
                            solicitud.FechaSolicitud = reader.GetDateTime(5);
                            solicitud.Estado = reader.GetString(4);
                            solicitud.CodigoVacuna = reader.GetString(2);

                            solicituds.Add(solicitud);
                        }
                        return solicituds;
                    }
                    else
                    {
                        return solicituds;
                    }
                }
            }
        }
    }
}
