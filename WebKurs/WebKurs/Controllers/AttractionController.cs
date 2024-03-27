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

        public IActionResult Index(int cityId)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var attraction = _attractionService.GetAllAttractionsByCityId(cityId);

            return View(attraction);
        }

        public IActionResult AddAttraction(AttractionModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            if (_attractionService.AddAttraction(model))
            {
                ViewBag.Message = "Достопримечательность успешно добавлена";
            }

            var cityList = _cityService.GetAllCity();
            return View(cityList);
        }

        public IActionResult SearchAttraction(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<Attraction> attractionList = new List<Attraction>();

            if (query == null)
            {
                attractionList = _attractionService.GetAllAttraction();
                return View(attractionList);
            }

            attractionList = _attractionService.GetAllAtractionByPartName(query);
            return View(attractionList);
        }

        public IActionResult UpdateAttraction(AttractionModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");
            model.Cities = _cityService.GetAllCity();

            if (_attractionService.UpdateAttraction(model))
            {
                ViewBag.Message = "Данные успешно обновлены";
                return View(model);
            }

            Attraction attraction = _attractionService.GetAttractionById(model.AttractionId);

            model.AttractionName = attraction.AttractionName;
            model.AttractionDescription = attraction.AttractionDescription;
            model.AttractionPhotoUrl = attraction.AttractionPhotoUrl;
            model.CityId = attraction.CityId;

            return View(model);
        }
    }
}
