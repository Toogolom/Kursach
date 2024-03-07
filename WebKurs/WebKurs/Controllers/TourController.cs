using Microsoft.AspNetCore.Mvc;
using PIS.Repository;

namespace WebKurs.Controllers
{
    public class TourController : Controller
    {
        public ITourRepository _tourRepository;

        public TourController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public IActionResult Index()
        {
            var tour = _tourRepository.GetAllTours();
            return View(tour);
        }
    }
}
