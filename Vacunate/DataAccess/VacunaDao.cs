using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class VacunaDao : ConnectionToSql
    {
        public void SaveVacuna(Vacuna vacuna)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert Into Vacunas (Codigo,Nombre,Dosis,Laboratorio,Clasificacion,Composicion,Conservacion,UserReg,FechaReg,Stock) values" +
                        "(@codigo,@nombre,@dosis,@laboratorio,@clasificacion,@composicion,@conservacion,@userReg,@fechaReg,@stock)";
                    command.Parameters.AddWithValue("@codigo", vacuna.Codigo);
                    command.Parameters.AddWithValue("@nombre", vacuna.Nombre);
                    command.Parameters.AddWithValue("@dosis", vacuna.NumeroDosis);
                    command.Parameters.AddWithValue("@laboratorio", vacuna.Laboratorio);
                    command.Parameters.AddWithValue("@clasificacion", vacuna.Clasificacion);
                    command.Parameters.AddWithValue("@composicion", vacuna.Composicion);
                    command.Parameters.AddWithValue("@conservacion", vacuna.Conservacion);
                    command.Parameters.AddWithValue("@userReg", vacuna.UserReg);
                    command.Parameters.AddWithValue("@fechaReg", vacuna.FechaReg);
                    command.Parameters.AddWithValue("@stock", vacuna.Stock);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool GetVacunaByCodigo(string codigo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Vacunas where Codigo=@codigo";
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public Vacuna GetVacunaByCodigo2(string codigo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                Vacuna vacuna = new Vacuna();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Vacunas where Codigo=@codigo";
                    command.Parameters.AddWithValue("@codigo", codigo);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            vacuna = MapearVacuna(reader);
                        }
                        return vacuna;
                    }
                    else
                    {
                        return vacuna;
                    }
                }
            }
        }

        private static Vacuna MapearVacuna(SqlDataReader reader)
        {
            Vacuna vacuna = new Vacuna();
            vacuna.IdVacuna = reader.GetInt32(0);
            vacuna.Codigo = reader.GetString(1);
            vacuna.Nombre = reader.GetString(2);
            vacuna.NumeroDosis = reader.GetInt32(3);
            vacuna.Laboratorio = reader.GetString(4);
            vacuna.Clasificacion = reader.GetString(5);
            vacuna.Composicion = reader.GetString(6);
            vacuna.Conservacion = reader.GetString(7);
            vacuna.Stock = reader.GetInt32(8);
            vacuna.Activa = reader.GetBoolean(13);
            return vacuna;
        }

        public void UpdateEstadoVacuna(int idVacuna)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update  Vacunas set Activa=0 where IdVacunas=@idVacuna";
                    command.Parameters.AddWithValue("@idVacuna", idVacuna);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Vacuna> GetVacunas()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<Vacuna> vacunas = new List<Vacuna>();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Vacunas";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vacuna vacuna = new Vacuna();
                            vacuna = MapearVacuna(reader);
                            vacunas.Add(vacuna);
                        }
                        return vacunas;
                    }
                    else
                    {
                        return vacunas;
                    }
                }
            }
        }
    }
}
