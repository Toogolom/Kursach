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

        public void DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
        }

        public void DeleteTour(int tourId)
        {
            _tourService.DeleteTour(tourId);
        }

        public void DeleteCity(int cityId)
        {
            _cityService.DeleteCityById(cityId);
        }

        public void DeleteAttraction(int attractionId)
        {
            _attractionService.DeleteAttrationById(attractionId);
        }
    }
}
