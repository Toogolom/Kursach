using Microsoft.AspNetCore.Mvc;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class AttractionController : Controller
    {
        public IAttractionService _attractionService;

        private readonly ISessionService _sessionService;

        public AttractionController(IAttractionService attractionService, SessionService sessionService)
        {
            _attractionService = attractionService;
            _sessionService = sessionService;
        }

        public IActionResult Index(int cityId)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            var attraction = _attractionService.GetAllAttractionsByCityId(cityId);
            return View(attraction);
        }
    }
}
