namespace PIS.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthenticationService
    {
        public Task<bool> AuthenticateAsync(string username, string password,Dictionary<string, string> error);

        public Task<bool> RegistrationAsync(string username, string password, string email, Dictionary<string, string> error);

        public Task<bool> IsUsernameAvailableAsync(string username);

        public bool IsEmailCorrect(string email);

        public string SendVerifyCodeToEmail(string email);

        public Task<bool> IsEmailAvailableAsync(string email);

        public bool IsPasswordCorrect(string password);

        public bool VerifyPassword(string password, string storedPassword);

    }
}
