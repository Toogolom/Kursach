namespace WebKurs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PIS.Interface;

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

            return View();
		}

		public IActionResult Result(string query)
		{
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");

            var model = _searchService.SearchResult(query);
            return View(model);
        }
	}
}
