namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS;
    using PIS.Interface;
    using PIS.Models;
    using PIS.Service;
    using System.Threading.Tasks;
    using WebKurs.Models;

    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        private readonly ISessionService _sessionService;

        public AdminController(IAdminService adminService, ISessionService sessionService)
        {
            _adminService = adminService;
            _sessionService = sessionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchUser()
        {
            return RedirectToAction("SearchUser", "User");
        }

        public IActionResult UpdateUser(UserModel model)
        {
            return RedirectToAction("UpdateUser", "User", model);
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _adminService.DeleteUser(userId);
            return RedirectToAction("SearchUser","User");
        }

        public IActionResult SearchCity()
        {
            return RedirectToAction("SearchCity", "City");
        }

        public IActionResult AddCity(CityModel model)
        {
            return RedirectToAction("AddCity", "City", model);
        }

        public IActionResult UpdateCity(CityModel model)
        {
            return RedirectToAction("UpdateCity", "City", model);
        }

        public async Task<IActionResult> DeleteCityAsync(string cityId)
        {
            await _adminService.DeleteCity(cityId);
            return RedirectToAction("SearchCity","City");
        }

        public IActionResult AddAttraction(AttractionModel model)
        {
            return RedirectToAction("AddAttraction", "Attraction", model);
        }

        public IActionResult SearchAttraction()
        {
            return RedirectToAction("SearchAttraction", "Attraction");
        }

        public IActionResult UpdateAttraction(AttractionModel model)
        {
            return RedirectToAction("UpdateAttraction", "Attraction", model);
        }

        public async Task<IActionResult> DeleteAttraction(string attractionId)
        {
            await _adminService.DeleteAttractionAsync(attractionId);
            return RedirectToAction("SearchAttraction","Attraction");
        }

        public IActionResult SearchTour ()
        {
            return RedirectToAction("SearchTour", "Tour");
        }

        public IActionResult AddTour(TourModel model)
        {
            return RedirectToAction("AddTour", "Tour", model);
        }

        public IActionResult UpdateTour(TourModel model)
        {
            return RedirectToAction("UpdateTour", "Tour", model);
        }

        public async Task<IActionResult> DeleteTour(string tourId)
        {
            await _adminService.DeleteTour(tourId);
            return RedirectToAction("SearchTour", "Tour");
        }
    }
}
