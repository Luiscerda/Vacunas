using System;
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
                            UserLoginCache.UserName = reader.GetString(1);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Email = reader.GetString(5);
                            UserLoginCache.Rol = reader.GetString(6);
                            UserLoginCache.Identificacion = reader.GetString(7);
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
        public void SaveUsers(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert Into Users (LoginName,Password,FirstName,LastName,Email,Rol,Identification) values" +
                        "(@loginName,@password,@name,@lastName,@mail,@rol,@identification)";
                    command.Parameters.AddWithValue("@loginName", user.UserName);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@lastName", user.LastName);
                    command.Parameters.AddWithValue("@mail", user.Mail);
                    command.Parameters.AddWithValue("@rol", user.Rol);
                    command.Parameters.AddWithValue("@identification", user.Identification);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> GetUsers()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                List<User> users = new List<User>();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Users";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.UserName = reader.GetString(1);
                            user.Name = reader.GetString(3);
                            user.LastName = reader.GetString(4);
                            user.Rol = reader.GetString(6);
                            user.Mail = reader.GetString(5);
                            user.Id = reader.GetInt32(0);
                            user.Identification = reader.GetString(7);

                            users.Add(user);
                        }
                        return users;
                    }
                    else
                    {
                        return users;
                    }
                }
            }
        }
        public bool GetUserByUserName(string userName)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Users where LoginName=@user";
                    command.Parameters.AddWithValue("@user", userName);
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
        public User GetUserById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                User user = new User();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select * from Users where UserId=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.UserName = reader.GetString(1);
                            user.Name = reader.GetString(3);
                            user.LastName = reader.GetString(4);
                            user.Rol = reader.GetString(6);
                            user.Mail = reader.GetString(5);
                            user.Id = reader.GetInt32(0);
                            user.Identification = string.IsNullOrEmpty(reader.GetString(7)) ? "" : reader.GetString(7);
                            user.Password = reader.GetString(2);

                        }
                        return user;
                    }
                    else
                    {
                        return user;
                    }
                }
            }
        }
        public void UpdateUser(User user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update  Users set FirstName=@name,Password=@password,LastName=@lastName, Email=@mail where UserId=@id";
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@lastName", user.LastName);
                    command.Parameters.AddWithValue("@mail", user.Mail);
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete  Users where UserId=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
