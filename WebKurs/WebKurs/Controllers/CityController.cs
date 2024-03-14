using Microsoft.AspNetCore.Mvc;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        private readonly SessionManager _sessionManager;

        public CityController(ICityRepository cityRepository, SessionManager sessionManager)
        {
            _cityRepository = cityRepository;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            var city = _cityRepository.GetAllCity();
            return View(city);
        }
    }
}
