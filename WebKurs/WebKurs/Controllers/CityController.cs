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
        public async Task<IActionResult> Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var city = await _cityService.GetAllCity();

            return View(city);
        }

        public async Task<IActionResult> SearchCity(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<City> cityList = new List<City>();

            if (query == null)
            {
                cityList = await _cityService.GetAllCity();
                return View(cityList);
            }

            cityList = await _cityService.GetAllCityByPartName(query);
            return View(cityList);
        }

        public async Task<IActionResult> AddCity(CityModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (model.URL == null && model.CityName == null && model.CityDescription == null)
            {
                return View();
            }

            if (await _cityService.AddCity(model))
            {
                ViewBag.Message = "Город успешно добавлен";
                return View();
            }

            ViewBag.Message = "Поля не должны быть пустыми";
            return View();

        }

        public async Task<IActionResult> UpdateCity(CityModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (await _cityService.UpdateCityAsync(model))
            {
                ViewBag.Message = "Данные обновлены";
                return View(model);
            }
            var city = await _cityService.GetCityById(model.CityId);

            model.URL = city.PhotoUrl;
            model.CityName = city.CityName;
            model.CityDescription = city.CityDescription;

            return View(model);
        }

    }
}
