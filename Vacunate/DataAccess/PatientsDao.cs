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
                    command.CommandText = "Insert Into Pacients (FirstName,LastName,Age,Telephone,Email,DateOfBirth,Identification) values" +
                        "(@firstName,@lastName,@age,@telephone,@mail,@dateOfBirth,@identification)";
                    command.Parameters.AddWithValue("@firstName", patient.FirstName);
                    command.Parameters.AddWithValue("@lastName", patient.LastName);
                    command.Parameters.AddWithValue("@age", patient.Age);
                    command.Parameters.AddWithValue("@telephone", patient.Telephone);
                    command.Parameters.AddWithValue("@mail", patient.Mail);
                    command.Parameters.AddWithValue("@dateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@identification", patient.Identification);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
