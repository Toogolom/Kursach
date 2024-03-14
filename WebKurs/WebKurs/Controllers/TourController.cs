using Microsoft.AspNetCore.Mvc;
using PIS.Memory;
using PIS;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class TourController : Controller
    {
        public ITourRepository _tourRepository;
        public IAttractionRepository _attractionRepository;
        private readonly SessionManager _sessionManager;

        public TourController(ITourRepository tourRepository, IAttractionRepository attractionRepository, SessionManager sessionManager)
        {
            _tourRepository = tourRepository;
            _attractionRepository = attractionRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            var tour = _tourRepository.GetAllTours();
            return View(tour);
        }

        public IActionResult DetailsTour(int tourId)
        {
            var attractionIds = _tourRepository.GetAllAttractionByTourId(tourId);
            var attractions = new List<Attraction>();
            foreach (var attractionId in attractionIds)
            {
                var attraction = _attractionRepository.GetAttractionById(attractionId);
                attractions.Add(attraction);
            }
            return View(attractions);
        }
    }
}
