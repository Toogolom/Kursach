using Microsoft.AspNetCore.Mvc;
using PIS.Memory;
using PIS;
using PIS.Interface;
using PIS.Models;
using System.Reflection;
using PIS.Service;

namespace WebKurs.Controllers
{
    public class TourController : Controller
    {
        public ITourService _tourService;
        public IAttractionService _attractionService;
        private readonly ISessionService _sessionService;

        public TourController(ITourService tourService, ISessionService sessionService, IAttractionService attractionService)
        {
            _tourService = tourService;
            _sessionService = sessionService;
            _attractionService = attractionService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var tour = await _tourService.GetAllToursAsync();

            return View(tour);
        }

        public async Task<IActionResult> DetailsTour(string tourId)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var attractions = await _tourService.GetAttractionDateForTour(tourId);

            return View(attractions);
        }

        public async Task<IActionResult> SearchTour(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<Tour> tourList = new List<Tour>();

            if (query == null)
            {
                tourList = await _tourService.GetAllToursAsync();
                return View(tourList);
            }

            tourList = await _tourService.GetAllTourByPartNameAsync(query);
            return View(tourList);

        }

        public async Task<IActionResult> UpdateTour(TourModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var tour = await _tourService.GetTourByIdAsync(model.TourId);
            model.Attractions = await _attractionService.GetAllAttractionAsync();

            if (await _tourService.UpdateTourAsync(model))
            {
                ViewBag.Message = "Тур успешно обновлен";
                return View(model);
            }

            model.TourName = tour.TourName;
            model.TourPrice = tour.TourPrice;
            model.TourDescription = tour.TourDescription;
            model.AttractionDate = tour.AttractionDate;
            model.StartDate = tour.StartDate;
            model.EndDate = tour.EndDate;
            

            return View(model);
        }

        public async Task<IActionResult> AddTour(TourModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");



            if (await _tourService.AddTourAsync(model))
            {
                ViewBag.Message = "Тур успешно добавлен";
            }

            var attList = await _attractionService.GetAllAttractionAsync();

            return View(attList);
        }
    }
}
