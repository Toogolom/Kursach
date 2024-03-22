using Microsoft.AspNetCore.Mvc;
using PIS.Interface;
using System.Diagnostics;
using WebKurs.Models;

namespace WebKurs.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

        private readonly ISessionService _sessionService;

        public HomeController(ILogger<HomeController> logger, SessionService sessionService)
		{
			_logger = logger;
			_sessionService = sessionService;
		}

		public IActionResult Index()
		{
			if(_sessionService.Get<string>("Email") == null)
			{
				_sessionService.Set("IsLoggedIn", false);
                _sessionService.Set("IsAdmin", false);
            }
			ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
