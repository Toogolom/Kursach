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

        public RegModel GetRegModel(RegModel model);

        public bool UpdateUser(RegModel model);

        public void DeleteUser(int id);

        public bool UpdatePassword(string newPassword, string password, Dictionary<string, string> Error);

        public string GetUsernameByEmail(string email);
    }
}
