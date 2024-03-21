using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using PIS;
using PIS.Interface;
using PIS.Memory;
using WebKurs.Models;

namespace WebKurs.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IOrderService _orderService;
        private readonly ITourService _tourService;

        public OrderController(IOrderService orderService, ISessionService sessionService, ITourService tourService)
        {
            _sessionService = sessionService;
            _orderService = orderService;
            _tourService = tourService;
        }

        public IActionResult Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsOrderPage"] = true;
            ViewData["Username"] = _sessionService.Get<string>("Username");

            List<int> tourIdList = _sessionService.Get<List<int>>("TourIdList");
            List<Tour> tours = _tourService.GetAllToursByAllId(tourIdList);
            var totalPrice = _orderService.CalculateTotalPrice(tours);

            return View(Tuple.Create(tours, totalPrice));
        }

        [HttpPost]
        public IActionResult AddToOrder(int tourId)
        {
            _orderService.AddTourToOrder(tourId);

            return Json(new { success = true });
        }

        public IActionResult AddOrder()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsOrderPage"] = true;
            ViewData["Username"] = _sessionService.Get<string>("Username");

            var order = _orderService.CreateOrder();
            return View(order);
        }

        [HttpPost]
        public IActionResult AddOrderResult(OrderModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");

            _orderService.AddOrder(model);
            ViewBag.Message = "Заказ успешно добавлен";

            return View();
        }

        public IActionResult RemoveItem(int tourId)
        {
            _orderService.RemoveTourFromOrder(tourId);
            return RedirectToAction("Index");
        }
    }
}