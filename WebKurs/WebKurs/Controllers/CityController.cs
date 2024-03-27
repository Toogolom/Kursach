using Microsoft.AspNetCore.Mvc;
using PIS;
using PIS.Interface;
using PIS.Models;
using PIS.Service;

namespace WebKurs.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        private readonly ISessionService _sessionService;

        public CityController(ICityService cityService, SessionService sessionService)
        {
            _cityService = cityService;
            _sessionService = sessionService;
        }
        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var city = _cityService.GetAllCity();

            return View(city);
        }

        public IActionResult SearchCity(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<City> cityList = new List<City>();

            if (query == null)
            {
                cityList = _cityService.GetAllCity();
                return View(cityList);
            }

            cityList = _cityService.GetAllCityByPartName(query);
            return View(cityList);
        }

        public IActionResult AddCity(CityModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.URL == null && model.CityName == null && model.CityDescription == null)
            {
                return View();
            }

            if (_cityService.AddCity(model))
            {
                ViewBag.Message = "Город успешно добавлен";
                return View();
            }

            ViewBag.Message = "Поля не должны быть пустыми";
            return View();

        }

        public IActionResult UpdateCity(CityModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (_cityService.UpdateCity(model))
            {
                ViewBag.Message = "Данные обновлены";
                return View(model);
            }
            var city = _cityService.GetCityById(model.CityId);

            model.URL = city.PhotoUrl;
            model.CityName = city.CityName;
            model.CityDescription = city.CityDescription;

            return View(model);
        }

    }
}
