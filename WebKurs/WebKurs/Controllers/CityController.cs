using Microsoft.AspNetCore.Mvc;
using PIS.Repository;

namespace WebKurs.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IActionResult Index()
        {
            var city = _cityRepository.GetAllCity();
            return View(city);
        }
    }
}
