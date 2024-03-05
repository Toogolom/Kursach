namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Repository;

    public class SearchController : Controller
	{
		private readonly ITourRepository _tourRepository;

		public SearchController(ITourRepository tourRepository)
		{
			_tourRepository = tourRepository;
		}

		public IActionResult Index(string query)
		{
			var tour = _tourRepository.GetAllByNameTours(query);
			return View(tour);
		}
	}
}
