using MyProject.DAL;
using MyProject.Entities;
using MyProject.BLL;
using UserManagement.BLL;

namespace MyProject.BLL
{
    public class UserManager
    {
        private UserDAL userDal = new UserDAL();

        public User Login(string email, string passwordHash)
        {
            return userDal.CheckUser(email, passwordHash);
        }
    }
}

using MyProject.DAL;
using MyProject.Entities;
using System.Collections.Generic;

namespace MyProject.BLL
{
    public class UserManager
    {
        private UserDAL _dal = new UserDAL();

        public List<User> GetAllUsers()
        {
            return _dal.GetAllUsers();
        }

        public void DeleteUser(int userId)
        {
            _dal.DeleteUser(userId);
        }

        public void SetUserActive(int userId, bool isActive)
        {
            _dal.SetUserActive(userId, isActive);
        }

        // Diðer metodlar: Login, AddUser, UpdateUser zaten var
    }
}


public void AddUser(string fullName, string email, byte[] passwordHash, byte[] salt, int roleId)
{
    _dal.AddUser(fullName, email, passwordHash, salt, roleId);
}

public void UpdateUser(User user)
{
    _dal.UpdateUser(user);
}

using MyProject.DAL;
using MyProject.Entities;
using System.Collections.Generic;

namespace MyProject.BLL
{
    public class UserManager
    {
        private UserDAL _dal = new UserDAL();

        public List<User> GetAllUsers()
        {
            return _dal.GetAllUsers();
        }
    }
}
