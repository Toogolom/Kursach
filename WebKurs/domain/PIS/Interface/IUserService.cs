namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebKurs.Models;

    public interface IUserService
    {
        public User GetUserByEmail(string email);

        public User GetUserById(int id);

        public List<User> GetAllUsersByUsername(string username);

        public UserModel GetUserModel(UserModel model);

        public bool UpdateUser(UserModel model);

        public List<User> GetAllUsers();

        public void DeleteUser(int id);

        public bool UpdatePassword(string newPassword, string password, Dictionary<string, string> Error);

        public string GetUsernameByEmail(string email);
    }
}
