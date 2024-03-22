namespace PIS.Service
{
    using PIS.Interface;
    using System;
    using WebKurs.Models;

    public class AdminService
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

        public bool AddUser(RegModel model)
        {
            return _authenticationService.Registration(model.Username, model.Password, model.Email, model.Error);
        }

        public bool UpdateUser(RegModel model)
        {
            return _userService.UpdateUser(model);
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

        public void AddCity(City city)
        {

        }

        public void UpdateCity(int cityId)
        {

        }

        public void DeleteCity(int cityId)
        {

        }

        public void AddAttraction(Attraction tourAttraction)
        {

        }

        public void UpdateAttraction(int  attractionId)
        {

        }

        public void DelteAttraction(int attractionId)
        {

        }
    }
}
