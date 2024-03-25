namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
    using System;
    using WebKurs.Models;

    public class AdminService : IAdminService
    {
        private readonly ITourService _tourService;

        private readonly ICityService _cityService;

        private readonly IAttractionService _attractionService;

        private readonly IAuthenticationService _authenticationService;

        private readonly IUserService _userService;


        public AdminService(ITourService tourService, ICityService cityService, IAttractionService attractionService, IUserService userService, IAuthenticationService authenticationService)
        {
            _tourService = tourService;
            _cityService = cityService;
            _attractionService = attractionService;
            _userService = userService;
            _authenticationService = authenticationService;
        }

        public bool UpdateUser(UserModel model)
        {
            var user = _userService.GetUserById(model.UserId);
            if (model.Username == null || model.Email == null)
            {
                model.Error["Empty"] = "Поля не должны быть пустыми";
                return false;
            }

            if (user.UserName != model.Username)
            {

                if (!_authenticationService.IsUsernameAvailable(model.Username))
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

                if (!_authenticationService.IsEmailAvailable(model.Email))
                {
                    model.Error["EmailTaken"] = "Уже существует аккунт с такой почтой";
                    return false;
                }
            }
            user.UserName = model.Username;
            user.Email = model.Email;

            return true;
        }

        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }

        public void AddTour(Tour tour)
        {
            
        }

        public void UpdateTour(int tourId)
        {

        }

        public void DeleteTour(int tourId)
        {

        }

        public bool AddCity(CityModel model)
        {
            if (model.URL == null || model.CityName == null || model.CityDescription == null)
            {
                return false;
            }

            _cityService.AddCity(model.URL, model.CityName, model.CityDescription);
            return true;
        }

        public bool UpdateCity(CityModel model)
        {
            if (model.URL == null || model.CityName == null || model.CityDescription == null)
            {
                return false;
            }

            City city = _cityService.GetCityById(model.CityId);

            city.PhotoUrl = model.URL;
            city.CityName = model.CityName;
            city.CityDescription = model.CityDescription;

            return true;
        }

        public void DeleteCity(int cityId)
        {
            _cityService.DeleteCityById(cityId);
        }

        public bool AddAttraction(AttractionModel model)
        {
            if (model.AttractionDescription == null && model.AttractionName == null && model.AttractionPhotoUrl == null)
            {
                return false;
            }

            _attractionService.AddAttraction(model);
            return true;
        }

        public void UpdateAttraction(int  attractionId)
        {

        }

        public void DelteAttraction(int attractionId)
        {

        }
    }
}
