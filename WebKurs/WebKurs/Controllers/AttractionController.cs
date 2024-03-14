using Microsoft.AspNetCore.Mvc;
using PIS.Interface;

namespace WebKurs.Controllers
{
    public class AttractionController : Controller
    {
        public IAttractionRepository _attractionRepository;

        private readonly SessionManager _sessionManager;

        public AttractionController(IAttractionRepository attractionRepository, SessionManager sessionManager)
        {
            _attractionRepository = attractionRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index(int cityId)
        {
            ViewData["IsLoggedIn"] = _sessionManager.Get<bool>("IsLoggedIn");
            var attraction = _attractionRepository.GetAllAttractionsByCityId(cityId);
            return View(attraction);
        }
    }
}
