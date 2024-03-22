using Microsoft.AspNetCore.Mvc;
using PIS.Memory;
using PIS;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class TourController : Controller
    {
        public ITourService _tourService;
        private readonly ISessionService _sessionService;

        public TourController(ITourService tourService, SessionService sessionService)
        {
            _tourService = tourService;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");

            var tour = _tourService.GetAllTours();

            return View(tour);
        }

        public IActionResult DetailsTour(int tourId)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            
            var attractions = _tourService.GetAttractionDateForTour(tourId);

            return View(attractions);
        }
    }
}
