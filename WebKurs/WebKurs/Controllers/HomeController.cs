using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebKurs.Models;

namespace WebKurs.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

        private readonly SessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, SessionManager sessionManager)
		{
			_logger = logger;
			_sessionManager = sessionManager;
		}

		public IActionResult Index()
		{
			if(_sessionManager.Get<string>("Email") == null)
			{
				_sessionManager.Set("IsLoggedIn", false);
			}
			ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
