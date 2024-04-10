using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using PIS;
using PIS.Interface;
using PIS.Memory;
using System.Text;
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

        public async Task<IActionResult> Index()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsOrderPage"] = true;
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            List<string> tourIdList = _sessionService.Get<List<string>>("TourIdList");
            List<Tour> tours = await _tourService.GetAllToursByAllIdAsync(tourIdList);
            var totalPrice = _orderService.CalculateTotalPrice(tours);

            return View(Tuple.Create(tours, totalPrice));
        }

        [HttpPost]
        public IActionResult AddToOrder(string tourId)
        {
            _orderService.AddTourToOrder(tourId);

            return Json(new { success = true });
        }

        public async Task<IActionResult> AddOrder()
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["IsOrderPage"] = true;
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            var order = await _orderService.CreateOrder();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderResult(OrderModel model)
        {
            ViewData["IsLoggedIn"] = _sessionService.Get<bool>("IsLoggedIn");
            ViewData["Username"] = _sessionService.Get<string>("Username");
            ViewData["IsAdmin"] = _sessionService.Get<bool>("IsAdmin");

            await _orderService.AddOrderAsync(model);

            TempData["Order"] = "Заказ успешно добавлен";

            return RedirectToAction("SendEmailOrderDetail", "Email", model);
        }

        public IActionResult RemoveItem(string tourId)
        {
            _orderService.RemoveTourFromOrder(tourId);
            return RedirectToAction("Index");
        }
    }
}