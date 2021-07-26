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
    }
}
