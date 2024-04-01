using Microsoft.AspNetCore.Mvc;
using PIS;
using PIS.Interface;
using PIS.Models;
using PIS.Service;

namespace WebKurs.Controllers
{
    public class AttractionController : Controller
    {
        public IAttractionService _attractionService;

        private readonly ISessionService _sessionService;

        public ICityService _cityService;

        public AttractionController(IAttractionService attractionService, SessionService sessionService, ICityService cityService)
        {
            _attractionService = attractionService;
            _sessionService = sessionService;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index(string cityId)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var attraction = await _attractionService.GetAllAttractionsByCityIdAsync(cityId);

            return View(attraction);
        }

        public async Task<IActionResult> AddAttraction(AttractionModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (await _attractionService.AddAttractionAsync(model))
            {
                ViewBag.Message = "Достопримечательность успешно добавлена";
            }

            var cityList = await _cityService.GetAllCity();
            return View(cityList);
        }

        public async Task<IActionResult> SearchAttraction(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<Attraction> attractionList = new List<Attraction>();

            if (query == null)
            {
                attractionList = await _attractionService.GetAllAttractionAsync();
                return View(attractionList);
            }

            attractionList = await _attractionService.GetAllAtractionByPartNameAsync(query);
            return View(attractionList);
        }

        public async Task<IActionResult> UpdateAttraction(AttractionModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");
            model.Cities = await _cityService.GetAllCity();

            if (await _attractionService.UpdateAttractionAsync(model))
            {
                ViewBag.Message = "Данные успешно обновлены";
                return View(model);
            }

            Attraction attraction = await _attractionService.GetAttractionByIdAsync(model.AttractionId);

            model.AttractionName = attraction.AttractionName;
            model.AttractionDescription = attraction.AttractionDescription;
            model.AttractionPhotoUrl = attraction.AttractionPhotoUrl;
            model.CityId = attraction.CityId;

            return View(model);
        }
    }
}
