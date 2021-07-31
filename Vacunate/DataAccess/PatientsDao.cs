using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Cache;

namespace DataAccess
{
    public class PatientsDao : ConnectionToSql
    {
        public bool GetPatientByIdentification(string identification)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Pacients where Identification=@identification";
                    command.Parameters.AddWithValue("@identification", identification);
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
        public void SavePatient(Patient patient)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert Into Pacients (FirstName,LastName,Age,Telephone,Email,DateOfBirth,Identification,TipoDoc,UserReg,FechaReg,Password) values" +
                        "(@firstName,@lastName,@age,@telephone,@mail,@dateOfBirth,@identification,@tipoDoc,@userReg,@fechaReg,@password)";
                    command.Parameters.AddWithValue("@firstName", patient.FirstName);
                    command.Parameters.AddWithValue("@lastName", patient.LastName);
                    command.Parameters.AddWithValue("@age", patient.Age);
                    command.Parameters.AddWithValue("@telephone", patient.Telephone);
                    command.Parameters.AddWithValue("@mail", patient.Mail);
                    command.Parameters.AddWithValue("@dateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@identification", patient.Identification);
                    command.Parameters.AddWithValue("@tipoDoc", patient.TipoDoc);
                    command.Parameters.AddWithValue("@userReg", patient.UserReg);
                    command.Parameters.AddWithValue("@fechaReg", patient.FechaReg);
                    command.Parameters.AddWithValue("@password", patient.Password);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Patient> GetPatients()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<Patient> patients = new List<Patient>();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Pacients";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Patient patient = new Patient();
                            patient.PatientId = reader.GetInt32(0);
                            patient.FirstName = reader.GetString(1);
                            patient.LastName = reader.GetString(2);
                            patient.Mail = reader.GetString(3);
                            patient.Telephone = reader.GetString(4);
                            patient.DateOfBirth = reader.GetDateTime(5);
                            patient.Identification = reader.GetString(6);
                            patient.Age = reader.GetInt32(7);

                            patients.Add(patient);
                        }
                        return patients;
                    }
                    else
                    {
                        return patients;
                    }
                }
            }
        }
        public bool Login(string user, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Pacients where Identification=@user and Password=@password";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.IdUser = reader.GetInt32(0);
                            UserLoginCache.UserName = reader.GetString(8);
                            UserLoginCache.FirstName = reader.GetString(1);
                            UserLoginCache.LastName = reader.GetString(2);
                            UserLoginCache.Email = reader.GetString(3);
                            UserLoginCache.Rol = "Paciente";
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public Patient GetPatientById(string identificacion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                Patient patient = new Patient();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Pacients where Identification=@id";
                    command.Parameters.AddWithValue("@id", identificacion);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            patient.FirstName = reader.GetString(1);
                            patient.LastName = reader.GetString(2);
                            patient.Mail = reader.GetString(3);
                            patient.Telephone = reader.GetString(4);
                            patient.DateOfBirth = reader.GetDateTime(5);
                            patient.Identification = reader.GetString(6);
                            patient.Age = reader.GetInt32(7);
                            patient.TipoDoc = reader.GetString(9);

                        }
                        return patient;
                    }
                    else
                    {
                        return patient;
                    }
                }
            }
        }
    }
}
