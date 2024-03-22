using Microsoft.AspNetCore.Mvc;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        private readonly ISessionService _sessionService;

        public CityController(ICityService cityService, SessionService sessionService)
        {
            _cityService = cityService;
            _sessionService = sessionService;
        }
        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var city = _cityService.GetAllCity();

            return View(city);
        }
    }
}
