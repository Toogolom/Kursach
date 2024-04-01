namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;
    using System.Threading.Tasks;
    using WebKurs.Models;

    public class SearchController : Controller
	{
		private readonly ISearchService _searchService;
        private readonly ISessionService _sessionService;

        public SearchController(ISearchService searchService, ISessionService sessionService)
        {
            _searchService = searchService;
            _sessionService = sessionService;
        }

        public IActionResult Index()
		{
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");


            return View();
		}

		public async Task<IActionResult> ResultAsync(string query, string searchType)
		{
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var model = await _searchService.SearchResultAsync(query, searchType);
            return View(model);
        }

        [HttpPost]
        public IActionResult Filter(bool showTours, bool showAttractions, bool showCities, SearchViewModel model)
        {
            model.ShowAttraction = showAttractions;
            model.ShowTours = showTours;
            model.ShowCity = showCities;

            return RedirectToAction("Result");
        }
    }
}
