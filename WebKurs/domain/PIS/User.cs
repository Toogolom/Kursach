namespace PIS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public int UserId { get; }

        public string UserName { get; }

        public string Email { get; }

        public string Password { get; }

        public User(int userId, string userName, string email, string password)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Password = password;
        }
    }
}
