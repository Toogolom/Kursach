namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        public bool Authenticate(string username, string password,Dictionary<string, string> error);

        public bool Registration(string username, string password, string email, Dictionary<string, string> error);

        public bool IsUsernameAvailable(string username);

        public bool IsEmailCorrect(string email);

        public string SendVerifyCodeToEmail(string email);

        public bool IsEmailAvailable(string email);

        public bool IsPasswordCorrect(string password);

        public bool VerifyPassword(string password, string storedPassword);

    }
}
