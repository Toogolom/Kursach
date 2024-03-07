namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Memory;
    using PIS.Repository;
    using System.Data;
    using WebKurs.Models;

    public class SearchController : Controller
	{
		private readonly ITourRepository _tourRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAttractionRepository _attractionRepository;

		public SearchController(ITourRepository tourRepository, ICityRepository cityRepository, IAttractionRepository attractionRepository)
		{
			_tourRepository = tourRepository;
            _cityRepository = cityRepository;
            _attractionRepository = attractionRepository;

		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Search(string query)
		{
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
