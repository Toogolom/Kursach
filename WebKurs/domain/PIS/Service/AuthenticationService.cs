namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        private readonly Regex _emailRegex = new Regex(@"^(\w)+@(gmail\.com|mail\.ru|yandex\.ru)$");

        private readonly Regex _passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\s]).{8,}$");

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Authenticate(string email, string password, Dictionary<string, string> error)
        {
            var user = _userRepository.GetUserByEmail(email);
            bool isCorrect = true;
            if (password == null || email == null)
            {
                error["Empty"] = "Поля не должны быть пустыми";
                return false;
            }

            if (!IsEmailCorrect(email))
            {
                error["InvalidEmail"] = "В адресе эл.почты не были указаны @gmail.com или @mail.ru или @yandex.ru";
                return false;
            }

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

        public bool Registration(string username, string password, string email, Dictionary<string, string> error)
        {
            bool isCorrect = true;

            if (username == null || password == null || email == null)
            {
                error["Empty"] = "Поля не должны быть пустыми";
                return false;
            }
            if (!IsUsernameAvailable(username))
            {
                error["UsernameTaken"] = "Данное имя пользователя уже занято";
                isCorrect = false;
            }

            if (!IsEmailCorrect(email))
            {
                error["InvalidEmail"] = "В адресе эл.почты не были указаны @gmail.com или @mail.ru или @yandex.ru";
                isCorrect = false;
            }

            if (!IsEmailAvailable(email))
            {
                error["EmailTaken"] = "Уже существует аккунт с такой почтой";
                isCorrect = false;
            }

            if (!IsPasswordCorrect(password))
            {
                error["InvalidPassword"] = "Пароль должен содержать как минимум одну заглавную латинскую букву, цифру и спец.знак";
                isCorrect = false;
            }

            if (isCorrect)
            {
                _userRepository.AddUser(username, email, password);
            }

            return isCorrect;
        }

        public bool IsUsernameAvailable(string username)
        {
            return _userRepository.UsernameNotExist(username);
        }

        public bool IsEmailCorrect(string email)
        {
            return _emailRegex.IsMatch(email);
        }

        public bool IsEmailAvailable(string email)
        {
            return _userRepository.UserEmailNotExist(email);
        }

        public bool IsPasswordCorrect(string password)
        {
            return _passwordRegex.IsMatch(password);
        }

        private string HashPassword(string password)
        {
            return password;
        }

        public bool VerifyPassword(string password, string storedPassword)
        {
            return password == storedPassword;
        }
    }
}
