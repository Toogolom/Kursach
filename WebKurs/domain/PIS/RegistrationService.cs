﻿namespace PIS
{
    using PIS.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        private readonly Regex _emailRegex = new Regex(@"^(\w)+@(gmail\.com|mail\.ru|yandex\.ru)$");

        private readonly Regex _passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\s]).{8,}$");

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Registration(string username, string password, string email,Dictionary<string,string> error)
        {
           bool isCorrect = true;
           if (!IsUsernameAvailable(username))
           {
                error["UsernameTaken"] = "Данное имя пользователя уже занято";
                isCorrect =  false;
           }

           if (!IsEmailCorrect(email))
           {
                error["InvalidEmail"] = "В адресе эл.почты не были указаны @gmail.com или @mail.ru или @yandex.ru";
                isCorrect = false;
           }

           if (!IsEmailAvailable(email))
           {
                error["EmailTaken"] = "Уже существует аккунт с такой почтой";
           }

           if (!IsPasswordCorrect(password))
           {
                error["InvalidPassword"] = "Пароль должен содержать как минимум одну заглавную латинскую букву, цифру и спец.знак";
                isCorrect = false;
           }
           if (isCorrect)
           {
               _userRepository.AddUser(email, username, password);
           }
            
            return isCorrect;
        }

        private bool IsUsernameAvailable(string username)
        {
            return _userRepository.UsernameNotExist(username);
        }

        private bool IsEmailCorrect(string email)
        {
            return _emailRegex.IsMatch(email);
        }

        private bool IsEmailAvailable(string email)
        {
            return _userRepository.UserEmailNotExist(email);
        }

        private bool IsPasswordCorrect(string password)
        {
           return _passwordRegex.IsMatch(password);
        }

        private string HashPassword(string password)
        {
            return password;
        }

    }
}
