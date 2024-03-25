namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using System.Reflection;
    using WebKurs.Models;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly ISessionService _sessionService;

        private readonly IAuthenticationService _authenticationService;


        public UserService(IUserRepository userRepository, ISessionService sessionService, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _sessionService = sessionService;
            _authenticationService = authenticationService;
        }

        public List<User> GetAllUsers() 
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public List<User> GetAllUsersByUsername(string username)
        {
            return _userRepository.GetUAllsersByPartUsername(username);
        }

        public UserModel GetUserModel(UserModel model)
        {
            string username = _sessionService.Get<string>("Username");
            var user = _userRepository.GetUserByUsername(username);
            model.Username = username;
            model.Email = user.Email;

            return model;
        }

        public bool UpdatePassword(string newPassword, string password, Dictionary<string, string> Error)
        {
            string usermame = _sessionService.Get<string>("Username");
            var user = _userRepository.GetUserByUsername(usermame);

            if (password == null || !_authenticationService.IsPasswordCorrect(newPassword))
            {
                Error["UnCorrectPassword"] = "Пароль должен содержать как минимум одну заглавную латинскую букву, цифру и спец.знак";
                return false;
            }

            if (newPassword == user.Password)
            {
                Error["PasswordEqual"] = "Пароли не должны совпадать";
                return false;
            }

            if (password != user.Password)
            {
                Error["InvalidPassword"] = "Неправильный пароль";
                return false;
            }

            if (newPassword != null)
            {
                user.Password = newPassword;
            }
            return true;

        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public bool UpdateUser(UserModel model)
        {
            string username = _sessionService.Get<string>("Username");
            string email = _sessionService.Get<string>("Email");
            var user = _userRepository.GetUserByUsername(username);

            if (username == null || model.Email == null)
            {
                    model.Error["Empty"] = "Поля не должны быть пустыми";
                    return false;
            }

            if (username != model.Username)
            {

                if (!_authenticationService.IsUsernameAvailable(model.Username))
                {
                    model.Error["UsernameTaken"] = "Данное имя пользователя уже занято";
                    return false;
                }
            }

            if (email != model.Email)
            {
                if (!_authenticationService.IsEmailCorrect(model.Email))
                {
                    model.Error["InvalidEmail"] = "В адресе эл.почты не были указаны @gmail.com или @mail.ru или @yandex.ru";
                    return false;
                }

                if (!_authenticationService.IsEmailAvailable(model.Email))
                {
                    model.Error["EmailTaken"] = "Уже существует аккунт с такой почтой";
                    return false;
                }
            }
                
            

           user.UserName = model.Username;
           user.Email = model.Email;

            _sessionService.Set("Username", model.Username);
            return true;
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public string GetUsernameByEmail(string email)
        {
            return _userRepository.GetUsernameByEmail(email);
        }
    }
}
