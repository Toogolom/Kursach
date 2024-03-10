namespace PIS
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Registration(string username, string password, string email)
        {
            if (IsUsernameAvailable(username))
            {
                _userRepository.AddUser(email,username,password);
                return true;
            }
            return false;
        }

        private bool IsUsernameAvailable(string username)
        {
            var User =_userRepository.GetUserByUserName(username);
            return User == null;
        }

        private string HashPassword(string password)
        {
            return password;
        }

    }
}
