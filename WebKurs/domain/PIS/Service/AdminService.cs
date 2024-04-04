namespace PIS.Service
{
    using PIS.Interface;
    using PIS.Models;
    using System;
    using System.Globalization;
    using WebKurs.Models;

    public class AdminService : IAdminService
    {
        private readonly ITourService _tourService;

        private readonly ICityService _cityService;

        private readonly IAttractionService _attractionService;

        private readonly IAuthenticationService _authenticationService;

        private readonly IUserService _userService;

        private readonly IOrderService _orderService;


        public AdminService(ITourService tourService, ICityService cityService, IAttractionService attractionService, IUserService userService, IAuthenticationService authenticationService, IOrderService orderService)
        {
            _tourService = tourService;
            _cityService = cityService;
            _attractionService = attractionService;
            _userService = userService;
            _authenticationService = authenticationService;
            _orderService = orderService;
        }

        public async Task DeleteUser(string userId)
        {
            await _userService.DeleteUser(userId);
        }

        public async Task DeleteTour(string tourId)
        {
            await _tourService.DeleteTour(tourId);
        }

        public async Task DeleteCity(string cityId)
        {
           await _cityService.DeleteCityByIdAsync(cityId);
           var attList = await _attractionService.GetAllAttractionsByCityIdAsync(cityId);
           foreach (var att in attList)
           {
              await _attractionService.DeleteAttrationByIdAsync(att.AttractionId);
           }
        }

        public async Task DeleteAttractionAsync(string attractionId)
        {
            await _attractionService.DeleteAttrationByIdAsync(attractionId);
        }
    }
}
