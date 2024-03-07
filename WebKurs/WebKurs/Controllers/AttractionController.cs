using Microsoft.AspNetCore.Mvc;
using PIS.Repository;

namespace WebKurs.Controllers
{
    public class AttractionController : Controller
    {
        public IAttractionRepository _attractionRepository;

        public AttractionController(IAttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        public IActionResult Index(int cityId)
        {
            var attraction = _attractionRepository.GetAllAttractionsByCityId(cityId);
            return View(attraction);
        }
    }
}
