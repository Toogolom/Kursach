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
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(string id);

        Task<User> GetUserByEmail(string email);

        Task<List<User>> GetAllUsersByUsername(string username);

        Task<bool> UpdatePassword(string newPassword, string password, Dictionary<string, string> error);

        Task<bool> UpdateUser(UserModel model);

        Task DeleteUser(string id);

        Task<string> GetUsernameByEmail(string email);
    }
}
