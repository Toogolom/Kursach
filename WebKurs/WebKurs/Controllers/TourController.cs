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

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var tour = _tourService.GetAllTours();

            return View(tour);
        }

        public IActionResult DetailsTour(int tourId)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var attractions = _tourService.GetAttractionDateForTour(tourId);

            return View(attractions);
        }

        public IActionResult SearchTour(string query)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<Tour> tourList = new List<Tour>();

            if (query == null)
            {
                tourList = _tourService.GetAllTours();
                return View(tourList);
            }

            tourList = _tourService.GetAllTourByPartName(query);
            return View(tourList);

        }

        public IActionResult UpdateTour(TourModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var tour = _tourService.GetTourById(model.TourId);
            model.Attractions = _attractionService.GetAllAttraction();

            if (_tourService.UpdateTour(model))
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

        public IActionResult AddTour(TourModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");



            if (_tourService.AddTour(model))
            {
                ViewBag.Message = "Тур успешно добавлен";
            }

            var attList = _attractionService.GetAllAttraction();

            return View(attList);
        }
    }
}
