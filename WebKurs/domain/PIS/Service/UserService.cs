namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task<List<User>> GetAllUsersByUsername(string username)
        {
            return await _userRepository.GetUsersByPartUsernameAsync(username);
        }

        public async Task<bool> UpdatePassword(string newPassword, string password, Dictionary<string, string> error)
        {
            string email = _sessionService.Get<string>("Email");
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (password == null || !_authenticationService.IsPasswordCorrect(newPassword))
            {
                error["UnCorrectPassword"] = "Пароль должен содержать как минимум одну заглавную латинскую букву, цифру и спец.знак";
                return false;
            }

            if (newPassword == user.Password)
            {
                error["PasswordEqual"] = "Пароли не должны совпадать";
                return false;
            }

            if (password != user.Password)
            {
                error["InvalidPassword"] = "Неправильный пароль";
                return false;
            }

            return await _userRepository.UpdatePassword(newPassword,email);
        }

        public async Task<bool> UpdateUser(UserModel model)
        {
            var user = await _userRepository.GetUserByIdAsync(model.UserId);

            if (model.Username == null || model.Email == null)
            {
                model.Error["Empty"] = "Поля не должны быть пустыми";
                return false;
            }

            if (user.Username != model.Username)
            {

                if (!await _authenticationService.IsUsernameAvailableAsync(model.Username))
                {
                    model.Error["UsernameTaken"] = "Данное имя пользователя уже занято";
                    return false;
                }
            }

            if (user.Email != model.Email)
            {
                if (!_authenticationService.IsEmailCorrect(model.Email))
                {
                    model.Error["InvalidEmail"] = "В адресе эл.почты не были указаны @gmail.com или @mail.ru или @yandex.ru";
                    return false;
                }

                if (!await _authenticationService.IsEmailAvailableAsync(model.Email))
                {
                    model.Error["EmailTaken"] = "Уже существует аккаунт с такой почтой";
                    return false;
                }
            }

            return await _userRepository.UpdateUser(model.Email, model.Username);
        }

        public async Task DeleteUser(string id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<string> GetUsernameByEmail(string email)
        {
            return await _userRepository.GetUsernameByEmailAsync(email);
        }
    }
}
