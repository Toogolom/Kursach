namespace PIS
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Authenticate(string email, string password, Dictionary<string,string> error)
        {
            var user = _userRepository.GetUserByEmail(email);
            bool isCorrect = true;

            if (user == null)
            {
                error["InvalidEmail"] = "Неправильный адрес эл.почты";
                isCorrect = false;
            }
            else if (!VerifyPassword(password, user.Password))
            {
                error["InvalidPassword"] = "Неправильный пароль";
                isCorrect = false;
            }

            return isCorrect;
        }

        private bool VerifyPassword(string password, string storedPassword)
        {
            return password == storedPassword;
        }
    }
}
