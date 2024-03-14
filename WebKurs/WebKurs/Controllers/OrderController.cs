using Microsoft.AspNetCore.Mvc;
using PIS.Interface;
using WebKurs.Models;

namespace WebKurs.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly SessionManager _sessionManager;

        private List<int> TourId = new List<int>();

        public OrderController(IOrderRepository orderRepository, SessionManager sessionManager)
        {
            _orderRepository = orderRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToOrder(int tourId,SearchViewModel model)
        {
            TourId.Add(tourId);
            return Json(new { success = true });
        }
    }
}