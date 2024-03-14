namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Memory;
    using PIS.Interface;
    using System.Data;
    using WebKurs.Models;

    public class SearchController : Controller
	{
		private readonly ITourRepository _tourRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAttractionRepository _attractionRepository;
        private readonly SessionManager _sessionManager;

        public SearchController(ITourRepository tourRepository, ICityRepository cityRepository, IAttractionRepository attractionRepository, SessionManager sessionManager)
        {
            _tourRepository = tourRepository;
            _cityRepository = cityRepository;
            _attractionRepository = attractionRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
		{
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            return View();
		}

		public IActionResult Result(string query)
		{
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            var tours = _tourRepository.GetAllByNameTours(query);
            var attractions = _attractionRepository.GetAllAttractionsByName(query);
            var cities = _cityRepository.GetAllCityByName(query);
            return View(new SearchViewModel
            {
                Tours = tours,
                Attractions = attractions,
                Cities = cities
            }) ;
        }
	}
}
