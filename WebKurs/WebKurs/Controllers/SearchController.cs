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

		public async Task<IActionResult> Result(SearchModel model)
		{
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            model = await _searchService.SearchResultAsync(model);

            return View(model);
        }
    }
}
