using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common;

namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        public bool Login(string user, string password)
        {
            return userDao.Login(user,password);
        }

        public string RecoveryPassword(string userRequesting)
        {
            return userDao.RecoveryPassword(userRequesting);
        }

        public List<User> GetUsers()
        {
            try
            {
                return userDao.GetUsers();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EditProfile(User user)
        {          
            try
            {
                userDao.EditProfile(user);
                Login(user.UserName,user.Password);
                return "Perfil modificado con exito";
            }
            catch (Exception)
            {
                return "Nombre de usuario ya registrado, intente con otro";
            }
        }
        public string SaveUser(User user)
        {
            try
            {
                bool response = userDao.GetUserByUserName(user.UserName.Trim());
                if (response)
                {
                    return "El nombre de usuario ya esta registrado, intentalo con otro";
                }
                else
                {
                    userDao.SaveUsers(user);
                    return "Registro con exito";
                }
            }
            catch (Exception e)
            {
                return "Error " + e.Message;
            }
        }
        public User GetUserById(int id)
        {
            return userDao.GetUserById(id);
        }
        public string UpdateUser(User user)
        {
            try
            {
                userDao.UpdateUser(user);
                return "Usuario modificado con exito";
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }
        public string DeleteUser(int id)
        {
            try
            {
                userDao.DeleteUser(id);
                return "Usuario eliminado con exito";
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }
    }
}
