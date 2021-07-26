﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Cache;
using Common;

namespace DataAccess
{
    public class UserDao : ConnectionToSql
    {
        public bool Login(string user, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Users where LoginName=@user and Password=@password";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.IdUser = reader.GetInt32(0);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Email = reader.GetString(5);
                            UserLoginCache.Rol = reader.GetString(6);
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
        public string RecoveryPassword(string userRequesting)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Users where LoginName=@user or Email=@mail";
                    command.Parameters.AddWithValue("@user", userRequesting);
                    command.Parameters.AddWithValue("@mail", userRequesting);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        string userName = reader.GetString(3) + " " + reader.GetString(4);
                        string email = reader.GetString(5);
                        string password = reader.GetString(2);

                        var mailService = new MailServices.SystemSupportMail();
                        mailService.SendMail(
                            subject: "SYSTEM: password recovery request",
                            body: "Hi," + userName + "\nYou Requested to Recover your password.\n"+
                            "your current password is:" + password+
                            "\nHowover, we ask that you change your password inmediately once you enter the system.",
                            recipientMail: new List<string> { email}
                            );
                        return "Hola," + userName + "\nSolicitó recuperar su contraseña.\n" +
                            "por favor revise su correo:" + email +
                            "\nSin embargo, le pedimos que cambie su contraseña\n" + "inmediatamente una vez que ingrese al sistema.";
                    }
                    else
                    {
                        return "Lo sentimos, no tienes una cuenta con ese correo \n"+
                            "o nombre de usuario.";
                    }
                }
            }
        }
        public void EditProfile(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update  Users set LoginName=@loginName,Password=@password,FirstName=@name,LastName=@lastName, Email=@mail where UserId=@id";
                    command.Parameters.AddWithValue("@loginName", user.UserName);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@lastName", user.LastName);
                    command.Parameters.AddWithValue("@mail", user.Mail);
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
